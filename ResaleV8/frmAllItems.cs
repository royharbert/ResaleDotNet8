using Microsoft.Office.Interop.Excel;
using ResaleV8_ClassLibrary;
using ResaleV8_ClassLibrary.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ResaleV8
{
    public partial class frmAllItems : Form
    {
        private int _item;
        /// <summary>
        /// Property to accept ItemID from calling form
        /// </summary>
        public int item
        {
            get
            {
                return _item;
            }

            set
            {
                _item = value;
                txtID.Text = _item.ToString();
                btnRetrieve.PerformClick();
                if (model.SaleDate > new DateTime(1900, 01, 01))
                {
                    txtProfit.Enabled = true;
                    txtProfit.Text = model.Profit.ToString("$0.00");
                    txtDaysHeld.Enabled = true;
                    txtDaysHeld.Text = model.ProductAge.ToString();
                }
                else
                {
                    dtpSaleDate.Format = DateTimePickerFormat.Custom;
                    dtpSaleDate.CustomFormat = " ";
                }
            }
        }

        ItemModel? model = new ItemModel();
        string[] allControls = { "txtDesc", "cboCategory", "dtpPurchaseDate", "txtPurchasePrice", "txtQuantity",
                        "StorageLocation", "dtpSaleDate", "txtPrice", "txtID" };
        void prepareForm()
        {
            switch (GV.MODE)
            {
                case Mode.Add:
                    this.Text = this.Text + " Add New Item";
                    disableAllControls();
                    string[] ctlsToEnable = { "txtDesc", "cboCategory", "dtpPurchaseDate", "txtPurchasePrice", "txtQuantity",
                        "txtStorage" };
                    enableDisableControls(ctlsToEnable, true);
                    txtPrice.Text = "0";
                    this.AcceptButton = btnSave;
                    break;
                case Mode.Edit:
                    this.Text = this.Text + " Edit Item";
                    enableDisableControls(allControls, true);
                    if (model != null && model.SalePrice == 0)
                    {
                        txtPrice.Text = "0";
                    }
                    this.AcceptButton = btnRetrieve;
                    break;
                case Mode.Delete:
                    this.Text = this.Text + " Delete Item";
                    this.AcceptButton = btnDelete;
                    enableDisableControls(allControls, false);
                    txtID.Enabled = true;
                    break;
            }
        }

        ItemModel? getItem()
        {
            string sql = "";
            if (txtID.Text != "")
            {
                sql = "Select * from PurchasedItems where ItemID = " + txtID.Text;
            }
            else
            {
                enableDisableControls(allControls, false);
                txtID.Enabled = true;
                MessageBox.Show("Please enter an Item ID");
                return null;
            }
            List<ItemModel> items = DataAccess.getModelList(sql);
            if (items.Count > 0)
            {
                model = items[0];
            }
            else
            {
                model = null;
            }

            return model;
        }
        void placeDataOnForm(ItemModel model)
        {
            if (model != null && model.ItemID != 0)
            {
                txtID.Text = model.ItemID.ToString();
                txtDesc.Text = model.ItemDesc;
                cboCategory.Text = model.Category;
                dtpBuy.Value = model.PurchaseDate;
                txtPurchasePrice.Text = model.PurchasePrice.ToString("$0.00");
                txtQuantity.Text = model.Quantity.ToString();
                cboStorage.Text = model.StorageLocation;
                if (model.SaleDate > new DateTime(1900, 01, 01))
                {
                    dtpSaleDate.Value = model.SaleDate;
                    dtpSaleDate.Format = DateTimePickerFormat.Long;
                }
                else
                {
                    dtpSaleDate.Format = DateTimePickerFormat.Custom;
                    dtpSaleDate.CustomFormat = " ";
                }
                if (model.SalePrice > 0)
                {
                    txtPrice.Text = model.SalePrice.ToString("$0.00");
                }
                else
                {
                    txtPrice.Text = "0";
                }
            }
        }

        void disableAllControls()
        {
            enableDisableControls(allControls, false);
        }
        void enableDisableControls(string[] controlArray, bool enable)
        {
            foreach (string ctrlName in controlArray)
            {
                Control[] ctrls = this.Controls.Find(ctrlName, true);
                if (ctrls.Length > 0)
                {
                    ctrls[0].Enabled = enable;
                }
            }
        }
        public frmAllItems()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmAllItems_Load(object sender, EventArgs e)
        {
            cboCategory.DataSource = GV.categories;
            cboCategory.SelectedIndex = -1;
            cboStorage.DataSource = GV.storageLocations;
            cboStorage.SelectedIndex = -1;
            prepareForm();
            if (GV.MODE == Mode.Add)
            {
                dtpSaleDate.Format = DateTimePickerFormat.Custom;
                dtpSaleDate.CustomFormat = " ";
            }
            txtID.Focus();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            switch (GV.MODE)
            {
                case Mode.Add:
                    // Add new item to database
                    loadModel();
                    int newID = DataAccess.addItemToDatabase(model);
                    txtID.Text = newID.ToString();
                    break;
                case Mode.Edit:
                    // Update existing item in database
                    loadModel();
                    DataAccess.updateItemInDatabase(model, model.ItemID);
                    break;
                case Mode.Delete:
                    // Delete item from database
                    break;
            }
        }

        private ItemModel loadModel()
        {
            if (model == null)
            {
                model = new ItemModel();
            }
            model.ItemDesc = txtDesc.Text;
            model.Category = cboCategory.Text;
            model.PurchaseDate = dtpBuy.Value;
            if (txtPurchasePrice.Text.Contains('$'))
            {
                model.PurchasePrice = Convert.ToDecimal(txtPurchasePrice.Text.Substring(1));
            }
            else
            {
                model.PurchasePrice = Convert.ToDecimal(txtPurchasePrice.Text);
            }
            model.Quantity = int.Parse(txtQuantity.Text);
            model.StorageLocation = cboStorage.Text;
            if (GV.MODE != Mode.Edit)
            {
                model.SaleDate = new DateTime(1900, 01, 01);
                dtpSaleDate.Format = DateTimePickerFormat.Custom;
            }
            else
            {
                model.SaleDate = dtpSaleDate.Value;
                dtpSaleDate.Format = DateTimePickerFormat.Long;
                dtpSaleDate.Value = DateTime.Now;
            }

            if (txtPrice.Text.Contains('$'))
            {
                model.SalePrice = Convert.ToDecimal(txtPrice.Text.Substring(1));
            }
            else
            {
                model.SalePrice = Convert.ToDecimal(txtPrice.Text);
            }
            //txtProfit.Enabled = true;
            txtProfit.Text = model.Profit.ToString("$0.00");
            //txtDaysHeld.Enabled = true;
            txtDaysHeld.Text = model.ProductAge.ToString();

            return model;
        }

        private void comboListMaintenance(object sender, EventArgs e)
        {
            /*
             * Check to see if text is in items collection
             * If not, add it to list
             *  Insert it into data table
             */
            ComboBox cbo = sender as ComboBox;
            ddEventArgs ea = new ddEventArgs();
            if (!cbo.Items.Contains(cbo.Text) && cbo.Text != "")
            {
                GV.categories.Add(cbo.Text);
                GV.categories.Sort();
                if (cbo.Name == "cboCategory")
                {
                    {
                        ea.newItem = cboCategory.Text;
                        ea.tableName = "Categories";
                        ea.columnName = "Category";
                    }
                }
                ;

                if (cbo.Name == "cboStorage")
                {
                    ea.newItem = cboStorage.Text;
                    ea.tableName = "storageLocations";
                    ea.columnName = "Location";
                }
                DataAccess.addDropDownItemToTable(ea);


                cboCategory.DataSource = null;
                cboCategory.DataSource = GV.categories;
                cboCategory.Text = ea.newItem;
            }
        }

        private void btnRetrieve_Click(object sender, EventArgs e)
        {
            ItemModel? model = getItem();
            if (model != null)
            {
                placeDataOnForm(model);
                if (model.SalePrice == 0)
                {
                    dtpSaleDate.CustomFormat = " ";
                    dtpSaleDate.Format = DateTimePickerFormat.Custom;
                    dtpSaleDate.Value = GV.emptyDate;
                }
                else
                {
                    dtpSaleDate.Format = DateTimePickerFormat.Long;
                    dtpSaleDate.Value = DateTime.Now;
                }
                txtID.Enabled = false;
            }
            else
            {
                MessageBox.Show("Item not found");
            }
            this.AcceptButton = btnSave;
        }

        private void btnDelete_Click_1(object sender, EventArgs e)
        {
            getItem();
            placeDataOnForm(model);
            DialogResult dr = MessageBox.Show("Are you sure?", "Confirm Delete",
                MessageBoxButtons.OKCancel);
            if (dr == DialogResult.OK)
            {
                DataAccess.deleteRecord(Convert.ToInt32(txtID.Text));
                MessageBox.Show("Item Deleted");
            }

        }

        private void cboCategory_Leave(object sender, EventArgs e)
        {
            comboListMaintenance(sender, e);
        }

        private void txtPrice_Leave(object sender, EventArgs e)
        {
            if (txtPrice.Text != "0")
            {
                dtpSaleDate.Format = DateTimePickerFormat.Long;
                dtpSaleDate.Value = DateTime.Now;
            }
            else
            {
                dtpSaleDate.Format = DateTimePickerFormat.Custom;
                dtpSaleDate.CustomFormat = " ";
            }
        }
    }
}
