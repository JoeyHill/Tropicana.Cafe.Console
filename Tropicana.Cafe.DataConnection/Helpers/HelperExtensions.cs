using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Reflection;
using System.ComponentModel;

namespace Tropicana.Cafe.Main.Extensions
{
    public static class HelperExtensions
    {
        /// <summary>
        /// Converts datatable to list<T> dynamically
        /// </summary>
        /// <typeparam name="T">Class name</typeparam>
        /// <param name="dataTable">data table to convert</param>
        /// <returns>List<T></returns>
        public static List<T> ToList<T>(this DataTable dataTable) where T : new()
        {
            var dataList = new List<T>();

            //Define what attributes to be read from the class
            const BindingFlags flags = BindingFlags.Public | BindingFlags.Instance;

            //Read Attribute Names and Types
            var objFieldNames = typeof(T).GetProperties(flags).Cast<PropertyInfo>().
                Select(item => new
                {
                    Name = item.Name,
                    Type = Nullable.GetUnderlyingType(item.PropertyType) ?? item.PropertyType
                }).ToList();

            //Read Datatable column names and types
            var dtlFieldNames = dataTable.Columns.Cast<DataColumn>().
                Select(item => new {
                    Name = item.ColumnName,
                    Type = item.DataType
                }).ToList();

            foreach (DataRow dataRow in dataTable.AsEnumerable().ToList())
            {
                var classObj = new T();

                foreach (var dtField in dtlFieldNames)
                {
                    PropertyInfo propertyInfos = classObj.GetType().GetProperty(dtField.Name);

                    var field = objFieldNames.Find(x => x.Name == dtField.Name);

                    if (field != null)
                    {

                        if (propertyInfos.PropertyType == typeof(DateTime))
                        {
                            propertyInfos.SetValue
                            (classObj, convertToDateTime(dataRow[dtField.Name]), null);
                        }
                        else if (propertyInfos.PropertyType == typeof(int))
                        {
                            propertyInfos.SetValue
                            (classObj, ConvertToInt(dataRow[dtField.Name]), null);
                        }
                        else if(propertyInfos.PropertyType == typeof(short))
                        {
                            propertyInfos.SetValue
                                (classObj, Convert.ToInt16(dataRow[dtField.Name]));
                        }
                        else if (propertyInfos.PropertyType == typeof(long))
                        {
                            propertyInfos.SetValue
                            (classObj, ConvertToLong(dataRow[dtField.Name]), null);
                        }
                        else if (propertyInfos.PropertyType == typeof(decimal))
                        {
                            propertyInfos.SetValue
                            (classObj, ConvertToDecimal(dataRow[dtField.Name]), null);
                        }
                        else if(propertyInfos.PropertyType == typeof(bool))
                        {
                            propertyInfos.SetValue
                                (classObj, ConvertToBoolean(dataRow[dtField.Name]), null);
                        }
                        else if (propertyInfos.PropertyType == typeof(String))
                        {
                            if (dataRow[dtField.Name].GetType() == typeof(DateTime))
                            {
                                propertyInfos.SetValue
                                (classObj, ConvertToDateString(dataRow[dtField.Name]), null);
                            }
                            else
                            {
                                propertyInfos.SetValue
                                (classObj, ConvertToString(dataRow[dtField.Name]), null);
                            }
                        }
                    }
                }
                dataList.Add(classObj);
            }
            return dataList;
        }

        private static string ConvertToDateString(object date)
        {
            if (date == null)
                return string.Empty;

            return Convert.ToDateTime(date).ToString();
        }

        private static bool ConvertToBoolean(object value)
        {
            return Convert.ToBoolean(value);
        }

        private static string ConvertToString(object value)
        {
            return Convert.ToString(HelperFunctions.ReturnEmptyIfNull(value));
        }

        private static int ConvertToInt(object value)
        {
            return Convert.ToInt32(HelperFunctions.ReturnZeroIfNull(value));
        }

        private static int ConvertToInt16(object value)
        {
            Int16 t = Convert.ToInt16(HelperFunctions.ReturnZeroIfNull(value));
            return Convert.ToInt32(t);
        }

        private static long ConvertToLong(object value)
        {
            return Convert.ToInt64(HelperFunctions.ReturnZeroIfNull(value));
        }

        private static decimal ConvertToDecimal(object value)
        {
            return Convert.ToDecimal(HelperFunctions.ReturnZeroIfNull(value));
        }

        private static DateTime convertToDateTime(object date)
        {
            return Convert.ToDateTime(HelperFunctions.ReturnDateTimeMinIfNull(date));
        }

        public static bool IsBetween(this DateTime current, DateTime start, DateTime end)
        {
            return (current <= end && current >= start);
        }

        public static bool IsBetween(this TimeSpan current, TimeSpan start, TimeSpan end)
        {
            return (current <= end && current >= start);
        }

        public static bool IsBetweenExclusive(this DateTime current, DateTime start, DateTime end)
        {
            return (current < end && current > start);
        }

        public static bool IsBetweenExclusive(this TimeSpan current, TimeSpan start, TimeSpan end)
        {
            return (current < end && current > start);
        }

        public static bool IsBetweenTailInclusive(this DateTime current, DateTime start, DateTime end)
        {
            return (current <= end && current > start);
        }

        public static bool IsBetweenTailInclusive(this TimeSpan current, TimeSpan start, TimeSpan end)
        {
            return (current <= end && current > start);
        }

        public static bool IsBetweenHeadInclusive(this DateTime current, DateTime start, DateTime end)
        {
            return (current < end && current >= start);
        }

        public static bool IsBetweenHeadInclusive(this TimeSpan current, TimeSpan start, TimeSpan end)
        {
            return (current < end && current >= start);
        }
        public static bool IsGreaterThan(this DateTime current, DateTime test)
        {
            return (current > test);
        }
        public static bool IsLessThan(this DateTime current, DateTime test)
        {
            return (current < test);
        }
        public static bool IsAfter(this DateTime current, DateTime test)
        {
            return (current > test);
        }
        public static bool IsBefore(this DateTime current, DateTime test)
        {
            return (current < test);
        }
        public static bool IsWeekend(this DayOfWeek dw)
        {
            return (dw == DayOfWeek.Saturday || dw == DayOfWeek.Sunday);
        }
        public static DateTime StartOfWeek(this DateTime dt, DayOfWeek startOfWeek)
        {
            int diff = dt.DayOfWeek - startOfWeek;
            if (diff < 0)
            {
                diff += 7;
            }
            return dt.AddDays(-1 * diff).Date;
        }

        public static DateTime AtMidnight(this DateTime dt, bool MovingForward = false)
        {
            if (MovingForward)
            {
                return dt.Date.AddHours(24);
            }
            else
            {
                return dt.Date;
            }
        }


        public static string GetEnumDescription(Enum value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());
            DescriptionAttribute[] attributes =
                (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);
            if(attributes != null && attributes.Length > 0)
            {
                return attributes[0].Description;
            }
            else
            {
                return value.ToString();
            }
        }
    }
}
