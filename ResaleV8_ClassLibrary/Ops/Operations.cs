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
            sellThru.Brand = brand;
            sellThru.TotalItems = allItems.Count;
            sellThru.TotalSold = soldItems.Count;
            sellThru.SellThruPct = sellThru.TotalSold * 100 / sellThru.TotalItems;
            decimal totalPurchasePrice = soldItems.Sum(i => i.PurchasePrice);
            if (totalPurchasePrice > 0)
            {
                sellThru.ProfitPct = soldItems.Sum(i => i.Profit) / totalPurchasePrice * 100; 
            }
            sellThru.FinancialPosition = soldItems.Sum(i => i.Profit) - allItems.Sum(i => i.PurchasePrice);
            return sellThru;
        }

        public static List<SellThruModel> DoBrandsSellThru(List<string> brands)
        {
            List<SellThruModel> sellThruList = new List<SellThruModel>();
            foreach (string brand in brands)
                if (brand != null)
                {
                    {
                        List<ItemModel> brandList = DoBrandSellThru(brand);
                        SellThruModel sellThru = DoSellThru(brand, brandList);
                        sellThruList.Add(sellThru);
                    } 
                }
            sellThruList = sellThruList.OrderByDescending(s => s.SellThruPct).ToList();
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

        public static void FormatSellThruDGV(DataGridView dgv)
        {
            string[] headers = new string[] { "Brand", "Total Items", "Total Sold", "Sell Thru %", "Profit %", "Financial Position" };
            for (int i = 0; i < headers.Length; i++)
            {
                if (i < dgv.Columns.Count)
                {
                    dgv.Columns[i].HeaderText = headers[i];
                }
            }
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgv.AllowUserToAddRows = false;
            dgv.AllowUserToDeleteRows = false;
            dgv.ReadOnly = true;
            dgv.MultiSelect = false;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv.RowHeadersVisible = true;
            dgv.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            foreach (DataGridViewColumn col in dgv.Columns)
            {
                col.SortMode = DataGridViewColumnSortMode.Automatic;
            }
        }
    }

    
}
