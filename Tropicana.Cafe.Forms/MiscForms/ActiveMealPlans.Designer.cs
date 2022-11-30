namespace Tropicana.Cafe.Forms.MiscForms
{
    partial class ActiveMealPlans
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
            this.ActiveMealPlanDataGrid = new System.Windows.Forms.DataGridView();
            this.UpdateButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.ActiveMealPlanDataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // ActiveMealPlanDataGrid
            // 
            this.ActiveMealPlanDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ActiveMealPlanDataGrid.Location = new System.Drawing.Point(12, 12);
            this.ActiveMealPlanDataGrid.Name = "ActiveMealPlanDataGrid";
            this.ActiveMealPlanDataGrid.Size = new System.Drawing.Size(375, 149);
            this.ActiveMealPlanDataGrid.TabIndex = 0;
            // 
            // UpdateButton
            // 
            this.UpdateButton.Location = new System.Drawing.Point(299, 174);
            this.UpdateButton.Name = "UpdateButton";
            this.UpdateButton.Size = new System.Drawing.Size(75, 23);
            this.UpdateButton.TabIndex = 1;
            this.UpdateButton.Text = "Update";
            this.UpdateButton.UseVisualStyleBackColor = true;
            this.UpdateButton.Click += new System.EventHandler(this.UpdateData);
            // 
            // ActiveMealPlans
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(399, 209);
            this.Controls.Add(this.UpdateButton);
            this.Controls.Add(this.ActiveMealPlanDataGrid);
            this.Name = "ActiveMealPlans";
            this.Text = "ActiveMealPlans";
            ((System.ComponentModel.ISupportInitialize)(this.ActiveMealPlanDataGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView ActiveMealPlanDataGrid;
        private System.Windows.Forms.Button UpdateButton;
    }
}