using MySql.Data.MySqlClient;

using ResaleV8_ClassLibrary;
using ResaleV8_ClassLibrary.DatabaseOps;
using ResaleV8_ClassLibrary.ExcelOps;
using ResaleV8_ClassLibrary.Models;
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
using Excel = Microsoft.Office.Interop.Excel;

namespace ResaleV8
{
    public partial class frmSoldReport : Form
    {
        string[] hiddenColumns = { };
        public frmSoldReport()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            string[] headers =  { "ID", "Category", "Description", "Brand", "Purchase Source", "Quantity", "Purchase Date",
                    "Purchase Price", "Where Listed", "Date Listed", "List Price", "Sale Date", "Sale Price", "Cost of Sale", "Product Age",
                    "Profit", "Storage Location" };
            string startDate = FormControlOps.dtpValueToString(dtpStart);
            string stopDate = FormControlOps.dtpValueToString(dtpStop);
            MySqlConnection con = ConnectToDB.OpenDB();
            string query = "Select * from purchasedItems where SaleDate between "
                + startDate + " and " + stopDate;

            List<ItemModel> dt = DataAccess.getModelList(query);
            GV.ItemList = dt;
            if (dt == null)
            {
                MessageBox.Show("No items sold in DateBoldEventArgs range");
            }

            dgvSoldReport.DataSource = dt;
            FormControlOps.formatDGV(dgvSoldReport, headers, hiddenColumns);
            GV.BusinessSummary.TotalSales = dt.Sum(item => item.SalePrice * item.Quantity);
            txtTotRevenue.Text = GV.BusinessSummary.TotalSales.ToString("C2");
            GV.BusinessSummary.TotalCost = dt.Sum(item => item.PurchasePrice * item.Quantity);
            txtTotalCost.Text = GV.BusinessSummary.TotalCost.ToString("C2");
            GV.BusinessSummary.TotalMargin = GV.BusinessSummary.TotalSales - GV.BusinessSummary.TotalCost;
            txtTotMargin.Text = GV.BusinessSummary.TotalMargin.ToString("C2");
            if (GV.BusinessSummary.TotalCost != 0)
            {
                GV.BusinessSummary.MarginPercentage = (GV.BusinessSummary.TotalSales / GV.BusinessSummary.TotalCost)
                    * 100;
                txtAvgPct.Text = GV.BusinessSummary.MarginPercentage.ToString("####.00");
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            List<ItemModel> dt = (List<ItemModel>)dgvSoldReport.DataSource;
            ExcelOps.createExcelSheet(dt, "Sold Report",  hiddenColumns, ExportType.Sold, "Sold Items");
        }

        private void frmSoldReport_Load(object sender, EventArgs e)
        {

        }

        private void dgvSoldReport_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int row = e.RowIndex;
            int itemID = (int)dgvSoldReport.Rows[row].Cells["ItemID"].Value;
            GV.MODE = Mode.Edit;
            frmAllItems allItemsForm = new frmAllItems();
            allItemsForm.MdiParent = this.MdiParent;
            allItemsForm.Show();
            allItemsForm.item = itemID;
            allItemsForm.Focus();
        }

        private void frmSoldReport_Leave(object sender, EventArgs e)
        {

        }
    }
}
