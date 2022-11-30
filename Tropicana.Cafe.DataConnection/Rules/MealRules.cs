using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tropicana.Cafe.Main.Extensions;
using Tropicana.Cafe.Main.Models;

namespace Tropicana.Cafe.Main.Rules
{
    public static class MealRules
    {
        //Valid Dates
        static Func<EntryMeal, bool> dateStartValid = meal => meal.DateStart <= DateTime.Now;
        static Func<EntryMeal, bool> dateEndValid = meal => meal.DateEnd.AtMidnight(true) >= DateTime.Now.AtMidnight(true);

        public static Func<Booking, bool> isCheckInDay = booking => booking.CheckInDate == DateTime.Today;
        public static Func<Booking, bool> isCheckOutDay = booking => booking.CheckOutDate == DateTime.Today;

        public static Func<Booking, bool> isInRoom = booking => booking.EntryStatusEnum == 5;

        public static Func<EntryMeal, bool> isMealPlanStart = mealplan => mealplan.DateStart == DateTime.Today;
        public static Func<EntryMeal, bool> isMealPlanEnd = mealplan => mealplan.DateEnd == DateTime.Today;

        /// <summary>
        /// Checks whether the MealStatus is Active or Upcoming
        /// </summary>
        public static Func<EntryMeal, bool> isValidStatus = mealplan => mealplan.MealStatus == MealStatus.Active || mealplan.MealStatus == MealStatus.Upcoming;

        /// <summary>
        /// Checks whether the AdHoc MealPlan dates are set on the EntryMeal. Does NOT check the mealplan, looks directly at the EntryMealPlanDetails.
        /// </summary>
        /// <param name="details"></param>
        /// <returns></returns>
        public static bool AdHocMealIsValid(List<EntryMealPlanDetail> details)
        {
            if(details == null)
            {
                return false;
            }
            var today = (from d in details
                         where d.MealPlanDate == DateTime.Today
                         select d).FirstOrDefault();
            if (today != null)
            {
                switch (HelperFunctions.GetMealPeriod(DateTime.Now))
                {
                    case BasicMealPeriods.Breakfast:
                        return Convert.ToBoolean(today.Breakfast);
                    case BasicMealPeriods.Lunch:
                        return Convert.ToBoolean(today.Lunch);
                    case BasicMealPeriods.Dinner:
                        return Convert.ToBoolean(today.Dinner);
                }
            }
            return false;
        }

        /// <summary>
        /// Checks the AdHocAdjustable Meals, only checks against the MealPlan as no EntryMealPlanDetails are created. 
        /// </summary>
        /// <param name="details"></param>
        /// <returns></returns>
        public static bool AdHocAdjustableMealIsValid(TropStudent student)
        {
            //Sunday is InRoomDay
            if (student.ActiveMeal.EntryMealPlanDetails == null)
            {
                return false;
            }
            int dayofweek = 0;
            if (MealRules.isCheckInDay(student.ActiveBooking))
            {
                dayofweek = 7;
            }
            else if (MealRules.isCheckOutDay(student.ActiveBooking))
            {
                dayofweek = 8;
            }

            var today = (from d in student.ActiveMeal.EntryMealPlanDetails
                         where d.DayInWeekEnum == dayofweek
                         select d).FirstOrDefault();

            if (today != null)
            {
                switch (HelperFunctions.GetMealPeriod(DateTime.Now))
                {
                    case BasicMealPeriods.Breakfast:
                        return Convert.ToBoolean(today.Breakfast);
                    case BasicMealPeriods.Lunch:
                        return Convert.ToBoolean(today.Lunch);
                    case BasicMealPeriods.Dinner:
                        return Convert.ToBoolean(today.Dinner);
                }
            }
            return false;
        }


        /// <summary>
        /// Checks whether the EntryMeal's Breakfast, Lunch, or Dinner items are setup appropriately. Do NOT use unless these are set. For typical Single Plans, the dates are the only valid 
        /// criteria by which to verify the mealplan validity. 
        /// </summary>
        /// <param name="meal"></param>
        /// <returns></returns>
        public static bool SinglePlanMealIsValid(EntryMeal meal)
        {
            if(meal == null)
            {
                return false;
            }
            switch (HelperFunctions.GetMealPeriod(DateTime.Now))
            {
                case BasicMealPeriods.Breakfast:
                    return Convert.ToBoolean(meal.Breakfast);
                case BasicMealPeriods.Lunch:
                    return Convert.ToBoolean(meal.Lunch);
                case BasicMealPeriods.Dinner:
                    return Convert.ToBoolean(meal.Dinner);
            }
            return false;
        }

