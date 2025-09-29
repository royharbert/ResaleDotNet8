using MySql.Data.MySqlClient;

using ResaleV8_ClassLibrary;
using ResaleV8_ClassLibrary.DatabaseOps;
using ResaleV8_ClassLibrary.ExcelOps;
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
using Excel = Microsoft.Office.Interop.Excel;

namespace ResaleV8
{
    public partial class frmSoldReport : Form
    {
        string[] hiddenColumns = { };
        public frmSoldReport()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnRun_Click(object sender, EventArgs e)
        {            
            string[] headers = { "ID", "Category", "Item Description", "Quantity", "Purchase Date",
                "Purchase Price", "Sale Date", "Sale Price", "Storage Location" };
            string startDate = FormControlOps.dtpValueToString(dtpStart);
            string stopDate = FormControlOps.dtpValueToString(dtpStop);
            MySqlConnection con = ConnectToDB.OpenDB();
            string query = "Select * from purchased_items where sale_date between "
                + startDate + " and " + stopDate;
            dgvSoldReport.DataSource = DataAccess.getData(con, query);
            FormControlOps.formatDGV(dgvSoldReport, headers, hiddenColumns);
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            DataTable dt = (DataTable)dgvSoldReport.DataSource;
            ExcelOps.createExcelSheet(dt, "Sold Report",true, hiddenColumns);            
        }

        private void frmSoldReport_Load(object sender, EventArgs e)
        {

        }
    }
}
