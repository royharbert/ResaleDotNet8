﻿using System;
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

        public static List<string> ConvertDataTableToList(DataTable dt, string columnName)         
        {
            List<string> data = new List<string>();
            string item = "";
            if (dt != null)
            {
                foreach (DataRow row in dt.Rows)
                {  
                    item = row[columnName].ToString();
                    data.Add(item);
                } 
            }
            return data;
        }
        //public static DataTable ConvertListToDataTable(List<string> list, string columnName)
        //{
        //    DataTable dt = new DataTable();
        //    dt.Columns.Add("ID", typeof(int));
        //    dt.Columns.Add(columnName, typeof(string));
        //    for (int i = 0; i < list.Count; i++)
        //    {
        //        dt.Rows.Add(i + 1, list[i]);
        //    }
        //    DataAccess.addListToDropDownTable(dt, list, columnName);
        //    return dt;
        //}
    }

    
}
