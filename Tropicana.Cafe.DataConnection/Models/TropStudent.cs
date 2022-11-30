using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using Tropicana.Cafe.Main.Data;
using Tropicana.Cafe.Main.Extensions;
using System.Drawing;


namespace Tropicana.Cafe.Main.Models
{
    public class TropStudent : Entry
    {
        public TropStudent()
        {
            
        }
        /// <summary>
        /// Must be called in order to initialize and gather related records. Calls the internal Associate function, which is also called when constructed with
        /// and EntryID. 
        /// </summary>
        public void Init()
        {
            Associate();
        }

        public TropStudent(int EntryID)
        {
            List<Entry> e = DatabaseAccess.GetByID(EntryID).ToList<Entry>();
            if(e.Count > 0)
            {
                Initialize(e[0]);
                Associate();
            }
        }

        public List<Booking> Bookings;
        public List<EntryMeal> EntryMeals;
        public List<EntryCustomField> CustomFields;
        public Booking ActiveBooking;
        public EntryMeal ActiveMeal;
        public EntryDetail Details;

        public bool CanHaveDirectorGuest
        {
            get
            {
                return (bool)DatabaseAccess.GetCustomField(this.EntryID, 145);
            }
        }

        public string Name
        {
            get
            {
                return String.Format("{0} {1}", this.NameFirst, this.NameLast);
            }
        }

        public Image Photo
        {
            get
            {
                return DatabaseAccess.GetPhoto(this.EntryID);
            }
        }

        public bool HasValidMeals
        {
            get
            {
                return (ActiveMeal != null);
            }
        }
        public bool HasInRoomBooking
        {
            get
            {
                return (ActiveBooking != null);
            }
        }

        private void Initialize(Entry e)
        {
            foreach(PropertyInfo p in e.GetType().GetProperties())
            {
                string propertyName = p.Name;
                object propertyValue = p.GetValue(e);
                this.GetType().GetProperty(propertyName).SetValue(this, propertyValue);
            }
        }

        private void Associate()
        {
            Bookings = DatabaseAccess.GetEntryRelatedRecords("Booking", this.EntryID).ToList<Booking>();
            EntryMeals = DatabaseAccess.GetEntryRelatedRecords("EntryMeal", this.EntryID).ToList<EntryMeal>();
            CustomFields = DatabaseAccess.GetEntryRelatedRecords("EntryCustomField", this.EntryID).ToList<EntryCustomField>();
            Details = DatabaseAccess.GetEntryRelatedRecords("EntryDetail", this.EntryID).ToList<EntryDetail>()[0];
            ActiveBooking = (from b in Bookings
                             where b.EntryStatusEnum == 5
                             select b).FirstOrDefault();
            List<EntryMeal> potentialMeals = EntryMeals.Where(meal => meal.DateStart <= DateTime.Now && meal.DateEnd.AtMidnight(true) >= DateTime.Now.AtMidnight(true) && (meal.MealStatus == MealStatus.Active || meal.MealStatus == MealStatus.Upcoming)).ToList<EntryMeal>();
            if(potentialMeals.Count == 0)
            {
                ActiveMeal = null;
            }
            if(potentialMeals.Count > 0)
            {   
                List<EntryMeal> ActiveMeals = potentialMeals.OrderBy(a => a.DateCreated).ToList();
                List<EntryMeal> IgnoredMeals = new List<EntryMeal>();
                foreach(EntryMeal m in ActiveMeals.ToList())
                {
                    //If Meal is Punch Card
                    if(m.MealPlan.MealSetup == MealSetupEnum.NumberMeals || m.MealPlan.MealSetup == MealSetupEnum.NumberPerMeal)
                    {
                        //And Punch Card has none left
                        if(m.NumberOfMeals == 0)
                        {
                            IgnoredMeals.Add(m);
                            ActiveMeals.Remove(m);
                            if(ActiveMeals.Count == 0)
                            {
                                break;
                            }
                        }
                    }
                }

                //Factors the punch card plans with a remainder still and uses the remainder first.
                if(ActiveMeals.Count == 0 && IgnoredMeals.Count > 0)
                {
                    ActiveMeal = IgnoredMeals.OrderBy(m => m.DateCreated).First();
                }
                else
                {
                    ActiveMeal = ActiveMeals.First();
                }
            }   
        }
    }
}
