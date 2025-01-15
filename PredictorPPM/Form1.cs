using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;

namespace PredictorPPM
{
    public partial class Form1 : Form
    {
        private List<JumpRecord> jumpRecords = new List<JumpRecord>();
        private Dictionary<string, Dictionary<string, int>> frequencyTable;
        private Dictionary<string, string> fileMap = new Dictionary<string, string>();
        private BitArray globalBranchStatus;
        private Dictionary<int, int> predictionsByOrder = new Dictionary<int, int>();
        private bool isPPMComplete = true;
        Dictionary<string, int> globalFrequency = new Dictionary<string, int> { { "True", 0 }, { "False", 0 } };

        public Form1()
        {
            InitializeComponent();
        }

        public struct JumpRecord
        {
            public string TipBr;
            public string AdrCrt;
            public string AdrDest;
        }

        private void AddFile_b_Click(object sender, EventArgs e)
        {
            using (var openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Title = "Select .tra Files";
                openFileDialog.Filter = "TRA Files (*.tra)|*.tra";
                openFileDialog.Multiselect = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    listBox.Items.Clear();
                    fileMap.Clear();

                    foreach (string filePath in openFileDialog.FileNames)
                    {
                        string fileName = Path.GetFileName(filePath);
                        fileMap[fileName] = filePath;
                        listBox.Items.Add(fileName);
                    }
                }
                else
                {
                    MessageBox.Show("No files selected.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }



        private async void b_start_Click(object sender, EventArgs e)
        {
            totalTextBox.Text = "";
            correctTextBox.Text = "";
            incorrectTextBox.Text = "";
            takenTextBox.Text = "";
            notTakenTextBox.Text = "";
            accuracyLabel.Text = "";
            executionTimeLabel.Text = "Execution Time: 0 ms";
            accuracyProgressBar.Value = 0;
            predictionsListBox.Items.Clear();

            if (listBox.SelectedItem == null)
            {
                MessageBox.Show("Please select a file from the ListBox!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string selectedFileName = listBox.SelectedItem.ToString();
            if (!fileMap.TryGetValue(selectedFileName, out string selectedFilePath))
            {
                MessageBox.Show("Could not find the selected file path!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            jumpRecords.Clear();
            predictionsByOrder.Clear();
            loadingProgressBar.Visible = true;
            loadingProgressBar.Style = ProgressBarStyle.Marquee;

            await Task.Delay(100);

            try
            {
                var stopwatch = System.Diagnostics.Stopwatch.StartNew();

                await Task.Run(() => ReadJumpRecords(selectedFilePath));
                if (jumpRecords.Count == 0)
                {
                    MessageBox.Show("The selected file does not contain valid data!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    loadingProgressBar.Visible = false;
                    return;
                }

                if (!int.TryParse(HRgTextBox.Text, out int HRg) || HRg <= 0)
                {
                    MessageBox.Show("Please enter a valid Context Size!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    loadingProgressBar.Visible = false;
                    return;
                }

                if (!int.TryParse(mTextBox.Text, out int maxOrder) || maxOrder < 0)
                {
                    MessageBox.Show("Please enter a valid Order Size!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    loadingProgressBar.Visible = false;
                    return;
                }

                await Task.Run(() => ProcessData(HRg, maxOrder));

                stopwatch.Stop();

                double elapsedSeconds = stopwatch.Elapsed.TotalSeconds;
                if (elapsedSeconds >= 60)
                {
                    int minutes = (int)(elapsedSeconds / 60);
                    double seconds = elapsedSeconds % 60;  
                    executionTimeLabel.Text = $"Execution Time: {minutes} min {seconds:F2} s";
                }
                else
                {
                    executionTimeLabel.Text = $"Execution Time: {elapsedSeconds:F2} s";
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                loadingProgressBar.Visible = false;
            }

            MessageBox.Show("Processing completed!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ReadJumpRecords(string filePath)
        {
            foreach (var line in File.ReadLines(filePath))
            {
                if (string.IsNullOrWhiteSpace(line)) continue;

                string[] parts = line.Split(' ');
                if (parts.Length == 3 && ValidateTipBr(parts[0]))
                {
                    jumpRecords.Add(new JumpRecord
                    {
                        TipBr = parts[0],
                        AdrCrt = parts[1],
                        AdrDest = parts[2]
                    });
                }
            }
        }

        private void ProcessData(int HRg, int maxOrder)
        {
            globalBranchStatus = new BitArray(jumpRecords.Count);
            DetermineBranchStatus();

            int correctPredictions = 0, incorrectPredictions = 0;
            int takenCount = 0, notTakenCount = 0;

            for (int i = 0; i < jumpRecords.Count; i++)
            {
                string predictedEvent = PredictNextEvent(HRg, maxOrder, i, isPPMComplete);
                string actualEvent = globalBranchStatus[i] ? "True" : "False";

                if (actualEvent == "True") takenCount++;
                else notTakenCount++;

                if (predictedEvent == actualEvent) correctPredictions++;
                else incorrectPredictions++;
            }

            Invoke(new Action(() =>
            {
                totalTextBox.Text = jumpRecords.Count.ToString();
                correctTextBox.Text = correctPredictions.ToString();
                incorrectTextBox.Text = incorrectPredictions.ToString();
                takenTextBox.Text = takenCount.ToString();
                notTakenTextBox.Text = notTakenCount.ToString();

                double accuracy = (double)correctPredictions / (correctPredictions + incorrectPredictions) * 100;
                accuracyProgressBar.Value = Math.Min((int)accuracy, 100);
                accuracyLabel.Text = $"{accuracy:F2}%";

                predictionsListBox.Items.Clear();
                foreach (var order in predictionsByOrder.Keys)
                {
                    predictionsListBox.Items.Add($"Order {order}: {predictionsByOrder[order]} predictions");
                }
            }));
        }

        private string PredictOrder0(int indexOfBranch)
        {
            int trueCount = 0;
            int falseCount = 0;

            for (int i = 0; i < indexOfBranch; i++)
            {
                if (globalBranchStatus[i]) trueCount++;
                else falseCount++;
            }

            if (!predictionsByOrder.ContainsKey(0)) predictionsByOrder[0] = 0;
            predictionsByOrder[0]++;
            
            return trueCount > falseCount ? "True" : "False";
        }

        private string PredictMaxOrder(int HRg, int maxOrder, int indexOfBranch)
        {
            if (indexOfBranch - maxOrder < 0) return null;

            string context = string.Join(" ", globalBranchStatus.Cast<bool>().Skip(Math.Max(0, indexOfBranch - maxOrder)).Take(maxOrder));
            CreateFrequencyTable(HRg, indexOfBranch, maxOrder);

            if (frequencyTable.TryGetValue(context, out var counts))
            {
                int trueCount = counts["True"];
                int falseCount = counts["False"];

                if (trueCount != falseCount)
                {
                    if (!predictionsByOrder.ContainsKey(maxOrder)) predictionsByOrder[maxOrder] = 0;
                    predictionsByOrder[maxOrder]++;
                    return trueCount > falseCount ? "True" : "False";
                }
            }
            return null;
        }

        private string PredictForOrder(int HRg, int order, int indexOfBranch)
        {
            if (indexOfBranch - order < 0) return null;

            string context = string.Join(" ", globalBranchStatus.Cast<bool>().Skip(Math.Max(0, indexOfBranch - order)).Take(order));
            CreateFrequencyTable(HRg, indexOfBranch, order);

            if (frequencyTable.TryGetValue(context, out var counts))
            {
                int trueCount = counts["True"];
                int falseCount = counts["False"];

                if (trueCount != falseCount)
                {
                    return trueCount > falseCount ? "True" : "False";
                }
            }

            return null; 
        }

        private string PredictNextEvent(int HRg, int maxOrder, int indexOfBranch, bool isPPMComplete)
        {
            if (isPPMComplete)
            {
                for (int order = maxOrder; order >= 0; order--)
                {
                    string result = PredictForOrder(HRg, order, indexOfBranch);
                    if (result != null)
                    {
                        if (!predictionsByOrder.ContainsKey(order)) predictionsByOrder[order] = 0;
                        predictionsByOrder[order]++;
                        return result;
                    }
                }
            }
            else
            {
                string result = PredictForOrder(HRg, maxOrder, indexOfBranch);
                if (result != null)
                {
                    if (!predictionsByOrder.ContainsKey(maxOrder)) predictionsByOrder[maxOrder] = 0;
                    predictionsByOrder[maxOrder]++;
                    return result;
                }

                return PredictOrder0(indexOfBranch);
            }

            return PredictOrder0(indexOfBranch);
        }

        private void CreateFrequencyTable(int HRg, int indexOfBranch, int order)
        {
            frequencyTable = new Dictionary<string, Dictionary<string, int>>();
            int startIndex = Math.Max(0, indexOfBranch - HRg);
            var history = globalBranchStatus.Cast<bool>().Skip(startIndex).Take(HRg).ToList();

            for (int i = 0; i <= history.Count - order - 1; i++)
            {
                string context = string.Join(" ", history.Skip(i).Take(order));
                string nextBit = history[i + order].ToString();

                if (!frequencyTable.ContainsKey(context))
                {
                    frequencyTable[context] = new Dictionary<string, int> { { "True", 0 }, { "False", 0 } };
                }

                frequencyTable[context][nextBit]++;
            }
        }

        private void DetermineBranchStatus()
        {
            for (int i = 0; i < jumpRecords.Count; i++)
            {
                if (int.TryParse(jumpRecords[i].AdrCrt, out int adrCrt) && int.TryParse(jumpRecords[i].AdrDest, out int adrDest))
                {
                    globalBranchStatus[i] = adrDest != adrCrt + 1;
                }
                else
                {
                    globalBranchStatus[i] = false;
                }
            }
        }

        private bool ValidateTipBr(string tipBr)
        {
            if (string.IsNullOrEmpty(tipBr) || tipBr.Length != 2) return false;

            char firstChar = tipBr[0];
            char secondChar = tipBr[1];

            return (firstChar == 'B' || firstChar == 'N') &&
                   (secondChar == 'T' || secondChar == 'F' || secondChar == 'S' || secondChar == 'M' || secondChar == 'R');
        }

        private void toggleModeButton_Click(object sender, EventArgs e)
        {
            isPPMComplete = !isPPMComplete;
            modeLabel.Text = isPPMComplete ? "Mode: PPM Complete" : "Mode: PPM Simple";
            toggleModeButton.Text = isPPMComplete ? "Switch to Simple PPM" : "Switch to Complete PPM";
        }

    }
}
