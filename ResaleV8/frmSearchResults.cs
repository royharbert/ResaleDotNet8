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
        private frmMain parent;


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
            parent = GV.MainForm as frmMain;
            InitializeComponent();
            parent.OnDatabaseModeChanged += Parent_OnDatabaseModeChanged;
        }

        private void Parent_OnDatabaseModeChanged(object? sender, DataModeChangedEventArgs e)
        {
            FormControlOps.SetDBModeIndicator(lblDBMode, e);
        }

        private void frmSearchResults_Load(object sender, EventArgs e)
        {
            dgvSearchresults.DataSource = models;
            formatDGVSearchResults();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            List<ItemModel> models = (List<ItemModel>)dgvSearchresults.DataSource;
            GV.BusinessSummary.TotalCost = models.Sum(x => x.PurchasePrice * x.Quantity);
            GV.BusinessSummary.AvgUnsoldAge = (int)models.Average(item => item.ProductAge);
            GV.BusinessSummary.UnsoldItemsCount = models.Sum(item => item.Quantity);
            string[] hiddenColumns = new string[] { };
            ExcelOps.createExcelSheet((List<ItemModel>)models,
                "Search Results", hiddenColumns, ExportType.SearchResults, "Search Results");
        }

        private void loadDataOnForm(int row)
        {
            GV.MODE = Mode.Edit;
            //int row = e.RowIndex;
            int itemID = (int)dgvSearchresults.Rows[row].Cells["ItemID"].Value;
            frmAllItems allItemsForm = new frmAllItems();
            allItemsForm.MdiParent = this.MdiParent;
            allItemsForm.Show();
            allItemsForm.item = itemID;
            allItemsForm.Task = "Edit Item";
            allItemsForm.Focus();
        }


        private void dgvSearchresults_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int row = e.RowIndex;
            loadDataOnForm(row);
        }

        private void formatDGVSearchResults()
        {
            string[] headers = GV.DGVHeaders;
            string[] hiddenColumns = new string[] { "Quantity", "ListerSKU" };
            FormControlOps.formatDGV(dgvSearchresults, headers, hiddenColumns);
            dgvSearchresults.Columns["ItemDesc"].Width = 450;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dgvSearchresults_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = e.RowIndex;
            loadDataOnForm(row);
        }

        private void frmSearchResults_FormClosing(object sender, FormClosingEventArgs e)
        {
            dgvSearchresults.DataSource = null;
            e.Cancel = true;
            this.Hide();
        }

        private void frmSearchResults_VisibleChanged(object sender, EventArgs e)
        {
            DataModeChangedEventArgs ea = new DataModeChangedEventArgs();
            ea.conString = GV.conString;
            ea.NewDataMode = GV.dbMode;
            Parent_OnDatabaseModeChanged(this, ea);
        }
    }
}
