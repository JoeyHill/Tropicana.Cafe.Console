using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tropicana.Cafe.Main.Models;
using System.Data;
using System.Reflection;

namespace Tropicana.Cafe.Forms.MiscForms
{
    public partial class EntryMealDetails : Form
    {
        public EntryMealDetails()
        {
            InitializeComponent();
        }

        public EntryMealDetails(TropStudent student)
        {
            InitializeComponent();
            if(student == null)
            {
                return;
            }
            TreeNode entry = new TreeNode(student.Name);
            TreeNode bookings = new TreeNode("Bookings");
            TreeNode meals = new TreeNode("Meals");
            
            foreach(Booking b in student.Bookings)
            {
                List<TreeNode> l = new List<TreeNode>();
                
                for(int i = 0; i < typeof(Booking).GetProperties().Count(); i++)
                {
                    PropertyInfo p = typeof(Booking).GetProperties()[i];
                    TreeNode n = new TreeNode(String.Format("{0}: {1}", p.Name, p.GetValue(b)));
                    l.Add(n);
                }
                TreeNode currentBooking = new TreeNode(b.RoomSpaceDescription, l.ToArray());
                bookings.Nodes.Add(currentBooking);
            }

            foreach (EntryMeal b in student.EntryMeals)
            {
                List<TreeNode> l = new List<TreeNode>();

                for (int i = 0; i < typeof(EntryMeal).GetProperties().Count(); i++)
                {
                    PropertyInfo p = typeof(EntryMeal).GetProperties()[i];
                    TreeNode n = new TreeNode(String.Format("{0}: {1}", p.Name, p.GetValue(b)));
                    l.Add(n);
                }
                TreeNode currentMeal = new TreeNode(b.MealPlan.Description, l.ToArray());
                meals.Nodes.Add(currentMeal);
            }

            TreeNode details = new TreeNode("Details");

            for (int i = 0; i < typeof(EntryDetail).GetProperties().Count(); i++)
            {
                PropertyInfo p = typeof(EntryDetail).GetProperties()[i];
                TreeNode n = new TreeNode(String.Format("{0}: {1}", p.Name, p.GetValue(student.Details)));
                details.Nodes.Add(n);
            }

            StudentTree.Nodes.Add(entry);
            entry.Nodes.Add(bookings);
            entry.Nodes.Add(meals);
            entry.Nodes.Add(details);

            List<string> PropertiesToExclude = new List<string>
            {
                "ID2",
                "ID3"
            };
            foreach (PropertyInfo prop in typeof(TropStudent).GetProperties())
            {
                if (PropertiesToExclude.Contains(prop.Name))
                {
                    continue;
                }
                entry.Nodes.Add(new TreeNode(String.Format("{0}: {1}", prop.Name, prop.GetValue(student))));
            }
            StudentTree.Nodes[0].Expand();
        }
    }
}
