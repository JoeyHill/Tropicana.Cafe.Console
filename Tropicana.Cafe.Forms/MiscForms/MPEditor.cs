using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using Tropicana.Cafe.Main.Data;

namespace Tropicana.Cafe.Forms.MiscForms
{
    public partial class MPEditor : Form
    {
        SqlDataAdapter da;
        SqlDataAdapter daBasic;
        DataTable dt;
        DataTable dtBasic;
        string connectionString = MealDatabaseAccess.GetMealsConnectionString();
        SqlCommandBuilder builder;
        SqlCommandBuilder builderBasic;

        public MPEditor()
        {
            InitializeComponent();
            SqlConnection con = new SqlConnection(connectionString);
            da = new SqlDataAdapter("SELECT * from MealPeriodEnum;", con);
            daBasic = new SqlDataAdapter("SELECT * from BasicMealPeriodEnum;", con);
            dt = new DataTable();
            dtBasic = new DataTable();
            try
            {
                con.Open();
                da.Fill(dt);
                daBasic.Fill(dtBasic);
                con.Close();
            }
            catch (Exception e)
            {

            }

            MealPeriodGridView.DataSource = dt;
            BasicGridView.DataSource = dtBasic;

            //Active Columns
            foreach (DataGridViewTextBoxColumn col in MealPeriodGridView.Columns)
            {
                if (col.Name.Contains("Time"))
                {
                    MealPeriodGridView.Columns[col.Name].DefaultCellStyle.Format = "HH:mm";
                }
            }

            foreach(DataGridViewTextBoxColumn col in BasicGridView.Columns)
            {
                if (col.Name.Contains("Time"))
                {
                    BasicGridView.Columns[col.Name].DefaultCellStyle.Format = "HH:mm";
                }
            }
        }

        private void UpdateData(object sender, EventArgs e)
        {
            builder = new SqlCommandBuilder(da);
            builderBasic = new SqlCommandBuilder(daBasic);

            if (dt.GetChanges() != null)
            {
                da.Update(dt.GetChanges());
            }
            if(dtBasic.GetChanges() != null)
            {
                daBasic.Update(dtBasic.GetChanges());
            }
            MessageBox.Show("Saved changes.", "Updated!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }
    }
}
