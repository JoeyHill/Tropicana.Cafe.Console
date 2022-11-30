using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tropicana.Cafe.Main.Models
{
    public class EntryMealPlanDetail
    {
        public int EntryMealPlanDetailID { get; set; }

        public int EntryMealID { get; set; }

        public int DayInWeekEnum { get; set; }

        public DateTime MealPlanDate { get; set; }

        public short Breakfast { get; set; }

        public short Lunch { get; set; }

        public short Dinner { get; set; }

        public short Other { get; set; }

    }
}
