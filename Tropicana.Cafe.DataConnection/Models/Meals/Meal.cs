using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tropicana.Cafe.Main.Models.Meals
{
    public class Meal
    {
        public int RecordNo { get; set; }

        public int EntryID { get; set; }

        public DateTime Time { get; set; }

        public string MealPlan { get; set; }

        public DateTime? Time2 { get; set; }

        public string MealPeriod { get; set; }

        public string Building { get; set; }

        public void Commit()
        {

        }

        public Meal()
        {

        }

        public Meal(int EntryID, string MealPeriod, string MealPlan, string Building)
        {
            this.EntryID = EntryID;
            this.Time = DateTime.Now;
            this.Time2 = DateTime.Now;
            this.MealPeriod = MealPeriod;
            this.MealPlan = MealPlan;
            this.Building = Building;
        }

    }

}
