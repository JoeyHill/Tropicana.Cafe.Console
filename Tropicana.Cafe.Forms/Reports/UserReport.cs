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
using Tropicana.Cafe.Main.Models;

namespace Tropicana.Cafe.Forms.Reports
{
    public partial class UserReport : Form
    {
        SqlCommand cmd;
        SqlDataAdapter da;
        DataTable dt = new DataTable();

        public UserReport()
        {
            InitializeComponent();
        }

        public UserReport(TropStudent stu)
        {
            InitializeComponent();
            if (stu != null)
            {
                using (SqlConnection con = new SqlConnection(MealDatabaseAccess.GetMealsConnectionString()))
                {
                    cmd = new SqlCommand("SELECT TOP 50 * FROM Meals1 WHERE EntryID = @EntryID ORDER BY Time DESC;", con);
                    cmd.Parameters.AddWithValue("@EntryID", stu.EntryID);
                    da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                    UserGridView.DataSource = dt;
                    UserGridView.AllowUserToResizeColumns = true;
                }
            }
        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
