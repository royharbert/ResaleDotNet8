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
        public frmAllItems allItemsForm = null;
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
            frmAllItems allItemsForm = new frmAllItems();
            GV.AllItemsForm = allItemsForm;

            GV.conString = "server=localhost;uid=dbUser;pwd=dbUser;database=Resale";

            GV.Categories = DataAccess.GetDropDownList("categories");

            GV.StorageLocations = DataAccess.GetDropDownList("storagelocations");

            GV.PurchaseSources = DataAccess.GetDropDownList("purchasesources");

            GV.Brands = DataAccess.GetDropDownList("brands");

            GV.WhereListed = DataAccess.GetDropDownList("wherelisted");
            GV.BusinessSummary = new BusinessSummary();
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

        private void openListEditorForm()
        {
            frmListEditor editor = new frmListEditor();
            //editor.cbo = cbo;
            editor.MdiParent = this;
            editor.Show();

        }

        private void categoriesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ComboBox cbo = allItemsForm.cboCategory;
            openListEditorForm(cbo);
        }

        private void purchaseSourceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            openListEditorForm();
            
        }

        private void brandToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ComboBox cbo = GV.AllItemsForm.cboBrand;
            openListEditorForm(cbo);
        }

        private void sToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ComboBox cbo = allItemsForm.cboStorage;
            openListEditorForm(cbo);
        }

        private void whereListedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ComboBox cbo = allItemsForm.cboWhereListed;
            openListEditorForm(cbo);
        }
    }
}
