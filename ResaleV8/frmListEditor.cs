using ResaleV8_ClassLibrary;
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

namespace ResaleV8
{
    public partial class frmListEditor : Form
    {
        public string cboName { get; set; }
        private string tableName;
        private string colName;
        private List<string> list;

        public frmListEditor()
        {
            InitializeComponent();
        }

        private void frmListEditor_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();

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
            dgvEditor.Columns[0].Visible = false;
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
                txtItem.Text = selectedRow.Cells[1].Value.ToString();
            }
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            DataTable dt = (DataTable)dgvEditor.DataSource;
            if (dgvEditor.CurrentRow != null)
            {
                list = DataAccess.ModifyListItem(dgvEditor.CurrentRow.Cells[1].Value.ToString(),
                    txtItem.Text.Trim(), list);
                switch (tableName)
                {
                    case "categories":
                        GV.categories = list;
                        break;
                    case "storageLocations":
                        GV.storageLocations = list;
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
                DataAccess.RemoveTableItems(tableName);
                DataAccess.addListToDropDownTable(tableName, list, colName);
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
                    break;
                case "storageLocations":
                    list = GV.storageLocations;
                    colName = "location";
                    break;
                case "purchasesources":
                    list = GV.PurchaseSources;
                    colName = "source";
                    break;
                case "brands":
                    list = GV.Brands;
                    colName = "brand";
                    break;
                case "whereListed":
                    list = GV.WhereListed;
                    colName = "listed";
                    break;
            }
            return list;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string item = "";
            list = GetGVList();
            item = txtItem.Text.Trim();
            int index = list.IndexOf(item);
            if (index == -1)
            {
                MessageBox.Show("Item not found in list.");
                return;
            }
            list.RemoveAt(index);
            DataAccess.RemoveTableItems(tableName);
           // Operations.ConvertListToDataTable(list, colName);
            ddEventArgs ea = new ddEventArgs();
            foreach (var ListItem in list)
            {
                ea.tableName = tableName;
                ea.columnName = colName;
                ea.newItem = listItem;
                DataAccess.addDropDownItemToTable(ea); 
            };
            dgvEditor.DataSource = null;
            dgvEditor.DataSource = list;
        }
    }
}
