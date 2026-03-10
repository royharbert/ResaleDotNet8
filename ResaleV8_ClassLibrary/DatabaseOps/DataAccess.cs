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
        public static DropDownEventArgs RecursiveControlEscapeChars(string item)
        {
            DropDownEventArgs args = new DropDownEventArgs();
            args.originalItem = item;
            args.StringToProcess = args.originalItem;
            args.escapedItem = "";
            args.unescapedItem = "";
            args.FirstPass = true;
            args.CaretPos = 0;
            ProcessDDItem(args);

            return args;
        }
        /// <summary>
        /// Processes a drop-down event argument by handling escaped and unescaped single quotes in the input string.
        /// </summary>
        /// <remarks>This method updates the provided <paramref name="args"/> object in place, parsing and
        /// transforming the input string to handle escaped single quotes. The method is typically used to prepare
        /// strings for display or further processing in drop-down controls.</remarks>
        /// <param name="args">The drop-down event arguments containing the string to process and related state information. Cannot be
        /// null.</param>
        /// <returns>A modified instance of the <see cref="DropDownEventArgs"/> reflecting the processed string and updated
        /// state.</returns>
        public static DropDownEventArgs ProcessDDItem(DropDownEventArgs args)
        {
            args.FirstPass = false;
            //Loop through input strings and locate instance of espcaped single quotes
            if (args.StringToProcess.Contains("''"))
            {
                args.unescapedItem = args.StringToProcess.Replace("''", "\'");
                args.escapedItem = args.StringToProcess;
                args.StringToProcess = "";
                // C#
                if (!string.IsNullOrEmpty(args.StringToProcess) && args.StringToProcess.IndexOf('\'') != -1)
                {
                    ProcessDDItem(args);
                }
            }
            else
            {
                if (args.StringToProcess.IndexOf('\'') == -1)
                {
                    args.escapedItem += args.StringToProcess;
                    args.unescapedItem += args.StringToProcess;
                    args.StringToProcess = "";
                    return args;
                }
                if (args.CaretPos < args.StringToProcess.Length)
                {
                    args.CaretPos = args.StringToProcess.IndexOf('\'', args.CaretPos); 
                }
                else
                {
                    return args;
                }
                if (args.StringToProcess[args.CaretPos + 1] == '\'')
                {
                    args.StringToProcess =
                        args.StringToProcess.Substring(args.CaretPos + 2);
                }
                while (args.StringToProcess.IndexOf('\'') != -1)
                {
                    args.escapedItem += args.StringToProcess.Replace("'", "''");
                    if (args.CaretPos <= args.StringToProcess.Length)
                    {
                        args.unescapedItem += args.StringToProcess;
                        args.StringToProcess = args.StringToProcess.Substring(args.CaretPos + 1);
                        args.CaretPos = 0;
                        if (args.CaretPos + 1 < args.StringToProcess.Length)
                        {
                            if (args.StringToProcess[args.CaretPos + 1] == '\'')
                            {
                                args.StringToProcess =
                                    args.StringToProcess.Substring(args.CaretPos + 2);
                            } 
                        }
                        args.CaretPos = args.StringToProcess.IndexOf('\'', args.CaretPos); 
                    }

                    if (!string.IsNullOrEmpty(args.StringToProcess) && args.StringToProcess.IndexOf('\'') != -1)
                    {
                        ProcessDDItem(args);
                    }
                }
            }
            // C#
            return args;
        }
        public static List<string> GetAllBrands()
        {
            MySqlConnection con = ConnectToDB.OpenDB();
            using (con)
            {
                string sql = "SELECT DISTINCT Brand FROM purchaseditems;";
                List<string> brands =
                        con.Query<string>(sql, commandType: CommandType.Text).AsList();
                return brands;
            }
        }

        public static List<ItemModel> GetItemsByBrand(string brand)
        {
            MySqlConnection con = ConnectToDB.OpenDB();
            using (con)
            {
                string sql = "SELECT * FROM purchaseditems where Brand = '" + brand + "';";
                List<ItemModel> models =
                        con.Query<ItemModel>(sql, commandType: CommandType.Text).AsList();
                return models;
            }
        }

        public static ItemModel GetItemByID(int itemID)
        {
            MySqlConnection con = ConnectToDB.OpenDB();
            using (con)
            {
                ItemModel model =
                        con.QuerySingle<ItemModel>("SELECT * FROM purchasedItems where ItemID = @ItemID",
                        new { ItemID = itemID }, commandType: CommandType.Text);
                return model;
            }
        }

        public static List<GenericModel> GetDropDownList(string tableName)
        {
            MySqlConnection con = ConnectToDB.OpenDB();
            using (con)
            {
                List<GenericModel> gvList = 
                        con.Query<GenericModel>("SELECT * FROM " + tableName + " order by Data", commandType: CommandType.Text). AsList();
                return gvList;
            }
        }

        public static void ModifySelectedFieldEntries(string oldItem, string newItem, string tableName, string itemColName)
        {
            int rows = 0;
            string sql = "update purchasedItems set " + itemColName + " = '" + newItem + "' where " + itemColName + " = '" + oldItem + "';" +
                $"select row_count() as rows_affected";
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

        /// <summary>
        /// Check for existing item in combo box list to prevent duplicates in database. 
        /// Returns true if item exists, false if not.
        /// </summary>
        /// <param name="cbo"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public static bool CheckForExistingItem(ComboBox cbo, string data)
        {
            MySqlConnection con = ConnectToDB.OpenDB();
            using (con)
            {
                string tableName = cbo.Tag.ToString();
                DropDownEventArgs args = new DropDownEventArgs();
                args.originalItem = data;
                args.StringToProcess = args.originalItem;
                args =DataAccess.RecursiveControlEscapeChars(data);
                data = args.escapedItem;

                string sql = "SELECT count(*) FROM " + tableName + " where Data = '" + data + "'";
                int count =
                        con.QuerySingle<int>(sql, new { Data = data }, commandType: CommandType.Text);
                return count > 0;
            }
        }

        public static bool CheckForExistingItem(string tableName, string data)
        {
            MySqlConnection con = ConnectToDB.OpenDB();
            using (con)
            {
                string sql = "SELECT count(*) FROM " + tableName + " where Data = '" + data + "'";
                int count =
                        con.QuerySingle<int>(sql, new { Data = data }, commandType: CommandType.Text);
                return count > 0;
            }
        }

        public static int AddNewItemToDropDownTable(ComboBox cbo)
        {
            int newID = -1;
            //check for existing item in database to prevent duplicates
            bool exists = Operations.IsExistingItem(cbo, cbo.Text);
            if (!exists)
            {
                string tableName = cbo.Tag.ToString();                
                DropDownEventArgs args = new DropDownEventArgs();
                args.originalItem = cbo.Text.Trim();
                DataAccess.RecursiveControlEscapeChars(args.originalItem);
                string sql = "INSERT INTO " + tableName + " (data) values ('" + cbo.Text + "')";
                MySqlConnection con = new MySqlConnection(GV.conString);
                con.Open();
                MySqlCommand cmd = new MySqlCommand(sql, con);
                object result = cmd.ExecuteScalar();
                newID = Convert.ToInt32(cmd.LastInsertedId);
                con.Close();
            }
            return newID;
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
            string sql = "INSERT INTO PurchasedItems (Category, ItemDesc, Color, PurchaseDate, PurchasePrice, " +
                "Quantity, SaleDate, SalePrice, StorageLocation, purchaseSource, Brand, ListingDate, WhereListed, " +
                "ListPrice, CostOfSale, DiscountPct) VALUES (@Category, " +
                "@ItemDesc, @Color, @PurchaseDate, @PurchasePrice, @Quantity, @SaleDate, @SalePrice, @StorageLocation," +
                "@PurchaseSource, @Brand, @DateListed, @WhereListed, @ListPrice, @CostOfSale, @DiscountPct )";
            MySqlConnection con = new MySqlConnection(GV.conString);
            con.Open();
            MySqlCommand cmd = new MySqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@DateListed", model.DateListed);
            cmd.Parameters.AddWithValue("@WhereListed", model.WhereListed);
            cmd.Parameters.AddWithValue("@Color", model.Color);
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
            cmd.Parameters.AddWithValue("@ListPrice", model.ListPrice);
            cmd.Parameters.AddWithValue("@CostOfSale", model.CostOfSale);
            cmd.Parameters.AddWithValue("@DiscountPct", model.DiscountPct);



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
                         "purchaseSource = @PurchaseSource, WhereListed = @WhereListed, Color = @Color, " +
                         "ListingDate = @DateListed, ListPrice = @ListPrice, CostOfSale = @CostOfSale, DiscountPct = @DiscountPct " +
                         "WHERE ItemID = @ItemID";
            MySqlConnection con = new MySqlConnection(GV.conString);
            con.Open();
            MySqlCommand cmd = new MySqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@DateListed", model.DateListed);
            cmd.Parameters.AddWithValue("@WhereListed", model.WhereListed);
            cmd.Parameters.AddWithValue("@Color", model.Color);
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
            cmd.Parameters.AddWithValue("@ListPrice", model.ListPrice);
            cmd.Parameters.AddWithValue("@CostOfSale", model.CostOfSale);
            cmd.Parameters.AddWithValue("@DiscountPct", model.DiscountPct);
            cmd.Parameters.AddWithValue("@ItemID", itemID);

            int rowsAffected = cmd.ExecuteNonQuery();
            con.Close();
            return rowsAffected;
        }

        public static void UpdateSingleDDItem(ComboBox cbo, string oldItem, string newItem)
        {
            string tableName = cbo.Tag.ToString();
            DropDownEventArgs args = new DropDownEventArgs();
            args.originalItem = oldItem;
            args = RecursiveControlEscapeChars(oldItem);
            oldItem = args.escapedItem;
            args.Reset();

            args.originalItem = newItem;
            args = RecursiveControlEscapeChars(newItem);
            newItem = args.escapedItem;
            
            MySqlConnection con = ConnectToDB.OpenDB();
            string sql = "update " + tableName + " set Data = '" + newItem + "' where Data = '" + oldItem + "'";
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
            DropDownEventArgs args = new DropDownEventArgs();
            args.originalItem = sql;
            //args = DataAccess.RecursiveControlEscapeChars(sql);
            //sql = args.escapedItem;
            List<ItemModel> list = new List<ItemModel>();
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
                if (reader["CostOfSale"] != DBNull.Value)
                    model.CostOfSale = Convert.ToDecimal(reader["CostOfSale"]);
                if (reader["ListPrice"] != DBNull.Value)
                    model.ListPrice = Convert.ToDecimal(reader["ListPrice"]);
                model.Quantity = Convert.ToInt32(reader["Quantity"]);
                if (reader["SaleDate"] != DBNull.Value)
                    model.SaleDate = Convert.ToDateTime(reader["SaleDate"]);
                if (reader["SalePrice"] != DBNull.Value)
                    model.SalePrice = Convert.ToDecimal(reader["SalePrice"]);
                if (reader["DiscountPct"] != DBNull.Value)
                {
                    model.DiscountPct = Convert.ToDecimal(reader["DiscountPct"]); 
                }
                model.StorageLocation = reader["StorageLocation"].ToString() ?? string.Empty;
                model.PurchaseSource = reader["PurchaseSource"].ToString() ?? string.Empty;
                model.Brand = reader["Brand"].ToString() ?? string.Empty;
                model.Color = reader["Color"].ToString() ?? string.Empty;

                if (reader["ListingDate"] != DBNull.Value)
                    model.DateListed = Convert.ToDateTime(reader["ListingDate"]);
                model.WhereListed = reader["WhereListed"].ToString() ?? string.Empty;
                list.Add(model);
            }
            con.Close();
            return list;
        }

        public static int DeleteDropDownItem(string tableName, int ID)
        {
            string sql = "delete from " + tableName + " where ID = " + ID + ";" + $"select row_count() as rows_affected; "; 
            MySqlConnection con = ConnectToDB.OpenDB();
            int rows = con.Execute(sql);
            return rows;
        }

        public static void DeleteRecord(int ID, string tableName)
        {
            string sql = "delete from " + tableName + " where ItemID = " + ID.ToString();
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

        public static List<GenericModel> ModifyListItem(string? oldItem, string newItem, List<GenericModel> list)
        {
            foreach (var item in list)
            {
                if (item.Data == oldItem)
                {
                    item.Data = newItem;
                }
            }
            return list;
        }
    }
}
