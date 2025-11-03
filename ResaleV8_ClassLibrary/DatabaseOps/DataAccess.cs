//using Microsoft.Office.Interop.Excel;
using MySql.Data.MySqlClient;
using ResaleV8_ClassLibrary.DatabaseOps;
using ResaleV8_ClassLibrary.Models;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using DataTable = System.Data.DataTable;
using Dapper;
using ResaleV8_ClassLibrary.Ops;

namespace ResaleV8_ClassLibrary
{
    public class DataAccess
    {
        public static List<GenericModel> GetDropDownList(string tableName)
        {
            MySqlConnection con = ConnectToDB.OpenDB();
            using (con)
            {
                List<GenericModel> calegoryList = 
                        con.Query<GenericModel>("SELECT * FROM " + tableName, commandType: CommandType.Text).AsList();
                return calegoryList;
            }
        }

        public static List<GenericModel> GetStorageLocationList()
        {
            MySqlConnection con = ConnectToDB.OpenDB();
            using (con)
            {
                List<GenericModel> storageLocationList =
                        con.Query<GenericModel>("SELECT * FROM storagelocations", commandType: CommandType.Text).AsList();
                return storageLocationList;
            }
        }

        public static List<GenericModel> GetPurchaseSourceList()
        {
            MySqlConnection con = ConnectToDB.OpenDB();
            using (con)
            {
                List<GenericModel> purchaseSourceList =
                        con.Query<GenericModel>("SELECT * FROM purchasesources", commandType: CommandType.Text).AsList();
                return purchaseSourceList;
            }
        }

        public static List<GenericModel> GetBrandList()
        {
            MySqlConnection con = ConnectToDB.OpenDB();
            using (con)
            {
                List<GenericModel> brandList =
                        con.Query<GenericModel>("SELECT * FROM brands", commandType: CommandType.Text).AsList();
                return brandList;
            }
        }

        public static void ModifySelectedFieldEntries(string oldItem, string newItem, string tableName, string colName)
        {
            int rows = 0;
            string sql = $"UPDATE purchaseditems SET {colName} = '{newItem}' WHERE {colName} = '{oldItem}';" +
                $"select row_count() as rows_affected";
            sql = Operations.EscapeApostrophes(sql);
            MySqlConnection con = new MySqlConnection(GV.conString);
            con.Open();
            rows = con.Execute(sql);
            if (rows > 0)
            {
                MessageBox.Show(rows.ToString() + " items affected"); 
            }
            else
            {
                MessageBox.Show("No existing rows required modification");
            }
                con.Close();
            return;
        }

        public static int addDropDownItemToTable(ddEventArgs ea)
        {
            string sql = "INSERT INTO " + ea.tableName + " (" + ea.columnName + ") values " +
                "('" + ea.newItem + "')";
            MySqlConnection con = new MySqlConnection(GV.conString);
            con.Open();
            MySqlCommand cmd = new MySqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@" + ea.columnName, ea.newItem);
            object result = cmd.ExecuteScalar();
            int newID = Convert.ToInt32(cmd.LastInsertedId);

            con.Close();
            
            return newID;
        }

