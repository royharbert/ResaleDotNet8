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
            string[] headers = { "ID", "Category", "Item Description", "Quantity", "Purchase Date",
                "Purchase Price", "Sale Date", "Sale Price", "Days Held", "Profit", "Storage Location" };
            string startDate = FormControlOps.dtpValueToString(dtpStart);
            string stopDate = FormControlOps.dtpValueToString(dtpStop);
            MySqlConnection con = ConnectToDB.OpenDB();
            string query = "Select * from purchasedItems where SaleDate between "
                + startDate + " and " + stopDate;

            List<ItemModel> dt = DataAccess.getModelList(query);
            GV.itemList = dt;
            if (dt == null)
            {
                MessageBox.Show("No items sold in DateBoldEventArgs range");
            }

            dgvSoldReport.DataSource = dt;
            FormControlOps.formatDGV(dgvSoldReport, headers, hiddenColumns);
            GV.businessSummary.TotalSales = dt.Sum(item => item.SalePrice * item.Quantity);
            txtTotRevenue.Text = GV.businessSummary.TotalSales.ToString("C2");
            GV.businessSummary.TotalCost = dt.Sum(item => item.PurchasePrice * item.Quantity);
            txtTotalCost.Text = GV.businessSummary.TotalCost.ToString("C2");
            GV.businessSummary.TotalMargin = GV.businessSummary.TotalSales - GV.businessSummary.TotalCost;
            txtTotMargin.Text = GV.businessSummary.TotalMargin.ToString("C2");
            if (GV.businessSummary.TotalCost != 0)
            {
                GV.businessSummary.MarginPercentage = (GV.businessSummary.TotalSales / GV.businessSummary.TotalCost)
                    * 100;
                txtAvgPct.Text = GV.businessSummary.MarginPercentage.ToString("####.00");
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            List<ItemModel> dt = (List<ItemModel>)dgvSoldReport.DataSource;
            ExcelOps.createExcelSheet(dt, "Sold Report", true, hiddenColumns);
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
