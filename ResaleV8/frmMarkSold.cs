using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using ResaleV8_ClassLibrary;
using ResaleV8_ClassLibrary.DatabaseOps;
using ResaleV8_ClassLibrary.ExcelOps;
using ResaleV8_ClassLibrary.Models;
using ResaleV8_ClassLibrary.Ops;

namespace ResaleV8
{
   /// <summary>
   /// Represents a form that allows users to mark items as sold by retrieving, displaying, and updating item details.
   /// </summary>
   /// <remarks>This form provides functionality to retrieve item details from a database, display the details
   /// to the user,  and update the item's status as sold. It includes controls for entering an item ID, viewing item
   /// information,  and saving updates. The form interacts with a database to fetch and persist item data.</remarks>

    public partial class frmMarkSold : Form
    {
        //Form scope variables
        DataTable dt = new DataTable();
        Color defaultTxtBackColor;
        ItemModel itemModel = new ItemModel();
        int itemID = 0;

        public frmMarkSold()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Creates Control array for enabling/disabling controls
        /// Sets AcceptButton to btnRetrieve
        /// Sets defaultTxtBackColor to txtID.BackColor
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmMarkSold_Load(object sender, EventArgs e)
        {
            btnSave.Enabled = false;
            Control[] ctls = makeControlArray();
            FormControlOps.enableDisableControls(ctls, false);
            this.AcceptButton = btnRetrieve;
            defaultTxtBackColor = txtID.BackColor;
            dtpSaleDate.Value = DateTime.Now;
        }

        /// <summary>
        /// Connects to database and retrieves item details based on the provided item ID.
        /// If the item is found, it populates the form fields with the item details and enables the relevant controls.
        /// SETS the AcceptButton to btnSave and changes txtID background color to LightGreen.
        /// Loads the item model with the retrieved data.
        /// Sisplays a message box if the item ID is not found.
        /// Closes the database connection after the operation.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// 
        ///
        /// <remarks>This method assumes that the item ID entered in txtID is valid and can be converted to an integer.
        private void btnRetrieve_Click(object sender, EventArgs e)
        {
            MySqlConnection con = ConnectToDB.OpenDB();
            string query = "Select * from purchased_items where item_id = " + txtID.Text;
            dt = DataAccess.getData(con, query);
            ValueTuple<Button, Button> btnPair = (btnRetrieve, btnSave);
            FormControlOps.toggleControlPairEnables(btnPair);
            if (dt.Rows.Count == 1)
            {
                itemID = Convert.ToInt32(dt.Rows[0]["Item_ID"]);
                displayData(dt);
                if(dtpSaleDate.Value == GV.emptyDate)
                {
                    dtpSaleDate.Value = DateTime.Now;
                }
                this.AcceptButton = btnSave;
                txtID.BackColor = Color.LightGreen;
                loadItemModel(dt);
            }
            else
            {
                MessageBox.Show("Item ID not found.");
            }
            con.Close();
        }


        /// <summary>
        /// Populates form controls with data from the specified <see cref="DataTable"/>.
        /// </summary>
        /// <remarks>If the "Sale_Date" column contains a non-null value, the date picker control is set
        /// to that value.  Otherwise, the date picker is cleared. The method also enables a predefined set of controls 
        /// before populating the data.</remarks>
        /// <param name="dt">A <see cref="DataTable"/> containing the data to display.  The table must have at least one row, and the
        /// following columns are expected:  "Product_Age", "Sale_Price", "Profit", and "Sale_Date".</param>
        private void displayData(DataTable dt)
        {
            Control[] ctls = makeControlArray();
            FormControlOps.enableDisableControls(ctls, true);
            dtpSaleDate.Value = DateTime.Now;
            if (dt.Rows.Count > 0)
            {
                lblDaysOwned.Text = dt.Rows[0]["Product_Age"].ToString();
                txtPrice.Text = dt.Rows[0]["Sale_Price"].ToString();
                lblProfit.Text = dt.Rows[0]["Profit"].ToString();
                if (dt.Rows[0]["Sale_Date"] != DBNull.Value)
                {
                    dtpSaleDate.Value = Convert.ToDateTime(dt.Rows[0]["Sale_Date"]);
                }
                else
                {
                    ResaleV8_ClassLibrary.Ops.FormControlOps.clearDTPicker(dtpSaleDate);
                }
            }

        }

