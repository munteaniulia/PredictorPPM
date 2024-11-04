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
            this.SuspendLayout();
            // 
            // l_AccuracyPercentage
            // 
            this.l_AccuracyPercentage.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.l_AccuracyPercentage.Location = new System.Drawing.Point(94, 388);
            this.l_AccuracyPercentage.Name = "l_AccuracyPercentage";
            this.l_AccuracyPercentage.Size = new System.Drawing.Size(65, 30);
            this.l_AccuracyPercentage.TabIndex = 0;
            // 
            // l_accuracy
            // 
            this.l_accuracy.Location = new System.Drawing.Point(12, 388);
            this.l_accuracy.Name = "l_accuracy";
            this.l_accuracy.Size = new System.Drawing.Size(76, 30);
            this.l_accuracy.TabIndex = 1;
            this.l_accuracy.Text = "Accuracy:";
            this.l_accuracy.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.l_accuracy.Click += new System.EventHandler(this.label1_Click);
            // 
            // l_rateError
            // 
            this.l_rateError.Location = new System.Drawing.Point(12, 332);
            this.l_rateError.Name = "l_rateError";
            this.l_rateError.Size = new System.Drawing.Size(76, 30);
            this.l_rateError.TabIndex = 2;
            this.l_rateError.Text = "Error Rate:";
            this.l_rateError.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // l_errorRatePercentage
            // 
            this.l_errorRatePercentage.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.l_errorRatePercentage.Location = new System.Drawing.Point(94, 338);
            this.l_errorRatePercentage.Name = "l_errorRatePercentage";
            this.l_errorRatePercentage.Size = new System.Drawing.Size(65, 30);
            this.l_errorRatePercentage.TabIndex = 3;
            // 
            // numberOfJumps
            // 
            this.numberOfJumps.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.numberOfJumps.Location = new System.Drawing.Point(373, 338);
            this.numberOfJumps.Name = "numberOfJumps";
            this.numberOfJumps.Size = new System.Drawing.Size(57, 30);
            this.numberOfJumps.TabIndex = 7;
            // 
            // l_numberOfJumps
            // 
            this.l_numberOfJumps.Location = new System.Drawing.Point(241, 332);
            this.l_numberOfJumps.Name = "l_numberOfJumps";
            this.l_numberOfJumps.Size = new System.Drawing.Size(118, 30);
            this.l_numberOfJumps.TabIndex = 6;
            this.l_numberOfJumps.Text = "Number of Jumps:";
            this.l_numberOfJumps.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // l_corectPredictions
            // 
            this.l_corectPredictions.Location = new System.Drawing.Point(238, 388);
            this.l_corectPredictions.Name = "l_corectPredictions";
            this.l_corectPredictions.Size = new System.Drawing.Size(121, 30);
            this.l_corectPredictions.TabIndex = 5;
            this.l_corectPredictions.Text = "Corect Predictions:";
            this.l_corectPredictions.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label4.Location = new System.Drawing.Point(373, 388);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 30);
            this.label4.TabIndex = 4;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.numberOfJumps);
            this.Controls.Add(this.l_numberOfJumps);
            this.Controls.Add(this.l_corectPredictions);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.l_errorRatePercentage);
            this.Controls.Add(this.l_rateError);
            this.Controls.Add(this.l_accuracy);
            this.Controls.Add(this.l_AccuracyPercentage);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

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
    }
}

