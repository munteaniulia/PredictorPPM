using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Threading.Tasks;

namespace PredictorPPM
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private List<JumpRecord> jumpRecords = new List<JumpRecord>();
        private Dictionary<string, Dictionary<string, int>> frequencyTable;
        private Dictionary<string, string> fileMap = new Dictionary<string, string>();
        private List<bool> globalBranchStatus = new List<bool>();
        private Dictionary<int, int> predictionsByOrder = new Dictionary<int, int>(); // New field to track predictions by order

        public struct JumpRecord
        {
            public string TipBr;
            public string AdrCrt;
            public string AdrDest;
        }

        private void AddFile_b_Click(object sender, EventArgs e)
        {
            string directoryPath = @"C:\\Users\\Iulia Muntean\\Documents\\GitHub\\PredictorPPM\\TRAfiles";

            if (Directory.Exists(directoryPath))
            {
                listBox.Items.Clear();
                fileMap.Clear();
                string[] files = Directory.GetFiles(directoryPath, "*.tra");

                foreach (string filePath in files)
                {
                    string fileName = Path.GetFileName(filePath);
                    fileMap[fileName] = filePath;
                    listBox.Items.Add(fileName);
                }
            }
            else
            {
                MessageBox.Show("The specified directory does not exist!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void b_start_Click(object sender, EventArgs e)
        {
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
            predictionsByOrder.Clear(); // Reset predictions by order

            loadingProgressBar.Visible = true;
            loadingProgressBar.Style = ProgressBarStyle.Marquee; // Stil pentru animație

            await Task.Delay(100);

            await Task.Run(() =>
            {
                try
                {
                    foreach (var line in File.ReadLines(selectedFilePath))
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
                catch (Exception ex)
                {
                    this.Invoke(new Action(() =>
                    {
                        MessageBox.Show($"Error reading the file: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }));
                    return;
                }

                if (jumpRecords.Count == 0)
                {
                    this.Invoke(new Action(() =>
                    {
                        MessageBox.Show("The selected file does not contain valid data!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }));
                    return;
                }

                if (!int.TryParse(contextSizeTextBox.Text, out int HRg) || HRg <= 0)
                {
                    this.Invoke(new Action(() =>
                    {
                        MessageBox.Show("Please enter a valid Context Size!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }));
                    return;
                }

                if (!int.TryParse(mTextBox.Text, out int maxOrder) || maxOrder < 0)
                {
                    this.Invoke(new Action(() =>
                    {
                        MessageBox.Show("Please enter a valid Order Size!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }));
                    return;
                }

                int correctPredictions = 0;
                int incorrectPredictions = 0;
                int takenCount = 0;
                int notTakenCount = 0;

                for (int i = 0; i < jumpRecords.Count; i++)
                {
                    DetermineBranchStatus();
                    string predictedEvent = PredictNextEvent(HRg, maxOrder, i);
                    string actualEvent = globalBranchStatus[i].ToString();

                    if (actualEvent == "True")
                        takenCount++;
                    else
                        notTakenCount++;

                    if (predictedEvent == actualEvent)
                        correctPredictions++;
                    else
                        incorrectPredictions++;
                }

                // Actualizăm interfața
                this.Invoke(new Action(() =>
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

                    // Ascundem cercul de încărcare
                    loadingProgressBar.Visible = false;
                }));
            });

            MessageBox.Show("Processing completed!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


        private void DetermineBranchStatus()
        {
            globalBranchStatus.Clear();

            foreach (var record in jumpRecords)
            {
                if (int.TryParse(record.AdrCrt, out int adrCrt) && int.TryParse(record.AdrDest, out int adrDest))
                {
                    globalBranchStatus.Add(adrDest != adrCrt + 1);
                }
                else
                {
                    globalBranchStatus.Add(false);
                }
            }
        }

        private void CreateFrequencyTable(int HRg, int indexOfBranch, int order)
        {
            frequencyTable = new Dictionary<string, Dictionary<string, int>>();
            int startIndex = Math.Max(0, indexOfBranch - HRg);
            var history = globalBranchStatus.Skip(startIndex).Take(HRg).ToList();


            for (int i = 0; i <= history.Count - order - 1; i++)
            {
                string context = string.Join(" ", history.Skip(i).Take(order).Select(x => x.ToString()));
                string nextBit = history[i + order].ToString();

                if (!frequencyTable.ContainsKey(context))
                {
                    frequencyTable[context] = new Dictionary<string, int> { { "True", 0 }, { "False", 0 } };
                }

                frequencyTable[context][nextBit]++;
            }
        }


        private string PredictNextEvent(int HRg, int maxOrder, int indexOfBranch)
        {
            for (int order = maxOrder; order >= 0; order--)
            {
                if (indexOfBranch - order < 0) continue;

                string context = string.Join(" ", globalBranchStatus.Skip(Math.Max(0, indexOfBranch - order)).Take(order));
                CreateFrequencyTable(HRg, indexOfBranch, order);

                if (frequencyTable.ContainsKey(context))
                {
                    int trueCount = frequencyTable[context]["True"];
                    int falseCount = frequencyTable[context]["False"];

                    if (trueCount == falseCount)
                    {
                        continue;
                    }

                    if (!predictionsByOrder.ContainsKey(order))
                    {
                        predictionsByOrder[order] = 0;
                    }
                    predictionsByOrder[order]++;

                    return trueCount > falseCount ? "True" : "False";
                }
            }

            if (!predictionsByOrder.ContainsKey(0))
            {
                predictionsByOrder[0] = 0;
            }
            predictionsByOrder[0]++;

            int globalTrueCount = globalBranchStatus.Take(indexOfBranch).Count(x => x);
            int globalFalseCount = indexOfBranch - globalTrueCount;

            return globalTrueCount >= globalFalseCount ? "True" : "False";
        }


        private bool ValidateTipBr(string tipBr)
        {
            if (string.IsNullOrEmpty(tipBr) || tipBr.Length != 2)
                return false;

            char firstChar = tipBr[0];
            char secondChar = tipBr[1];

            return (firstChar == 'B' || firstChar == 'N') &&
                   (secondChar == 'T' || secondChar == 'F' || secondChar == 'S' || secondChar == 'M' || secondChar == 'R');
        }

    }
}
