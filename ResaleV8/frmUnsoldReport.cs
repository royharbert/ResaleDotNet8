using MySql.Data.MySqlClient;
using ResaleV8_ClassLibrary;
using ResaleV8_ClassLibrary.DatabaseOps;
using ResaleV8_ClassLibrary.ExcelOps;
using Excel = Microsoft.Office.Interop.Excel;
using ResaleV8_ClassLibrary.Ops;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ResaleV8_ClassLibrary.Models;
using Org.BouncyCastle.Bcpg.OpenPgp;

namespace ResaleV8
{
    public partial class frmUnsoldReport : Form
    {
        EventArgs e = new EventArgs();
        string[] hiddenColumns = new string[] { "Sale Date", "Sale Price", "Profit", "Quantity", "ListerSKU"};
        public frmUnsoldReport()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmUnsoldReport_Load(object sender, EventArgs e)
        {
            MySqlConnection con = ConnectToDB.OpenDB();
            List<ItemModel> itemList =
                    DataAccess.getModelList("Select * from purchasedItems where SaleDate = '1900-01-01'");
            GV.ItemList = itemList;
            dgvUnsold.DataSource = itemList;
            string[] columnsToHide = {"Profit", "SalePrice", "Quantity", "ListerSKU", "SaleDate", "DiscountPCT", "CostOfSale" };
            FormControlOps.formatDGV(dgvUnsold,
                headers: GV.DGVHeaders ,
                columnsToHide);
            dgvUnsold.Columns["ItemDesc"].Width = 450;
            GV.BusinessSummary.UnsoldCost = itemList.Sum(item => item.PurchasePrice * item.Quantity);
            txtTotalCost.Text = GV.BusinessSummary.UnsoldCost.ToString("C2");
            GV.BusinessSummary.AvgUnsoldAge = Convert.ToDecimal(itemList.Average(item => item.ProductAge));
            txtAvgAge.Text = GV.BusinessSummary.AvgUnsoldAge.ToString("###.0");
            GV.BusinessSummary.UnsoldItemsCount = itemList.Sum(item => item.Quantity);
            txtItemTotal.Text = GV.BusinessSummary.UnsoldItemsCount.ToString();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            ExcelOps.createExcelSheet(GV.ItemList, "Unsold Report", hiddenColumns, ExportType.Unsold, "Unsold Items");
        }

        private void dgvUnsold_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int row = e.RowIndex;
            int itemID = (int)dgvUnsold.Rows[row].Cells["ItemID"].Value;
            GV.MODE = Mode.Edit;
            frmAllItems allItemsForm = new frmAllItems();
            allItemsForm.MdiParent = this.MdiParent;
            allItemsForm.Show();
            allItemsForm.item = itemID;
            allItemsForm.Task = "Edit Item";
            allItemsForm.Focus();
        }

        private void dgvUnsold_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = e.RowIndex;
            int itemID = (int)dgvUnsold.Rows[row].Cells["ItemID"].Value;
            GV.MODE = Mode.Edit;
            frmAllItems allItemsForm = new frmAllItems();
            allItemsForm.MdiParent = this.MdiParent;
            allItemsForm.Show();
            allItemsForm.item = itemID;
            allItemsForm.Task = "Edit Item";
            allItemsForm.Focus();
        }
    }
}
