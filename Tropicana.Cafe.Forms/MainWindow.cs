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
using Tropicana.Cafe.Main.Data;
using Tropicana.Cafe.Main.Models;
using System.Collections;
using Tropicana.Cafe.Main.Validators;
using System.Windows.Input;
using System.Diagnostics;
using Tropicana.Cafe.Main;
using Tropicana.Cafe.Main.Settings;
using System.Deployment.Application;

namespace Tropicana.Cafe.Forms
{
    public partial class MainWindow : Form
    {
        public TropStudent ActiveStudentObject
        {
            get
            {
                return ActiveStudent;
            }
            set
            {
                ActiveStudent = value;
            }
        }
        TropStudent ActiveStudent;

        #region Settings and Variables
        //ToDo: Replace with settings
        private int WaitMilliseconds = 500;
        private int MaxHistory = 10;
        private string BuildingSetting = MainSettings.Default.Building;

        public void ConductTest()
        {
            EntryList_SelectedIndexChanged(null, null);
            FakeEnter();
        }

        MealValidator v;

        Timer WaitTimer = new Timer();
        #endregion

        public MainWindow()
        {
            Debug.WriteLine("Starting");
            InitializeComponent();
            if(!DatabaseAccess.TestConnection() || !MealDatabaseAccess.TestConnection())
            {
                MessageBox.Show("There is an error connecting one or more of the databases. Please verify the settings.", "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            WaitTimer.Interval = WaitMilliseconds;
            WaitTimer.Tick += WaitTimer_Tick;
            LogList.HeaderStyle = ColumnHeaderStyle.None;
            
            
            if (Globals.TESTINGMODE)
            {
                LogList.BackColor = Color.Crimson;
            }
            
        }

        private void WaitTimer_Tick(object sender, EventArgs e)
        {
            //textBox1.SelectAll();
            WaitTimer.Stop();
        }

        /// <summary>
        /// Checks the input text and collects the appropriate entry or list to display. Does not verify entry validity, only lists. 
        /// </summary>
        private void textBox1_KeyUp(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox1.Text.Length < 3)
            {
                EntryList.DataSource = null;
                ClearListbox();
                ClearPhoto();
                return;
            }
            Dictionary<int, string> dt;
            //EntryList.Items.Clear();
            if (textBox1.Text.IsNumber())
            {
                dt = DatabaseAccess.GetSimpleEntry(int.Parse(textBox1.Text));
            }
            else
            {
                dt = DatabaseAccess.GetSimpleEntry(textBox1.Text);
            }

            if(dt.Count == 0)
            {
                ClearListbox();
                return;
            }
            EntryList.DataSource = new BindingSource(dt, null);
            EntryList.DisplayMember = "Value";
            EntryList.ValueMember = "Key";
            WaitTimer.Stop();
            WaitTimer.Start();
        }

        /// <summary>
        /// Clears the Entry Listbox.
        /// </summary>
        private void ClearListbox()
        {
            EntryList.DataSource = null;
            EntryList.Items.Clear();
            return;
        }


        /// <summary>
        /// Looks up the selected Entry and sets to the ActiveStudent property. 
        /// </summary>
        private void EntryList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(EntryList.SelectedIndex > -1)
            {
                var selectedProperty = (KeyValuePair<int, string>)EntryList.SelectedItem;
                int k = selectedProperty.Key;
                DataTable dt = DatabaseAccess.GetByID((k));
                ActiveStudent = dt.ToList<TropStudent>()[0];
                ActiveStudent.Init();
                v = new MealValidator(ActiveStudent.ActiveMeal);
                if(v.Response.Status == Main.Validation.Invalid)
                {
                    pictureBox2.BackColor = RemainingCountLabel.BackColor = Color.Red;
                    if (ActiveStudent.ActiveMeal != null && ActiveStudent.ActiveMeal.MealPlan.IsPunchCard)
                    {
                        RemainingCountLabel.Text = "00";
                    }
                    else
                    {
                        RemainingCountLabel.Text = "";
                    }
                }
                else
                {
                    pictureBox2.BackColor = RemainingCountLabel.BackColor = Color.Green;
                    string remaining = (ActiveStudent.ActiveMeal.Balance == 0) ? "" : ActiveStudent.ActiveMeal.Balance.ToString("D2");
                    RemainingCountLabel.Text = remaining;
                }
                SetPhoto();
            }
            else
            {
                ClearPhoto();
            }
            #region Debug
            //Debug.WriteLine(String.Format("Entry: {0}\nActive Meal: {1}", ActiveStudent.EntryID, ActiveStudent.ActiveMeal.EntryMealID));
            #endregion

        }

