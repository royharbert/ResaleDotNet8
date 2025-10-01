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

        private void addItemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAdd addItemForm = new frmAdd();
            addItemForm.MdiParent = this;
            addItemForm.Show();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            GV.conString = "server=localhost;uid=dbUser;pwd=dbUser;database=Resale";
            MySqlConnection con = ConnectToDB.OpenDB();
            DataTable dtCat = DataAccess.getData(con, "Select CategoryList from Categories");
            GV.categories = dtCat.AsEnumerable()
                         .Select(row => row.Field<string>("CategoryList"))
                         .ToList();

            GV.conString = "server=localhost;uid=dbUser;pwd=dbUser;database=Resale";
            con = ConnectToDB.OpenDB();
            DataTable dtLoc = DataAccess.getData(con, "Select Locations from storage_locations");
            GV.storageLocations = dtLoc.AsEnumerable()
                               .Select(row => row.Field<string>("Locations"))
                               .ToList();
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

        private void markIemAsSoldToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMarkSold markSoldForm = new frmMarkSold();
            markSoldForm.MdiParent = this;
            markSoldForm.Show();
        }
    }
}
