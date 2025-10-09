using ResaleV8_ClassLibrary;
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

namespace ResaleV8
{
    public partial class frmSearchResults : Form
    {
        private List<ItemModel> models;

        public List<ItemModel> Models
        {
            get
            {
                return models;
            }
            set
            {
                models = value;
            }
        }

        public frmSearchResults()
        {
            InitializeComponent();
        }

        private void frmSearchResults_Load(object sender, EventArgs e)
        {
            dgvSearchresults.DataSource = models;
            formatDGVSearchResults();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            List<ItemModel> models = (List<ItemModel>)dgvSearchresults.DataSource;
            GV.businessSummary.TotalCost = models.Sum(x => x.PurchasePrice * x.Quantity);
            GV.businessSummary.AvgUnsoldAge = (int)models.Average(item => item.ProductAge);
            GV.businessSummary.UnsoldItemsCount = models.Sum(item => item.Quantity);
            string[] hiddenColumns = new string[] { };
            ExcelOps.createExcelSheet((List<ItemModel>)models,
                "Search Results", hiddenColumns, ExportType.SearchResults);
        }


        private void dgvSearchresults_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            GV.MODE = Mode.Edit;
            int row = e.RowIndex;
            int itemID = (int)dgvSearchresults.Rows[row].Cells["ItemID"].Value;
            frmAllItems allItemsForm = new frmAllItems();
            allItemsForm.MdiParent = this.MdiParent;
            allItemsForm.Show();
            allItemsForm.item = itemID;
            allItemsForm.Task = "Edit Item";
            allItemsForm.Focus();
        }

        private void formatDGVSearchResults()
        {
            string[] headers = { "ID", "Category", "Item Description", "Quantity", "Purchase Date",
                "Purchase Price", "Sale Date", "Sale Price", "Days Held", "Profit", "Storage Location" };
            string[] hiddenColumns = new string[] { };
            FormControlOps.formatDGV(dgvSearchresults, headers, hiddenColumns);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
