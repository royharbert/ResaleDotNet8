using Microsoft.VisualBasic.ApplicationServices;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Common;
using ResaleV8_ClassLibrary;
using ResaleV8_ClassLibrary.DatabaseOps;
using ResaleV8_ClassLibrary.ExcelOps;
using ResaleV8_ClassLibrary.Models;
using ResaleV8_ClassLibrary.Ops;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net.Http.Headers;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ResaleV8
{
    public partial class frmMain : Form
    {

        public frmAllItems AllItemsForm;
        public frmSearchResults ResultsForm;
        public frmListEditor ListEditorForm;
        public frmSoldReport SoldReportForm;
        public frmUnsoldReport UnsoldReportForm; 

        public event EventHandler<DataModeChangedEventArgs> OnDatabaseModeChanged;
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
            GV.BundleDiscount = 10; // Set default bundle discount to 10%
            bool sandBox = Properties.Settings.Default.Sandbox;
            if (sandBox)
            {
                SetDBMode(DataMode.SandboxDB);
                GV.conString = "server = localhost; uid = dbUser; pwd = dbUser; database = sandboxresale";
            }
            else
            {
                SetDBMode(DataMode.LiveDB);
                GV.conString = "server = localhost; uid = dbUser; pwd = dbUser; database = MagicFinds";
            }
            GV.MainForm = this;
            //GV.conString = "server=localhost;uid=dbUser;pwd=dbUser;database=Resale";
            //GV.dbMode = DataMode.LiveDB;

            AllItemsForm = new frmAllItems();
            AllItemsForm.MdiParent = this;
            ResultsForm = new frmSearchResults();
            ResultsForm.MdiParent = this;
            ListEditorForm = new frmListEditor();
            ListEditorForm.MdiParent = this;
            GV.ItemForm = AllItemsForm;
            //SellThruForm = new frmSellThru();
            //SellThruForm.MdiParent = this;
            SoldReportForm = new frmSoldReport();
            SoldReportForm.MdiParent = this;
            UnsoldReportForm = new frmUnsoldReport();
            UnsoldReportForm.MdiParent = this;
            //SellThruReportForm = new frmSellThru();
            ListEditorForm.ParentAllItems = AllItemsForm;




            GV.Categories = DataAccess.GetDropDownList("categories");

            GV.StorageLocations = DataAccess.GetDropDownList("storagelocations");

            GV.PurchaseSources = DataAccess.GetDropDownList("purchasesources");

            GV.Brands = DataAccess.GetDropDownList("brand");

            GV.WhereListed = DataAccess.GetDropDownList("wherelisted");

            GV.BusinessSummary = new BusinessSummary();

            // Get file version of the application
            var fileVersion = FileVersionInfo.GetVersionInfo(Assembly.GetExecutingAssembly().Location).FileVersion;
            Console.WriteLine($"File Version: {fileVersion}");
            this.Text = $"Resale Inventory Management System - Version {fileVersion}";
        }


        private void soldItemReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //frmSoldReport soldReportForm = new frmSoldReport();
            //soldReportForm.MdiParent = this;
            SoldReportForm.Show();
        }

        private void unsoldItemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //frmUnsoldReport unsoldReportForm = new frmUnsoldReport();
            //unsoldReportForm.MdiParent = this;
            UnsoldReportForm.Show();
        }

        private void addItemToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            GV.MODE = Mode.Add;
            //AllItemsForm.MdiParent = this;
            AllItemsForm.Show();
            AllItemsForm.Task = "Add New Item";
        }

        private void editItemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GV.MODE = Mode.Retrieve;
            //AllItemsForm.MdiParent = this;
            AllItemsForm.Show();
            AllItemsForm.Task = "Edit Item";
        }

        private void deleteItemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GV.MODE = Mode.Delete;
            //AllItemsForm.MdiParent = this;
            AllItemsForm.Show();
            AllItemsForm.Task = "Delete Item";
        }

        private void searchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GV.MODE = Mode.Search;
            //frmAllItems allItemsForm = new frmAllItems();
            //allItemsForm.MdiParent = this;
            AllItemsForm.Show();
            AllItemsForm.Task = "Search Items";
        }

        private void openListEditorForm()
        {
            //frmListEditor editor = new frmListEditor();
            //editor.MdiParent = this;
            ListEditorForm.Show();
        }

        private void categoriesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GV.mode = Mode.EditCategories;
            openListEditorForm();
        }

        private void purchaseSourceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GV.mode = Mode.EditPurchaseSources;
            openListEditorForm();
        }

        private void brandToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GV.mode = Mode.EditBrands;
            openListEditorForm();
        }

        private void sToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GV.mode = Mode.EditStorageLocations;
            openListEditorForm();
        }

        private void whereListedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GV.mode = Mode.EditWhereListed;
            openListEditorForm();
        }

        private void brandSellthruToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GV.MODE = Mode.SellThru;
            frmSellThru sellThruForm = new frmSellThru();
            sellThruForm.MdiParent = this;
            sellThruForm.Show();
        }

        private void SetDBMode(DataMode mode)
        {
            GV.dbMode = mode;
            DataModeChangedEventArgs? eventArgs = new DataModeChangedEventArgs();
            eventArgs.NewDataMode = mode;
            switch (mode)
            {
                case DataMode.LiveDB:
                    GV.dbMode = DataMode.LiveDB;
                    eventArgs.conString = "server = localhost; uid = dbUser; pwd = dbUser; database = MagicFinds";
                    Properties.Settings.Default.Sandbox = false;
                    break;

                case DataMode.SandboxDB:
                    GV.dbMode = DataMode.SandboxDB;
                    eventArgs.conString = "server = localhost; uid = dbUser; pwd = dbUser; database = sandboxresale";
                    Properties.Settings.Default.Sandbox = true;
                    break;
                default:
                    throw new ArgumentException("Invalid data mode");
            }
            GV.conString = eventArgs.conString;
            Properties.Settings.Default.Save();
            OnDatabaseModeChanged?.Invoke(this, eventArgs);
            eventArgs = null;

            foreach (Control ctl in this.Controls)
            {
                MdiClient client = ctl as MdiClient;
                if (!(client == null))
                {
                    if (GV.dbMode == DataMode.SandboxDB)
                    {

                        client.BackColor = Color.IndianRed;
                    }
                    else if (!(client == null))
                    {
                        client.BackColor = SystemColors.AppWorkspace;
                    }
                }
            }
        }

        private void liveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetDBMode(DataMode.LiveDB);
        }

        private void sandboxToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetDBMode(DataMode.SandboxDB);
        }

        private void importSalesReportToolStripMenuItem_Click(object sender, EventArgs e)
        {

            frmImportSalesReport importForm = new frmImportSalesReport();
            importForm.MdiParent = this;
            importForm.Show();
        }

        private void brandsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Operations.UpdateDropDownSource("Brand");
        }

        private void categoriesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Operations.UpdateDropDownSource("categories");
        }

        private void whereListedToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Operations.UpdateDropDownSource("wherelisted");
        }
    }
}
