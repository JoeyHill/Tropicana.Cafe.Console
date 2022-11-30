using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tropicana.Cafe.Main.Data;
using Tropicana.Cafe.Main.Models.Meals;
using Tropicana.Cafe.Main.Validators;


namespace Tropicana.Cafe.Forms.Logic
{
    public static class Function
    {
        /// <summary>
        /// Checks whether the most recent meal for an Entry is within the Time specified in the settings (Default: 5 minutes).
        /// </summary>
        /// <param name="EntryID"></param>
        /// <returns></returns>
        public static bool IsDoubleEntry(int EntryID)
        {
            int Time = 5;
            TimeSpan ts = new TimeSpan(0, Time, 0);
            DateTime t = DateTime.Now.Subtract(ts);
            Meal m = MealDatabaseAccess.GetMostRecentMeal(EntryID);
            if(DateTime.Compare(m.Time, t) >= 0)
            {
                return true;
            }
            return false;
        }
        
        //Alert for remaining meals
        //Override warning
    }
}