        /// <summary>
        /// Verifies whether the start and end date of a mealplan are outside of today. Checks "<=" and ">=". 
        /// </summary>
        /// <param name="meal"></param>
        /// <returns></returns>
        public static bool MealPlanDatesAreValid(EntryMeal meal)
        {
            if(meal == null)
            {
                return false;
            }
            return dateStartValid(meal) && dateEndValid(meal);
        }

        /// <summary>
        /// Verifies whether a current meal is allowed on an EntryMeal's MealPlanDetails, based on the Date and the Period provided. Checks the EntryMealPlanDetails. 
        /// </summary>
        /// <param name="meal"></param>
        /// <param name="date"></param>
        /// <param name="period"></param>
        /// <returns></returns>
        public static bool MealIsAllowed(this EntryMeal meal, DateTime date, BasicMealPeriods period)
        {
            EntryMealPlanDetail detail = meal.EntryMealPlanDetails.Where(m => m.MealPlanDate == date.Date).First();
            switch (period)
            {
                case BasicMealPeriods.Breakfast:
                    return Convert.ToBoolean(detail.Breakfast);
                case BasicMealPeriods.Lunch:
                    return Convert.ToBoolean(detail.Lunch);
                case BasicMealPeriods.Dinner:
                    return Convert.ToBoolean(detail.Dinner);
            }
            return false;
        }

        /// <summary>
        /// Verifies whether a current meal is allowed on an EntryMeal's MealPlanDetails based on a Day of Week and a Period provided. Checks the EntryMealPlanDetails.
        /// </summary>
        /// <param name="meal"></param>
        /// <param name="dw"></param>
        /// <param name="period"></param>
        /// <returns></returns>
        public static bool MealIsAllowed(this EntryMeal meal, DayOfWeek dw, BasicMealPeriods period)
        {
            MealPlanDetail detail = meal.MealPlan.MealPlanDetails.Where(m => m.DayInWeekEnum == (int)dw).First();
            switch (period)
            {
                case BasicMealPeriods.Breakfast:
                    return Convert.ToBoolean(detail.Breakfast);
                case BasicMealPeriods.Lunch:
                    return Convert.ToBoolean(detail.Lunch);
                case BasicMealPeriods.Dinner:
                    return Convert.ToBoolean(detail.Dinner);
            }
            return false;
        }

        /// <summary>
        /// Verifies whether a current meal is allowed on an EntryMeal's MealPlanDetails based on the integer form of the weekday. Check EntryMealPlanDetails.
        /// </summary>
        /// <param name="meal"></param>
        /// <param name="DayofWeekInt"></param>
        /// <param name="period"></param>
        /// <returns></returns>
        public static bool MealIsAllowed(this EntryMeal meal, int DayofWeekInt, BasicMealPeriods period)
        {
            MealPlanDetail detail = meal.MealPlan.MealPlanDetails.Where(m => m.DayInWeekEnum == DayofWeekInt).First();
            switch (period)
            {
                case BasicMealPeriods.Breakfast:
                    return Convert.ToBoolean(detail.Breakfast);
                case BasicMealPeriods.Lunch:
                    return Convert.ToBoolean(detail.Lunch);
                case BasicMealPeriods.Dinner:
                    return Convert.ToBoolean(detail.Dinner);
            }
            return false;
        }

        /// <summary>
        /// Checks to see whether the meal has been used already within the last Globals.MOSTRECENTCHECKINTERVAL. 
        /// </summary>
        public static bool MealHasBeenUsed(this EntryMeal meal)
        {
            Models.Meals.Meal m = Tropicana.Cafe.Main.Data.MealDatabaseAccess.GetMostRecentMeal(meal.Parent.EntryID);
            DateTime test = DateTime.Now.AddMinutes(Globals.MOSTRECENTMEALTESTINTERVAL * -1);
            return m.Time.IsAfter(test);
        }
    }
}
