using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Tropicana.Cafe.Main;
using Tropicana.Cafe.Main.Models;
using Rules = Tropicana.Cafe.Main.Rules;
using Tropicana.Cafe.Main.Validators;
using System.Reflection;


namespace Tropicana.Cafe.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                string input = System.Console.ReadLine();
                int EntryID = 0;
                int.TryParse(input, out EntryID);
                var watch = System.Diagnostics.Stopwatch.StartNew();
                TropStudent student = new TropStudent(EntryID);
                System.Console.WriteLine(String.Format("Testing EntryMeal: {0}, ID: {1}", student.ActiveMeal.MealPlan.Description, student.ActiveMeal.MealPlanID));
                MealValidator v = new MealValidator(student.ActiveMeal);
                ListProperties(v.Response);
                //ListProperties(student);
                
                watch.Stop();
                var elapsed = watch.ElapsedMilliseconds;
                System.Console.WriteLine("Time: "+elapsed.ToString());
            }   
        }

        protected static void ListProperties(object obj)
        {
            System.Console.WriteLine("Fields:::");
            foreach (FieldInfo prop in obj.GetType().GetFields())
            {
                System.Console.WriteLine(prop.Name + " - " + prop.GetValue(obj));
            }
            System.Console.WriteLine("Properties:::");
            foreach (PropertyInfo prop in obj.GetType().GetProperties())
            {
                System.Console.WriteLine(prop.Name + " - " + prop.GetValue(obj));
            }
        }
    }
}
