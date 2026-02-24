using Microsoft.VisualBasic.ApplicationServices;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Common;
using ResaleV8_ClassLibrary;
using ResaleV8_ClassLibrary.DatabaseOps;
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
        public frmSellThru SellThruForm;
        public frmSoldReport SoldReportForm;
        public frmUnsoldReport UnsoldReportForm;
        public frmSellThru SellThruReportForm;  

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
            GV.MainForm = this;
            GV.conString = "server=localhost;uid=dbUser;pwd=dbUser;database=Resale";
            GV.dbMode = DataMode.LiveDB;

            AllItemsForm = new frmAllItems();
            AllItemsForm.MdiParent = this;
            ResultsForm = new frmSearchResults();
            ResultsForm.MdiParent = this;
            ListEditorForm = new frmListEditor();   
            ListEditorForm.MdiParent = this;
            SellThruForm = new frmSellThru();
            SellThruForm.MdiParent = this;
            SoldReportForm = new frmSoldReport();
            SoldReportForm.MdiParent = this;
            UnsoldReportForm = new frmUnsoldReport();
            UnsoldReportForm.MdiParent = this;
            SellThruReportForm = new frmSellThru();




            GV.Categories = DataAccess.GetDropDownList("categories");

            GV.StorageLocations = DataAccess.GetDropDownList("storagelocations");

            GV.PurchaseSources = DataAccess.GetDropDownList("purchasesources");

            GV.Brands = DataAccess.GetDropDownList("brands");

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
            //frmSellThru sellThruForm = new frmSellThru();
            //sellThruForm.MdiParent = this;
            SellThruForm.Show();
        }

        private void liveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GV.dbMode = DataMode.LiveDB;
            DataModeChangedEventArgs? eventArgs = new DataModeChangedEventArgs();
            GV.dbMode = DataMode.LiveDB;
            eventArgs.NewDataMode = DataMode.LiveDB;
            eventArgs.conString = "server = localhost; uid = dbUser; pwd = dbUser; database = resale";            
            OnDatabaseModeChanged?.Invoke(this, eventArgs); 
            eventArgs = null;
        }

        private void sandboxToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GV.dbMode = DataMode.SandboxDB;
            DataModeChangedEventArgs? eventArgs = new DataModeChangedEventArgs();
            eventArgs.NewDataMode = DataMode.SandboxDB;
            eventArgs.conString = "server = localhost; uid = dbUser; pwd = dbUser; database = sandboxresale";
            GV.dbMode = DataMode.SandboxDB;
            OnDatabaseModeChanged?.Invoke(this, eventArgs );
            eventArgs = null;
        }
    }
}
