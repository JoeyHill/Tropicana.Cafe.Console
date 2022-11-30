using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tropicana.Cafe.Main.Models.Meals
{
    public class Attempts
    {
        public int RecordNo { get; set; }

        public int EntryID { get; set; }

        public string MealPlan { get; set; }

        public DateTime? Time { get; set; }

        public string MealPeriod { get; set; }

        public string Building { get; set; }

        public string Reason { get; set; }

    }
}
