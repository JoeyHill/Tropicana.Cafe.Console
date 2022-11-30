using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tropicana.Cafe.Main
{

    public enum Building
    {
        [Description("Tropicana Gardens")]
        TropicanaGardens,
        [Description("Tropicana Del Norte")]
        TropicanaDelNorte
    }

    public enum MealSetupEnum
    {
        NumberMeals,
        NumberPerMeal,
        SinglePlan,
        WeeklyPlan,
        Allowance,
        AdHoc,
        AdHocAdjustable
    }

    public enum MealStatus
    {
        Upcoming,
        Active,
        History,
        Cancelled
    }

    public enum MealPeriods
    {
        Breakfast,
        Continental,
        Lunch,
        Snack,
        Dinner,
        Grill,
        LateNight
    }

    public enum BasicMealPeriods
    {
        Breakfast,
        Lunch,
        Dinner,
        Blank
    }

    public enum Validation
    {
        Valid,
        Invalid
    }

    public enum ErrorType
    {
        StartDate,
        EndDate,
        History,
        MealPeriod,
        MealPlan,
        AccountHold,
        EntryStatus,
        NoMeals,
    }

    public static class ErrorLookup
    {
        public static Dictionary<ErrorType, string> Message = new Dictionary<ErrorType, string>()
    {
        { ErrorType.StartDate, "The START DATE has not yet passed." },
        { ErrorType.EndDate, "The END DATE for this mealplan has already passed." },
        { ErrorType.History, "This entry's meal is in HISTORY status." },
        { ErrorType.MealPeriod, "This MEAL PERIOD is not authorized for this individual." },
        { ErrorType.MealPlan, "This MEAL PLAN is not valid." },
        { ErrorType.AccountHold, "This entry has a HOLD on their account." },
        { ErrorType.EntryStatus, "This entry's STATUS is not approved." },
        { ErrorType.NoMeals, "This entry has NO MEAL PLAN." }
    };
    }

}
