﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace PredictorPPM
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private List<JumpRecord> jumpRecords = new List<JumpRecord>();
        private Dictionary<string, Dictionary<string, int>> ppmModel = new Dictionary<string, Dictionary<string, int>>();
        private Dictionary<int, string[]> precomputedContexts = new Dictionary<int, string[]>();
        private Dictionary<string, string> fileMap = new Dictionary<string, string>();

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

                if (!int.TryParse(contextSizeTextBox.Text, out int maxOrder) || maxOrder <= 0)
                {
                    this.Invoke(new Action(() =>
                    {
                        MessageBox.Show("Please enter a valid Context Size!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }));
                    return;
                }

                PrecomputeContexts(maxOrder);
                BuildPPMModel(maxOrder);

                int branches = jumpRecords.Count(r => r.TipBr.StartsWith("B"));
                int noBranches = jumpRecords.Count(r => r.TipBr.StartsWith("N"));

                int correctPredictions = 0;
                int incorrectPredictions = 0;

                for (int i = maxOrder; i < jumpRecords.Count; i++)
                {
                    string context = string.Join(" ", precomputedContexts[i].Take(maxOrder));
                    string actualEvent = jumpRecords[i].TipBr;

                    string predictedEvent = PredictNextEvent(context, maxOrder);

                    if (predictedEvent != null)
                    {
                        if (predictedEvent == actualEvent)
                            correctPredictions++;
                        else
                            incorrectPredictions++;
                    }
                    else
                    {
                        incorrectPredictions++;
                    }
                }

                this.Invoke(new Action(() =>
                {
                    branchesTextBox.Text = branches.ToString();
                    noBranchesTextBox.Text = noBranches.ToString();
                    correctTextBox.Text = correctPredictions.ToString();
                    incorrectTextBox.Text = incorrectPredictions.ToString();

                    double accuracy = (double)correctPredictions / (correctPredictions + incorrectPredictions) * 100;
                    accuracyProgressBar.Value = Math.Min((int)accuracy, 100);
                    accuracyLabel.Text = $"{accuracy:F2}%";
                }));
            });

            MessageBox.Show("Processing completed!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void PrecomputeContexts(int maxOrder)
        {
            precomputedContexts.Clear();

            for (int i = 0; i < jumpRecords.Count; i++)
            {
                var contexts = new string[maxOrder];
                var context = "";

                for (int order = 1; order <= maxOrder && i - order >= 0; order++)
                {
                    context = jumpRecords[i - order].TipBr + (context == "" ? "" : " ") + context;
                    contexts[order - 1] = context;
                }

                precomputedContexts[i] = contexts;
            }
        }

        private void BuildPPMModel(int maxOrder)
        {
            ppmModel.Clear();

            Parallel.For(0, jumpRecords.Count, i =>
            {
                string context = "";
                for (int order = 1; order <= maxOrder; order++)
                {
                    if (i - order < 0) break;

                    context = jumpRecords[i - order].TipBr + (context == "" ? "" : " ") + context;
                    string currentEvent = jumpRecords[i].TipBr;

                    lock (ppmModel)
                    {
                        if (!ppmModel.ContainsKey(context))
                        {
                            ppmModel[context] = new Dictionary<string, int>();
                        }

                        if (!ppmModel[context].ContainsKey(currentEvent))
                        {
                            ppmModel[context][currentEvent] = 0;
                        }

                        ppmModel[context][currentEvent]++;
                    }
                }
            });
        }

        private string PredictNextEvent(string context, int maxOrder)
        {
            for (int order = maxOrder; order > 0; order--)
            {
                string[] contextParts = context.Split(' ');
                string currentContext = string.Join(" ", contextParts.Skip(contextParts.Length - order));

                if (ppmModel.TryGetValue(currentContext, out var predictions))
                {
                    return predictions.OrderByDescending(kvp => kvp.Value).First().Key;
                }
            }

            return ppmModel.Values
                           .SelectMany(dict => dict)
                           .GroupBy(kvp => kvp.Key)
                           .OrderByDescending(group => group.Sum(kvp => kvp.Value))
                           .FirstOrDefault()?.Key;
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