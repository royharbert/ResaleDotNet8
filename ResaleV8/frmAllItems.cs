using Microsoft.Office.Interop.Excel;
using ResaleV8_ClassLibrary;
using ResaleV8_ClassLibrary.Models;
using ResaleV8_ClassLibrary.Ops;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ResaleV8
{
    public partial class frmAllItems : Form
    {
        private bool formDirty = false;
        private bool formLoading = false;
        private int _item;

        /// <summary>
        /// Property to accept ItemID from calling form
        /// </summary>
        public int item
        {
            get => _item;

            set
            {
                _item = value;
                txtID.Text = _item.ToString();
                //btnRetrieve.PerformClick();
                ItemModel? model = DataAccess.GetItemByID(_item);
                placeDataOnForm(model);
                if (model.SaleDate <= GV.emptyDate)
                {
                    dtpSaleDate.Format = DateTimePickerFormat.Custom;
                    dtpSaleDate.CustomFormat = " ";
                }
                else
                {
                    txtProfit.Enabled = true;
                    txtProfit.Text = model.Profit.ToString("$0.00");
                    txtDaysHeld.Enabled = true;
                    txtDaysHeld.Text = model.ProductAge.ToString();
                }
                changeMode(Mode.Edit);
                this.Task = "Edit Item";
                prepareForm();
            }
        }

        private string? _task;

        public string Task
        {
            get => _task;
            set
            {
                _task = value;
                lblTask.Text = _task;
            }
        }

        private void MarkFormDirty(object sender, EventArgs e)
        {
            if (!formLoading)
            {
                formDirty = true;
            }
        }

        public ItemModel? model = new ItemModel();
        string[] allControls = { "txtID", "cboBrand", "cboCategory", "txtDesc", "cboPurchaseSource", "dtpBuy",
                        "txtQuantity", "txtPurchasePrice", "cboWhereListed", "cboStorage", "dtpDateListed", "txtListPrice",
                        "txtPrice", "txtCostOfSale", "DiscountPct", "dtpSaleDate", "txtProfit", "txtDaysHeld", "txtSKU" };

        string[] allButtons = { "btnRetrieve",  "btnSave",
                        "btnDelete", "btnClose", "btnSearch", "cboWhereListed", "dtpDateListed",
                        "cboBrand", "cboPurchaseSource", "txtListPrice", "txtCostOfSale"};

        string[] addButtons = { "btnSave", "btnClose" };

        string[] addControls = { "cboBrand", "cboCategory", "txtDesc", "cboPurchaseSource", "dtpBuy", "txtQuantity", "txtPurchasePrice",
                        "cboWhereListed", "cboStorage", "dtpDateListed", "txtListPrice", "txtSalePrice", "txtSKU", "txtDiscountPct" };

        string[] retrieveButtons = { "btnRetrieve", "btnClose" };

        string[] retrieveControls = { "txtID" };

        string[] editButtons = { "btnSave", "btnClose" };

        string[] editControls = { "cboBrand", "cboCategory", "txtDesc", "cboPurchaseSource", "dtpBuy", "txtQuantity", "txtPurchasePrice",
                        "cboWhereListed", "cboStorage", "dtpDateListed", "txtListPrice", "txtPrice", "txtCostOfSale", "txtDiscountPct",
                        "dtpSaleDate", "txtProfit", "txtDaysHeld", "txtSKU" };

        string[] deleteButtons = { "btnDelete", "btnClose" };

        string[] deleteControls = { "txtID" };

        string[] searchButtons = { "btnSearch", "btnClose" };

        string[] searchControls = { "txtID", "cboBrabd", "txtDesc", "cboCategory",
                        "dtpBuy", "txtPurchasePrice", "txtQuantity", "cboWhereListed", "dtpDateListed", "txtListPrice",
                        "cboStorage", "txtPrice", "dtpSaleDate", "cboPurchaseSource", "cboBrand", "txtSKU", "txtDiscountPct" };


        void changeMode(Mode mode)
        {
            GV.MODE = mode;
            prepareForm();
            switch (mode)
            {
                case Mode.Add:
                    cboBrand.Focus();
                    break;
                case Mode.Retrieve:
                    txtID.Focus();
                    break;
                case Mode.Edit:
                    cboBrand.Focus();
                    break;
                case Mode.Delete:
                    txtID.Focus();
                    break;
                case Mode.Search:
                    txtID.Focus();
                    break;

            }
            prepareForm();
        }

        void prepareForm()
        {
            string[] buttonsToEnable = { };
            string[] controlsToEnable = { };
            switch (GV.MODE)
            {
                case Mode.Add:
                    this.Text = this.Text + " Add New Item";
                    disableAllControls();
                    enableDisableButtons(addButtons, true);
                    enableDisableControls(allControls, true);
                    txtID.Enabled = false;
                    cboBrand.Focus();
                    txtPrice.Text = "";
                    this.AcceptButton = btnSave;
                    break;
                case Mode.Retrieve:
                    this.Text = this.Text + " Retrieve Item";
                    txtID.Focus();
                    disableAllControls();
                    enableDisableControls(retrieveControls, true);
                    enableDisableButtons(retrieveButtons, true);
                    this.AcceptButton = btnRetrieve;
                    break;
                case Mode.Edit:
                    this.Text = this.Text + " Edit Item";
                    enableDisableButtons(allButtons, false);
                    enableDisableControls(editControls, true);
                    enableDisableButtons(editButtons, true);
                    if (model != null && model.SalePrice == 0)
                    {
                        txtPrice.Text = "";
                    }
                    this.AcceptButton = btnSave;
                    break;
                case Mode.Delete:
                    this.Text = this.Text + " Delete Item";
                    this.AcceptButton = btnDelete;
                    disableAllControls();
                    enableDisableControls(deleteControls, true);
                    enableDisableButtons(deleteButtons, true);
                    txtID.Enabled = true;
                    break;
                case Mode.Search:
                    this.AcceptButton = btnRetrieve;
                    disableAllControls();
                    enableDisableButtons(searchButtons, true);
                    enableDisableControls(searchControls, true);
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
                //enableDisableControls(allControls, false);
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
                formLoading = true;
                txtID.Text = model.ItemID.ToString();
                txtDesc.Text = model.ItemDesc;
                cboCategory.Text = model.Category;
                dtpBuy.Value = model.PurchaseDate;
                txtPurchasePrice.Text = model.PurchasePrice.ToString("$0.00");
                txtCostOfSale.Text = model.CostOfSale.ToString("$0.00");
                txtDiscountPct.Text = model.DiscountPct.ToString("0.00");
                txtQuantity.Text = model.Quantity.ToString();
                cboStorage.Text = model.StorageLocation;
                txtListPrice.Text = model.ListPrice.ToString("$0.00");
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
                txtSKU.Text = model.ListerSKU;
                if (model.DateListed > new DateTime(1900, 01, 01))
                {
                    dtpDateListed.Value = model.DateListed;
                    dtpDateListed.Format = DateTimePickerFormat.Long;
                }
                else
                {
                    FormControlOps.ClearDTP(dtpDateListed);
                }
                if (model.WhereListed == "Poshmark")
                {
                    calculateCostOfSale(model.SalePrice, model.WhereListed);
                }
                txtCostOfSale.Text = model.CostOfSale.ToString("$0.00");
                txtDaysHeld.Text = model.ProductAge.ToString();
                if (model.Profit > 0)
                {
                    txtProfit.Text = model.Profit.ToString("$0.00");
                }
                formLoading = false;
            }
        }

        private void calculateCostOfSale(decimal salePrice, string whereListed)
        {
            switch (whereListed)
            {
                case "Poshmark":
                    model.CostOfSale = salePrice * 0.2M;
                    txtCostOfSale.Text = model.CostOfSale.ToString("$0.00");
                    break;
            }
        }

        void disableAllControls()
        {
            enableDisableButtons(allButtons, false);
            enableDisableControls(allControls, false);
        }

        void enableDisableButtons(string[] controlArray, bool enable)
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

        private frmMain parent;


        public frmAllItems()
        {
            parent = GV.MainForm as frmMain;
            InitializeComponent();

            parent.OnDatabaseModeChanged += Parent_OnDatabaseModeChanged;
        }


        private void Parent_OnDatabaseModeChanged(object? sender, DataModeChangedEventArgs e)
        {

            FormControlOps.SetDBModeIndicator(lblDBMode, e);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmAllItems_Load(object sender, EventArgs e)
        {
            formLoading = true;
            lblDBMode.Text = GV.dbMode.ToString();
            lblDBMode.BackColor = Color.LightGreen;
            FormControlOps.ClearDTP(dtpDateListed);
            FormControlOps.ClearDTP(dtpSaleDate);
            cboWhereListed.DataSource = GV.WhereListed;
            cboWhereListed.DisplayMember = "Data";
            cboWhereListed.SelectedIndex = -1;
            cboCategory.DataSource = GV.Categories;
            cboCategory.DisplayMember = "Data";
            cboCategory.SelectedIndex = -1;
            cboStorage.DataSource = GV.StorageLocations;
            cboStorage.DisplayMember = "Data";
            cboStorage.SelectedIndex = -1;
            cboBrand.DataSource = GV.Brands;
            cboBrand.DisplayMember = "Data";
            cboBrand.SelectedIndex = -1;
            cboPurchaseSource.DataSource = GV.PurchaseSources;
            cboPurchaseSource.DisplayMember = "Data";
            cboPurchaseSource.SelectedIndex = -1;

            prepareForm();
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
                    clearForm();
                    formDirty = false;
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
                    formDirty = false;
                    break;
                case Mode.Delete:
                    // Delete item from database
                    break;
            }
            Close();
        }

        private ItemModel loadModel()
        {
            if (model != null)
            {
                model.WhereListed = cboWhereListed.Text;
                model.ListerSKU = txtSKU.Text;
                model.DateListed = dtpDateListed.Value;
                model.PurchaseSource = cboPurchaseSource.Text;
                model.Brand = cboBrand.Text;
                model.ItemDesc = txtDesc.Text;
                model.Category = cboCategory.Text;
                model.PurchaseDate = dtpBuy.Value;
                if (txtCostOfSale.Text.Contains('$'))
                {
                    model.CostOfSale = Convert.ToDecimal(txtCostOfSale.Text.Substring(1));
                }
                else
                {
                    if (txtCostOfSale.Text != "")
                    {
                        model.CostOfSale = Convert.ToDecimal(txtCostOfSale.Text);
                    }
                }
                if (txtListPrice.Text.Contains('$'))
                {
                    model.ListPrice = Convert.ToDecimal(txtListPrice.Text.Substring(1));
                }
                else
                {
                    if (txtListPrice.Text != "")
                    {
                        model.ListPrice = Convert.ToDecimal(txtListPrice.Text);
                    }
                }
                if (txtPurchasePrice.Text.Contains('$'))
                {
                    model.PurchasePrice = Convert.ToDecimal(txtPurchasePrice.Text.Substring(1));
                }
                else
                {
                    if (txtPurchasePrice.Text != "")
                    {
                        model.PurchasePrice = Convert.ToDecimal(txtPurchasePrice.Text);
                    }
                }
                model.Quantity = int.Parse(txtQuantity.Text);
                model.StorageLocation = cboStorage.Text;

                if (txtPrice.Text != "")
                {
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
                }

                return model;
            }
            else
            {
                MessageBox.Show("Error loading model");
                return null;
            }
        }

        private void AddItemIfNeeded(ddEventArgs ea, List<GenericModel> ddList)
        {
            bool itemExists = false;
            foreach (GenericModel item in ddList)
            {
                if (item.Data.Contains(ea.newItem))
                {
                    itemExists = true;
                    break;
                }

            }
            if (!itemExists)
            {
                DataAccess.addDropDownItemToTable(ea);
            }
        }

        private ddEventArgs CreateEventArgs(string newItem, string tableName,
            string columnName, List<GenericModel> list)
        {
            ddEventArgs ea = new ddEventArgs();
            ea.newItem = newItem;
            ea.tableName = tableName;
            ea.columnName = columnName;
            ea.gvList = list;
            return ea;
        }

        private void comboListMaintenance(object sender, EventArgs e)
        {
            /*
            * Check for single quotes in text
            * If found, escape them
            * Check to see if text is in items collection
            * If not, add it to list
            *  Insert it into data table
            */
            ComboBox? cbo = sender as ComboBox;
            string? originalItem = cbo.Text;
            //ddEventArgs ea = new ddEventArgs();
            GenericModel gm = new GenericModel();
            string escapedItem = Operations.EscapeApostrophes(originalItem);
            //if (item.Contains("''"))
            //{
            //    return;
            //}
            //if (item.Contains("'"))
            //{
            //    item = item.Replace("'", "''");
            //}
            bool itemExists = false;
            foreach (GenericModel item in cbo.Items)
            {
                itemExists = item.Data == originalItem;
                if (itemExists) break;
            }
            if (!itemExists && cbo.Text != "")
            {
                // Not in list, so add it refresh list add item to table
                switch (cbo.Name)
                {
                    case "cboCategory":
                        List<GenericModel> existingCategories = DataAccess.GetDropDownList("Categories");
                        ddEventArgs ea = CreateEventArgs(escapedItem, "Categories", "Data", existingCategories);
                        AddItemIfNeeded(ea, existingCategories);
                        GV.Categories = DataAccess.GetDropDownList("Categories");
                        cboCategory.DataSource = null;
                        cboCategory.DataSource = GV.Categories;
                        cboCategory.DisplayMember = "Data";
                        cboCategory.Text = ea.newItem;
                        break;
                    case "cboStorage":
                        List<GenericModel> existingStorage = DataAccess.GetDropDownList("storageLocations");
                        ea = CreateEventArgs(escapedItem, "storageLocations", "Data", existingStorage);
                        AddItemIfNeeded(ea, existingStorage);
                        GV.StorageLocations = DataAccess.GetDropDownList(ea.tableName);
                        cboStorage.DataSource = null;
                        cboStorage.DataSource = GV.StorageLocations;
                        cboStorage.DisplayMember = "Data";
                        cboStorage.Text = ea.newItem;
                        break;
                    case "cboPurchaseSource":
                        List<GenericModel> existingPurchaseSources = DataAccess.GetDropDownList("PurchaseSources");
                        ea = CreateEventArgs(escapedItem, "purchaseSources", "Data", existingPurchaseSources);
                        AddItemIfNeeded(ea, existingPurchaseSources);
                        GV.PurchaseSources = DataAccess.GetDropDownList(ea.tableName);
                        cboPurchaseSource.DataSource = null;
                        cboPurchaseSource.DataSource = GV.PurchaseSources;
                        cboPurchaseSource.DisplayMember = "Data";
                        cboPurchaseSource.Text = ea.newItem;
                        break;
                    case "cboBrand":
                        List<GenericModel> existingBrands = DataAccess.GetDropDownList("Brands");
                        ea = CreateEventArgs(escapedItem, "brands", "Data", existingBrands);
                        AddItemIfNeeded(ea, existingBrands);
                        GV.Brands = DataAccess.GetDropDownList(ea.tableName);
                        cboBrand.DataSource = null;
                        cboBrand.DataSource = GV.Brands;
                        cboBrand.DisplayMember = "Data";
                        cboBrand.Text = ea.newItem;
                        break;
                    case "cboWhereListed":
                        List<GenericModel> existingListLocations = DataAccess.GetDropDownList("WhereListed");
                        ea = CreateEventArgs(escapedItem, "WhereListed", "Data", existingListLocations);
                        AddItemIfNeeded(ea, existingListLocations);
                        GV.WhereListed = DataAccess.GetDropDownList(ea.tableName);
                        cboWhereListed.DataSource = null;
                        cboWhereListed.DataSource = GV.WhereListed;
                        cboWhereListed.DisplayMember = "Data";
                        cboWhereListed.Text = ea.newItem;
                        break;
                }

            }
        }

        private void btnRetrieve_Click(object sender, EventArgs e)
        {
            ItemModel? model = getItem();
            if (model != null)
            {
                changeMode(Mode.Edit);
                placeDataOnForm(model);
                if (model.SalePrice == 0)
                {
                    dtpSaleDate.CustomFormat = " ";
                    dtpSaleDate.Format = DateTimePickerFormat.Custom;
                    dtpSaleDate.Value = GV.emptyDate;
                }
                string[] ctlsToEnable = new string[] { "txtDesc", "cboCategory", "dtpBuy", "txtPurchasePrice", "txtQuantity",
                        "cboStorage", "txtPrice", "dtpSaleDate", "btnSave", "btnClose" };
                //enableDisableControls(ctlsToEnable, true);
                this.AcceptButton = btnSave;
            }
            else
            {
                MessageBox.Show("Item not found");
            }
            btnRetrieve.Enabled = false;
            btnSave.Enabled = true;
            this.AcceptButton = btnSave;
        }

        private void btnDelete_Click_1(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Are you sure?", "Confirm Delete",
               MessageBoxButtons.OKCancel);
            if (dr == DialogResult.OK)
            {
                DataAccess.DeleteRecord(Convert.ToInt32(txtID.Text), "purchasedItems");
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
                if (txtPrice.Text != "")
                {
                    model.SalePrice = Convert.ToDecimal(txtPrice.Text.Replace("$", ""));
                }
                txtPrice.Text = model.SalePrice.ToString("$0.00");
            }
            else
            {
                dtpSaleDate.Format = DateTimePickerFormat.Custom;
                dtpSaleDate.CustomFormat = " ";
            }
            if (model.WhereListed == "Poshmark" || cboWhereListed.Text == "Poshmark")
            {
                calculateCostOfSale(model.SalePrice, "Poshmark");
            }
            txtProfit.Enabled = true;
            txtProfit.Text = model.Profit.ToString("$0.00");
            txtDaysHeld.Enabled = true;
            txtDaysHeld.Text = model.ProductAge.ToString();
        }

        private void clearForm()
        {
            model = new ItemModel();
            txtDiscountPct.Text = "";
            txtPrice.Text = "";
            txtProfit.Text = "";
            txtDaysHeld.Text = "";
            txtDesc.Text = "";
            txtPurchasePrice.Text = "";
            txtID.Text = "";
            txtID.Enabled = false;
            txtSKU.Text = "";
            txtListPrice.Text = "";
            txtQuantity.Text = "1";
            txtCostOfSale.Text = "";
            dtpSaleDate.Format = DateTimePickerFormat.Custom;
            dtpSaleDate.CustomFormat = " ";
            cboBrand.SelectedIndex = -1;
            cboBrand.Text = "";
            cboPurchaseSource.SelectedIndex = -1;
            cboPurchaseSource.Text = "";
            cboCategory.SelectedIndex = -1;
            cboCategory.Text = "";
            cboStorage.SelectedIndex = -1;
            cboStorage.Text = "";
            cboWhereListed.SelectedIndex = -1;
            cboWhereListed.Text = "";
            this.AcceptButton = btnSave;
            //disableAllControls();
            //string[] ctlsToEnable = { "txtDesc", "cboCategory", "dtpBuy", "dtpDateListed", "txtPurchasePrice", "txtQuantity",
            //            "cboStorage", "btnSave", "btnClose", "txtSKU" };
            //enableDisableControls(ctlsToEnable, true);
            cboCategory.Focus();

        }

        private void btnAddAnother_Click(object sender, EventArgs e)
        {
            clearForm();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            changeMode(Mode.Search);
            txtQuantity.Text = "";
            List<(string, string)> searchQuery = buildSearchQuery();
            string sql = "Select * from purchasedItems where ";
            foreach ((string, string) c in searchQuery)
            {
                if (c.Item1 == "ProductAge" && c.Item2.Length >= 5)
                {
                    //sql = sql + c.Item1 + " = '" + c.Item2 + "' and ";
                    break;
                }
                else
                {
                    sql = sql + c.Item1 + " = '" + c.Item2 + "' and ";
                }
            }
            sql = sql.Substring(0, sql.Length - 5);
            List<ItemModel> models = DataAccess.getModelList(sql);
            frmSearchResults ResultsForm = parent.ResultsForm;
            ResultsForm.Models = models;
            Close();
            ResultsForm.Show();
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
            return result;
        }

        private void cboStorage_Leave(object sender, EventArgs e)
        {
            model.StorageLocation = cboStorage.Text;
            comboListMaintenance(sender, e);
        }

        private void cboPurchaseSource_Leave(object sender, EventArgs e)
        {
            model.PurchaseSource = cboPurchaseSource.Text;
            comboListMaintenance(sender, e);
        }

        private void cboBrand_Leave(object sender, EventArgs e)
        {
            //model.Brand = cboBrand.Text;
            comboListMaintenance(sender, e);
        }

        private void cboPurchaseSource_Leave_1(object sender, EventArgs e)
        {
            model.PurchaseSource = cboPurchaseSource.Text;
            comboListMaintenance(sender, e);
        }

        private void cboWhereListed_Leave(object sender, EventArgs e)
        {
            comboListMaintenance(sender, e);
            model.WhereListed = cboWhereListed.Text;
            if (cboWhereListed.Text != "")
            {
                dtpDateListed.Value = DateTime.Now;
                dtpDateListed.Format = DateTimePickerFormat.Long;
            }
            else
            {
                FormControlOps.ClearDTP(dtpDateListed);
            }
        }

        private void frmAllItems_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            DialogResult result = DialogResult.None;
            if (formDirty && GV.MODE != Mode.Search)
            {
                result = MessageBox.Show("Save changses before closing?", "Confirm Close",
                                MessageBoxButtons.YesNoCancel);
            }
            if (result == DialogResult.Yes)
            {
                btnSave.PerformClick();
            }
            else if (result == DialogResult.Cancel)
            {
                return;
                this.Hide();
            }
            this.Hide();
        }

        private void txtCostOfSale_Leave(object sender, EventArgs e)
        {
            model.CostOfSale = Convert.ToDecimal(txtCostOfSale.Text.Replace("$", ""));
            txtProfit.Text = model.Profit.ToString("$0.00");
            txtDaysHeld.Text = model.ProductAge.ToString();
        }

        private void dtpSaleDate_ValueChanged(object sender, EventArgs e)
        {
            dtpSaleDate.Format = DateTimePickerFormat.Long;
            model.SaleDate = dtpSaleDate.Value;
            formDirty = true;
        }

        private void dtpDateListed_ValueChanged(object sender, EventArgs e)
        {
            if (dtpDateListed.Value != GV.emptyDate)
            {
                model.DateListed = dtpDateListed.Value;
                dtpDateListed.Format = DateTimePickerFormat.Long;
                MarkFormDirty(sender, e);
            }
        }

        private void dtpBuy_ValueChanged(object sender, EventArgs e)
        {
            model.PurchaseDate = dtpBuy.Value;
            MarkFormDirty(sender, e);
        }

        private void txtPurchasePrice_TextChanged(object sender, EventArgs e)
        {
            if (txtPurchasePrice.Text != "")
            {
                model.PurchasePrice = Convert.ToDecimal(txtPurchasePrice.Text.Replace("$", ""));

            }

            MarkFormDirty(sender, e);
        }

        private void cboBrand_TextChanged(object sender, EventArgs e)
        {
            model.Brand = cboBrand.Text;
            MarkFormDirty(sender, e);
        }

        private void cboCategory_TextUpdate(object sender, EventArgs e)
        {
            model.Category = cboCategory.Text;
            MarkFormDirty(sender, e);
        }

        private void txtDesc_TextChanged(object sender, EventArgs e)
        {
            model.ItemDesc = txtDesc.Text;
            MarkFormDirty(sender, e);
        }

        private void cboPurchaseSource_TextChanged(object sender, EventArgs e)
        {
            model.PurchaseSource = cboPurchaseSource.Text;
            MarkFormDirty(sender, e);
        }

        private void txtQuantity_TextChanged(object sender, EventArgs e)
        {
            if (txtQuantity.Text != "")
            {
                model.Quantity = Convert.ToInt32(txtQuantity.Text);
            }
            MarkFormDirty(sender, e);
        }

        private void cboWhereListed_TextChanged(object sender, EventArgs e)
        {
            model.WhereListed = cboWhereListed.Text;
            MarkFormDirty(sender, e);
        }

        private void cboStorage_TextChanged(object sender, EventArgs e)
        {
            model.StorageLocation = cboStorage.Text;
            MarkFormDirty(sender, e);
        }

        private void txtListPrice_TextChanged(object sender, EventArgs e)
        {
            if (txtListPrice.Text != "")
            {
                model.ListPrice = Convert.ToDecimal(txtListPrice.Text.Replace("$", ""));
            }
            MarkFormDirty(sender, e);
        }

        private void txtPrice_TextChanged(object sender, EventArgs e)
        {
            try
            {
                model.SalePrice = Convert.ToDecimal(txtPrice.Text.Replace("$", ""));
            }
            catch (Exception)
            {
                //throw;
            }
            MarkFormDirty(sender, e);
        }

        private void txtCostOfSale_TextChanged(object sender, EventArgs e)
        {
            if (txtCostOfSale.Text != "")
            {
                model.CostOfSale = Convert.ToDecimal(txtCostOfSale.Text.Replace("$", ""));
            }
            MarkFormDirty(sender, e);
        }

        private void txtProfit_TextChanged(object sender, EventArgs e)
        {
            MarkFormDirty(sender, e);
        }

        private void btnSellThru_Click(object sender, EventArgs e)
        {
            List<string> brands = DataAccess.GetAllBrands();
            List<SellThruModel> allItems = Operations.DoBrandsSellThru(brands);
        }

        private void frmAllItems_Activated(object sender, EventArgs e)
        {
            if (GV.MODE == Mode.SellThru)
            {
                lblTask.Text = "Sell Thru Report";
                enableDisableControls(allControls, false);
                cboBrand.Enabled = true;
            }
        }

        private void txtSKU_TextChanged(object sender, EventArgs e)
        {
            model.ListerSKU = txtSKU.Text;
            MarkFormDirty(sender, e);
        }

        private void txtDiscountPct_TextChanged(object sender, EventArgs e)
        {
            if (txtDiscountPct.Text != "")
            {
                model.DiscountPct = Convert.ToDecimal(txtDiscountPct.Text.Replace("%", ""));
                txtProfit.Text = model.Profit.ToString();
            }
        }

        private void lblDBMode_TextChanged(object sender, EventArgs e)
        {
            if (GV.dbMode == DataMode.SandboxDB)
            {
                lblDBMode.BackColor = Color.IndianRed;
            }
            else
            {
                lblDBMode.BackColor = Color.LightGreen;
            }
        }

        private void frmAllItems_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible)
            {
                prepareForm();
                this.WindowState = FormWindowState.Maximized;
                DataModeChangedEventArgs ea = new DataModeChangedEventArgs();
                ea.conString = GV.conString;
                ea.NewDataMode = GV.dbMode;
                Parent_OnDatabaseModeChanged(this, ea); 
            }
            else
            {
                clearForm();
            }
        }
    }
}
