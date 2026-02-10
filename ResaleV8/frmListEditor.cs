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
        private string itemColName;
        private List<GenericModel> list;
        private string oldItem;

        public frmListEditor()
        {
            InitializeComponent();
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
            if (dgvEditor.CurrentRow != null)
            {
                int oldIndex = Convert.ToInt32(dgvEditor.CurrentRow.Cells[0].Value);
                DataAccess.DeleteDropDownItem(tableName, oldIndex);

                list = DataAccess.ModifyListItem(dgvEditor.CurrentRow.Cells[1].Value.ToString(),
                    txtItem.Text.Trim(), list);
                switch (tableName)
                {
                    case "categories":
                        GV.Categories = list;                      
                        break;
                    case "StorageLocations":
                        GV.StorageLocations = list;
                        break;
                    case "purchasesources":
                        GV.PurchaseSources = list;
                        break;
                    case "brands":
                        GV.Brands = list;
                        break;
                    case "whereListed":
                        GV.WhereListed = list;
                        break;
                }
                DataAccess.UpdateSingleDDItem(tableName, colName, oldItem, txtItem.Text);
                dgvEditor.DataSource = null;
                dgvEditor.DataSource = DataAccess.GetComboItemList(tableName);
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
    }
}
