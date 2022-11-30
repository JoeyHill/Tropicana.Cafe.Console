using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Data;
using Tropicana.Cafe.Main.Models;
using System.Drawing;
using System.IO;
using Tropicana.Cafe.Main.Extensions;


namespace Tropicana.Cafe.Main.Data
{
    public class DatabaseAccess
    {
        //private const string _dbString = "Server=starrez;Initial Catalog=snRez1_Main;User ID=remote;Password=Srez4dm1n;";

        private static SqlConnectionStringBuilder b = new SqlConnectionStringBuilder();

        private static string _dbString
        {
            get
            {
                b.DataSource = Main.Settings.MainSettings.Default.StuServer;
                b.InitialCatalog = Main.Settings.MainSettings.Default.StuDB;
                b.UserID = Main.Settings.MainSettings.Default.StuUser;
                b.Password = Main.Settings.MainSettings.Default.StuPass;
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
                catch(Exception e)
                {
                    return false;
                }
            }
        }

        private static DataTable Get(SqlCommand cmd)
        {
            using (SqlConnection con = new SqlConnection(_dbString))
            {
                cmd.Connection = con;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        /// <summary>
        /// Get an Entry with a given EntryID.
        /// </summary>
        /// <param name="EntryID"></param>
        /// <returns></returns>
        public static DataTable GetByID(int EntryID)
        {
            SqlCommand cmd = new SqlCommand("Select * from Entry WHERE EntryID = @EntryID;");
            cmd.Parameters.AddWithValue("@EntryID", EntryID);
            return Get(cmd);
        }

        /// <summary>
        /// Get a Table based on a Column and its Value
        /// </summary>
        /// <param name="TableName"></param>
        /// <param name="KeyColumn"></param>
        /// <param name="KeyID"></param>
        /// <returns></returns>
        public static DataTable GetTableWithID(string TableName, string KeyColumn, int KeyID)
        {
            if(TableName.Contains(" ") || TableName.Contains(";"))
            {
                throw new Exception("TableName was inappropriate.");
            }
            if(KeyColumn.Contains(" ") || KeyColumn.Contains(";"))
            {
                throw new Exception("ColumnName was inappropriate.");
            }
            string commandText = String.Format("Select * from {0} WHERE {1} = @ID;", TableName, KeyColumn);
            SqlCommand cmd = new SqlCommand(commandText.ToString());
            cmd.Parameters.AddWithValue("@ID", KeyID.ToString());
            

            return Get(cmd);
        }

        /// <summary>
        /// Gets the related records from a table that includes an EntryID. E.g. "Booking", "EntryMeal", etc.
        /// </summary>
        /// <param name="TableName"></param>
        /// <param name="EntryID"></param>
        /// <returns></returns>
        public static DataTable GetEntryRelatedRecords(string TableName, int EntryID)
        {
            if (TableName.Contains(" ") || TableName.Contains(";"))
            {
                throw new Exception("TableName was inappropriate.");
            }
            string commandText = String.Format("Select * from {0} WHERE EntryID = @ID;", TableName);
            SqlCommand cmd = new SqlCommand(commandText.ToString());
            cmd.Parameters.AddWithValue("@ID", EntryID.ToString());


            return Get(cmd);
        }

        /// <summary>
        /// Updates the number of meals on a given meal plan. Only one field is updated. 
        /// </summary>
        /// <param name="EntryMealID">The EntryMealPlanID of the Active Meal Plan to update.</param>
        public static void ModifyMealValue(EntryMeal meal, bool IsReversal = false)
        {
            
            using (SqlConnection con = new SqlConnection(_dbString))
            {
                int newCount = 0;
                switch (meal.MealPlan.MealSetup)
                {
                    case MealSetupEnum.Allowance:
                        newCount = (IsReversal) ? (int)meal.AllowanceAInitial + 1 : (int)meal.AllowanceAInitial - 1;
                        break;
                    case MealSetupEnum.NumberMeals:
                    case MealSetupEnum.NumberPerMeal:
                        newCount = (IsReversal) ? (int)meal.NumberOfMeals + 1 : (int)meal.NumberOfMeals - 1;
                        break;
                    default:
                        newCount = 0;
                        break;
                }
                SqlCommand cmd = new SqlCommand("UPDATE EntryMeal SET NumberOfMeals = @Number, AllowanceAInitial = @Number WHERE EntryMealID = @ID");
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("@Number", newCount);
                cmd.Parameters.AddWithValue("@ID", meal.EntryMealID);
                try
                {
                    con.Open();
                    if (!Globals.TESTINGMODE)
                    {
                        cmd.ExecuteNonQuery();
                    }
                    con.Close();
                    meal.AllowanceAInitial = newCount;
                    meal.NumberOfMeals = (short)newCount;
                }
                catch (Exception e)
                {
                    throw new Exception(e.Message);
                }
            }
        }

        /// <summary>
        /// Updates the number of meals on a given meal plan by adding/subtracting the given count. Only one field is updated. 
        /// </summary>
        /// <param name="EntryMealID">The EntryMealPlanID of the Active Meal Plan to update.</param>
        public static void ModifyMealValue(EntryMeal meal, int Count, bool IsReversal = false)
        {

            using (SqlConnection con = new SqlConnection(_dbString))
            {
                int newCount = 0;
                switch (meal.MealPlan.MealSetup)
                {
                    case MealSetupEnum.Allowance:
                        newCount = (IsReversal) ? (int)meal.AllowanceAInitial + Count : (int)meal.AllowanceAInitial - Count;
                        break;
                    case MealSetupEnum.NumberMeals:
                    case MealSetupEnum.NumberPerMeal:
                        newCount = (IsReversal) ? (int)meal.NumberOfMeals + Count : (int)meal.NumberOfMeals - Count;
                        break;
                    default:
                        newCount = 0;
                        break;
                }
                SqlCommand cmd = new SqlCommand("UPDATE EntryMeal SET NumberOfMeals = @Number, AllowanceAInitial = @Number WHERE EntryMealID = @ID");
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("@Number", newCount);
                cmd.Parameters.AddWithValue("@ID", meal.EntryMealID);
                try
                {
                    con.Open();
                    if (!Globals.TESTINGMODE)
                    {
                        cmd.ExecuteNonQuery();
                    }
                    con.Close();
                    meal.AllowanceAInitial = newCount;
                    meal.NumberOfMeals = (short)newCount;
                }
                catch (Exception e)
                {
                    throw new Exception(e.Message);
                }
            }
        }


        /// <summary>
        /// Resets the EntryMeal to the NumberOfMeals on the associated MealPlan. 
        /// </summary>
        /// <param name="EntryMealID"></param>
        public static void ResetMeals(EntryMeal meal)
        {
            int EntryMealID = meal.EntryMealID;
            using (SqlConnection con = new SqlConnection(_dbString))
            {
                string commandText = (meal.MealPlan.MealSetup == MealSetupEnum.Allowance) ?
                    "UPDATE EntryMeal SET EntryMeal.AllowanceAInitial = MealPlan.AllowanceA, EntryMeal.DateChargedTo = @NewDate FROM EntryMeal JOIN MealPlan ON EntryMeal.MealPlanID = MealPlan.MealPlanID WHERE EntryMeal.EntryMealID = @ID" :
                    "UPDATE EntryMeal SET EntryMeal.NumberOfMeals = MealPlan.NumberOfMeals, EntryMeal.DateChargedTo = @NewDate FROM EntryMeal JOIN MealPlan ON EntryMeal.MealPlanID = MealPlan.MealPlanID WHERE EntryMeal.EntryMealID = @ID";
                SqlCommand cmd = new SqlCommand(commandText);
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("@ID", EntryMealID);
                cmd.Parameters.AddWithValue("@NewDate", DateTime.Now.StartOfWeek(Globals.WEEKLYRESET).AddDays(7));
                try
                {
                    con.Open();
                    if (!Globals.TESTINGMODE)
                    {
                        cmd.ExecuteNonQuery();
                    }
                    con.Close();
                }
                catch(Exception e)
                {
                    throw e;
                }
                System.Diagnostics.Debug.WriteLine(String.Format("Have reset DateChargeTo to {0}",DateTime.Now.StartOfWeek(Globals.WEEKLYRESET).AddDays(7)));
            }
        }

        /// <summary>
        /// Updates the EntryMeal's value to today's date on the associated MealPlan. 
        /// </summary>
        /// <param name="EntryMealID"></param>
        public static void ResetMealDateOnly(EntryMeal meal, DateTime? date = null)
        {
            int EntryMealID = meal.EntryMealID;
            using (SqlConnection con = new SqlConnection(_dbString))
            {
                DateTime newDate = date ?? DateTime.Today.AtMidnight();
                string commandText =
                    "UPDATE EntryMeal SET EntryMeal.DateChargedTo = @NewDate FROM EntryMeal WHERE EntryMeal.EntryMealID = @ID";
                SqlCommand cmd = new SqlCommand(commandText);
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("@ID", EntryMealID);
                cmd.Parameters.AddWithValue("@NewDate", newDate);
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
                    throw e;
                }
                System.Diagnostics.Debug.WriteLine(String.Format("Have reset DateChargeTo to {0}", DateTime.Now.StartOfWeek(Globals.WEEKLYRESET).AddDays(7)));
            }
        }

        public static Dictionary<int, string> GetSimpleEntry(int EntryID)
        {
            Dictionary<int, string> result = new Dictionary<int, string>();
            string commandText = String.Format("Select DISTINCT TOP 50 Entry.EntryID, Entry.NameFirst, Entry.NameLast FROM Entry JOIN EntryMeal ON Entry.EntryID = EntryMeal.EntryID AND EntryMeal.DateEnd > DATEADD(d, -15, GETDATE()) WHERE Entry.EntryID = @EntryID;");
            SqlCommand cmd = new SqlCommand(commandText);
            cmd.Parameters.AddWithValue("@EntryID", EntryID);
            DataTable dt = Get(cmd);
            foreach(DataRow row in dt.Rows)
            {
                string name = String.Format("{0} - {1} {2}", row["EntryID"].ToString(), row["NameFirst"].ToString(), row["NameLast"].ToString());
                result.Add((int)row["EntryID"], name);
            }
            return result;
        }

        public static Dictionary<int, string> GetSimpleEntry(string LastName)
        {
            Dictionary<int, string> result = new Dictionary<int, string>();
            string commandText = String.Format("Select DISTINCT TOP 50 Entry.EntryID, Entry.NameFirst, Entry.NameLast FROM Entry JOIN EntryMeal ON Entry.EntryID = EntryMeal.EntryID AND EntryMeal.DateEnd > DATEADD(d, -15, GETDATE()) WHERE Entry.NameLast LIKE '%'+@LastName+'%';");
            SqlCommand cmd = new SqlCommand(commandText);
            cmd.Parameters.AddWithValue("@LastName", LastName);
            DataTable dt = Get(cmd);
            foreach(DataRow row in dt.Rows)
            {
                string name = String.Format("{0} - {1} {2}", row["EntryID"].ToString(), row["NameFirst"].ToString(), row["NameLast"].ToString());
                result.Add((int)row["EntryID"], name);
            }
            return result;
        }

        public static Image GetPhoto(int EntryID)
        {
            using (SqlConnection con = new SqlConnection(_dbString))
            {
                string commandText = String.Format("SELECT PhotoImage From EntryDetail WHERE EntryID = @EntryID;");
                SqlCommand cmd = new SqlCommand(commandText, con);
                cmd.Parameters.AddWithValue("@EntryID", EntryID);
                object myObject = null;
                try
                {
                    con.Open();
                    myObject = (object)cmd.ExecuteScalar();
                }
                catch(Exception e)
                {
                    return null;
                }
                
                if(!(myObject is DBNull ) && myObject != null)
                {
                    byte[] imgData = (byte[])myObject;
                    MemoryStream ms = new MemoryStream(imgData);
                    Image pic = Image.FromStream(ms);
                    ms.Dispose();
                    return pic;
                }
                else
                {
                    //return blank image or error?
                    return null;
                }
                
            }
        }

        public static DataTable GetStandardMeals()
        {
            using (SqlConnection con = new SqlConnection(_dbString))
            {
                SqlCommand cmd = new SqlCommand("select MealPlan.MealPlanID, MealPlan.Description, MealPlan.DateStart, MealPlan.DateEnd, MealPlan.Active from MealPlan FULL OUTER JOIN GroupMealPlan ON GroupMealPlan.MealPlanID = MealPlan.MealPlanID FULL OUTER JOIN EventMealPlan ON EventMealPlan.MealPlanID = MealPlan.MealPlanID WHERE GroupMealPlan.GroupMealPlanID IS NULL AND EventMealPlan.EventMealPlanID IS NULL AND MealPlan.MealPlanID <> 0;");
                cmd.Connection = con;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        public static void ReverseEntryMeal(int EntryID)
        {
            TropStudent Student = new TropStudent(EntryID);
            Models.Meals.Meal m = MealDatabaseAccess.GetMostRecentMeal(Student.EntryID);
            int r = m.RecordNo;
            EntryMeal em = Student.ActiveMeal;
            if (r != 0)
            {
                MealDatabaseAccess.RemoveMeal(r);
                if (em.MealPlan.IsNumberPerMeal)
                {
                    ResetMealDateOnly(em, DateTime.Today.AddDays(-1));
                }
                else
                {
                    ModifyMealValue(em, true);
                }
            }
            System.Diagnostics.Debug.WriteLine(r.ToString() + " - " + Student.EntryID);
        }

        public static string GetRoomSpaceDescription(int RoomSpaceID)
        {
            string result = "No Room Space Description";
            using (SqlConnection con = new SqlConnection(_dbString))
            {
                SqlCommand cmd = new SqlCommand("SELECT Description FROM RoomSpace WHERE RoomSpaceID = @ID;", con);
                cmd.Parameters.AddWithValue("@ID", RoomSpaceID);
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

        public static object GetCustomField(int EntryID, int CustomFieldDefinitionID)
        {
            string sql = "SELECT * FROM EntryCustomField WHERE CustomFieldDefinitionID = @CustomID AND EntryID = @EntryID;";            
            using (SqlConnection con = new SqlConnection(_dbString))
            {
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@EntryID", EntryID);
                cmd.Parameters.AddWithValue("@CustomID", CustomFieldDefinitionID);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                try
                {
                    da.Fill(dt);
                }
                catch(Exception e)
                {
                    return null;
                }
                if(dt.Rows.Count < 1)
                {
                    return null;
                }
                else
                {
                    string t = dt.Rows[0]["FieldDataTypeEnum"].ToString();
                    switch (t)
                    {
                        default:
                        case "0":
                        case "1":
                            return dt.Rows[0]["ValueString"].ToString();
                        case "2":
                        case "3":
                            return (DateTime)dt.Rows[0]["ValueDate"];
                        case "4":
                            return (bool)dt.Rows[0]["ValueBoolean"];
                        case "5":
                            return (int)dt.Rows[0]["ValueInteger"];
                        case "6":
                            return (double)dt.Rows[0]["ValueMoney"];
                            

                    }
                }
            }
        }
    }
}