        public static void RemoveTableItems(string tableName)
        {
            string sql = "DELETE FROM " + tableName + " where ID > 0";
            MySqlConnection con = new MySqlConnection(GV.conString);
            con.Open();
            MySqlCommand cmd = new MySqlCommand(sql, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public static void RemoveListItem(string tableName, string colName, string item)
        {
            MySqlConnection con = ConnectToDB.OpenDB();
            string sql = "delete from " + tableName + " where " + colName + " = '" + item + "';";
            MySqlCommand cmd = new MySqlCommand( sql, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }


        public static int AddListToDropDownTable(string tableName, List<string> list, string colName)
        {
            MySqlConnection con = new MySqlConnection(GV.conString);
            MySqlCommand cmd = new MySqlCommand();
            con.Open();
            foreach(var item in list)
            {
                string sql = "INSERT INTO " + tableName + " (" + colName + ") values " +
                    "('" + item + "')";
                cmd = new MySqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@" + colName, item);
                object result = cmd.ExecuteScalar();
            }
            con.Close();
            int newID = Convert.ToInt32(cmd.LastInsertedId);
            return newID;
        }

        public static int addItemToDatabase(ItemModel model)
        {            
            string sql = "INSERT INTO PurchasedItems (Category, ItemDesc, PurchaseDate, PurchasePrice, " +
                "Quantity, SaleDate, SalePrice, StorageLocation, purchaseSource, Brand, ListingDate, WhereListed) VALUES (@Category, " +
                "@ItemDesc, @PurchaseDate, @PurchasePrice, @Quantity, @SaleDate, @SalePrice, @StorageLocation," +
                "@PurchaseSource, @Brand, @DateListed, @WhereListed )";
            MySqlConnection con = new MySqlConnection(GV.conString);
            con.Open();
            MySqlCommand cmd = new MySqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@DateListed", model.DateListed);
            cmd.Parameters.AddWithValue("@WhereListed", model.WhereListed);
            cmd.Parameters.AddWithValue("@Brand", model.Brand);
            cmd.Parameters.AddWithValue("@PurchaseSource", model.PurchaseSource);
            cmd.Parameters.AddWithValue("@Category", model.Category);
            cmd.Parameters.AddWithValue("@ItemDesc", model.ItemDesc);
            cmd.Parameters.AddWithValue("@PurchaseDate", model.PurchaseDate);
            cmd.Parameters.AddWithValue("@PurchasePrice", model.PurchasePrice);
            cmd.Parameters.AddWithValue("@Quantity", model.Quantity);
            cmd.Parameters.AddWithValue("@SaleDate", model.SaleDate);
            cmd.Parameters.AddWithValue("@SalePrice", model.SalePrice);
            cmd.Parameters.AddWithValue("@StorageLocation", model.StorageLocation);
            cmd.Parameters.AddWithValue("@Profit", model.Profit);
            cmd.Parameters.AddWithValue("@ProductAge", model.ProductAge);

            object result = cmd.ExecuteScalar();
            int newID = Convert.ToInt32(cmd.LastInsertedId);

            con.Close();
            return newID;
        }

        public static int updateItemInDatabase(ItemModel model, int itemID)
        {
            string sql = "UPDATE PurchasedItems SET Category = @Category, ItemDesc = @ItemDesc, PurchaseDate = @PurchaseDate, " +
                         "PurchasePrice = @PurchasePrice, Quantity = @Quantity, SaleDate = @SaleDate, " +
                         "SalePrice = @SalePrice, StorageLocation = @StorageLocation, Brand = @Brand, " +
                         "purchaseSource = @PurchaseSource, WhereListed = @WhereListed, " +
                         "ListingDate = @DateListed WHERE ItemID = @ItemID";
            MySqlConnection con = new MySqlConnection(GV.conString);
            con.Open();
            MySqlCommand cmd = new MySqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@DateListed", model.DateListed);
            cmd.Parameters.AddWithValue("@WhereListed", model.WhereListed);
            cmd.Parameters.AddWithValue("@Brand", model.Brand);
            cmd.Parameters.AddWithValue("@PurchaseSource", model.PurchaseSource);
            cmd.Parameters.AddWithValue("@Category", model.Category);
            cmd.Parameters.AddWithValue("@ItemDesc", model.ItemDesc);
            cmd.Parameters.AddWithValue("@PurchaseDate", model.PurchaseDate);
            cmd.Parameters.AddWithValue("@PurchasePrice", model.PurchasePrice);
            cmd.Parameters.AddWithValue("@Quantity", model.Quantity);
            cmd.Parameters.AddWithValue("@SaleDate", model.SaleDate);
            cmd.Parameters.AddWithValue("@SalePrice", model.SalePrice);
            cmd.Parameters.AddWithValue("@StorageLocation", model.StorageLocation);
            cmd.Parameters.AddWithValue("@ItemID", itemID);
            int rowsAffected = cmd.ExecuteNonQuery();
            con.Close();
            return rowsAffected;
        }

        public static void UpdateSingleDDItem(string tableName, string colName, string oldItem, string newItem)
        {
            List<int> indx = new List<int>();
            int index = -1;
            if (newItem.Contains("'") || oldItem.Contains("'"))
            {
                oldItem = Operations.EscapeApostrophes(oldItem);
                index = newItem.IndexOf("'");
                newItem = Operations.EscapeApostrophes(newItem);
            }
            MySqlConnection con = ConnectToDB.OpenDB();
            string sql = "update " + tableName + " set " + colName + " = '" + newItem + "' where " + colName + " = '" + oldItem + "'";
            MySqlCommand cmd =new MySqlCommand(sql, con);
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Item updated");
        }
       
        public static List<GenericModel> LoadDDModel(string tableName)
        { 
            List<GenericModel> model = new List<GenericModel>();
            string sql = "SELECT * FROM " + tableName;
            MySqlConnection con = new MySqlConnection(GV.conString);
            con.Open();
            MySqlCommand cmd = new MySqlCommand(sql, con);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                GenericModel item = new GenericModel();
                item.ID = Convert.ToInt32(reader[0].ToString());
                item.Data = reader[1].ToString();
                model.Add(item);
                item = null;
            }
            con.Close();
            return model;
        }

        public static List<ItemModel> getModelList(string sql)
        {
            List<ItemModel> list = new List<ItemModel>();
            //string sql = "SELECT * FROM PurchasedItems";
            MySqlConnection con = new MySqlConnection(GV.conString);
            con.Open();
            MySqlCommand cmd = new MySqlCommand(sql, con);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                ItemModel model = new ItemModel();
                model.ItemID = Convert.ToInt32(reader["ItemID"]);
                model.Category = reader["Category"].ToString();
                model.ItemDesc = reader["ItemDesc"]?.ToString() ?? string.Empty;
                model.PurchaseDate = Convert.ToDateTime(reader["PurchaseDate"]);
                model.PurchasePrice = Convert.ToDecimal(reader["PurchasePrice"]);
                model.Quantity = Convert.ToInt32(reader["Quantity"]);
                if (reader["SaleDate"] != DBNull.Value)
                    model.SaleDate = Convert.ToDateTime(reader["SaleDate"]);
                if (reader["SalePrice"] != DBNull.Value)
                    model.SalePrice = Convert.ToDecimal(reader["SalePrice"]);
                model.StorageLocation = reader["StorageLocation"].ToString() ?? string.Empty;
                model.PurchaseSource = reader["PurchaseSource"].ToString() ?? string.Empty;
                model.Brand = reader["Brand"].ToString() ?? string.Empty;
                
                if (reader["ListingDate"] != DBNull.Value)
                    model.DateListed = Convert.ToDateTime(reader["ListingDate"]);
                model.WhereListed = reader["WhereListed"].ToString() ?? string.Empty;
                list.Add(model);
            }
            con.Close();
            return list;
        }

        public static void DeleteRecord(int ID, string tableName)
        {
            string sql = "delete from " + tableName + " where ID = " + ID.ToString();
            MySqlConnection con = ConnectToDB.OpenDB();
            MySqlCommand cmd = new MySqlCommand(sql, con);
            cmd.ExecuteNonQuery();
        }

        public static DataTable GetComboItemList(string tableName)
        {
            DataTable dt = new DataTable();
            MySqlConnection con = new MySqlConnection(GV.conString);
            con.Open();
            string sql = "SELECT * FROM " + tableName;
            MySqlCommand cmd = new MySqlCommand(sql, con);
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.Fill(dt);
            con.Close();
            return dt;
        }
    }
}
