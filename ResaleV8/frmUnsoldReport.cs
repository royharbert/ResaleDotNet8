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
        EventArgs e = new EventArgs();
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
            List<ItemModel> itemList =
                    DataAccess.getModelList("Select * from purchasedItems where SaleDate = '1900-01-01'");
            GV.itemList = itemList;
            dgvUnsold.DataSource = itemList;
            string[] columnsToHide = { "Profit", "SalePrice" };
            FormControlOps.formatDGV(dgvUnsold,
                headers: new string[] { "ID", "Category", "Description", "Quantity", "Purchase Date",
                    "Purchase Price", "Sale Date", "Sale Price", "Product Age",
                    "Profit", "Storage Location" },
                columnsToHide);
            GV.businessSummary.UnsoldCost = itemList.Sum(item => item.PurchasePrice * item.Quantity);
            txtTotalCost.Text = GV.businessSummary.UnsoldCost.ToString("C2");
            GV.businessSummary.AvgUnsoldAge = (int)itemList.Average(item => item.ProductAge);
            txtAvgAge.Text = GV.businessSummary.AvgUnsoldAge.ToString("###.0");
            GV.businessSummary.UnsoldItemsCount = itemList.Sum(item => item.Quantity);
            txtItemTotal.Text = GV.businessSummary.UnsoldItemsCount.ToString();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            //List<ItemModel> dt = (List<ItemModel>)dgvUnsold.DataSource;
            ExcelOps.createExcelSheet(GV.itemList, "Unsold Report",  hiddenColumns, "Unsold");
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
    }
}
