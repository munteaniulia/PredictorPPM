namespace PredictorPPM
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.incorrectTextBox = new System.Windows.Forms.Label();
            this.l_IncorctPredictions = new System.Windows.Forms.Label();
            this.l_CorrectPredictions = new System.Windows.Forms.Label();
            this.correctTextBox = new System.Windows.Forms.Label();
            this.totalTextBox = new System.Windows.Forms.Label();
            this.l_Total = new System.Windows.Forms.Label();
            this.b_start = new System.Windows.Forms.Button();
            this.accuracyProgressBar = new System.Windows.Forms.ProgressBar();
            this.l_accuracy = new System.Windows.Forms.Label();
            this.accuracyLabel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.contextSizeTextBox = new System.Windows.Forms.TextBox();
            this.mTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.listBox = new System.Windows.Forms.ListBox();
            this.AddFile_b = new System.Windows.Forms.Button();
            this.predictionsListBox = new System.Windows.Forms.ListBox();
            this.takenTextBox = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.notTakenTextBox = new System.Windows.Forms.Label();
            this.loadingProgressBar = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // incorrectTextBox
            // 
            this.incorrectTextBox.BackColor = System.Drawing.Color.LightCyan;
            this.incorrectTextBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.incorrectTextBox.Location = new System.Drawing.Point(387, 295);
            this.incorrectTextBox.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.incorrectTextBox.Name = "incorrectTextBox";
            this.incorrectTextBox.Size = new System.Drawing.Size(49, 24);
            this.incorrectTextBox.TabIndex = 0;
            // 
            // l_IncorctPredictions
            // 
            this.l_IncorctPredictions.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.l_IncorctPredictions.Location = new System.Drawing.Point(226, 295);
            this.l_IncorctPredictions.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.l_IncorctPredictions.Name = "l_IncorctPredictions";
            this.l_IncorctPredictions.Size = new System.Drawing.Size(143, 24);
            this.l_IncorctPredictions.TabIndex = 1;
            this.l_IncorctPredictions.Text = "Incorrect Predictions:";
            this.l_IncorctPredictions.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // l_CorrectPredictions
            // 
            this.l_CorrectPredictions.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.l_CorrectPredictions.Location = new System.Drawing.Point(236, 245);
            this.l_CorrectPredictions.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.l_CorrectPredictions.Name = "l_CorrectPredictions";
            this.l_CorrectPredictions.Size = new System.Drawing.Size(133, 24);
            this.l_CorrectPredictions.TabIndex = 2;
            this.l_CorrectPredictions.Text = "Correct Predictions:";
            this.l_CorrectPredictions.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // correctTextBox
            // 
            this.correctTextBox.BackColor = System.Drawing.Color.LightCyan;
            this.correctTextBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.correctTextBox.Location = new System.Drawing.Point(387, 245);
            this.correctTextBox.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.correctTextBox.Name = "correctTextBox";
            this.correctTextBox.Size = new System.Drawing.Size(49, 24);
            this.correctTextBox.TabIndex = 3;
            // 
            // totalTextBox
            // 
            this.totalTextBox.BackColor = System.Drawing.Color.LightCyan;
            this.totalTextBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.totalTextBox.Location = new System.Drawing.Point(105, 245);
            this.totalTextBox.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.totalTextBox.Name = "totalTextBox";
            this.totalTextBox.Size = new System.Drawing.Size(49, 24);
            this.totalTextBox.TabIndex = 7;
            // 
            // l_Total
            // 
            this.l_Total.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.l_Total.Location = new System.Drawing.Point(14, 245);
            this.l_Total.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.l_Total.Name = "l_Total";
            this.l_Total.Size = new System.Drawing.Size(73, 24);
            this.l_Total.TabIndex = 6;
            this.l_Total.Text = "Total:";
            this.l_Total.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // b_start
            // 
            this.b_start.BackColor = System.Drawing.Color.LimeGreen;
            this.b_start.Font = new System.Drawing.Font("Ink Free", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.b_start.ForeColor = System.Drawing.SystemColors.ControlText;
            this.b_start.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.b_start.Location = new System.Drawing.Point(526, 135);
            this.b_start.Margin = new System.Windows.Forms.Padding(2);
            this.b_start.Name = "b_start";
            this.b_start.Size = new System.Drawing.Size(110, 76);
            this.b_start.TabIndex = 8;
            this.b_start.Text = "START";
            this.b_start.UseCompatibleTextRendering = true;
            this.b_start.UseVisualStyleBackColor = false;
            this.b_start.Click += new System.EventHandler(this.b_start_Click);
            // 
            // accuracyProgressBar
            // 
            this.accuracyProgressBar.BackColor = System.Drawing.SystemColors.Highlight;
            this.accuracyProgressBar.Location = new System.Drawing.Point(304, 344);
            this.accuracyProgressBar.Margin = new System.Windows.Forms.Padding(2);
            this.accuracyProgressBar.Name = "accuracyProgressBar";
            this.accuracyProgressBar.Size = new System.Drawing.Size(134, 19);
            this.accuracyProgressBar.TabIndex = 9;
            // 
            // l_accuracy
            // 
            this.l_accuracy.AutoSize = true;
            this.l_accuracy.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.l_accuracy.Location = new System.Drawing.Point(213, 344);
            this.l_accuracy.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.l_accuracy.Name = "l_accuracy";
            this.l_accuracy.Size = new System.Drawing.Size(64, 13);
            this.l_accuracy.TabIndex = 10;
            this.l_accuracy.Text = "Accuracy:";
            // 
            // accuracyLabel
            // 
            this.accuracyLabel.AutoSize = true;
            this.accuracyLabel.Location = new System.Drawing.Point(301, 365);
            this.accuracyLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.accuracyLabel.Name = "accuracyLabel";
            this.accuracyLabel.Size = new System.Drawing.Size(0, 13);
            this.accuracyLabel.TabIndex = 11;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(308, 92);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 17);
            this.label3.TabIndex = 12;
            this.label3.Text = "Context size:";
            // 
            // contextSizeTextBox
            // 
            this.contextSizeTextBox.BackColor = System.Drawing.Color.LightCyan;
            this.contextSizeTextBox.Location = new System.Drawing.Point(311, 123);
            this.contextSizeTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.contextSizeTextBox.Name = "contextSizeTextBox";
            this.contextSizeTextBox.Size = new System.Drawing.Size(76, 20);
            this.contextSizeTextBox.TabIndex = 13;
            // 
            // mTextBox
            // 
            this.mTextBox.BackColor = System.Drawing.Color.LightCyan;
            this.mTextBox.Location = new System.Drawing.Point(311, 191);
            this.mTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.mTextBox.Name = "mTextBox";
            this.mTextBox.Size = new System.Drawing.Size(76, 20);
            this.mTextBox.TabIndex = 14;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(307, 169);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(23, 20);
            this.label5.TabIndex = 15;
            this.label5.Text = "M";
            // 
            // listBox
            // 
            this.listBox.BackColor = System.Drawing.Color.LightCyan;
            this.listBox.ForeColor = System.Drawing.SystemColors.WindowText;
            this.listBox.FormattingEnabled = true;
            this.listBox.Location = new System.Drawing.Point(12, 12);
            this.listBox.Name = "listBox";
            this.listBox.Size = new System.Drawing.Size(142, 199);
            this.listBox.TabIndex = 16;
            // 
            // AddFile_b
            // 
            this.AddFile_b.BackColor = System.Drawing.Color.LightCyan;
            this.AddFile_b.FlatAppearance.BorderColor = System.Drawing.Color.LightSkyBlue;
            this.AddFile_b.FlatAppearance.BorderSize = 6;
            this.AddFile_b.Location = new System.Drawing.Point(172, 188);
            this.AddFile_b.Name = "AddFile_b";
            this.AddFile_b.Size = new System.Drawing.Size(75, 23);
            this.AddFile_b.TabIndex = 17;
            this.AddFile_b.Text = "Load";
            this.AddFile_b.UseVisualStyleBackColor = false;
            this.AddFile_b.Click += new System.EventHandler(this.AddFile_b_Click);
            // 
            // predictionsListBox
            // 
            this.predictionsListBox.BackColor = System.Drawing.Color.LightCyan;
            this.predictionsListBox.FormattingEnabled = true;
            this.predictionsListBox.Location = new System.Drawing.Point(498, 245);
            this.predictionsListBox.Name = "predictionsListBox";
            this.predictionsListBox.Size = new System.Drawing.Size(138, 121);
            this.predictionsListBox.TabIndex = 18;
            // 
            // takenTextBox
            // 
            this.takenTextBox.BackColor = System.Drawing.Color.LightCyan;
            this.takenTextBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.takenTextBox.Location = new System.Drawing.Point(105, 295);
            this.takenTextBox.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.takenTextBox.Name = "takenTextBox";
            this.takenTextBox.Size = new System.Drawing.Size(49, 24);
            this.takenTextBox.TabIndex = 22;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(31, 295);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 24);
            this.label2.TabIndex = 21;
            this.label2.Text = "Taken:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(-2, 338);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 24);
            this.label4.TabIndex = 20;
            this.label4.Text = "Not Taken:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // notTakenTextBox
            // 
            this.notTakenTextBox.BackColor = System.Drawing.Color.LightCyan;
            this.notTakenTextBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.notTakenTextBox.Location = new System.Drawing.Point(105, 342);
            this.notTakenTextBox.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.notTakenTextBox.Name = "notTakenTextBox";
            this.notTakenTextBox.Size = new System.Drawing.Size(49, 24);
            this.notTakenTextBox.TabIndex = 19;
            // 
            // loadingProgressBar
            // 
            this.loadingProgressBar.Cursor = System.Windows.Forms.Cursors.PanEast;
            this.loadingProgressBar.Location = new System.Drawing.Point(526, 86);
            this.loadingProgressBar.MarqueeAnimationSpeed = 30;
            this.loadingProgressBar.Name = "loadingProgressBar";
            this.loadingProgressBar.RightToLeftLayout = true;
            this.loadingProgressBar.Size = new System.Drawing.Size(110, 23);
            this.loadingProgressBar.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.loadingProgressBar.TabIndex = 23;
            this.loadingProgressBar.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(667, 411);
            this.Controls.Add(this.loadingProgressBar);
            this.Controls.Add(this.takenTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.notTakenTextBox);
            this.Controls.Add(this.predictionsListBox);
            this.Controls.Add(this.AddFile_b);
            this.Controls.Add(this.listBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.mTextBox);
            this.Controls.Add(this.contextSizeTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.accuracyLabel);
            this.Controls.Add(this.l_accuracy);
            this.Controls.Add(this.accuracyProgressBar);
            this.Controls.Add(this.b_start);
            this.Controls.Add(this.totalTextBox);
            this.Controls.Add(this.l_Total);
            this.Controls.Add(this.correctTextBox);
            this.Controls.Add(this.l_CorrectPredictions);
            this.Controls.Add(this.l_IncorctPredictions);
            this.Controls.Add(this.incorrectTextBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "Predictor PPM";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label incorrectTextBox;
        private System.Windows.Forms.Label l_IncorctPredictions;
        private System.Windows.Forms.Label l_CorrectPredictions;
        private System.Windows.Forms.Label correctTextBox;
        private System.Windows.Forms.Label totalTextBox;
        private System.Windows.Forms.Label l_Total;
        private System.Windows.Forms.Button b_start;
        private System.Windows.Forms.ProgressBar accuracyProgressBar;
        private System.Windows.Forms.Label l_accuracy;
        private System.Windows.Forms.Label accuracyLabel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox contextSizeTextBox;
        private System.Windows.Forms.TextBox mTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ListBox listBox;
        private System.Windows.Forms.Button AddFile_b;
        private System.Windows.Forms.ListBox predictionsListBox;
        private System.Windows.Forms.Label takenTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label notTakenTextBox;
        private System.Windows.Forms.ProgressBar loadingProgressBar;
    }
}

