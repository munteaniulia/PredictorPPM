using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

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
        private Dictionary<string, string> fileMap = new Dictionary<string, string>();

        public struct JumpRecord
        {
            public string TipBr;  // Tipul saltului
            public string AdrCrt; // Adresa curentă
            public string AdrDest; // Adresa de destinație
        }

        // Încărcarea fișierelor
        private void AddFile_b_Click(object sender, EventArgs e)
        {
            string directoryPath = @"C:\Users\Iulia Muntean\Documents\GitHub\PredictorPPM\TRAfiles";

            if (Directory.Exists(directoryPath))
            {
                listBox.Items.Clear();
                fileMap.Clear();

                string[] files = Directory.GetFiles(directoryPath, "*.tra");

                foreach (string filePath in files)
                {
                    string fileName = Path.GetFileName(filePath);
                    fileMap[fileName] = filePath; // Salvăm calea completă în dicționar
                    listBox.Items.Add(fileName); // Afișăm doar numele fișierului
                }

                MessageBox.Show($"{files.Length} fișiere încărcate!", "Succes", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Directorul specificat nu există!", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void b_start_Click(object sender, EventArgs e)
        {
            if (listBox.SelectedItem == null)
            {
                MessageBox.Show("Selectați un fișier din ListBox!", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string selectedFileName = listBox.SelectedItem.ToString();
            if (!fileMap.TryGetValue(selectedFileName, out string selectedFilePath))
            {
                MessageBox.Show("Nu s-a găsit calea fișierului selectat!", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            jumpRecords.Clear();

            await Task.Run(() =>
            {
                try
                {
                    using (StreamReader reader = new StreamReader(selectedFilePath))
                    {
                        string line;
                        while ((line = reader.ReadLine()) != null)
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
                }
                catch (Exception ex)
                {
                    this.Invoke(new Action(() =>
                    {
                        MessageBox.Show($"Eroare la citirea fișierului: {ex.Message}", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }));
                    return;
                }

                if (jumpRecords.Count == 0)
                {
                    this.Invoke(new Action(() =>
                    {
                        MessageBox.Show("Fișierul selectat nu conține date valide!", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }));
                    return;
                }

                if (!int.TryParse(contextSizeTextBox.Text, out int maxOrder) || maxOrder <= 0)
                {
                    this.Invoke(new Action(() =>
                    {
                        MessageBox.Show("Introduceți un Context Size valid!", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }));
                    return;
                }

                BuildPPMModel(maxOrder);

                // Calcularea categoriilor
                int branches = jumpRecords.Count(r => r.TipBr.StartsWith("B"));
                int noBranches = jumpRecords.Count(r => r.TipBr.StartsWith("N"));

                // Calcularea predicțiilor corecte și incorecte
                int correctPredictions = 0;
                int incorrectPredictions = 0;

                for (int i = maxOrder; i < jumpRecords.Count; i++)
                {
                    string context = string.Join(" ", jumpRecords.Skip(i - maxOrder).Take(maxOrder).Select(r => r.TipBr));
                    string actualEvent = jumpRecords[i].TipBr;

                    string predictedEvent = PredictNextEvent(context, maxOrder);

                    // Compararea exactă a predicțiilor
                    if (predictedEvent != null)
                    {
                        if (predictedEvent.Equals(actualEvent, StringComparison.Ordinal)) 
                            correctPredictions++;
                        else
                            incorrectPredictions++;
                    }
                    else
                    {
                        incorrectPredictions++;
                    }
                }

                // Actualizarea UI-ului
                this.Invoke(new Action(() =>
                {
                    branchesTextBox.Text = branches.ToString();
                    noBranchesTextBox.Text = noBranches.ToString();
                    correctTextBox.Text = correctPredictions.ToString();
                    incorrectTextBox.Text = incorrectPredictions.ToString();
                    accuracyProgressBar.Value = (int)((double)correctPredictions / (correctPredictions + incorrectPredictions) * 100);
                    accuracyLabel.Text = ((double)correctPredictions / (correctPredictions + incorrectPredictions)).ToString("P2");
                }));
            });

            MessageBox.Show("Procesarea a fost finalizată!", "Succes", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Construirea modelului PPM
        private void BuildPPMModel(int maxOrder)
        {
            ppmModel.Clear();

            for (int i = 0; i < jumpRecords.Count; i++)
            {
                for (int order = 1; order <= maxOrder; order++)
                {
                    if (i - order < 0) break;

                    string context = string.Join(" ", jumpRecords.Skip(i - order).Take(order).Select(r => r.TipBr));
                    string currentEvent = jumpRecords[i].TipBr;

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
        }

        // Calcularea acurateței
        private double CalculateAccuracy(int maxOrder)
        {
            int correctPredictions = 0;
            int totalPredictions = 0;

            for (int i = maxOrder; i < jumpRecords.Count; i++)
            {
                string context = string.Join(" ", jumpRecords.Skip(i - maxOrder).Take(maxOrder).Select(r => r.TipBr));
                string actualEvent = jumpRecords[i].TipBr;

                string predictedEvent = PredictNextEvent(context, maxOrder);

                if (predictedEvent != null && predictedEvent[0] == actualEvent[0])
                {
                    correctPredictions++;
                }

                totalPredictions++;
            }

            return totalPredictions > 0 ? (double)correctPredictions / totalPredictions : 0.0;
        }

        // Validarea TipBr
        private bool ValidateTipBr(string tipBr)
        {
            if (string.IsNullOrEmpty(tipBr) || tipBr.Length != 2)
                return false;

            char firstChar = tipBr[0];
            char secondChar = tipBr[1];

            return (firstChar == 'B' || firstChar == 'N') &&
                   (secondChar == 'T' || secondChar == 'F' || secondChar == 'S' || secondChar == 'M' || secondChar == 'R');
        }

        // Predicția următorului eveniment
        private string PredictNextEvent(string context, int maxOrder)
        {
            for (int order = maxOrder; order >= 0; order--)
            {
                string[] contextParts = context.Split(' ');
                string currentContext = string.Join(" ", contextParts.Skip(Math.Max(0, contextParts.Length - order)));

                if (ppmModel.ContainsKey(currentContext))
                {
                    return ppmModel[currentContext].OrderByDescending(kvp => kvp.Value).First().Key;
                }
            }

            return null;
        }
    }
}