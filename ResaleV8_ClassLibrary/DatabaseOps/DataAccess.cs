using Microsoft.Office.Interop.Excel;
using MySql.Data.MySqlClient;
using ResaleV8_ClassLibrary.DatabaseOps;
using ResaleV8_ClassLibrary.Models;
using System.Data;
using System.Windows.Forms;

namespace ResaleV8_ClassLibrary
{
    public class DataAccess
    {
        public static int addDropDownItemToTable(ddEventArgs ea)
        {
            string sql = "INSERT INTO " + ea.tableName + " (" + ea.columnName + ") values ('" + ea.newItem + "')";
            MySqlConnection con = new MySqlConnection(GV.conString);
            con.Open();
            MySqlCommand cmd = new MySqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@" + ea.columnName, ea.newItem);
            object result = cmd.ExecuteScalar();
            int newID = Convert.ToInt32(cmd.LastInsertedId);

            con.Close();
            
            return newID;
        }

        public static int addItemToDatabase(ItemModel model)
        {            
            string sql = "INSERT INTO PurchasedItems (Category, ItemDesc, PurchaseDate, PurchasePrice, Quantity, SaleDate, SalePrice, StorageLocation)" +
                         "VALUES (@Category, @ItemDesc, @PurchaseDate, @PurchasePrice, @Quantity, @SaleDate, @SalePrice, @StorageLocation)";
            MySqlConnection con = new MySqlConnection(GV.conString);
            con.Open();
            MySqlCommand cmd = new MySqlCommand(sql, con);
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

        public static void updateItemInDatabase(ItemModel model, int itemID)
        {
            string sql = "UPDATE PurchasedItems SET Category = @Category, ItemDesc = @ItemDesc, PurchaseDate = @PurchaseDate, " +
                         "PurchasePrice = @PurchasePrice, Quantity = @Quantity, SaleDate = @SaleDate, " +
                         "SalePrice = @SalePrice, StorageLocation = @StorageLocation " +
                         "WHERE ItemID = @ItemID";
            MySqlConnection con = new MySqlConnection(GV.conString);
            con.Open();
            MySqlCommand cmd = new MySqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@Category", model.Category);
            cmd.Parameters.AddWithValue("@ItemDesc", model.ItemDesc);
            cmd.Parameters.AddWithValue("@PurchaseDate", model.PurchaseDate);
            cmd.Parameters.AddWithValue("@PurchasePrice", model.PurchasePrice);
            cmd.Parameters.AddWithValue("@Quantity", model.Quantity);
            cmd.Parameters.AddWithValue("@SaleDate", model.SaleDate);
            cmd.Parameters.AddWithValue("@SalePrice", model.SalePrice);
            cmd.Parameters.AddWithValue("@StorageLocation", model.StorageLocation);
            cmd.Parameters.AddWithValue("@ItemID", itemID);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public static System.Data.DataTable getData(MySqlConnection con, string query)
        {
            using (con)
            {
                MySqlCommand cmd = new MySqlCommand(query, con);
                MySqlDataReader reader = cmd.ExecuteReader();
                System.Data.DataTable dt = new System.Data.DataTable();
                dt.Load(reader);
                return dt;
            }
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
                //model.Profit = Convert.ToDecimal(reader["Profit"]);
                //model.ProductAge = Convert.ToInt32(reader["ProductAge"]);
                list.Add(model);
            }
            con.Close();
            return list;
        }

        public static void deleteRecord(int ID)
        {
            string sql = "delete from purchasedItems where ItemID = " + ID.ToString();
            MySqlConnection con = ConnectToDB.OpenDB();
            MySqlCommand cmd = new MySqlCommand(sql, con);
            cmd.ExecuteNonQuery();
        }
    }
}
