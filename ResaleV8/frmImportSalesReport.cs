using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ResaleV8_ClassLibrary;
using ResaleV8_ClassLibrary.ExcelOps;

namespace ResaleV8
{
    public partial class frmImportSalesReport : Form
    {
        public frmImportSalesReport()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            int startRow = Convert.ToInt32(txtStart.Text);
            int stopRow = Convert.ToInt32(txtStop.Text);
            pBar.Minimum = startRow;
            pBar.Maximum = stopRow;
            pBar.Step = 1;
            int importedItems = stopRow - startRow + 1;
            ExcelOps.ImportPoshmarkSalesReportToDB(startRow, stopRow, pBar);
            MessageBox.Show("Process complete." + importedItems + " items imported.");
        }
    }
}
