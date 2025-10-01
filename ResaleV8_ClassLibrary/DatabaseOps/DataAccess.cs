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
            //cmd.Parameters.AddWithValue("@Profit", model.Profit);
            //cmd.Parameters.AddWithValue("@ProductAge", model.ProductAge);

            object result = cmd.ExecuteScalar();
            int newID = Convert.ToInt32(cmd.LastInsertedId);

            con.Close();
            return newID;
        }

        public static void updateItemInDatabase(ItemModel model, int itemID)
        {
            string sql = "UPDATE PurchasedItems SET Category, ItemDesc = @ItemDesc, PurchaseDate = @PurchaseDate, " +
                         "PurchasePrice = @Category, @PurchasePrice, Quantity = @Quantity, SaleDate = @SaleDate, " +
                         "SalePrice = @SalePrice, StorageLocation = @StorageLocation " +
                         "WHERE ItemID = @ItemID";
            MySqlConnection con = new MySqlConnection(GV.conString);
            con.Open();
            MySqlCommand cmd = new MySqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@Item_esc", model.ItemDesc);
            cmd.Parameters.AddWithValue("@ItemDesc", model.ItemDesc);
            cmd.Parameters.AddWithValue("@PurchasePrice", model.PurchasePrice);
            cmd.Parameters.AddWithValue("@Quantity", model.Quantity);
            cmd.Parameters.AddWithValue("@SaleDate", model.SaleDate);
            cmd.Parameters.AddWithValue("@SalePrice", model.SalePrice);
            cmd.Parameters.AddWithValue("@StorageLocations", model.StorageLocation);
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
    }
}
