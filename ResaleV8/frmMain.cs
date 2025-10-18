using MySql.Data.MySqlClient;
using ResaleV8_ClassLibrary;
using ResaleV8_ClassLibrary.DatabaseOps;
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
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            GV.conString = "server=localhost;uid=dbUser;pwd=dbUser;database=Resale";

            GV.categories = DataAccess.getColumnList("categories", "Category");

            GV.storageLocations = DataAccess.getColumnList("storagelocations", "Location");

            GV.PurchaseSources = DataAccess.getColumnList("purchasesources", "Source");

            GV.Brands = DataAccess.getColumnList("brands", "Brand");

            GV.WhereListed = DataAccess.getColumnList("wherelisted", "listed");
            GV.businessSummary = new BusinessSummary();
        }

        private void soldItemReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSoldReport soldReportForm = new frmSoldReport();
            soldReportForm.MdiParent = this;
            soldReportForm.Show();
        }

        private void unsoldItemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUnsoldReport unsoldReportForm = new frmUnsoldReport();
            unsoldReportForm.MdiParent = this;
            unsoldReportForm.Show();
        }

        private void addItemToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            GV.MODE = Mode.Add;
            frmAllItems allItemsForm = new frmAllItems();
            allItemsForm.MdiParent = this;
            allItemsForm.Show();
            allItemsForm.Task = "Add New Item";
        }

        private void editItemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GV.MODE = Mode.Retrieve;
            frmAllItems allItemsForm = new frmAllItems();
            allItemsForm.MdiParent = this;
            allItemsForm.Show();
            allItemsForm.Task = "Edit Item";
        }

        private void deleteItemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GV.MODE = Mode.Delete;
            frmAllItems allItemsForm = new frmAllItems();
            allItemsForm.MdiParent = this;
            allItemsForm.Show();
        }

        private void editRecordToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void searchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GV.MODE = Mode.Search;
            frmAllItems allItemsForm = new frmAllItems();
            allItemsForm.MdiParent = this;
            allItemsForm.Show();
            allItemsForm.Task = "Search Items";
        }

        private void openListEditorForm(string cboName)
        {
            frmListEditor editor = new frmListEditor();
            editor.cboName = cboName;
            editor.MdiParent = this;
            editor.Show();

        }

        private void categoriesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openListEditorForm("cboCategory");
        }

        private void purchaseSourceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openListEditorForm("cboPurchaseSource");
        }

        private void brandToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openListEditorForm("cboBrand");
        }

        private void sToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openListEditorForm("cboStorage");
        }

        private void whereListedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openListEditorForm("cboWhereListed");
        }
    }
}
