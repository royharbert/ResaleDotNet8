using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Data;
using Dapper;
using ResaleV8_ClassLibrary.Models;
using ResaleV8_ClassLibrary.DatabaseOps;
using MySql.Data.MySqlClient;

namespace ResaleV8_ClassLibrary.Ops
{
    public static class Operations
    {
        public static SellThruModel DoSellThru(string brand, List<ItemModel> allItems)
        {
            SellThruModel sellThru = new SellThruModel();
            List<ItemModel> soldItems = allItems.Where(i => i.SalePrice > 0).ToList();
            sellThru.TotalItems = allItems.Count;
            sellThru.TotalSold = soldItems.Count;
            sellThru.SellThruPct = sellThru.TotalSold * 100 / sellThru.TotalItems;
            //if (soldItems.Sum(i => i.PurchasePrice != 0)
            //{
            decimal totalPurchasePrice = soldItems.Sum(i => i.PurchasePrice);
            if (totalPurchasePrice > 0)
            {
                sellThru.ProfitPct = soldItems.Sum(i => i.Profit) / totalPurchasePrice * 100; 
            }
            //}
            sellThru.FinancialPosition = soldItems.Sum(i => i.Profit) - allItems.Sum(i => i.PurchasePrice);
            //MessageBox.Show($"Brand: {brand}\n" +
            //    $"Total Items: {totalItems}\n" +
            //    $"Total Sold: {totalSold}\n" +
            //    $"Sell Thru %: {pctSellThru}%\n" +
            //    $"Profit %: {profitPct.ToString("0.00")}%\n" +
            //    $"Financial Position: {financialPoition.ToString("C")}");
            return sellThru;
        }

        public static List<SellThruModel> DoBrandsSellThru(List<string> brands)
        {
            List<SellThruModel> sellThruList = new List<SellThruModel>();
            foreach (string brand in brands)
            {
                List<ItemModel> brandList = DoBrandSellThru(brand);
                SellThruModel sellThru = DoSellThru(brand, brandList);
                sellThruList.Add(sellThru);
            }

            return sellThruList;
        }

        public static List<ItemModel> DoBrandSellThru(string brand)
        {
            List<ItemModel> brandList = DataAccess.GetItemsByBrand(brand);
            return brandList;
        }

        public static void RefreshDDList(ComboBox cbo, List<GenericModel> list)
        {
            cbo.Items.Clear();
            foreach (GenericModel item in list)
            {
                cbo.Items.Add(item.Data);
            }
        }

        public static List<GenericModel> GetDDItems(string tableName)
        { 
            MySqlConnection con = ConnectToDB.OpenDB();
            using (con)
            {
                string query = $"SELECT id AS ID, item AS Data FROM {tableName} ORDER BY {tableName.Substring(0, tableName.Length - 1)} ASC";
                var result = con.Query<GenericModel>(query).ToList();
                return result;
            }
        }

        public static int FindStringInList(string searchString, List<GenericModel> list)
        {
            foreach (GenericModel item in list)
            {
                if (item.Data.Equals(searchString, StringComparison.OrdinalIgnoreCase))
                {
                    return item.ID;
                }
            }
            return -1; // Not found
        }
        public static string EscapeApostrophes(string input)
        {
            if (input.Contains("''"))
            {
                if (string.IsNullOrEmpty(input))
                {
                    return input;
                }
                return input;
            }
            return input.Replace("'", "''");
        }

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
