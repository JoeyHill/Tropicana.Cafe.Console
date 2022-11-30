using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tropicana.Cafe.Main.Models;
using Tropicana.Cafe.Main.Rules;
using Tropicana.Cafe.Main.Extensions;
using System.Diagnostics;

namespace Tropicana.Cafe.Main.Validators
{
    /// <summary>
    /// Tests an entry meal for its validity. 
    /// </summary>
    public class MealValidator
    {
        public ValidationResponse Response;
        public MealValidator(EntryMeal meal)
        {
            
            if (meal != null && meal.Parent.HasValidMeals)
            {
                Response = FuncLookup[meal.MealPlan.MealSetup](meal);
            }
            else
            {
                Response = new ValidationResponse(false, Globals.NOVALIDMEAL, meal);
            }
        }

        public MealValidator(EntryMeal meal, string DiningHall)
        {
            int hall = Globals.DININGHALL(DiningHall);
            if(meal.MealPlan.MealPlanDiningHallID != 0 && meal.MealPlan.MealPlanDiningHallID != hall)
            {
                Response = new ValidationResponse(false, Globals.BADHALL, meal);
                return;
            }

            if (meal != null && meal.Parent.HasValidMeals)
            {
                Response = FuncLookup[meal.MealPlan.MealSetup](meal);
            }
            else
            {
                Response = new ValidationResponse(false, Globals.NOVALIDMEAL, meal);
            }
        }

        private Dictionary<MealSetupEnum, Func<EntryMeal, ValidationResponse>> FuncLookup = new Dictionary<MealSetupEnum, Func<EntryMeal, ValidationResponse>>()
        {
            { MealSetupEnum.SinglePlan, SinglePlanValidation },
            { MealSetupEnum.NumberMeals, NumberMealsValidation },
            { MealSetupEnum.NumberPerMeal, NumberPerMealValidation },
            { MealSetupEnum.Allowance, AllowanceValidation },
            { MealSetupEnum.AdHoc, AdHocValidation },
            { MealSetupEnum.WeeklyPlan, WeeklyValidation },
            { MealSetupEnum.AdHocAdjustable, AdHocAdjustableValidation }
        };

        /// <summary>
        /// Checks a SinglePlan validity as well as Hold validity.
        /// </summary>
        /// <param name="meal"></param>
        /// <returns></returns>
        private static ValidationResponse SinglePlanValidation(EntryMeal meal)
        {
            if (Settings.MainSettings.Default.RestrictToBuilding)
            {
                string Building = Globals.RoomLocation[meal.Parent.ActiveBooking.RoomLocationID];
                if(Building != Settings.MainSettings.Default.Building)
                {
                    return new ValidationResponse(false, Globals.BADHALL, meal);
                }
            }
            List<EntryCustomField> cf = meal.Parent.CustomFields;
            EntryCustomField hold = cf.Where(c => c.CustomFieldDefinitionID == 44).FirstOrDefault();
            EntryCustomField reason = cf.Where(c => c.CustomFieldDefinitionID == 77).FirstOrDefault();

            //Check the Free Periods.
            foreach(MealPlanFree free in meal.MealPlan.FreePeriods)
            {
                if(DateTime.Now.IsBetween(free.DateStart, free.DateEnd))
                {
                    return new ValidationResponse(false, Globals.FREEPERIOD, meal);
                }
            }

            
            //Check the Hold
            if (hold.ValueBoolean)
            {
                string msg = String.Format("{0}:{1}", Globals.ADMINNOTICE, reason.ValueString);
                return new ValidationResponse(false, msg, meal);
            }

            //Check the InRoom status
            if(InRoomValidation(meal).Status == Validation.Invalid)
            {
                return InRoomValidation(meal);
            }

            //Check the Dates
            if (MealRules.MealPlanDatesAreValid(meal))
            {
                if (MealRules.isValidStatus(meal))
                {
                    return new ValidationResponse(true, meal);
                }
                return new ValidationResponse(false, Globals.INVALIDMEALSTATUS, meal);
            }
            else
            {
                return new ValidationResponse(false, Globals.INVALIDMEALDATES, meal);
            }            
        }

        /// <summary>
        /// Checks whether the meal has already been used. 
        /// </summary>
        private static ValidationResponse MealUseValidation(EntryMeal meal)
        {
            if (meal.MealHasBeenUsed())
            {
                return new ValidationResponse(false, Globals.ALREADYUSED, meal);
            }
            else { return new ValidationResponse(true, meal); }
        }


        /// <summary>
        /// NumberMeals is the limited number, like punch card. 
        /// </summary>
        /// <param name="meal"></param>
        /// <returns></returns>
        private static ValidationResponse NumberMealsValidation(EntryMeal meal)
        {
            //Verify Dates and Status
            if(SinglePlanValidation(meal).Status == Validation.Invalid)
            {
                return SinglePlanValidation(meal);
            }
            if(meal.NumberOfMeals > 0 || meal.AllowanceAInitial > 0)
            {
                return new ValidationResponse(true, meal);
            }
            else
            {
                return new ValidationResponse(false, Globals.ZEROBALANCE, meal);
            }
        }

