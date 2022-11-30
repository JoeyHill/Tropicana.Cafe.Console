using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Text.RegularExpressions;

namespace Tropicana.Cafe.Main.Extensions
{
    public static class ObjectExtensions
    {
        public static bool IsNumber(this object input, out int output)
        {
            int outObject;
            bool result = int.TryParse(input.ToString(), out outObject);
            output = outObject;
            return result;
        }

        public static List<string> ToStringList<T>(this List<T> input, string Format)
        {
            List<string> Result = new List<string>();
            PropertyInfo[] properties = typeof(T).GetProperties();
            FieldInfo[] fields = typeof(T).GetFields();
            foreach (T obj in input)
            {
                string objResult = Format;
                foreach (PropertyInfo property in properties)
                {
                    Regex exactMatch = new Regex(property.Name);
                    string wrapped = String.Format("{0}", property.Name);
                    
                    if (exactMatch.IsMatch(objResult))
                    {
                        string propVal = property.GetValue(obj).ToString();
                        objResult = objResult.Replace(wrapped, propVal);
                    }
                }
                Result.Add(objResult);
            }
            return Result;
        }
    }
}
