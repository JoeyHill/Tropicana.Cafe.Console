using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tropicana.Cafe.Main;
using Tropicana.Cafe.Main.Extensions;
using Tropicana.Cafe.Main.Models;

namespace Tropicana.Cafe.Main.ValidationActions
{
    public static class ValidationAction
    {
        /// <summary>
        /// This conducts the work required for a NumberPerMeal meal plan type. 
        /// These are used for Short Stay conferences where one Breakfast is included. 
        /// </summary>
        /// <param name="v">Meal Validator object containing the validation.</param>
        public static void NumberPerMealAction(Validators.MealValidator v, string Building = "Tropicana Gardens")
        {
            ///Assume validated
            ///Set DateChargedTo to current Date
            EntryMeal m = (EntryMeal)v.Response.ValidatedObject;
            Data.DatabaseAccess.ResetMealDateOnly(m);
            Data.MealDatabaseAccess.LogMealWithoutCheck(m.EntryID, m.Parent.Name, m.MealPlan.Description, Building, HelperFunctions.GetMealPeriod().ToString());
        }
    }
}
