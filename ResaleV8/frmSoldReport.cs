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
                "Purchase Price", "Sale Date", "Sale Price", "Days Held", "Storage Location" };
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
            decimal totalSales = dt.Sum(item => item.SalePrice * item.Quantity);
            txtTotRevenue.Text = totalSales.ToString("C2");
            decimal totalCost = dt.Sum(item => item.PurchasePrice * item.Quantity);
            txtTotalCost.Text = totalCost.ToString("C2");
            decimal totalProfit = totalSales - totalCost;
            txtTotMargin.Text = totalProfit.ToString("C2");
            if (totalCost != 0)
            {
                txtAvgPct.Text = (totalProfit / totalCost).ToString("P2"); 
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            List<ItemModel> dt = (List<ItemModel>)dgvSoldReport.DataSource;
            ExcelOps.createExcelSheet(dt, "Sold Report",true, hiddenColumns);            
        }

        private void frmSoldReport_Load(object sender, EventArgs e)
        {

        }
    }
}
