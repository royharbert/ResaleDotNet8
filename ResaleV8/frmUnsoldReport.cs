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

namespace ResaleV8
{
    public partial class frmUnsoldReport : Form
    {
        string[] hiddenColumns = new string[] { "Sale Date", "Sale Price", "Profit" };
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
            List<ItemModel> itemList = DataAccess.getModelList("Select * from purchasedItems where SaleDate = '1900-01-01'");
            dgvUnsold.DataSource = itemList;
            string[] columnsToHide = { "ProductAge", "Profit" };
            FormControlOps.formatDGV(dgvUnsold,
                headers: new string[] { "ID", "Category", "Description", "Quantity", "Purchase Date",
                    "Purchase Price", "Sale Date", "Sale Price", "Storage Location",
                    "Product Age", "Profit" },
                columnsToHide);
            decimal totalCost = itemList.Sum(item => item.PurchasePrice * item.Quantity);
            txtTotalCost.Text = totalCost.ToString("C2");
            int avgAge = (int)itemList.Average(item => item.ProductAge);
            txtAvgAge.Text = avgAge.ToString();
            int totalItems = itemList.Sum(item => item.Quantity);
            txtItemTotal.Text = totalItems.ToString();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            List<ItemModel> dt = (List<ItemModel>)dgvUnsold.DataSource;
            ExcelOps.createExcelSheet(dt, "Unsold Report", false, hiddenColumns);            
        }
    }
}
