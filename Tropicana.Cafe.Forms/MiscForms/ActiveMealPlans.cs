using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tropicana.Cafe.Main.Data;
using System.Data.SqlClient;

namespace Tropicana.Cafe.Forms.MiscForms
{
    public partial class ActiveMealPlans : Form
    {
        private string connectionString = MealDatabaseAccess.GetMealsConnectionString();
        private SqlDataAdapter da;
        private SqlCommandBuilder builder;
        private DataTable dt;

        public ActiveMealPlans()
        {
            InitializeComponent();
            SqlConnection con = new SqlConnection(connectionString);
            da = new SqlDataAdapter("SELECT * from MealType;", con);
            dt = new DataTable();
            try
            {
                con.Open();
                da.Fill(dt);
                con.Close();
            }
            catch(Exception e)
            {

            }
            foreach(DataColumn col in dt.Columns)
            {
                if(col.ColumnName != "Active")
                {
                    col.ReadOnly = true;
                }
            }
            ActiveMealPlanDataGrid.DataSource = dt;
        }

        private void UpdateData(object sender, EventArgs e)
        {
            builder = new SqlCommandBuilder(da);
            if(dt.GetChanges() != null)
            {
                da.Update(dt.GetChanges());
            }
        }
    }
}