        /// <summary>
        /// Sets the PictureBox to the Active Student's Photo.
        /// </summary>
        private void SetPhoto()
        {
            if(ActiveStudent != null)
            {
                pictureBox1.Image = ActiveStudent.Photo;
            }
        }

        /// <summary>
        /// Clears and disposes of the image in the PictureBox.
        /// </summary>
        private void ClearPhoto()
        {
            if(pictureBox1.Image == null)
            {
                return;
            }
            pictureBox1.Image.Dispose();
            pictureBox1.Image = null;
        }

        /// <summary>
        /// Adds a given string to the LogList item. 
        /// </summary>
        private void AddToHistory(string Object, bool Red = false)
        {
            if(LogList.Items.Count >= MaxHistory)
            {
                LogList.Items.RemoveAt(4);
            }
            LogList.Items.Insert(0, Object);
            LogList.Items[0].Tag = ActiveStudent.EntryID.ToString();
            if (Red)
            {
                LogList.Items[0].ForeColor = Color.Red;
            }
            LogList.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        #region Main Work Done Here
        /// <summary>
        /// Performs the main verification and resulting functions. 
        /// </summary>
        private void OnEnterKey(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter || e.KeyCode == Keys.Return)
            {
                if (EntryList.SelectedIndex == -1)
                {
                    return;
                }
                //textBox1.SelectAll();
                //Main Verification Done Here
                if (v.Response.Status == Main.Validation.Valid)
                {
                    string obj = String.Format("[+]{0}::{1} - {2} {3}", DateTime.Now, ActiveStudent.EntryID.ToString(), ActiveStudent.NameFirst, ActiveStudent.NameLast);
                    EntryMeal m = (EntryMeal)v.Response.ValidatedObject;
                    if (m.MealPlan.IsPunchCard)
                    {
                        MiscForms.NumberMealsQuantity q = new MiscForms.NumberMealsQuantity();
                        q.CurrentMealCount = m.NumberOfMeals;
                        q.SetMaxCount(m.NumberOfMeals);
                        DialogResult r = q.ShowDialog();
                        if (r == DialogResult.OK)
                        {
                            Debug.WriteLine(String.Format("Count: {0}", q.Count));
                            if (MainSettings.Default.CommitMeals)
                            {
                                DatabaseAccess.ModifyMealValue(m, q.Count);
                                for (int i = 1; i <= q.Count; i++)
                                {
                                    MealDatabaseAccess.LogMealWithoutCheck(m.EntryID, m.Parent.Name, m.MealPlan.Description, BuildingSetting, HelperFunctions.GetMealPeriod().ToString());
                                }
                                string punches = (q.Count > 1) ? String.Format("{0} punches", q.Count) : "1 punch";
                                obj = obj.Insert(0, punches + " - ");
                            }
                        }
                        else if(r == DialogResult.Cancel)
                        {
                            return;
                        }
                    }
                    else if (m.MealPlan.IsNumberPerMeal)
                    {
                        Tropicana.Cafe.Main.ValidationActions.ValidationAction.NumberPerMealAction(v, BuildingSetting);
                    }
                    else
                    {
                        if (MainSettings.Default.CommitMeals)
                        {
                            DatabaseAccess.ModifyMealValue(m);
                            MealDatabaseAccess.LogMeal(m.EntryID, m.Parent.Name, m.MealPlan.Description, BuildingSetting, HelperFunctions.GetMealPeriod().ToString());
                        }
                    }
                    //Refresh Validated Object
                    string EntryID = m.EntryID.ToString();
                    textBox1.Text = EntryID;
                    textBox1.SelectAll();
                    AddToHistory(obj);
                    Debug.WriteLine("Meal logged here.");
                    if (m.MealPlan.IsPunchCard || m.MealPlan.IsAllowance)
                    {
                        if(m.Balance <= 0)
                        {
                            v = new MealValidator(m);
                            pictureBox2.BackColor = RemainingCountLabel.BackColor = Color.Red;
                        }
                        RemainingCountLabel.Text = m.Balance.ToString("D2");
                    }
                    else
                    {
                        RemainingCountLabel.Text = "";
                    }
                }
                else
                {
                    Debug.WriteLine(String.Format("Invalid Reason: {0}", v.Response.ValidationMessage));
                    string obj = String.Format("[-]{0}::{1} {2} {3} - {4}", DateTime.Now, ActiveStudent.EntryID.ToString(), ActiveStudent.NameFirst, ActiveStudent.NameLast, v.Response.ValidationMessage);
                    AddToHistory(obj, true);
                    if(ActiveStudent.ActiveMeal != null)
                    {
                        MealDatabaseAccess.LogMeal(ActiveStudent.EntryID, ActiveStudent.Name, ActiveStudent.ActiveMeal.MealPlan.Description, BuildingSetting, HelperFunctions.GetMealPeriod().ToString(), v.Response.ValidationMessage);
                        Debug.WriteLine("Logged an attempt.");
                    }
                    Debug.WriteLine("Nothing logged.");
                }
                e.Handled = true;
                e.SuppressKeyPress = true;
                textBox1.SelectAll();
            }
            OnUpOrDown(sender, e);
            WaitTimer.Stop();
            WaitTimer.Start();
        }
#endregion

