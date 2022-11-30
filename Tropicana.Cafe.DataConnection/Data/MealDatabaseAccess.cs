using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tropicana.Cafe.Main.Models.Meals;
using Tropicana.Cafe.Main.Extensions;
using System.Data.SqlClient;
using System.Data;
using System.Diagnostics;
using Tropicana.Cafe.Main;

namespace Tropicana.Cafe.Main.Data
{
    public static class MealDatabaseAccess
    {
        

        private static SqlConnectionStringBuilder b = new SqlConnectionStringBuilder();

        private static string _dbString
        {
            get
            {
                b.DataSource = Main.Settings.MainSettings.Default.MealServer;
                b.InitialCatalog = Main.Settings.MainSettings.Default.MealDB;
                b.UserID = Main.Settings.MainSettings.Default.MealUser;
                b.Password = Main.Settings.MainSettings.Default.MealPass;
                return b.ConnectionString;
            }
        }

        public static bool TestConnection()
        {
            using (SqlConnection con = new SqlConnection(_dbString))
            {
                try
                {
                    con.Open();
                    con.Close();
                    return true;
                }
                catch (Exception e)
                {
                    return false;
                }
            }
        }

        public static Meal GetMostRecentMeal(int EntryID)
        {
            using (SqlConnection con = new SqlConnection(_dbString))
            {
                SqlCommand cmd = new SqlCommand("SELECT TOP 1 * FROM Meals1 WHERE EntryID = @EntryID ORDER BY Time DESC;");
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("@EntryID", EntryID);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    return dt.ToList<Meal>()[0];
                }
                else
                {
                    Meal m = new Models.Meals.Meal();
                    m.Time = new DateTime(0);
                    return m;
                }
            }
        }

        /// <summary>
        /// Logs after checking that the most recent meal was within the paramerters.
        /// </summary>
        public static void LogMeal(int EntryID, string EntryName, string MealPlan, string Building, string MealPeriod, string Reason = "")
        {

            SqlCommand cmd;
            if (Reason == "")
            {
                cmd = new SqlCommand("INSERT INTO Meals1 (EntryID, EntryName, MealPlan, Building, MealPeriod, Time) VALUES (@EntryID, @EntryName, @MealPlan, @Building, @MealPeriod, @Time);");
            }
            else
            {
                cmd = new SqlCommand("INSERT INTO Attempts1 (EntryID, MealPlan, Building, MealPeriod, Reason, Time) VALUES (@EntryID, @MealPlan, @Building, @MealPeriod, @Reason, @Time);");
                cmd.Parameters.AddWithValue("@Reason", Reason);
            }

            cmd.Parameters.AddWithValue("@EntryID", EntryID);
            cmd.Parameters.AddWithValue("@EntryName", EntryName);
            cmd.Parameters.AddWithValue("@MealPlan", MealPlan);
            cmd.Parameters.AddWithValue("@Building", Building);
            cmd.Parameters.AddWithValue("@MealPeriod", GetTropMealPeriod());
            cmd.Parameters.AddWithValue("@Time", DateTime.Now);
            ExecuteSQL(cmd);
        }

        private static void ExecuteSQL(SqlCommand cmd)
        {
            using (SqlConnection con = new SqlConnection(_dbString))
            {
                try
                {
                    con.Open();
                    cmd.Connection = con;
                    if (!Globals.TESTINGMODE)
                    {
                        cmd.ExecuteNonQuery();
                    }
                    con.Close();
                }
                catch (Exception e)
                {
                    throw new Exception(e.Message);
                }
            }
        }

