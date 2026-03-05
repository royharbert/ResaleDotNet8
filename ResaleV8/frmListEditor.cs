using Microsoft.Office.Interop.Excel;
using ResaleV8_ClassLibrary;
using ResaleV8_ClassLibrary.Models;
using ResaleV8_ClassLibrary.Ops;
using System;
using System.Collections;
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
    public partial class frmListEditor : Form
    {
        public string cboName { get; set; }
        private string tableName;
        private string colName;
        private string itemColName;
        private List<GenericModel> list;
        private string oldItem;
        public frmAllItems ParentAllItems;
        private frmMain parent;

        public frmListEditor()
        {
            parent = GV.MainForm as frmMain;
            //parentAllItems = GV.ItemForm as frmAllItems;
            InitializeComponent();

            parent.OnDatabaseModeChanged += Parent_OnDatabaseModeChanged;
        }

        private void Parent_OnDatabaseModeChanged(object? sender, DataModeChangedEventArgs e)
        {
            FormControlOps.SetDBModeIndicator(lblDBMode, e);
        }

        private void frmListEditor_Load(object sender, EventArgs e)
        {
            switch (GV.MODE)
            {
                case Mode.EditCategories:
                    tableName = "categories";
                    cboName = "cboCategory";                    
                    itemColName = "Category";
                    this.Text = "Category List Editor";
                    list = GV.Categories;
                    break;
                case Mode.EditStorageLocations:
                    tableName = "storageLocations";
                    cboName = "cboStorage";
                    itemColName = "StorageLocation";
                    this.Text = "Storage Location List Editor";
                    list = GV.StorageLocations;
                    break;
                case Mode.EditPurchaseSources:
                    tableName = "purchasesources";
                    cboName = "cboPurchaseSource";
                    itemColName = "PurchaseSource";
                    this.Text = "Purchase Source List Editor";
                    list = GV.PurchaseSources;
                    break;
                case Mode.EditBrands:
                    tableName = "brands";
                    cboName = "cboBrand";
                    itemColName = "Brand";
                    this.Text = "Brand List Editor";
                    list = GV.Brands;
                    break;
                case Mode.EditWhereListed:
                    tableName = "whereListed";
                    cboName = "cboWhereListed";
                    itemColName = "WhereListed";
                    this.Text = "Where Listed List Editor";
                    list = GV.WhereListed;
                    break;
            }
            dgvEditor.DataSource = list;
            formatDGV();
            txtItem.Focus();
        }

        private void formatDGV()
        {
            dgvEditor.Columns[1].Width = 200;
            dgvEditor.Columns[1].HeaderText = "Item";
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dgvEditor_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int rowIndex = e.RowIndex;
            if (rowIndex >= 0) // Ensure the row index is valid
            {
                DataGridViewRow selectedRow = dgvEditor.Rows[rowIndex];
                oldItem = selectedRow.Cells[1].Value.ToString();
                txtItem.Text = oldItem;
            }
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            DoModification();
        }


        private void DoModification()
        {
            ComboBox cbo = null;
            switch (cboName)
            {
                case "cboCategory":
                    cbo = ParentAllItems.cboCategory;
                    break;

                case "cboStorage":  
                    cbo = ParentAllItems.cboStorage;
                    break;
                case "cboPurchaseSource":
                    cbo = ParentAllItems.cboPurchaseSource;
                    break;
                case "cboBrand":
                    cbo = ParentAllItems.cboBrand;
                    break;
                case "cboWhereListed":
                    cbo = ParentAllItems.cboWhereListed;
                    break;
                default:
                    break;
            }
            //Get current list from DB
            List<GenericModel> list = GetGVList();
            //Find oldItem
            GenericModel item = list.Find(x => x.Data == oldItem);
            //Check if newItem already exists in DB
            bool itemExists;
            itemExists = DataAccess.CheckForExistingItem(cbo, oldItem);
            //If not, update DB with newItem
            if (itemExists)
            {
                DataAccess.UpdateSingleDDItem(cbo, oldItem, txtItem.Text.Trim());
            }
            
            else
            {
                DropDownEventArgs ea = new DropDownEventArgs();
                ea.originalItem = txtItem.Text.Trim();
                DataAccess.AddNewItemToDropDownTable(cbo);
            }
            //Update GV list with DB changes
            DialogResult reply = MessageBox.Show("Correct existing entries?", "Modify Existing?",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            DropDownEventArgs args = new DropDownEventArgs();
            if (reply == DialogResult.Yes)
            {
                args.originalItem = oldItem;
                args.StringToProcess= oldItem;
                DataAccess.ProcessDDItem(args);
                oldItem = args.escapedItem;
                args.Reset();
                args.originalItem = txtItem.Text.Trim();
                args.StringToProcess = txtItem.Text.Trim();
                DataAccess.ProcessDDItem(args);
                string newItem = args.escapedItem;
                DataAccess.ModifySelectedFieldEntries(oldItem, newItem, tableName, itemColName);
            }
            list = GetGVList();
            //Refresh DGV with DB changes
            dgvEditor.DataSource = null;
            dgvEditor.DataSource = list;
        }

        private List<GenericModel> GetGVList()
        {
            List<GenericModel> list = new List<GenericModel>();
            switch (tableName)
            {
                case "categories":
                    list = GV.Categories;
                    list.Clear();
                    colName = "Data";
                    list = DataAccess.GetDropDownList("categories");
                    break;
                case "storageLocations":
                    list = GV.StorageLocations;
                    list.Clear();
                    colName = "Data";
                    list = DataAccess.GetDropDownList("storagelocations");

                    break;
                case "purchasesources":
                    list = GV.PurchaseSources;
                    list.Clear();
                    colName = "Data";
                    list = DataAccess.GetDropDownList("PurchaseSources");
                    break;
                case "brands":
                    list = GV.Brands;
                    list.Clear();
                    colName = "Data";
                    list = DataAccess.GetDropDownList("Brands");
                    break;
                case "whereListed":
                    list = GV.WhereListed;
                    list.Clear();
                    colName = "Data";
                    list = DataAccess.GetDropDownList("whereListed");
                    break;
            }
            return list;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            ComboBox cbo = null;
            List<GenericModel> gvList = new List<GenericModel>();
            //cbo.DataSource = null;
            switch (tableName)
            {
                case "categories":
                    GV.Categories = DataAccess.GetDropDownList("categories").ToList();
                    gvList = GV.Categories;
                    break;
                case "storageLocations":
                    GV.StorageLocations = DataAccess.GetDropDownList("storagelocations").ToList();
                    gvList = GV.StorageLocations;
                    break;
                case "purchasesources":
                    GV.PurchaseSources = DataAccess.GetDropDownList("PurchaseSources").ToList();
                    gvList = GV.PurchaseSources;
                    break;
                case "brands":
                    GV.Brands = DataAccess.GetDropDownList("Brands").ToList();
                    gvList = GV.Brands;
                    break;
                case "whereListed":
                    GV.WhereListed = DataAccess.GetDropDownList("WhereListed").ToList();
                    gvList = GV.WhereListed;
                    break;
            }


            int idx = Operations.FindStringInList(txtItem.Text.Trim(), gvList);
            if (idx != -1)
            {
                int result = DataAccess.DeleteDropDownItem(tableName, idx);
                gvList.RemoveAll(x => x.ID == idx);
                MessageBox.Show(result.ToString() + " Item deleted.");
                txtItem.Text = "";
                dgvEditor.DataSource = DataAccess.GetComboItemList(tableName);
                formatDGV();
            }
            else
            {
                MessageBox.Show("Item not found in list.");
            }
        }

        private void frmListEditor_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }

        private void frmListEditor_VisibleChanged(object sender, EventArgs e)
        {
            DataModeChangedEventArgs ea = new DataModeChangedEventArgs();
            ea.conString = GV.conString;
            ea.NewDataMode = GV.dbMode;
            Parent_OnDatabaseModeChanged(this,  ea);      
        }
    }
}
