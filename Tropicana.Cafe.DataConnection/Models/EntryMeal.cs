using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tropicana.Cafe.Main.Extensions;
using System.Data;
using Tropicana.Cafe.Main.Data;

namespace Tropicana.Cafe.Main.Models
{
    public class EntryMeal
    {

        public int EntryMealID { get; set; }

        public int EntryID { get; set; }

        public TropStudent Parent
        {
            get
            {
                return new TropStudent(this.EntryID);
            }
        }

        public int MealPlanID { get; set; }

        public int TermSessionID { get; set; }

        public int MealStatusEnum { get; set; }

        public MealStatus MealStatus
        {
            get
            {
                switch (MealStatusEnum)
                {
                    case 2:
                        return MealStatus.Upcoming;
                    case 5:
                        return MealStatus.Active;
                    case 10:
                        return MealStatus.History;
                    case 70:
                        return MealStatus.Cancelled;
                    default:
                        return MealStatus.History;
                }
            }
        }

        public int BookingID { get; set; }

        public short NumberOfGuests { get; set; }

        public short NumberOfMeals { get; set; }

        public short Breakfast { get; set; }

        public short Lunch { get; set; }

        public short Dinner { get; set; }

        public short Other { get; set; }

        public DateTime DateStart { get; set; }

        public DateTime DateEnd { get; set; }

        public DateTime ContractDateStart { get; set; }

        public DateTime ContractDateEnd { get; set; }

        public decimal AllowanceAInitial { get; set; }

        public decimal AllowanceAUsed { get; set; }

        public decimal AllowanceBInitial { get; set; }

        public decimal AllowanceBUsed { get; set; }

        public decimal AllowanceCInitial { get; set; }

        public decimal AllowanceCUsed { get; set; }

        public bool Cancelled { get; set; }

        public bool ProcessedCharged { get; set; }

        public bool ProcessedCancelled { get; set; }

        public string Comments { get; set; }

        public DateTime DateModified { get; set; }

        public DateTime DateCreated { get; set; }

        public bool CustomBit1 { get; set; }

        public bool CustomBit2 { get; set; }

        public string CustomString1 { get; set; }

        public string CustomString2 { get; set; }

        public string CustomString3 { get; set; }

        public string CustomString4 { get; set; }

        public string CustomString5 { get; set; }

        public string CustomString6 { get; set; }

        public DateTime? CustomDate1 { get; set; }

        public DateTime? CustomDate2 { get; set; }

        public DateTime DateChargedTo { get; set; }

        public MealPlan MealPlan
        {
            get
            {
                DataTable dt = Data.DatabaseAccess.GetTableWithID("MealPlan", "MealPlanID", this.MealPlanID);
                if(dt.Rows.Count > 0)
                {
                    return dt.ToList<MealPlan>()[0];
                }
                else
                {
                    return null;
                }
            }
        }

        public List<EntryMealPlanDetail> EntryMealPlanDetails
        {
            get
            {
                return Data.DatabaseAccess.GetTableWithID("EntryMealPlanDetail", "EntryMealID", this.EntryMealID).ToList<EntryMealPlanDetail>();
            }
        }


        public bool NeedsReset
        {
            get
            {
                return DateTime.Now > DateChargedTo;
            }
        }

        public int Balance
        {
            get
            {
                if(MealPlan.MealSetup == MealSetupEnum.NumberMeals || MealPlan.MealSetup == MealSetupEnum.NumberPerMeal)
                {
                    return NumberOfMeals;
                }
                else if(MealPlan.MealSetup == MealSetupEnum.Allowance)
                {
                    return (int)AllowanceAInitial;
                }
                else
                {
                    return 0;
                }
            }
        }

    }

}
