namespace Tropicana.Cafe.Forms.Reports
{
    partial class HalfHourReportForm
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.endDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.startDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.TropicanaMealsDataSet = new Tropicana.Cafe.Forms.Reports.TropicanaMealsDataSet();
            this.HalfHourMealsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.HalfHourMealsTableAdapter = new Tropicana.Cafe.Forms.Reports.TropicanaMealsDataSetTableAdapters.HalfHourMealsTableAdapter();
            this.HourlyMealsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.HourlyMealsTableAdapter = new Tropicana.Cafe.Forms.Reports.TropicanaMealsDataSetTableAdapters.HourlyMealsTableAdapter();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.TropicanaMealsDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.HalfHourMealsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.HourlyMealsBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // endDateTimePicker
            // 
            this.endDateTimePicker.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.endDateTimePicker.Location = new System.Drawing.Point(369, 13);
            this.endDateTimePicker.MaxDate = new System.DateTime(2100, 12, 31, 0, 0, 0, 0);
            this.endDateTimePicker.MinDate = new System.DateTime(2016, 1, 1, 0, 0, 0, 0);
            this.endDateTimePicker.Name = "endDateTimePicker";
            this.endDateTimePicker.Size = new System.Drawing.Size(200, 20);
            this.endDateTimePicker.TabIndex = 5;
            this.endDateTimePicker.ValueChanged += new System.EventHandler(this.HalfHourReportForm_Load);
            // 
            // startDateTimePicker
            // 
            this.startDateTimePicker.Location = new System.Drawing.Point(11, 13);
            this.startDateTimePicker.MaxDate = new System.DateTime(2100, 12, 31, 0, 0, 0, 0);
            this.startDateTimePicker.MinDate = new System.DateTime(2016, 1, 1, 0, 0, 0, 0);
            this.startDateTimePicker.Name = "startDateTimePicker";
            this.startDateTimePicker.Size = new System.Drawing.Size(200, 20);
            this.startDateTimePicker.TabIndex = 4;
            this.startDateTimePicker.ValueChanged += new System.EventHandler(this.HalfHourReportForm_Load);
            // 
            // TropicanaMealsDataSet
            // 
            this.TropicanaMealsDataSet.DataSetName = "TropicanaMealsDataSet";
            this.TropicanaMealsDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // HalfHourMealsBindingSource
            // 
            this.HalfHourMealsBindingSource.DataMember = "HalfHourMeals";
            this.HalfHourMealsBindingSource.DataSource = this.TropicanaMealsDataSet;
            // 
            // HalfHourMealsTableAdapter
            // 
            this.HalfHourMealsTableAdapter.ClearBeforeFill = true;
            // 
            // HourlyMealsBindingSource
            // 
            this.HourlyMealsBindingSource.DataMember = "HourlyMeals";
            this.HourlyMealsBindingSource.DataSource = this.TropicanaMealsDataSet;
            // 
            // HourlyMealsTableAdapter
            // 
            this.HourlyMealsTableAdapter.ClearBeforeFill = true;
            // 
            // reportViewer1
            // 
            reportDataSource2.Name = "DataSet1";
            reportDataSource2.Value = this.HalfHourMealsBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Tropicana.Cafe.Forms.Reports.Report1.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(12, 39);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(556, 401);
            this.reportViewer1.TabIndex = 6;
            // 
            // HalfHourReportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(580, 452);
            this.Controls.Add(this.reportViewer1);
            this.Controls.Add(this.endDateTimePicker);
            this.Controls.Add(this.startDateTimePicker);
            this.Name = "HalfHourReportForm";
            this.Text = "HalfHourReportForm";
            this.Load += new System.EventHandler(this.HalfHourReportForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.TropicanaMealsDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.HalfHourMealsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.HourlyMealsBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DateTimePicker endDateTimePicker;
        private System.Windows.Forms.DateTimePicker startDateTimePicker;
        private System.Windows.Forms.BindingSource HalfHourMealsBindingSource;
        private TropicanaMealsDataSet TropicanaMealsDataSet;
        private TropicanaMealsDataSetTableAdapters.HalfHourMealsTableAdapter HalfHourMealsTableAdapter;
        private System.Windows.Forms.BindingSource HourlyMealsBindingSource;
        private TropicanaMealsDataSetTableAdapters.HourlyMealsTableAdapter HourlyMealsTableAdapter;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
    }
}