using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tropicana.Cafe.Main
{
    public static class Globals
    {
        public const bool TESTINGMODE = false;

        public const string INVALIDMEALSTATUS = "The mealplan's status was not Active or Upcoming.";
        public const string INVALIDMEALDATES = "The mealplan's dates were not valid.";
        public const string ADMINNOTICE = "The mealplan has been put on hold.";
        public const string MEALNOTALLOWED = "This meal is not allowed on the mealplan.";
        public const string ZEROBALANCE = "This mealplan has reached a zero balance.";
        public const string NOBOOKING = "This entry has no bookings that can be considered active.";
        public const string NOVALIDMEAL = "This entry has no valid mealplans.";
        public const string FREEPERIOD = "This mealplan has been deactivated temporarily based on a free period.";
        public const string ALREADYUSED = "This entry has already used a meal for this period.";

        public const string NUMBERMEALS_ZERO = "This meal plan has reached a zero balance for this period. This is either because the meal is not allowed, or the meal has been used already.";

        public const string BOOKINGREQUIRED = "A Booking is required for this meal setup.";
        public const string CHECKINREQUIRED = "This person has not been checked in.";

        public const string BADHALL = "This meal plan is not authorized for this dining hall.";

        public const int MOSTRECENTMEALTESTINTERVAL = 120;

        public const DayOfWeek WEEKLYRESET = DayOfWeek.Sunday;

        public const int MEALHOLDCUSTOMFIELDID = 140;


        public const string TG_BUILDING = "Tropicana Gardens";
        public const string TDN_BUILDING = "Tropicana Del Norte";

        public static int DININGHALL(string input) {
            switch (input)
            {
                case "Tropicana Gardens":
                    return 1;
                case "Tropicana Del Norte":
                    return 2;
                default:
                    return 0;
            }
        }


        public static readonly MealSetupEnum[] COUNTEDMEALPLANS = { MealSetupEnum.NumberMeals, MealSetupEnum.NumberPerMeal, MealSetupEnum.Allowance };

        public static readonly Dictionary<int, string> RoomLocation = new Dictionary<int, string>()
        {
            { 2, "Tropicana Del Norte" },
            { 3, "Tropicana Villas" },
            { 4, "Tropicana Gardens" },
            { 0, "(Unallocated)" },
            { 6, "Tropicana Summer" }
        };
    }
}
