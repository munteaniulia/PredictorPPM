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

                for (int i = 0; i < jumpRecords.Count; i++)
                {
                    DetermineBranchStatus();
                    string predictedEvent = PredictNextEvent(HRg, maxOrder, i);
                    string actualEvent = globalBranchStatus[i].ToString();

                    if (predictedEvent == actualEvent)
                        correctPredictions++;
                    else
                        incorrectPredictions++;
                }

                this.Invoke(new Action(() =>
                {
                    TotalTextBox.Text = jumpRecords.Count.ToString();
                    correctTextBox.Text = correctPredictions.ToString();
                    incorrectTextBox.Text = incorrectPredictions.ToString();

                    double accuracy = (double)correctPredictions / (correctPredictions + incorrectPredictions) * 100;
                    accuracyProgressBar.Value = Math.Min((int)accuracy, 100);
                    accuracyLabel.Text = $"{accuracy:F2}%";
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

            for (int i = Math.Max(0, indexOfBranch - HRg); i < indexOfBranch; i++)
            {
                if (i + order >= jumpRecords.Count) continue;

                string context = string.Join(" ", globalBranchStatus.Skip(i).Take(order));
                string nextBit = globalBranchStatus[i + order].ToString();

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
                    return frequencyTable[context].OrderByDescending(kvp => kvp.Value).First().Key;
                }
            }

            int trueCount = globalBranchStatus.Take(indexOfBranch).Count(x => x);
            int falseCount = indexOfBranch - trueCount;

            return trueCount >= falseCount ? "True" : "False";
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
