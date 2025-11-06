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
                    colName = "Data";
                    list = GV.Categories;
                    break;
                case "cboStorage":
                    dt = DataAccess.GetComboItemList("storageLocations");
                    tableName = "storageLocations";
                    colName = "Data";
                    list = GV.StorageLocations;
                    break;
                case "cboPurchaseSource":
                    dt = DataAccess.GetComboItemList("purchasesources");
                    tableName = "purchasesources";
                    colName = "Data";
                    list = GV.PurchaseSources;
                    break;
                case "cboBrand":
                    dt = DataAccess.GetComboItemList("brands");
                    tableName = "brands";
                    colName = "Data";
                    list = GV.Brands;
                    break;
                case "cboWhereListed":
                    dt = DataAccess.GetComboItemList("whereListed");
                    tableName = "whereListed";
                    colName = "Data";
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
            ComboBox cbo = null;
            string colName = "";
            string itemColName = "";
            System.Data.DataTable dt = (System.Data.DataTable)dgvEditor.DataSource;
            if (dgvEditor.CurrentRow != null)
            {
                //list = DataAccess.ModifyListItem(dgvEditor.CurrentRow.Cells[1].Value.ToString(),
                    //txtItem.Text.Trim(), list);
                switch (tableName)
                {
                    case "categories":
                        GV.Categories = list;
                        cbo = frmAllItems.cboCategory;
                        colName  = "Data";
                        itemColName = "Category";
                        break;
                    case "StorageLocations":
                        GV.StorageLocations = list;
                        cbo = frmAllItems.cboStorage;
                        colName = "Data";
                        itemColName = "StorageLocation";
                        break;
                    case "purchasesources":
                        GV.PurchaseSources = list;
                        cbo = frmAllItems.cboPurchaseSource;
                        colName = "Data";
                        itemColName = "purchasesource";
                        break;
                    case "brands":
                        GV.Brands = list;
                        cbo = frmAllItems.cboBrand;
                        colName = "Data";
                        itemColName = "Brand";
                        break;
                    case "whereListed":
                        GV.WhereListed = list;
                        cbo = frmAllItems.cboWhereListed;
                        colName = "Data";
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
            //
            //
            FormControlOps.EditDropDownList(cbo, list);
        }

        private List<GenericModel> GetGVList()
        {
            switch (tableName)
            {
                case "categories":
                    list = GV.Categories;
                    colName = "Data";
                    List<GenericModel> categoryModel = DataAccess.GetDropDownList("categories");
                    break;
                case "storageLocations":
                    list = GV.StorageLocations;
                    colName = "Data";
                    List<GenericModel> storageModel = DataAccess.GetDropDownList("storagelocations");
                    break;
                case "purchasesources":
                    list = GV.PurchaseSources;
                    colName = "Data";
                    List<GenericModel> purchaseModel = DataAccess.GetDropDownList("PurchaseSources");
                    break;
                case "brands":
                    list = GV.Brands;
                    colName = "Data";
                    List<GenericModel> brandModel = DataAccess.GetDropDownList("Brands");
                    break;
                case "whereListed":
                    list = GV.WhereListed;
                    colName = "Data";
                    List<GenericModel> whereListedModel = DataAccess.GetDropDownList("whereListed");
                    break;
            }
            return list;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            ComboBox cbo = null;
            List<GenericModel> gvList = new List<GenericModel>();
            switch (tableName)
            {
                case "categories":
                    gvList = DataAccess.GetDropDownList("categories").ToList();
                    cbo = frmAllItems.cboCategory;
                    break;
                case "storageLocations":
                    gvList = DataAccess.GetDropDownList("storagelocations").ToList();
                    cbo = frmAllItems.cboStorage;
                    break;
                case "purchasesources":
                    gvList = DataAccess.GetDropDownList("PurchaseSources").ToList();
                    cbo = frmAllItems.cboPurchaseSource;
                    break;
                case "brands":
                    gvList = DataAccess.GetDropDownList("Brands").ToList();
                    cbo = frmAllItems.cboBrand;
                    break;
                case "whereListed":
                    gvList = DataAccess.GetDropDownList("WhereListed").ToList();
                    cbo = frmAllItems.cboWhereListed;
                    break;
            }           

            
            int idx = Operations.FindStringInList(txtItem.Text.Trim(), gvList);
            if (idx != -1)
            {
                DataAccess.DeleteRecord(idx, tableName);
                gvList.RemoveAll(x => x.ID == idx);
                MessageBox.Show("Item deleted.");
                txtItem.Text = "";
                dgvEditor.DataSource = DataAccess.GetComboItemList(tableName);
                formatDGV();
            }
            else
            {
                MessageBox.Show("Item not found in list.");
            }
        }
    }
}
