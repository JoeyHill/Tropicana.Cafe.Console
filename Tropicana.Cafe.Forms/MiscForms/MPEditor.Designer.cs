namespace Tropicana.Cafe.Forms.MiscForms
{
    partial class MPEditor
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
            this.MealPeriodGridView = new System.Windows.Forms.DataGridView();
            this.UpdateButton = new System.Windows.Forms.Button();
            this.BasicGridView = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.MealPeriodGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BasicGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // MealPeriodGridView
            // 
            this.MealPeriodGridView.AllowUserToOrderColumns = true;
            this.MealPeriodGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.MealPeriodGridView.Location = new System.Drawing.Point(12, 32);
            this.MealPeriodGridView.Name = "MealPeriodGridView";
            this.MealPeriodGridView.Size = new System.Drawing.Size(507, 206);
            this.MealPeriodGridView.TabIndex = 0;
            // 
            // UpdateButton
            // 
            this.UpdateButton.Location = new System.Drawing.Point(444, 465);
            this.UpdateButton.Name = "UpdateButton";
            this.UpdateButton.Size = new System.Drawing.Size(75, 23);
            this.UpdateButton.TabIndex = 1;
            this.UpdateButton.Text = "Update";
            this.UpdateButton.UseVisualStyleBackColor = true;
            this.UpdateButton.Click += new System.EventHandler(this.UpdateData);
            // 
            // BasicGridView
            // 
            this.BasicGridView.AllowUserToOrderColumns = true;
            this.BasicGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.BasicGridView.Location = new System.Drawing.Point(12, 283);
            this.BasicGridView.Name = "BasicGridView";
            this.BasicGridView.Size = new System.Drawing.Size(507, 120);
            this.BasicGridView.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Trop Meal Periods";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 267);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Basic Meal Periods";
            // 
            // MPEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(531, 500);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BasicGridView);
            this.Controls.Add(this.UpdateButton);
            this.Controls.Add(this.MealPeriodGridView);
            this.Name = "MPEditor";
            this.Text = "MPEditor";
            ((System.ComponentModel.ISupportInitialize)(this.MealPeriodGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BasicGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView MealPeriodGridView;
        private System.Windows.Forms.Button UpdateButton;
        private System.Windows.Forms.DataGridView BasicGridView;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}