using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tropicana.Cafe.Main.Extensions;
using Tropicana.Cafe.Main;

namespace Tropicana.Cafe.Main.Models
{
    public class MealPlan
    {
        public int MealPlanID { get; set; }

        public int RecordTypeEnum { get; set; }

        public int TermSessionID { get; set; }

        public int MealPlanDiningHallID { get; set; }

        public string Description { get; set; }

        public string Code { get; set; }

        public DateTime DateStart { get; set; }

        public DateTime DateEnd { get; set; }

        public bool Active { get; set; }

        public int MealSetupEnum { get; set; }

        public MealSetupEnum MealSetup
        {
            get
            {
                switch (MealSetupEnum)
                {
                    case 0:
                        return Main.MealSetupEnum.NumberMeals;
                    case 1:
                        return Main.MealSetupEnum.NumberPerMeal;
                    case 2:
                        return Main.MealSetupEnum.SinglePlan;
                    case 3:
                        return Main.MealSetupEnum.WeeklyPlan;
                    case 4:
                        return Main.MealSetupEnum.Allowance;
                    case 5:
                        return Main.MealSetupEnum.AdHoc;
                    case 6:
                        return Main.MealSetupEnum.AdHocAdjustable;
                    default:
                        return Main.MealSetupEnum.NumberMeals;
                }
            }
        }

        public bool ChargesNotAllowed { get; set; }

        public int MealPricingID { get; set; }

        public short NumberOfMeals { get; set; }

        public short NumberOfServings { get; set; }

        public int ChargeItemID { get; set; }

        public decimal AllowanceA { get; set; }

        public decimal AllowanceARate { get; set; }

        public decimal AllowanceB { get; set; }

        public decimal AllowanceBRate { get; set; }

        public decimal AllowanceC { get; set; }

        public decimal AllowanceCRate { get; set; }

        public DateTime? TransactionDateDue { get; set; }

        public string Comments { get; set; }

        public bool ViewOnWeb { get; set; }

        public string WebDescription { get; set; }

        public int WebOrder { get; set; }

        public string WebComments { get; set; }

        public int SecurityUserID { get; set; }

        public DateTime DateModified { get; set; }

        public DateTime DateCreated { get; set; }

        public bool UpdateContractDatesWhenDatesChange { get; set; }

        public bool CustomBit1 { get; set; }

        public bool CCMealPlan
        {
            get
            {
                return CustomBit1;
            }
        }

        public bool CustomBit2 { get; set; }

        public bool UCMealPlan
        {
            get
            {
                return CustomBit2;
            }
        }

        public string CustomString1 { get; set; }

        public string CustomString2 { get; set; }

        public string CustomString3 { get; set; }

        public string CustomString4 { get; set; }

        public string CustomString5 { get; set; }

        public string CustomString6 { get; set; }

        public DateTime? CustomDate1 { get; set; }

        public DateTime? CustomDate2 { get; set; }

        public List<MealPlanDetail> MealPlanDetails
        {
            get
            {
                return Data.DatabaseAccess.GetTableWithID("MealPlanDetail", "MealPlanID", this.MealPlanID).ToList<MealPlanDetail>();
            }
        }

        public bool IsPunchCard
        {
            get
            {
                return (this.MealSetup == Main.MealSetupEnum.NumberMeals);
            }
        }

        public bool IsNumberPerMeal
        {
            get
            {
                return (this.MealSetup == Main.MealSetupEnum.NumberPerMeal);
            }
        }

        public bool IsAllowance
        {
            get
            {
                return (this.MealSetup == Main.MealSetupEnum.Allowance);
            }
        }

        public List<MealPlanFree> FreePeriods
        {
            get
            {
                return Data.DatabaseAccess.GetTableWithID("MealPlanFree", "MealPlanID", this.MealPlanID).ToList<MealPlanFree>();
            }
        }

    }

}
