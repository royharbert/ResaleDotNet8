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
        public static int addDropDownItemToTable(string item, string columnName,string table)
        {
            string sql = "INSERT INTO " + table + " (" + columnName +") values " + item + ")";
            MySqlConnection con = new MySqlConnection(GV.conString);
            con.Open();
            MySqlCommand cmd = new MySqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@" + columnName, item);
            object result = cmd.ExecuteScalar();
            int newID = Convert.ToInt32(cmd.LastInsertedId);

            con.Close();
            return newID;
        }

        public static int addItemToDatabase(ItemModel model)
        {            
            string sql = "INSERT INTO purchased_items (Item_Category, Item_Desc, Purchase_Date, Purchase_Price, Quantity, Sale_Date, Sale_Price, storage_location)" +
                         "VALUES (@Item_Category, @Item_Desc, @Purchase_Date, @Purchase_Price, @Quantity, @Sale_Date, @Sale_Price, @storage_location)";
            MySqlConnection con = new MySqlConnection(GV.conString);
            con.Open();
            MySqlCommand cmd = new MySqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@Item_Category", model.Item_Category);
            cmd.Parameters.AddWithValue("@Item_Desc", model.Item_Desc);
            cmd.Parameters.AddWithValue("@Purchase_Date", model.Purchase_Date);
            cmd.Parameters.AddWithValue("@Purchase_Price", model.Purchase_Price);
            cmd.Parameters.AddWithValue("@Quantity", model.Quantity);
            cmd.Parameters.AddWithValue("@Sale_Date", model.Sale_Date);
            cmd.Parameters.AddWithValue("@Sale_Price", model.Sale_Price);
            cmd.Parameters.AddWithValue("@storage_location", model.storage_location);
            //cmd.Parameters.AddWithValue("@Profit", model.Profit);
            //cmd.Parameters.AddWithValue("@Product_age", model.Product_Age);

            object result = cmd.ExecuteScalar();
            int newID = Convert.ToInt32(cmd.LastInsertedId);

            con.Close();
            return newID;
        }

        public static void updateItemInDatabase(ItemModel model, int itemID)
        {
            string sql = "UPDATE purchased_items SET Item_Desc = @Item_Desc, Purchase_Date = @Purchase_Date, " +
                         "Purchase_Price = @Purchase_Price, Quantity = @Quantity, Sale_Date = @Sale_Date, " +
                         "Sale_Price = @Sale_Price, storage_location = @storage_location " +
                         "WHERE Item_ID = @Item_ID";
            MySqlConnection con = new MySqlConnection(GV.conString);
            con.Open();
            MySqlCommand cmd = new MySqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@Item_Desc", model.Item_Desc);
            cmd.Parameters.AddWithValue("@Purchase_Date", model.Purchase_Date);
            cmd.Parameters.AddWithValue("@Purchase_Price", model.Purchase_Price);
            cmd.Parameters.AddWithValue("@Quantity", model.Quantity);
            cmd.Parameters.AddWithValue("@Sale_Date", model.Sale_Date);
            cmd.Parameters.AddWithValue("@Sale_Price", model.Sale_Price);
            cmd.Parameters.AddWithValue("@storage_location", model.storage_location);
            cmd.Parameters.AddWithValue("@Item_ID", itemID);
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