        private void OnUpOrDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Up)
            {
                if(EntryList.SelectedIndex != 0 && EntryList.SelectedIndex != -1)
                {
                    EntryList.SelectedIndex--;
                }
            }
            else if(e.KeyCode == Keys.Down)
            {
                if (EntryList.SelectedIndex != (EntryList.Items.Count-1) && EntryList.SelectedIndex != -1)
                {
                    EntryList.SelectedIndex++;
                }
            }
        }

#region Click Functions
        /// <summary>
        /// Show log list context menu.
        /// </summary>
        private void LogList_MouseClick(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Right)
            {
                if(LogList.FocusedItem.Bounds.Contains(e.Location) == true)
                {
                    LogListContextMenu.Show(Cursor.Position);
                }
            }
        }

        /// <summary>
        /// Shows a MessageBox which displays the LogListItem in full. 
        /// </summary>
        private void showMessageMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(LogList.FocusedItem.Text, "Message");
        }

        /// <summary>
        /// Shows the selected LogListItem Entry photo in the PictureBox. 
        /// </summary>
        private void showPhotoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClearPhoto();
            DataTable dt = DatabaseAccess.GetByID(int.Parse(LogList.FocusedItem.Tag.ToString()));
            ActiveStudent = dt.ToList<TropStudent>()[0];
            SetPhoto();
        }


        /// <summary>
        /// Will contain settings form. Currently used for testing reports/functions. 
        /// </summary>
        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Settings.RestrictedForm f = new Settings.RestrictedForm();
            if(f.ShowDialog() == DialogResult.OK)
            {
                Settings.MealPlanSettings m = new Settings.MealPlanSettings();
                m.Show();
            }
        }

        /// <summary>
        /// Shows the Hourly Report Viewer.
        /// </summary>
        private void hourlyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.AppStarting;
            Forms.Reports.MealPeriodReport viewer = new Reports.MealPeriodReport();
            viewer.Show();
            this.Cursor = Cursors.Default;
        }

        private void halfhourlyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.AppStarting;
            Forms.Reports.HalfHourReportForm viewer = new Reports.HalfHourReportForm();
            viewer.Show();
            this.Cursor = Cursors.Default;
        }

        /// <summary>
        /// Shows the MealPeriod Report
        /// </summary>
        private void byMealToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.AppStarting;
            Forms.Reports.MealPeriodReport viewer = new Reports.MealPeriodReport("MealPeriods");
            viewer.Show();
            this.Cursor = Cursors.Default;
        }

        /// <summary>
        /// Reverses the selected LogListItem Entry meal. 
        /// </summary>
        private void reverseEntryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!MainSettings.Default.CommitMeals)
            {
                MessageBox.Show("Cannot reverse entries with CommitMeals disabled.");
                return;
            }
            if (LogList.FocusedItem.Text.StartsWith("[-]"))
            {
                MessageBox.Show("Cannot reverse unsuccessful entries.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            /*if (ActiveStudent.ActiveMeal.MealPlan.IsNumberPerMeal)
            {
                MessageBox.Show("Cannot reverse Continental breakfast entries. Please take a note and report this issue.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }*/
            DialogResult result = MessageBox.Show("Are you sure you want to reverse this entry?", "Confirmation", MessageBoxButtons.OKCancel);
            
            if(result == DialogResult.OK)
            {
                //If punch card plan, ask how many. Else just reverse by one. 
                int count = 1;
                int EntryID = int.Parse(LogList.FocusedItem.Tag.ToString());
                TropStudent s = new TropStudent(EntryID);
                if (s.ActiveMeal.MealPlan.IsPunchCard)
                {
                    MiscForms.NumberMealsQuantity q = new MiscForms.NumberMealsQuantity();
                    q.CurrentMealCount = s.ActiveMeal.Balance;
                    DialogResult r = q.ShowDialog();
                    if(r == DialogResult.OK)
                    {
                        count = q.Count;
                    }
                    else if(r == DialogResult.Cancel)
                    {
                        return;
                    }
                }
                for(int i = 1; i <= count; i++)
                {
                    DatabaseAccess.ReverseEntryMeal(EntryID);
                }
                //TODO: Reverse the entry - Add "Reversed" to beginning of list item
                //TODO: Credit NumberMeals/Allowance Plans
                string newText = String.Format("REV[{0}]-",count)+LogList.FocusedItem.Text;
                LogList.FocusedItem.Text = newText;
                //ShowMealCount(EntryID);
                EntryList_SelectedIndexChanged(null, null);
            }
        }


#endregion

        private void ShowMealCount(int EntryID)
        {
            TropStudent stu = new TropStudent(EntryID);
            if (stu.ActiveMeal != null && Globals.COUNTEDMEALPLANS.Contains(stu.ActiveMeal.MealPlan.MealSetup))
            {
                RemainingCountLabel.Text = stu.ActiveMeal.Balance.ToString("D2");
            }
            else
            {
                RemainingCountLabel.Text = "N/A";
            }

        }

        private void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult r = MessageBox.Show("Are you sure you want to quit?", "Quitting...", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if(r == DialogResult.Cancel)
            {
                e.Cancel = true;
            }
        }

        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Settings.RestrictedForm f = new Settings.RestrictedForm();
            if (f.ShowDialog() == DialogResult.OK)
            {
                MiscForms.EntryMealDetails m = new MiscForms.EntryMealDetails(ActiveStudent);
                m.Show();
            }
        }


        private void FakeEnter()
        {
            KeyEventArgs e = new KeyEventArgs(Keys.Return);
            OnEnterKey(null, e);
        }

        private void mealPeriodsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Settings.RestrictedForm f = new Settings.RestrictedForm();
            if (f.ShowDialog() == DialogResult.OK)
            {
                MiscForms.MPEditor m = new MiscForms.MPEditor();
                m.Show();
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox1 a = new AboutBox1();
            a.Show();
        }

        private void checkForUpdatesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InstallUpdateSyncWithInfo();
        }

        private void InstallUpdateSyncWithInfo()
        {
            UpdateCheckInfo info = null;

            //if (ApplicationDeployment.IsNetworkDeployed)
            if(true)
            {
                ApplicationDeployment ad = ApplicationDeployment.CurrentDeployment;

                try
                {
                    info = ad.CheckForDetailedUpdate();

                }
                catch (DeploymentDownloadException dde)
                {
                    MessageBox.Show("The new version of the application cannot be downloaded at this time. \n\nPlease check your network connection, or try again later. Error: " + dde.Message);
                    return;
                }
                catch (InvalidDeploymentException ide)
                {
                    MessageBox.Show("Cannot check for a new version of the application. The ClickOnce deployment is corrupt. Please redeploy the application and try again. Error: " + ide.Message);
                    return;
                }
                catch (InvalidOperationException ioe)
                {
                    MessageBox.Show("This application cannot be updated. It is likely not a ClickOnce application. Error: " + ioe.Message);
                    return;
                }

                if (info.UpdateAvailable)
                {
                    Boolean doUpdate = true;

                    if (!info.IsUpdateRequired)
                    {
                        DialogResult dr = MessageBox.Show("An update is available. Would you like to update the application now?", "Update Available", MessageBoxButtons.OKCancel);
                        if (!(DialogResult.OK == dr))
                        {
                            doUpdate = false;
                        }
                    }
                    else
                    {
                        // Display a message that the app MUST reboot. Display the minimum required version.
                        MessageBox.Show("This application has detected a mandatory update from your current " +
                            "version to version " + info.MinimumRequiredVersion.ToString() +
                            ". The application will now install the update and restart.",
                            "Update Available", MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                    }

                    if (doUpdate)
                    {
                        try
                        {
                            ad.Update();
                            MessageBox.Show("The application has been upgraded, and will now restart.");
                            Application.Restart();
                        }
                        catch (DeploymentDownloadException dde)
                        {
                            MessageBox.Show("Cannot install the latest version of the application. \n\nPlease check your network connection, or try again later. Error: " + dde);
                            return;
                        }
                    }
                }
            }
        }

        private void individualMealsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reports.UserReport r = new Reports.UserReport(ActiveStudent);
            r.Show();
        }

        private void byMealPlanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.AppStarting;
            Forms.Reports.MealPeriodReport viewer = new Reports.MealPeriodReport("MealPlan");
            viewer.Show();
            this.Cursor = Cursors.Default;
        }
    }
}
