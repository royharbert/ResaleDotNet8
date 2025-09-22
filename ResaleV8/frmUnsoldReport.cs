using MySql.Data.MySqlClient;
using ResaleV8_ClassLibrary;
using ResaleV8_ClassLibrary.DatabaseOps;
using ResaleV8_ClassLibrary.ExcelOps;
using Excel = Microsoft.Office.Interop.Excel;
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
    public partial class frmUnsoldReport : Form
    {
        string[] hiddenColumns = new string[] { "Sale Date", "Sale Price", "Profit" };
        public frmUnsoldReport()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmUnsoldReport_Load(object sender, EventArgs e)
        {
            MySqlConnection con = ConnectToDB.OpenDB();
            dgvUnsold.DataSource = DataAccess.getData(con,
                query: "Select * from purchased_items where sale_date = '1900-01-01'");
            string[] columnsToHide = { "product_age", "Profit" };
            FormControlOps.formatDGV(dgvUnsold,
                headers: new string[] { "ID", "Description", "Quantity", "Purchase Date",
                    "Purchase Price", "Sale Date", "Sale Price", "Storage Location",
                    "Product Age", "Profit" },
                columnsToHide);
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            DataTable dt = (DataTable)dgvUnsold.DataSource;
            ExcelOps.createExcelSheet(dt, "Unsold Report", false, hiddenColumns);            
        }
    }
}
