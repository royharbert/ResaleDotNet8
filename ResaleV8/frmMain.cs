using ResaleV8_ClassLibrary;
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
            GV.conString = "server=localhost;uid=dbUser;pwd=dbUser;database=resale";
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
