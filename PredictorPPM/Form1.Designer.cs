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
            this.l_accuracy = new System.Windows.Forms.Label();
            this.l_rateError = new System.Windows.Forms.Label();
            this.correctTextBox = new System.Windows.Forms.Label();
            this.branchesTextBox = new System.Windows.Forms.Label();
            this.l_numberOfJumps = new System.Windows.Forms.Label();
            this.l_corectPredictions = new System.Windows.Forms.Label();
            this.noBranchesTextBox = new System.Windows.Forms.Label();
            this.b_start = new System.Windows.Forms.Button();
            this.accuracyProgressBar = new System.Windows.Forms.ProgressBar();
            this.label1 = new System.Windows.Forms.Label();
            this.accuracyLabel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.contextSizeTextBox = new System.Windows.Forms.TextBox();
            this.mTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.listBox = new System.Windows.Forms.ListBox();
            this.AddFile_b = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // incorrectTextBox
            // 
            this.incorrectTextBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.incorrectTextBox.Location = new System.Drawing.Point(132, 315);
            this.incorrectTextBox.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.incorrectTextBox.Name = "incorrectTextBox";
            this.incorrectTextBox.Size = new System.Drawing.Size(49, 24);
            this.incorrectTextBox.TabIndex = 0;
            // 
            // l_accuracy
            // 
            this.l_accuracy.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.l_accuracy.Location = new System.Drawing.Point(9, 315);
            this.l_accuracy.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.l_accuracy.Name = "l_accuracy";
            this.l_accuracy.Size = new System.Drawing.Size(118, 24);
            this.l_accuracy.TabIndex = 1;
            this.l_accuracy.Text = "Incorrect Predictions:";
            this.l_accuracy.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // l_rateError
            // 
            this.l_rateError.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.l_rateError.Location = new System.Drawing.Point(9, 283);
            this.l_rateError.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.l_rateError.Name = "l_rateError";
            this.l_rateError.Size = new System.Drawing.Size(118, 24);
            this.l_rateError.TabIndex = 2;
            this.l_rateError.Text = "Correct Predictions:";
            this.l_rateError.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // correctTextBox
            // 
            this.correctTextBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.correctTextBox.Location = new System.Drawing.Point(132, 283);
            this.correctTextBox.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.correctTextBox.Name = "correctTextBox";
            this.correctTextBox.Size = new System.Drawing.Size(49, 24);
            this.correctTextBox.TabIndex = 3;
            // 
            // branchesTextBox
            // 
            this.branchesTextBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.branchesTextBox.Location = new System.Drawing.Point(132, 212);
            this.branchesTextBox.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.branchesTextBox.Name = "branchesTextBox";
            this.branchesTextBox.Size = new System.Drawing.Size(49, 24);
            this.branchesTextBox.TabIndex = 7;
            // 
            // l_numberOfJumps
            // 
            this.l_numberOfJumps.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.l_numberOfJumps.Location = new System.Drawing.Point(26, 212);
            this.l_numberOfJumps.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.l_numberOfJumps.Name = "l_numberOfJumps";
            this.l_numberOfJumps.Size = new System.Drawing.Size(88, 24);
            this.l_numberOfJumps.TabIndex = 6;
            this.l_numberOfJumps.Text = "Branches:";
            this.l_numberOfJumps.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // l_corectPredictions
            // 
            this.l_corectPredictions.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.l_corectPredictions.Location = new System.Drawing.Point(24, 250);
            this.l_corectPredictions.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.l_corectPredictions.Name = "l_corectPredictions";
            this.l_corectPredictions.Size = new System.Drawing.Size(91, 24);
            this.l_corectPredictions.TabIndex = 5;
            this.l_corectPredictions.Text = "No branches:";
            this.l_corectPredictions.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // noBranchesTextBox
            // 
            this.noBranchesTextBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.noBranchesTextBox.Location = new System.Drawing.Point(132, 250);
            this.noBranchesTextBox.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.noBranchesTextBox.Name = "noBranchesTextBox";
            this.noBranchesTextBox.Size = new System.Drawing.Size(49, 24);
            this.noBranchesTextBox.TabIndex = 4;
            // 
            // b_start
            // 
            this.b_start.BackColor = System.Drawing.Color.LimeGreen;
            this.b_start.Font = new System.Drawing.Font("Ink Free", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.b_start.ForeColor = System.Drawing.SystemColors.ControlText;
            this.b_start.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.b_start.Location = new System.Drawing.Point(446, 35);
            this.b_start.Margin = new System.Windows.Forms.Padding(2);
            this.b_start.Name = "b_start";
            this.b_start.Size = new System.Drawing.Size(136, 81);
            this.b_start.TabIndex = 8;
            this.b_start.Text = "START";
            this.b_start.UseVisualStyleBackColor = false;
            this.b_start.Click += new System.EventHandler(this.b_start_Click);
            // 
            // accuracyProgressBar
            // 
            this.accuracyProgressBar.Location = new System.Drawing.Point(251, 263);
            this.accuracyProgressBar.Margin = new System.Windows.Forms.Padding(2);
            this.accuracyProgressBar.Name = "accuracyProgressBar";
            this.accuracyProgressBar.Size = new System.Drawing.Size(134, 19);
            this.accuracyProgressBar.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(289, 248);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Accuracy:";
            // 
            // accuracyLabel
            // 
            this.accuracyLabel.AutoSize = true;
            this.accuracyLabel.Location = new System.Drawing.Point(308, 296);
            this.accuracyLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.accuracyLabel.Name = "accuracyLabel";
            this.accuracyLabel.Size = new System.Drawing.Size(0, 13);
            this.accuracyLabel.TabIndex = 11;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(491, 229);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 17);
            this.label3.TabIndex = 12;
            this.label3.Text = "Context size:";
            // 
            // contextSizeTextBox
            // 
            this.contextSizeTextBox.Location = new System.Drawing.Point(506, 248);
            this.contextSizeTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.contextSizeTextBox.Name = "contextSizeTextBox";
            this.contextSizeTextBox.Size = new System.Drawing.Size(76, 20);
            this.contextSizeTextBox.TabIndex = 13;
            // 
            // mTextBox
            // 
            this.mTextBox.Location = new System.Drawing.Point(506, 318);
            this.mTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.mTextBox.Name = "mTextBox";
            this.mTextBox.Size = new System.Drawing.Size(76, 20);
            this.mTextBox.TabIndex = 14;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(534, 296);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(23, 20);
            this.label5.TabIndex = 15;
            this.label5.Text = "M";
            // 
            // listBox
            // 
            this.listBox.FormattingEnabled = true;
            this.listBox.Location = new System.Drawing.Point(27, 13);
            this.listBox.Name = "listBox";
            this.listBox.Size = new System.Drawing.Size(142, 134);
            this.listBox.TabIndex = 16;
            // 
            // AddFile_b
            // 
            this.AddFile_b.Location = new System.Drawing.Point(27, 166);
            this.AddFile_b.Name = "AddFile_b";
            this.AddFile_b.Size = new System.Drawing.Size(75, 23);
            this.AddFile_b.TabIndex = 17;
            this.AddFile_b.Text = "Add File";
            this.AddFile_b.UseVisualStyleBackColor = true;
            this.AddFile_b.Click += new System.EventHandler(this.AddFile_b_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 366);
            this.Controls.Add(this.AddFile_b);
            this.Controls.Add(this.listBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.mTextBox);
            this.Controls.Add(this.contextSizeTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.accuracyLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.accuracyProgressBar);
            this.Controls.Add(this.b_start);
            this.Controls.Add(this.branchesTextBox);
            this.Controls.Add(this.l_numberOfJumps);
            this.Controls.Add(this.l_corectPredictions);
            this.Controls.Add(this.noBranchesTextBox);
            this.Controls.Add(this.correctTextBox);
            this.Controls.Add(this.l_rateError);
            this.Controls.Add(this.l_accuracy);
            this.Controls.Add(this.incorrectTextBox);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "Predictor PPM";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label incorrectTextBox;
        private System.Windows.Forms.Label l_accuracy;
        private System.Windows.Forms.Label l_rateError;
        private System.Windows.Forms.Label correctTextBox;
        private System.Windows.Forms.Label branchesTextBox;
        private System.Windows.Forms.Label l_numberOfJumps;
        private System.Windows.Forms.Label l_corectPredictions;
        private System.Windows.Forms.Label noBranchesTextBox;
        private System.Windows.Forms.Button b_start;
        private System.Windows.Forms.ProgressBar accuracyProgressBar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label accuracyLabel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox contextSizeTextBox;
        private System.Windows.Forms.TextBox mTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ListBox listBox;
        private System.Windows.Forms.Button AddFile_b;
    }
}

