using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Data;

namespace Tropicana.Cafe.Main.Extensions
{
    public static class DataExtensions
    {
        /*public static IList<T> ToList<T>(this DataTable table) where T : new()
        {
            IList<PropertyInfo> properties = typeof(T).GetProperties().ToList();
            IList<T> result = new List<T>();

            foreach (var row in table.Rows)
            {
                var item = CreateItemFromRow<T>((DataRow)row, properties);
                result.Add(item);
            }

            return result;
        }*/

        private static T CreateItemFromRow<T>(DataRow row, IList<PropertyInfo> properties) where T : new()
        {
            T item = new T();

            foreach (var property in properties)
            {
                if (row.Table.Columns.Contains(property.Name))
                {
                    if (row.Table.Columns[property.Name].DataType == property.PropertyType)
                    {
                        property.SetValue(item, row[property.Name], null);
                    }
                }
            }
            return item;
        }

        public static T CreateObjectFromRow<T>(this DataRow row) where T : new()
        {
            T item = new T();
            IList<PropertyInfo> properties = typeof(T).GetProperties().ToList();
            foreach (var property in properties)
            {
                if (row.Table.Columns.Contains(property.Name))
                {
                    if (row.Table.Columns[property.Name].DataType == property.PropertyType)
                    {
                        property.SetValue(item, row[property.Name], null);
                    }
                }
            }
            return item;
        }
    }
}
