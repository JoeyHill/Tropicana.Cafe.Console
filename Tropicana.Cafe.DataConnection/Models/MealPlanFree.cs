using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tropicana.Cafe.Main.Models
{
    public class MealPlanFree
    {
        public int MealPlanFreeID { get; set; }

        public int RecordTypeEnum { get; set; }

        public int MealPlanID { get; set; }

        public DateTime DateStart { get; set; }

        public DateTime DateEnd { get; set; }

    }
}
