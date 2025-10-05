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
        ItemModel model = new ItemModel();
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
                    break;
                case Mode.Edit:
                    this.Text = this.Text + " Edit Item";
                    enableDisableControls(allControls, true);
                    dtpSaleDate.Format = DateTimePickerFormat.Long;
                    dtpSaleDate.Value = DateTime.Now;
                    txtID.Focus();  
                    break;
                case Mode.Delete:
                    this.Text = this.Text + " Delete Item";
                    break;
            }
        }

        ItemModel getItem()
        {
            string sql = "Select * from PurchasedItems where ItemID = " + txtID.Text;
            List<ItemModel> items = DataAccess.getModelList(sql);
            if (items.Count > 0)
            {
                model = items[0];
            }
            else
            {
                model = null;
                MessageBox.Show("Item not found.");
            }
            return model;
        }
        void placeDataOnForm(ItemModel model)
        {
            txtID.Text = model.ItemID.ToString();
            txtDesc.Text = model.ItemDesc;
            cboCategory.Text = model.Category;
            dtpBuy.Value = model.PurchaseDate;
            txtPurchasePrice.Text = model.PurchasePrice.ToString("0.00");
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
            if (model.SalePrice > 0.0M)
            {
                txtPrice.Text = model.SalePrice.ToString("0.00");
            }
            else
            {
                txtPrice.Text = "";
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
            dtpSaleDate.Format = DateTimePickerFormat.Custom;
            if (GV.MODE == Mode.Add)
            {
                dtpSaleDate.CustomFormat = " ";
            }
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
                    break;
                case Mode.Delete:
                    // Delete item from database
                    break;
            }
        }

        private ItemModel loadModel()
        {
            model.ItemDesc = txtDesc.Text;
            model.Category = cboCategory.Text;
            model.PurchaseDate = dtpBuy.Value;
            model.PurchasePrice = decimal.Parse(txtPurchasePrice.Text);
            model.Quantity = int.Parse(txtQuantity.Text);
            model.StorageLocation = cboStorage.Text;
            if (GV.MODE != Mode.Edit)
            {
                model.SaleDate = new DateTime(1900, 01, 01); 
                dtpSaleDate.Format = DateTimePickerFormat.Custom;
            }

            model.SalePrice = 0.0M;

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
                cboCategory.SelectedItem = model.Category;
            }
        }

        private void btnRetrieve_Click(object sender, EventArgs e)
        {
            ItemModel model = getItem();
            placeDataOnForm(model);
        }
    }
}
