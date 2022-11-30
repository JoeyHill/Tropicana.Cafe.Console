using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tropicana.Cafe.Main.Extensions;

namespace Tropicana.Cafe.Forms.Reports
{
    public partial class MealPeriodReport : Form
    {
        public MealPeriodReport()
        {
            InitializeComponent();
            startDateTimePicker.Value = DateTime.Now.Date;
            endDateTimePicker.Value = DateTime.Now.Date.AtMidnight(true);
        }

        public MealPeriodReport(string Type)
        {
            InitializeComponent();
            startDateTimePicker.Value = DateTime.Now.Date;
            endDateTimePicker.Value = DateTime.Now.Date.AtMidnight(true);

            if(Type == "MealPeriods")
            {
                Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
                reportDataSource1.Name = "n_Meals1DataSet";
                reportDataSource1.Value = this.meals1BindingSource;
                this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
                this.reportViewer1.LocalReport.ReportEmbeddedResource = "Tropicana.Cafe.Forms.Reports.MealPeriodReport.rdlc";
            }
            else if(Type == "MealPlan")
            {
                Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
                reportDataSource1.Name = "n_ByMealPlan";
                reportDataSource1.Value = this.meals1BindingSource;
                this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
                this.reportViewer1.LocalReport.ReportEmbeddedResource = "Tropicana.Cafe.Forms.Reports.ByMealPlan.rdlc";
            }
        }

        private void ReportViewer_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'tropicanaMealsDataSet.HalfHourMeals' table. You can move, or remove it, as needed.
            //this.HalfHourMealsTableAdapter.Fill(this.tropicanaMealsDataSet.HalfHourMeals, startDateTimePicker.Value, endDateTimePicker.Value);
            // TODO: This line of code loads data into the 'tropicanaMealsDataSet.HourlyMeals' table. You can move, or remove it, as needed.
            this.HourlyMealsTableAdapter.Fill(this.tropicanaMealsDataSet.HourlyMeals, startDateTimePicker.Value, endDateTimePicker.Value);
            // TODO: This line of code loads data into the 'tropicanaMealsDataSet.Meals1' table. You can move, or remove it, as needed.
            this.meals1TableAdapter.Fill(this.tropicanaMealsDataSet.Meals1, startDateTimePicker.Value, endDateTimePicker.Value);

            this.reportViewer1.RefreshReport();
        }

    }
}
