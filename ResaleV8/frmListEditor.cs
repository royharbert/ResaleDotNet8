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
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Windows.ApplicationModel.Email;

namespace ResaleV8
{
    public partial class frmListEditor : Form
    {
        public string cboName { get; set; }
        private string tableName;
        private string colName;
        private List<GenericModel> list;
        private string oldItem;

        public frmListEditor()
        {
            InitializeComponent();
        }

        private void frmListEditor_Load(object sender, EventArgs e)
        {
            System.Data.DataTable dt = new System.Data.DataTable();

            switch (cboName)
            {
                case "cboCategory":
                    dt = DataAccess.GetComboItemList("categories");
                    tableName = "categories";
                    colName = "category";
                    list = GV.categories;
                    break;
                case "cboStorage":
                    dt = DataAccess.GetComboItemList("storageLocations");
                    tableName = "storageLocations";
                    colName = "location";
                    list = GV.storageLocations;
                    break;
                case "cboPurchaseSource":
                    dt = DataAccess.GetComboItemList("purchasesources");
                    tableName = "purchasesources";
                    colName = "source";
                    list = GV.PurchaseSources;
                    break;
                case "cboBrand":
                    dt = DataAccess.GetComboItemList("brands");
                    tableName = "brands";
                    colName = "brand";
                    list = GV.Brands;
                    break;
                case "cboWhereListed":
                    dt = DataAccess.GetComboItemList("whereListed");
                    tableName = "whereListed";
                    colName = "listed";
                    list = GV.WhereListed;
                    break;
            }
            dgvEditor.DataSource = dt;
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
            //string oldItem = txtItem.Text.Trim();
            string colName = "";
            string itemColName = "";
            System.Data.DataTable dt = (System.Data.DataTable)dgvEditor.DataSource;
            if (dgvEditor.CurrentRow != null)
            {
                list = DataAccess.ModifyListItem(dgvEditor.CurrentRow.Cells[1].Value.ToString(),
                    txtItem.Text.Trim(), list);
                switch (tableName)
                {
                    case "categories":
                        GV.categories = list;
                        colName  = "category";
                        itemColName = "category";
                        break;
                    case "storageLocations":
                        GV.storageLocations = list;
                        colName = "location";
                        itemColName = "StorageLocation";
                        break;
                    case "purchasesources":
                        GV.PurchaseSources = list;
                        colName = "source";
                        itemColName = "purchaseSource";
                        break;
                    case "brands":
                        GV.Brands = list;
                        colName = "Brand";
                        itemColName = "Brand";
                        break;
                    case "whereListed":
                        GV.WhereListed = list;
                        colName = "listed";
                        itemColName = "WhereListed";
                        break;
                }
                DataAccess.UpdateSingleDDItem(tableName, colName, oldItem, txtItem.Text);
                DialogResult reply = MessageBox.Show("Correct existing entries?", "Modify Existing?",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (reply == DialogResult.Yes)
                {
                    oldItem = Operations.EscapeApostrophes(oldItem);
                    string newItem = Operations.EscapeApostrophes(txtItem.Text.Trim());
                    DataAccess.ModifySelectedFieldEntries(oldItem, newItem , tableName, itemColName);
                }
                                                                                                                                                                   
            }
            else
            {
                MessageBox.Show("No row selected.");
            }
        }

        private List<string> GetGVList()
        {
            switch (tableName)
            {
                case "categories":
                    list = GV.categories;
                    colName = "category";
                    List<GenericModel> categoryModel = DataAccess.GetCategoryList();
                    break;
                case "storageLocations":
                    list = GV.storageLocations;
                    colName = "location";
                    List<GenericModel> storageModel = DataAccess.GetStorageLocationList();
                    break;
                case "purchasesources":
                    list = GV.PurchaseSources;
                    colName = "source";
                    List<GenericModel> purchaseModel = DataAccess.GetPurchaseSourceList();
                    break;
                case "brands":
                    list = GV.Brands;
                    colName = "brand";
                    List<GenericModel> brandModel = DataAccess.GetBrandList();
                    break;
                case "whereListed":
                    list = GV.WhereListed;
                    colName = "listed";
                    List<GenericModel> whereListedModel = DataAccess.LoadDDModel("whereListed");
                    break;
            }
            return list;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            List<GenericModel> gvList = new List<GenericModel>();    
            //List<string> gvList = GetGVList();
            switch (tableName)
            {
                case "categories":
                    gvList = DataAccess.GetCategoryList().Select(c => new GenericModel 
                        { ID = c.ID, Data = c.Data }).ToList();
                    break;
                case "storageLocations":
                    gvList = DataAccess.GetStorageLocationList().Select(c => new GenericModel
                        { ID = c.ID, Data = c.Data }).ToList();
                    //GV.storageLocations = gvList;
                    break;
                case "purchasesources":
                    //GV.PurchaseSources = gvList;
                    break;
                case "brands":
                    //GV.Brands = gvList;
                    break;
                case "whereListed":
                    //GV.WhereListed = gvList;
                    break;
            }
        }
    }
}
