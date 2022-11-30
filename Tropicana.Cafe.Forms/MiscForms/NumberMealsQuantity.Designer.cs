namespace Tropicana.Cafe.Forms.MiscForms
{
    partial class NumberMealsQuantity
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
            this.DebitCounter = new System.Windows.Forms.NumericUpDown();
            this.WarningLabel = new System.Windows.Forms.Label();
            this.CancelButton = new System.Windows.Forms.Button();
            this.OKButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DebitCounter)).BeginInit();
            this.SuspendLayout();
            // 
            // DebitCounter
            // 
            this.DebitCounter.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DebitCounter.Location = new System.Drawing.Point(139, 66);
            this.DebitCounter.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.DebitCounter.Name = "DebitCounter";
            this.DebitCounter.Size = new System.Drawing.Size(120, 26);
            this.DebitCounter.TabIndex = 0;
            this.DebitCounter.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.DebitCounter.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // WarningLabel
            // 
            this.WarningLabel.AutoSize = true;
            this.WarningLabel.Location = new System.Drawing.Point(95, 29);
            this.WarningLabel.Name = "WarningLabel";
            this.WarningLabel.Size = new System.Drawing.Size(201, 13);
            this.WarningLabel.TabIndex = 1;
            this.WarningLabel.Text = "How many meals would you like to debit?";
            // 
            // CancelButton
            // 
            this.CancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelButton.Location = new System.Drawing.Point(221, 119);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(75, 23);
            this.CancelButton.TabIndex = 2;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseVisualStyleBackColor = true;
            // 
            // OKButton
            // 
            this.OKButton.Location = new System.Drawing.Point(98, 119);
            this.OKButton.Name = "OKButton";
            this.OKButton.Size = new System.Drawing.Size(75, 23);
            this.OKButton.TabIndex = 3;
            this.OKButton.Text = "OK";
            this.OKButton.UseVisualStyleBackColor = true;
            this.OKButton.Click += new System.EventHandler(this.OKButton_Click);
            // 
            // NumberMealsQuantity
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.CancelButton;
            this.ClientSize = new System.Drawing.Size(384, 154);
            this.Controls.Add(this.OKButton);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.WarningLabel);
            this.Controls.Add(this.DebitCounter);
            this.Name = "NumberMealsQuantity";
            this.Text = "NumberMealsQuantity";
            ((System.ComponentModel.ISupportInitialize)(this.DebitCounter)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown DebitCounter;
        private System.Windows.Forms.Label WarningLabel;
        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.Button OKButton;
    }
}