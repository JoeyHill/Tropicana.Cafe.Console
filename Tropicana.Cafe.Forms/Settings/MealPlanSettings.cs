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
using Tropicana.Cafe.Main.Settings;

namespace Tropicana.Cafe.Forms.Settings
{
    public partial class MealPlanSettings : Form
    {
        public MealPlanSettings()
        {
            InitializeComponent();
            setBuilding();

            //Meal Settings
            mServer.Text = MainSettings.Default.MealServer;
            mServer.Tag = "MealServer";
            mDB.Text = MainSettings.Default.MealDB;
            mDB.Tag = "MealDB";
            mUser.Text = MainSettings.Default.MealUser;
            mUser.Tag = "MealUser";
            mPass.Text = MainSettings.Default.MealPass;
            mPass.Tag = "MealPass";

            //Student Settings
            sServer.Text = MainSettings.Default.StuServer;
            sServer.Tag = "StuServer";
            sDB.Text = MainSettings.Default.StuDB;
            sDB.Tag = "StuDB";
            sUser.Text = MainSettings.Default.StuUser;
            sUser.Tag = "StuUser";
            sPass.Text = MainSettings.Default.StuPass;
            sPass.Tag = "StuPass";

            enforceSingleCheck.Checked = MainSettings.Default.EnforceSingleMeal;
            enforceSingleCheck.DataBindings.Add(new System.Windows.Forms.Binding("Checked", MainSettings.Default, "EnforceSingleMeal", true, DataSourceUpdateMode.OnPropertyChanged));
            enforceSingleCheck.Tag = "EnforceSingleMeal";

        }

        private void UpdateSetting(string Setting, string Value)
        {
            MainSettings.Default[Setting] = Value;
            MainSettings.Default.Save();
        }

        private void SettingTextChanged(object sender, EventArgs e)
        {
            if(sender.GetType() == typeof(TextBox))
            {
                TextBox tb = (TextBox)sender;
                UpdateSetting(tb.Tag.ToString(), tb.Text);

            }
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            //TODO: use a Dictionary to store edited IDs or ID/Value, send each to DB to update?
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            MainSettings.Default.Save();
            MainSettings.Default.Upgrade();
            MessageBox.Show("Settings Saved!\nA restart may be required.", "Saved!", MessageBoxButtons.OK);
            this.Close();
        }

        private void setBuilding()
        {
            switch(MainSettings.Default.Building)
            {
                case "Tropicana Del Norte":
                    tdn_Radio.Checked = true;
                    tg_Radio.Checked = false;
                    break;
                default:
                case "Tropicana Gardens":
                    tg_Radio.Checked = true;
                    tdn_Radio.Checked = false;
                    break;
            }
        }

        private void CloseWindow(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buildingRadioChanged(object sender, EventArgs e)
        {
            if (tg_Radio.Checked)
            {
                MainSettings.Default.Building = tg_Radio.Text;
            }
            else if (tdn_Radio.Checked)
            {
                MainSettings.Default.Building = tdn_Radio.Text;
            }
            MainSettings.Default.Save();
            MainSettings.Default.Reload();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            CloseWindow(sender, e);
        }

        private void TestConnection(object sender, EventArgs e)
        {
            string name = (sender as Button).Name;
            SqlConnectionStringBuilder csb = new SqlConnectionStringBuilder();
            if(name == "sTestCon")
            {
                csb.DataSource = sServer.Text;
                csb.InitialCatalog = sDB.Text;
                csb.UserID = sUser.Text;
                csb.Password = sPass.Text;
            }
            else
            {
                csb.DataSource = mServer.Text;
                csb.InitialCatalog = mDB.Text;
                csb.UserID = mUser.Text;
                csb.Password = mPass.Text;
            }

            string result = "";

            using (SqlConnection con = new SqlConnection(csb.ConnectionString))
            {
                try
                {
                    con.Open();
                    con.Close();
                    result = "Success!";
                }
                catch(Exception er)
                {
                    result = er.Message.ToString();
                }
            }

            MessageBox.Show(result);
        }
    }
}
