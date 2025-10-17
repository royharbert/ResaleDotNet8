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

        private string _task;

        public string Task
        {
            get
            {
                return _task;
            }
            set
            {
                _task = value;
                lblTask.Text = _task;
            }
        }


        ItemModel? model = new ItemModel();
        string[] allControls = { "txtDesc", "cboCategory", "dtpBuy", "txtPurchasePrice", "txtQuantity",
                        "cboStorageLocation", "dtpSaleDate", "txtPrice", "txtID", "btnRetrieve",  "btnSave", "btnAddAnother", "btnDelete",
                        "btnClose", "btnSearch"};
        void prepareForm()
        {
            string[] ctlsToEnable = { };
            switch (GV.MODE)
            {
                case Mode.Add:
                    this.Text = this.Text + " Add New Item";
                    disableAllControls();
                    ctlsToEnable = new string[] { "txtDesc", "cboCategory", "dtpBuy", "txtPurchasePrice", "txtQuantity",
                        "cboStorage", "btnSave", "btnClose" };
                    enableDisableControls(ctlsToEnable, true);
                    txtPrice.Text = "0";
                    this.AcceptButton = btnSave;
                    break;
                case Mode.Retrieve:
                    this.Text = this.Text + " Retrieve Item";
                    disableAllControls();
                    ctlsToEnable = new string[] { "txtID", "btnRetrieve", "btnClose" };
                    enableDisableControls(ctlsToEnable, true);
                    this.AcceptButton = btnRetrieve;
                    break;
                case Mode.Edit:
                    this.Text = this.Text + " Edit Item";
                    enableDisableControls(allControls, false);
                    ctlsToEnable = new string[] { "txtDesc", "cboCategory", "dtpBuy", "txtPurchasePrice", "txtQuantity",
                        "cboStorage", "txtPrice", "dtpSaleDate", "btnRetrieve", "btnClose", "txtItemID" };
                    enableDisableControls(ctlsToEnable, true);
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
                case Mode.Search:
                    enableDisableControls(allControls, false);
                    ctlsToEnable = new string[] { "txtDesc", "cboCategory", "dtpBuy", "txtPurchasePrice", "txtQuantity",
                        "cboStorage", "txtPrice", "dtpSaleDate", "btnSearch", "btnClose" };
                    enableDisableControls(ctlsToEnable, true);
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
                cboBrand.Text = model.Brand;
                cboPurchaseSource.Text = model.PurchaseSource;
                cboWhereListed.Text = model.WhereListed;
                if (model.WhereListed != "")
                {
                    dtpDateListed.Value = model.DateListed;
                    dtpDateListed.Format = DateTimePickerFormat.Long;
                }
                else
                {
                    ClearDTP(dtpDateListed);

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

        private void ClearDTP(DateTimePicker dtp)
        {
            dtp.Format = DateTimePickerFormat.Custom;
            dtp.CustomFormat = " ";
            dtp.Value = GV.emptyDate;
        }

        private void frmAllItems_Load(object sender, EventArgs e)
        {
            ClearDTP(dtpDateListed);
            ClearDTP(dtpSaleDate);
            cboWhereListed.DataSource = GV.WhereListed;
            cboWhereListed.SelectedIndex = -1;
            cboCategory.DataSource = GV.categories;
            cboCategory.SelectedIndex = -1;
            cboStorage.DataSource = GV.storageLocations;
            cboStorage.SelectedIndex = -1;
            cboBrand.DataSource = GV.Brands;
            cboBrand.SelectedIndex = -1;
            cboPurchaseSource.DataSource = GV.PurchaseSources;
            cboPurchaseSource.SelectedIndex = -1;

            prepareForm();
            //if (GV.MODE == Mode.Add)
            //{
            //    dtpSaleDate.Format = DateTimePickerFormat.Custom;
            //    dtpSaleDate.CustomFormat = " ";
            //}
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
                    if (newID != 0)
                    {
                        MessageBox.Show("Item Added");
                    }
                    btnAddAnother.Enabled = true;
                    break;
                case Mode.Edit:
                    // Update existing item in database
                    lblTask.Text = "Editing Item";
                    loadModel();
                    int rowsAffected = DataAccess.updateItemInDatabase(model, model.ItemID);
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Item Updated");
                    }
                    break;
                case Mode.Delete:
                    // Delete item from database
                    break;
            }
        }

        private ItemModel loadModel()
        {
            if (model != null)
            {
                model.WhereListed = cboWhereListed.Text;
                model.DateListed = dtpDateListed.Value; 
                model.PurchaseSource = cboPurchaseSource.Text;
                model.Brand = cboBrand.Text;
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
                txtProfit.Text = model.Profit.ToString("$0.00");
                txtDaysHeld.Text = model.ProductAge.ToString();

                return model;
            }
            else
            {
                MessageBox.Show("Error loading model");
                return null;
            }
        }



        private void comboListMaintenance(object sender, EventArgs e)
        {
            /*
             * Check to see if text is in items collection
             * If not, add it to listtrffrffd
             *  Insert it into data table
             */
            ComboBox cbo = sender as ComboBox;
            ddEventArgs ea = new ddEventArgs();
            if (!cbo.Items.Contains(cbo.Text) && cbo.Text != "")
            {
                switch (cbo.Name)
                {
                    case "cboCategory":
                        GV.categories.Add(cbo.Text);
                        GV.categories.Sort();
                        ea.newItem = cboCategory.Text;
                        ea.tableName = "Categories";
                        ea.columnName = "Category";
                        cboCategory.DataSource = null;
                        cboCategory.DataSource = GV.categories;
                        cboCategory.Text = ea.newItem;
                        break;
                    case "cboStorage":
                        GV.storageLocations.Add(cbo.Text);
                        GV.storageLocations.Sort();
                        ea.newItem = cboStorage.Text;
                        ea.tableName = "storageLocations";
                        ea.columnName = "Location";
                        cboStorage.DataSource = null;
                        cboStorage.DataSource = GV.storageLocations;
                        cboStorage.Text = ea.newItem;
                        break;
                    case "cboPurchaseSource":
                        GV.PurchaseSources.Add(cbo.Text);
                        GV.PurchaseSources.Sort();
                        ea.newItem = cboPurchaseSource.Text;
                        ea.tableName = "purchaseSources";
                        ea.columnName = "source";
                        cboPurchaseSource.DataSource = null;
                        cboPurchaseSource.DataSource = GV.PurchaseSources;
                        cboPurchaseSource.Text = ea.newItem;
                        break;
                    case "cboBrand":
                        GV.Brands.Add(cbo.Text);
                        GV.Brands.Sort();
                        ea.newItem = cboBrand.Text;
                        ea.tableName = "brands";
                        ea.columnName = "brand";
                        cboBrand.DataSource = null;
                        cboBrand.DataSource = GV.Brands;
                        cboBrand.Text = ea.newItem;
                        break;
                    case "cboWhereListed":
                        GV.WhereListed.Add(cbo.Text);
                        GV.WhereListed.Sort();
                        ea.newItem = cboWhereListed.Text;
                        ea.tableName = "WhereListed";
                        ea.columnName = "Listed";
                        cboWhereListed.DataSource = null;
                        cboWhereListed.DataSource = GV.WhereListed;
                        cboWhereListed.Text = ea.newItem;
                        break;
                }
                DataAccess.addDropDownItemToTable(ea);
            }
        }

        private void btnRetrieve_Click(object sender, EventArgs e)
        {
            ItemModel? model = getItem();
            if (model != null)
            {
                GV.MODE = Mode.Edit;
                disableAllControls();
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
                string[] ctlsToEnable = new string[] { "txtDesc", "cboCategory", "dtpBuy", "txtPurchasePrice", "txtQuantity",
                        "cboStorage", "txtPrice", "dtpSaleDate", "btnSave", "btnClose" };
                enableDisableControls(ctlsToEnable, true);
                this.AcceptButton = btnSave;
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
                DataAccess.deleteRecord(Convert.ToInt32(txtID.Text), "purchasedItems");
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

        private void clearForm()
        {
            model = new ItemModel();
            txtPrice.Text = "0";
            txtProfit.Text = "";
            txtDaysHeld.Text = "";
            txtDesc.Text = "";
            txtPurchasePrice.Text = "";
            txtID.Text = "";
            txtID.Enabled = false;
            txtQuantity.Text = "1";
            dtpSaleDate.Format = DateTimePickerFormat.Custom;
            dtpSaleDate.CustomFormat = " ";
            cboCategory.SelectedIndex = -1;
            cboCategory.Text = "";
            cboStorage.SelectedIndex = -1;
            cboStorage.Text = "";
            this.AcceptButton = btnSave;
            disableAllControls();
            string[] ctlsToEnable = { "txtDesc", "cboCategory", "dtpPurchaseDate", "txtPurchasePrice", "txtQuantity",
                        "cboStorage", "btnSave", "btnClose" };
            enableDisableControls(ctlsToEnable, true);
            cboCategory.Focus();
        }

        private void btnAddAnother_Click(object sender, EventArgs e)
        {
            clearForm();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            GV.MODE = Mode.Search;

            txtQuantity.Text = "";
            List<(string, string)> searchQuery = buildSearchQuery();
            string sql = "Select * from purchasedItems where ";
            foreach ((string, string) c in searchQuery)
            {
                sql = sql + c.Item1 + " = '" + c.Item2 + "' and ";
            }
            sql = sql.Substring(0, sql.Length - 5);
            List<ItemModel> models = DataAccess.getModelList(sql);
            frmSearchResults resultsForm = new frmSearchResults();
            resultsForm.Models = models;
            resultsForm.ShowDialog();
        }

        private List<(string, string)> buildSearchQuery()
        {
            List<(string, string)> result = new List<(string, string)>();
            foreach (Control ctl in this.Controls)
            {
                if (ctl is System.Windows.Forms.TextBox || ctl is ComboBox)
                {
                    if (ctl.Tag != null && ctl.Text != "")
                    {
                        result.Add((ctl.Tag.ToString(), ctl.Text));
                    }
                }
            }
            //result.Add((dtpBuy.Tag.ToString(), dtpBuy.Value.ToString("yyyy-MM-dd")));
            //result.Add((dtpSaleDate.Tag.ToString(), dtpSaleDate.Value.ToString("yyyy-MM-dd")));
            return result;
        }

        private void cboStorage_Leave(object sender, EventArgs e)
        {
            comboListMaintenance(sender, e);
        }

        private void cboPurchaseSource_Leave(object sender, EventArgs e)
        {
            comboListMaintenance(sender, e);
        }

        private void cboBrand_Leave(object sender, EventArgs e)
        {
            comboListMaintenance(sender, e);
        }

        private void cboPurchaseSource_Leave_1(object sender, EventArgs e)
        {
            comboListMaintenance(sender, e);
        }

        private void cboWhereListed_Leave(object sender, EventArgs e)
        {
            comboListMaintenance(sender, e);
            if(cboWhereListed.Text != "")
            {
                dtpDateListed.Value = DateTime.Now;
                dtpDateListed.Format = DateTimePickerFormat.Long;
            }
            else
            {
                ClearDTP(dtpDateListed);
            }
        }
    }
}