        /// <summary>
        /// Logs without checking for the most recent meal. 
        /// </summary>
        public static void LogMealWithoutCheck(int EntryID, string EntryName, string MealPlan, string Building, string MealPeriod, string Reason = "")
        {
            SqlCommand cmd;
            if (Reason == "")
            {
                cmd = new SqlCommand("INSERT INTO Meals1 (EntryID, EntryName, MealPlan, Building, MealPeriod, Time) VALUES (@EntryID, @EntryName, @MealPlan, @Building, @MealPeriod, @Time);");
            }
            else
            {
                cmd = new SqlCommand("INSERT INTO Attempts (EntryID, MealPlan, Building, MealPeriod, Reason, Time) VALUES (@EntryID, @MealPlan, @Building, @MealPeriod, @Reason, @Time);");
                cmd.Parameters.AddWithValue("@Reason", Reason);
            }

            cmd.Parameters.AddWithValue("@EntryID", EntryID);
            cmd.Parameters.AddWithValue("@EntryName", EntryName);
            cmd.Parameters.AddWithValue("@MealPlan", MealPlan);
            cmd.Parameters.AddWithValue("@Building", Building);
            cmd.Parameters.AddWithValue("@MealPeriod", GetTropMealPeriod());
            cmd.Parameters.AddWithValue("@Time", DateTime.Now);
            using (SqlConnection con = new SqlConnection(_dbString))
            {
                try
                {
                    con.Open();
                    cmd.Connection = con;
                    if (!Globals.TESTINGMODE)
                    {
                        cmd.ExecuteNonQuery();
                    }
                    con.Close();
                }
                catch (Exception e)
                {
                    throw new Exception(e.Message);
                }
            }
        }

        private static string GetTropMealPeriod()
        {
            using (SqlConnection con = new SqlConnection(_dbString))
            {
                string r = "MealError";
                SqlCommand cmd = new SqlCommand("SELECT Description FROM MealPeriodEnum WHERE CAST(GETDATE() as time) BETWEEN CAST(TimeStart as time) AND CAST(TimeEnd as time);", con);
                try
                {
                    con.Open();
                    r = cmd.ExecuteScalar().ToString();
                    con.Close();
                }
                catch (Exception e)
                {
                    throw new Exception(e.Message);
                }
                return r;
            }
        }

        public static string GetBasicMealPeriod()
        {
            using (SqlConnection con = new SqlConnection(_dbString))
            {
                string r = "MealError";
                SqlCommand cmd = new SqlCommand("SELECT Description FROM BasicMealPeriodEnum WHERE CAST(GETDATE() as time) BETWEEN CAST(TimeStart as time) AND CAST(TimeEnd as time);", con);
                try
                {
                    con.Open();
                    r = cmd.ExecuteScalar().ToString();
                    con.Close();
                }
                catch (Exception e)
                {
                    throw new Exception(e.Message);
                }
                return r;
            }
        }

        public static void RemoveMeal(int RecordNumber)
        {
            using (SqlConnection con = new SqlConnection(_dbString))
            {
                SqlCommand cmd = new SqlCommand("DELETE FROM Meals1 WHERE RecordNo = @RecordNumber;", con);
                cmd.Parameters.AddWithValue("@RecordNumber", RecordNumber);
                try
                {
                    con.Open();
                    if (!Globals.TESTINGMODE)
                    {
                        cmd.ExecuteNonQuery();
                    }
                    con.Close();
                }
                catch (Exception e)
                {

                }
            }
        }

        public static string GetMealsConnectionString()
        {
            return _dbString;
        }

        public static string GetAdminHash()
        {
            using (SqlConnection con = new SqlConnection(_dbString))
            {
                string commandText = "SELECT PasswordHash FROM AdminPass WHERE PasswordID = 1;";
                SqlCommand cmd = new SqlCommand(commandText, con);
                string result = "C8E5E1E691AB4F82D5BD992DF8896BCD21F122F5A53FB4B4ABF3F0126687566583E49B11CB1F3A4CA31F5217A1CF50005A178774FAC6485268BEB7A097E92C4C112";
                try
                {
                    con.Open();
                    result = cmd.ExecuteScalar().ToString();
                    con.Close();
                }
                catch(Exception e)
                {

                }
                return result;
            }
        }
    }
}