        private static ValidationResponse NumberPerMealValidation(EntryMeal meal)
        {
            if(SinglePlanValidation(meal).Status == Validation.Invalid)
            {
                return SinglePlanValidation(meal);
            }
            int mealPeriod = 0;
            switch (HelperFunctions.GetMealPeriod())
            {
                case BasicMealPeriods.Breakfast:
                    mealPeriod = meal.Breakfast;
                    break;
                case BasicMealPeriods.Lunch:
                    mealPeriod = meal.Lunch;
                    break;
                case BasicMealPeriods.Dinner:
                    mealPeriod = meal.Dinner;
                    break;
                default:
                    mealPeriod = meal.Breakfast;
                    break;
            }
            if(mealPeriod > 0 && meal.DateChargedTo < DateTime.Today.AtMidnight())
            {
                return new ValidationResponse(true, meal);
            }
            else
            {
                return new ValidationResponse(false, Globals.NUMBERMEALS_ZERO, meal);
            }
        }
        
        private static ValidationResponse AdHocValidation(EntryMeal meal)
        {
            //Verify Dates and Status
            if (SinglePlanValidation(meal).Status == Validation.Invalid)
            {
                return SinglePlanValidation(meal);
            }
            if(MealUseValidation(meal).Status == Validation.Invalid)
            {
                if (Main.Settings.MainSettings.Default.EnforceSingleMeal)
                {
                    return MealUseValidation(meal);
                }
            }
            if (MealRules.AdHocMealIsValid(meal.EntryMealPlanDetails))
            {
                return new ValidationResponse(true, meal);
            }
            return new ValidationResponse(false, Globals.MEALNOTALLOWED, meal);
        }

        private static ValidationResponse WeeklyValidation(EntryMeal meal)
        {
            //Verify Dates and Status
            TropStudent student = meal.Parent;
            if (SinglePlanValidation(student.ActiveMeal).Status == Validation.Invalid)
            {
                return SinglePlanValidation(student.ActiveMeal);
            }
            if (Main.Settings.MainSettings.Default.EnforceSingleMeal)
            {
                    if (Main.Settings.MainSettings.Default.EnforceSingleMeal)
                    {
                        return MealUseValidation(meal);
                    }
            }
            int dw = (int)DateTime.Now.DayOfWeek;
            if(student.ActiveBooking != null)
            {
                if (student.ActiveBooking.IsCheckInDay)
                {
                    dw = 7;
                }
                if (student.ActiveBooking.IsCheckOutDay)
                {
                    dw = 8;
                }
            }
            else
            {
                if(student.Details.DateEntry == DateTime.Now.Date)
                {
                    dw = 7;
                }
                if(student.Details.DateExit == DateTime.Now.Date)
                {
                    dw = 8;
                }
            }


            if (MealRules.MealIsAllowed(meal, dw, HelperFunctions.GetMealPeriod()))
            {
                return new ValidationResponse(true, meal);
            }
            return new ValidationResponse(false, Globals.MEALNOTALLOWED, meal);
        }

        /// <summary>
        /// Allowance is the Weekly number of meals. E.g. 14 meals/week.
        /// </summary>
        /// <param name="meal"></param>
        /// <returns></returns>
        private static ValidationResponse AllowanceValidation(EntryMeal meal)
        {
            //Run Meal Reset Check
            //if (meal.NeedsReset)
            //{
            //    Debug.WriteLine(String.Format("Meal Reset Date: {0}/n", meal.DateChargedTo.ToShortDateString()));
            //    Debug.WriteLine("Resetting Meals.../n");
            //    Data.DatabaseAccess.ResetMeals(meal);
            //    meal.NumberOfMeals = meal.MealPlan.NumberOfMeals;
            //    meal.AllowanceAInitial = meal.MealPlan.AllowanceA;
            //    Debug.WriteLine("Meal Date Reset./n");
            //}
            //Verify Dates and Status
            if (SinglePlanValidation(meal).Status == Validation.Invalid)
            {
                return SinglePlanValidation(meal);
            }
            if (meal.AllowanceAInitial - meal.AllowanceAUsed > 0)
            {
                //TODO: DebitMeals
                int newCount = (int)meal.AllowanceAInitial - 1;
                int current = (int)meal.AllowanceAInitial;
                Debug.Write(String.Format("Current: {0} New: {1}", current.ToString("D2"), newCount.ToString()));
                //Data.DatabaseAccess.DebitMeal(meal.EntryMealID, newCount);
                return new ValidationResponse(true, meal);
            }
            else
            {
                return new ValidationResponse(false, Globals.ZEROBALANCE, meal);
            }
        }

        private static ValidationResponse AdHocAdjustableValidation(EntryMeal meal)
        {
            TropStudent student = meal.Parent;
            //Verify Dates and Status
            if (SinglePlanValidation(student.ActiveMeal).Status == Validation.Invalid)
            {
                return SinglePlanValidation(student.ActiveMeal);
            }
            if (MealUseValidation(meal).Status == Validation.Invalid)
            {
                if (Main.Settings.MainSettings.Default.EnforceSingleMeal)
                {
                    return MealUseValidation(meal);
                }
            }
            int dw = student.EntryStatusEnum == 5 ? 0 : 99;
            if (student.ActiveBooking.IsCheckInDay)
            {
                dw = 7;
            }
            if (student.ActiveBooking.IsCheckOutDay)
            {
                dw = 8;
            }
            if(MealRules.MealIsAllowed(meal, dw, HelperFunctions.GetMealPeriod()))
            {
                return new ValidationResponse(true, meal);
            }
            return new ValidationResponse(false, Globals.MEALNOTALLOWED, meal);
        }

        private static ValidationResponse InRoomValidation(EntryMeal meal)
        {
            TropStudent student = meal.Parent;
            int[] CheckedInArray = {5, 10, 0, 31, 20};

            if (CheckedInArray.Contains(student.EntryStatusEnum))
            {
                return new ValidationResponse(true, meal);
            }
            else
            {
                return new ValidationResponse(false, Globals.CHECKINREQUIRED, meal);
            }
        }
    }
}
