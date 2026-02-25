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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;
using Excel = Microsoft.Office.Interop.Excel;

namespace ResaleV8
{
    public partial class frmSoldReport : Form
    {
        private frmMain parent;
        string[] hiddenColumns = { };
        public frmSoldReport()
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

        private void btnRun_Click(object sender, EventArgs e)
        {
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
            FormControlOps.formatDGV(dgvSoldReport, GV.DGVHeaders, hiddenColumns);
            dgvSoldReport.Columns["ItemDesc"].Width = 450;
            dgvSoldReport.RowHeadersVisible = false;
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
            ExcelOps.createExcelSheet(dt, "Sold Report", hiddenColumns, ExportType.Sold, "Sold Items");
        }

        private void dgvSoldReport_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
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

        private void frmSoldReport_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            dgvSoldReport.DataSource = null;
            this.Hide();
        }

        private void frmSoldReport_VisibleChanged(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            DataModeChangedEventArgs ea = new DataModeChangedEventArgs();
            ea.conString = GV.conString;
            ea.NewDataMode = GV.dbMode;
            Parent_OnDatabaseModeChanged(this, ea);
        }
    }
}
