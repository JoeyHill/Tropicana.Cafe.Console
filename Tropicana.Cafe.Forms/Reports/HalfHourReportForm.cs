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
    public partial class HalfHourReportForm : Form
    {
        public HalfHourReportForm()
        {
            InitializeComponent();
            startDateTimePicker.Value = DateTime.Now.Date;
            endDateTimePicker.Value = DateTime.Now.Date.AtMidnight(true);
        }

        private void HalfHourReportForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'TropicanaMealsDataSet.HalfHourMeals' table. You can move, or remove it, as needed.
            this.HalfHourMealsTableAdapter.Fill(this.TropicanaMealsDataSet.HalfHourMeals, startDateTimePicker.Value, endDateTimePicker.Value);

            this.reportViewer1.RefreshReport();
        }
    }
}
