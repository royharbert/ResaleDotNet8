using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Data;

namespace ResaleV8_ClassLibrary.Ops
{
    public static class Operations
    {
        public static List<string> getModelPtoperties<T>(T model)
        {
            List<string> properties = new List<string>();
            PropertyInfo[] props = typeof(T).GetProperties();
            foreach (PropertyInfo prop in props)
            {
                properties.Add(prop.Name);
            }            

            return properties;
        }

        public static List<T> convertDataTableToList<T>(DataTable dt, string columnName) where T : new()
        {
            List<T> data = new List<T>();
            foreach (DataRow row in dt.Rows)
            {
                // Assumes the column value can be cast to T
                T item = (T)row[columnName];
                data.Add(item);
            }
            return data;
        }
    }

    
}
