using ResaleV8_ClassLibrary;
using ResaleV8_ClassLibrary.ExcelOps;
using ResaleV8_ClassLibrary.Models;
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
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            string[] hiddenColumns = new string[] { };
            ExcelOps.createExcelSheet((List<ItemModel>)dgvSearchresults.DataSource, "Search Results", false, hiddenColumns);
        }


        private void dgvSearchresults_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int row = e.RowIndex;
            int itemID = (int)dgvSearchresults.Rows[row].Cells["ItemID"].Value;
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
