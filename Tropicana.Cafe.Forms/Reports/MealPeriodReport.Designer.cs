namespace Tropicana.Cafe.Forms.Reports
{
    partial class MealPeriodReport
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
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MealPeriodReport));
            this.HourlyMealsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tropicanaMealsDataSet = new Tropicana.Cafe.Forms.Reports.TropicanaMealsDataSet();
            this.meals1BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.startDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.endDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.meals1TableAdapter = new Tropicana.Cafe.Forms.Reports.TropicanaMealsDataSetTableAdapters.Meals1TableAdapter();
            this.HourlyMealsTableAdapter = new Tropicana.Cafe.Forms.Reports.TropicanaMealsDataSetTableAdapters.HourlyMealsTableAdapter();
            this.halfHourMealsTableAdapter1 = new Tropicana.Cafe.Forms.Reports.TropicanaMealsDataSetTableAdapters.HalfHourMealsTableAdapter();
            this.HalfHourMealsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.HalfHourMealsTableAdapter = new Tropicana.Cafe.Forms.Reports.TropicanaMealsDataSetTableAdapters.HalfHourMealsTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.HourlyMealsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tropicanaMealsDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.meals1BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.HalfHourMealsBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // HourlyMealsBindingSource
            // 
            this.HourlyMealsBindingSource.DataMember = "HourlyMeals";
            this.HourlyMealsBindingSource.DataSource = this.tropicanaMealsDataSet;
            // 
            // tropicanaMealsDataSet
            // 
            this.tropicanaMealsDataSet.DataSetName = "TropicanaMealsDataSet";
            this.tropicanaMealsDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // meals1BindingSource
            // 
            this.meals1BindingSource.DataMember = "Meals1";
            this.meals1BindingSource.DataSource = this.tropicanaMealsDataSet;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.reportViewer1.AutoSize = true;
            reportDataSource1.Name = "n_HalfHourly";
            reportDataSource1.Value = this.HalfHourMealsBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Tropicana.Cafe.Forms.Reports.HalfHour.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(12, 54);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ShowBackButton = false;
            this.reportViewer1.ShowFindControls = false;
            this.reportViewer1.ShowPageNavigationControls = false;
            this.reportViewer1.ShowStopButton = false;
            this.reportViewer1.Size = new System.Drawing.Size(558, 385);
            this.reportViewer1.TabIndex = 0;
            this.reportViewer1.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.PageWidth;
            // 
            // startDateTimePicker
            // 
            this.startDateTimePicker.Location = new System.Drawing.Point(12, 12);
            this.startDateTimePicker.MaxDate = new System.DateTime(2100, 12, 31, 0, 0, 0, 0);
            this.startDateTimePicker.MinDate = new System.DateTime(2016, 1, 1, 0, 0, 0, 0);
            this.startDateTimePicker.Name = "startDateTimePicker";
            this.startDateTimePicker.Size = new System.Drawing.Size(200, 20);
            this.startDateTimePicker.TabIndex = 1;
            this.startDateTimePicker.ValueChanged += new System.EventHandler(this.ReportViewer_Load);
            // 
            // endDateTimePicker
            // 
            this.endDateTimePicker.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.endDateTimePicker.Location = new System.Drawing.Point(370, 12);
            this.endDateTimePicker.MaxDate = new System.DateTime(2100, 12, 31, 0, 0, 0, 0);
            this.endDateTimePicker.MinDate = new System.DateTime(2016, 1, 1, 0, 0, 0, 0);
            this.endDateTimePicker.Name = "endDateTimePicker";
            this.endDateTimePicker.Size = new System.Drawing.Size(200, 20);
            this.endDateTimePicker.TabIndex = 2;
            this.endDateTimePicker.ValueChanged += new System.EventHandler(this.ReportViewer_Load);
            // 
            // meals1TableAdapter
            // 
            this.meals1TableAdapter.ClearBeforeFill = true;
            // 
            // HourlyMealsTableAdapter
            // 
            this.HourlyMealsTableAdapter.ClearBeforeFill = true;
            // 
            // halfHourMealsTableAdapter1
            // 
            this.halfHourMealsTableAdapter1.ClearBeforeFill = true;
            // 
            // HalfHourMealsBindingSource
            // 
            this.HalfHourMealsBindingSource.DataMember = "HalfHourMeals";
            this.HalfHourMealsBindingSource.DataSource = this.tropicanaMealsDataSet;
            // 
            // HalfHourMealsTableAdapter
            // 
            this.HalfHourMealsTableAdapter.ClearBeforeFill = true;
            // 
            // MealPeriodReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(582, 451);
            this.Controls.Add(this.endDateTimePicker);
            this.Controls.Add(this.startDateTimePicker);
            this.Controls.Add(this.reportViewer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MealPeriodReport";
            this.Text = "ReportViewer";
            this.Load += new System.EventHandler(this.ReportViewer_Load);
            ((System.ComponentModel.ISupportInitialize)(this.HourlyMealsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tropicanaMealsDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.meals1BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.HalfHourMealsBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private TropicanaMealsDataSet tropicanaMealsDataSet;
        private System.Windows.Forms.BindingSource meals1BindingSource;
        private TropicanaMealsDataSetTableAdapters.Meals1TableAdapter meals1TableAdapter;
        private System.Windows.Forms.DateTimePicker startDateTimePicker;
        private System.Windows.Forms.DateTimePicker endDateTimePicker;
        private System.Windows.Forms.BindingSource HourlyMealsBindingSource;
        private TropicanaMealsDataSetTableAdapters.HourlyMealsTableAdapter HourlyMealsTableAdapter;
        private TropicanaMealsDataSetTableAdapters.HalfHourMealsTableAdapter halfHourMealsTableAdapter1;
        private System.Windows.Forms.BindingSource HalfHourMealsBindingSource;
        private TropicanaMealsDataSetTableAdapters.HalfHourMealsTableAdapter HalfHourMealsTableAdapter;
    }
}