using System;
using System.Collections.Generic;
using System.IO;
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

        public struct JumpRecord
        {
            public string TipBr;  // Tipul saltului
            public string AdrCrt; // Adresa curentă
            public string AdrDest; // Adresa de destinație
        }

        private void AddFile_b_Click(object sender, EventArgs e)
        {
            string directoryPath = @"C:\Users\Iulia Muntean\Documents\GitHub\PredictorPPM\TRAfiles";

            if (Directory.Exists(directoryPath))
            {
                string[] files = Directory.GetFiles(directoryPath, "*.tra");

                foreach (string filePath in files)
                {
                    string fileName = Path.GetFileName(filePath);

                    if (!listBox.Items.Contains(fileName))
                    {
                        listBox.Items.Add(fileName);
                    }
                }
            }
            else
            {
                MessageBox.Show("Directorul specificat nu există!");
            }
        }

        private void b_start_Click(object sender, EventArgs e)
        {
            jumpRecords.Clear(); // Curățăm lista înainte de a procesa noi fișiere

            // Verificăm dacă există fișiere selectate
            if (listBox.SelectedItems.Count == 0)
            {
                MessageBox.Show("Selectați cel puțin un fișier pentru procesare!", "Atenție", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            foreach (var selectedItem in listBox.SelectedItems)
            {
                string fileName = selectedItem.ToString();
                string filePath = Path.Combine(@"C:\Users\Iulia Muntean\Documents\GitHub\PredictorPPM\TRAfiles", fileName);

                try
                {
                    // Citim fișierul linie cu linie
                    string[] lines = File.ReadAllLines(filePath);

                    foreach (string line in lines)
                    {
                        // Ignorăm liniile goale
                        if (string.IsNullOrWhiteSpace(line))
                            continue;

                        // Spargem linia în părți: TipBr, AdrCrt, AdrDest
                        string[] parts = line.Split(' ');
                        if (parts.Length == 3)
                        {
                            JumpRecord record = new JumpRecord
                            {
                                TipBr = parts[0],
                                AdrCrt = parts[1],
                                AdrDest = parts[2]
                            };

                            jumpRecords.Add(record); // Adăugăm în listă
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Eroare la procesarea fișierului {fileName}: {ex.Message}", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            // Afișăm un mesaj de confirmare
            MessageBox.Show($"Procesare completă! Au fost încărcate {jumpRecords.Count} înregistrări.", "Succes", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}