        /// <summary>
        /// enables/disables controls used in this form
        /// </summary>
        /// <returns></returns>
        private Control[] makeControlArray()
        {
            Control[] ctls = new Control[4];
            ctls[0] = lblDaysOwned;
            ctls[1] = txtPrice;
            ctls[2] = lblProfit;
            ctls[3] = dtpSaleDate;
            return ctls;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            txtID.BackColor = defaultTxtBackColor;
            itemModel.Sale_Date = dtpSaleDate.Value;
            itemModel.Sale_Price = Convert.ToSingle(txtPrice.Text);
            DataAccess.updateItemInDatabase(itemModel, itemID);
            MySqlConnection con =  ConnectToDB.OpenDB();
            dt = DataAccess.getData(con, "Select * from purchased_items where Item_ID = " + txtID.Text);
            if (dt.Rows.Count > 0)
            {
                loadItemModel(dt);
            }
            lblDaysOwned.Text = (itemModel.Sale_Date - itemModel.Purchase_Date).TotalDays.ToString();
            double profit = itemModel.Sale_Price - itemModel.Purchase_Price;

            if(itemModel.Sale_Date.Year == 1900)
            {
                lblProfit.Text = "0";
            }
            else
            {
                lblProfit.Text = (itemModel.Sale_Date - itemModel.Purchase_Date).TotalDays.ToString();
            }
;
            ValueTuple<Button, Button> btnPair = (btnRetrieve, btnSave);
            FormControlOps.toggleControlPairEnables(btnPair);
        }

        /// <summary>
        /// Populates the <see cref="itemModel"/> instance with data from the specified <see cref="DataTable"/>.
        /// </summary>
        /// <remarks>This method assumes that the provided <paramref name="dt"/> contains valid data in
        /// the expected format. If the "Sale_Date" or "Sale_Price" columns contain <see cref="DBNull.Value"/>, the
        /// corresponding properties in <see cref="itemModel"/> will not be set.</remarks>
        /// <param name="dt">A <see cref="DataTable"/> containing item data. The table must have at least one row, and the following
        /// columns are expected: "Item_Desc" (string), "Purchase_Date" (DateTime), "Purchase_Price" (float), "Quantity"
        /// (int), "storage_location" (string). Optional columns include "Sale_Date" (DateTime) and "Sale_Price"
        /// (float).</param>
        private void loadItemModel(DataTable dt)
        {
            itemModel.Item_Desc = dt.Rows[0]["Item_Desc"]?.ToString() ?? string.Empty;
            itemModel.Purchase_Date = Convert.ToDateTime(dt.Rows[0]["Purchase_Date"]);
            itemModel.Purchase_Price = Convert.ToSingle(dt.Rows[0]["Purchase_Price"]);
            itemModel.Quantity = Convert.ToInt32(dt.Rows[0]["Quantity"]);
            itemModel.storage_location = dt.Rows[0]["storage_location"]?.ToString() ?? string.Empty;
            if (dt.Rows[0]["Sale_Date"] != DBNull.Value)
            {
                itemModel.Sale_Date = Convert.ToDateTime(dt.Rows[0]["Sale_Date"]);
            }
            if (dt.Rows[0]["Sale_Price"] != DBNull.Value)
            {
                itemModel.Sale_Price = Convert.ToSingle(dt.Rows[0]["Sale_Price"]);
            }

        }

        
        private ItemModel getModelFromForm()
        {
            itemModel.Sale_Date = dtpSaleDate.Value;
            if (txtPrice.Text != "")
            {
                itemModel.Sale_Price = Convert.ToSingle(txtPrice.Text);
            }
            return itemModel;
        }
    }
}
