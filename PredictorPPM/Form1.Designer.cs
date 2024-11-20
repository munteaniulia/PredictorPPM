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
            this.l_AccuracyPercentage = new System.Windows.Forms.Label();
            this.l_accuracy = new System.Windows.Forms.Label();
            this.l_rateError = new System.Windows.Forms.Label();
            this.l_errorRatePercentage = new System.Windows.Forms.Label();
            this.numberOfJumps = new System.Windows.Forms.Label();
            this.l_numberOfJumps = new System.Windows.Forms.Label();
            this.l_corectPredictions = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.b_start = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.t_contextSize = new System.Windows.Forms.TextBox();
            this.t_m = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // l_AccuracyPercentage
            // 
            this.l_AccuracyPercentage.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.l_AccuracyPercentage.Location = new System.Drawing.Point(176, 388);
            this.l_AccuracyPercentage.Name = "l_AccuracyPercentage";
            this.l_AccuracyPercentage.Size = new System.Drawing.Size(65, 30);
            this.l_AccuracyPercentage.TabIndex = 0;
            // 
            // l_accuracy
            // 
            this.l_accuracy.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.l_accuracy.Location = new System.Drawing.Point(12, 388);
            this.l_accuracy.Name = "l_accuracy";
            this.l_accuracy.Size = new System.Drawing.Size(158, 30);
            this.l_accuracy.TabIndex = 1;
            this.l_accuracy.Text = "Incorrect Predictions:";
            this.l_accuracy.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.l_accuracy.Click += new System.EventHandler(this.label1_Click);
            // 
            // l_rateError
            // 
            this.l_rateError.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.l_rateError.Location = new System.Drawing.Point(12, 348);
            this.l_rateError.Name = "l_rateError";
            this.l_rateError.Size = new System.Drawing.Size(158, 30);
            this.l_rateError.TabIndex = 2;
            this.l_rateError.Text = "Correct Predictions:";
            this.l_rateError.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // l_errorRatePercentage
            // 
            this.l_errorRatePercentage.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.l_errorRatePercentage.Location = new System.Drawing.Point(176, 348);
            this.l_errorRatePercentage.Name = "l_errorRatePercentage";
            this.l_errorRatePercentage.Size = new System.Drawing.Size(65, 30);
            this.l_errorRatePercentage.TabIndex = 3;
            // 
            // numberOfJumps
            // 
            this.numberOfJumps.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.numberOfJumps.Location = new System.Drawing.Point(176, 261);
            this.numberOfJumps.Name = "numberOfJumps";
            this.numberOfJumps.Size = new System.Drawing.Size(65, 30);
            this.numberOfJumps.TabIndex = 7;
            // 
            // l_numberOfJumps
            // 
            this.l_numberOfJumps.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.l_numberOfJumps.Location = new System.Drawing.Point(35, 261);
            this.l_numberOfJumps.Name = "l_numberOfJumps";
            this.l_numberOfJumps.Size = new System.Drawing.Size(118, 30);
            this.l_numberOfJumps.TabIndex = 6;
            this.l_numberOfJumps.Text = "Branches:";
            this.l_numberOfJumps.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // l_corectPredictions
            // 
            this.l_corectPredictions.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.l_corectPredictions.Location = new System.Drawing.Point(32, 308);
            this.l_corectPredictions.Name = "l_corectPredictions";
            this.l_corectPredictions.Size = new System.Drawing.Size(121, 30);
            this.l_corectPredictions.TabIndex = 5;
            this.l_corectPredictions.Text = "No branches:";
            this.l_corectPredictions.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label4.Location = new System.Drawing.Point(176, 308);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 30);
            this.label4.TabIndex = 4;
            // 
            // b_start
            // 
            this.b_start.BackColor = System.Drawing.Color.LimeGreen;
            this.b_start.Font = new System.Drawing.Font("Ink Free", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.b_start.ForeColor = System.Drawing.SystemColors.ControlText;
            this.b_start.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.b_start.Location = new System.Drawing.Point(594, 43);
            this.b_start.Name = "b_start";
            this.b_start.Size = new System.Drawing.Size(181, 100);
            this.b_start.TabIndex = 8;
            this.b_start.Text = "START";
            this.b_start.UseVisualStyleBackColor = false;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(335, 324);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(179, 23);
            this.progressBar1.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(385, 305);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 16);
            this.label1.TabIndex = 10;
            this.label1.Text = "Accuracy:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(461, 355);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 16);
            this.label2.TabIndex = 11;
            this.label2.Text = "label2";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(655, 282);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(120, 20);
            this.label3.TabIndex = 12;
            this.label3.Text = "Context size:";
            // 
            // t_contextSize
            // 
            this.t_contextSize.Location = new System.Drawing.Point(675, 305);
            this.t_contextSize.Name = "t_contextSize";
            this.t_contextSize.Size = new System.Drawing.Size(100, 22);
            this.t_contextSize.TabIndex = 13;
            // 
            // t_m
            // 
            this.t_m.Location = new System.Drawing.Point(675, 392);
            this.t_m.Name = "t_m";
            this.t_m.Size = new System.Drawing.Size(100, 22);
            this.t_m.TabIndex = 14;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(712, 364);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(30, 25);
            this.label5.TabIndex = 15;
            this.label5.Text = "M";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.t_m);
            this.Controls.Add(this.t_contextSize);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.b_start);
            this.Controls.Add(this.numberOfJumps);
            this.Controls.Add(this.l_numberOfJumps);
            this.Controls.Add(this.l_corectPredictions);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.l_errorRatePercentage);
            this.Controls.Add(this.l_rateError);
            this.Controls.Add(this.l_accuracy);
            this.Controls.Add(this.l_AccuracyPercentage);
            this.Name = "Form1";
            this.Text = "Predictor PPM";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label l_AccuracyPercentage;
        private System.Windows.Forms.Label l_accuracy;
        private System.Windows.Forms.Label l_rateError;
        private System.Windows.Forms.Label l_errorRatePercentage;
        private System.Windows.Forms.Label numberOfJumps;
        private System.Windows.Forms.Label l_numberOfJumps;
        private System.Windows.Forms.Label l_corectPredictions;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button b_start;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox t_contextSize;
        private System.Windows.Forms.TextBox t_m;
        private System.Windows.Forms.Label label5;
    }
}

