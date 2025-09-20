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
            FormControlOps.formatDGV(dgvUnsold,
                headers: new string[] { "ID", "Description", "Quantity", "Purchase Date",
                    "Purchase Price", "Sale Date", "Sale Price", "Storage Location",
                    "Product Age (Days)", "Profit" },
                hiddenColumns: new string[] { "Sale_Date", "Sale_Price", "Product_Age", "Profit" });
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            DataTable dt = (DataTable)dgvUnsold.DataSource;

            Excel.Application xlApp = ExcelOps.makeExcelApp();
            Excel.Workbook workbook = ExcelOps.makeExcelWorkbook(xlApp);
            Excel.Worksheet wks = ExcelOps.makeExcelWorksheet(workbook, "Sold Report");
            string[] headers = { "ID", "Item Description", "Quantity", "Purchase Date",
                "Purchase Price", "Sale Date", "Sale Price", "Storage Location"," Profit", "Days Held" };
            int[] colWidth = { 5, 30, 10, 15, 15, 15, 15, 30, 10, 10 };
            int dataStartRow = ExcelOps.makeTitle(wks, 1, headers.Length, "Sold Report", headers);
            ExcelOps.setCellWidth(wks, colWidth);
            ExcelOps.insertDataTable(wks, dataStartRow, 1, (DataTable)dgvUnsold.DataSource);
            int[] currencyCols = { 5, 7, 9 };
            ExcelOps.formatColumnAsCurrency(wks, currencyCols);

            ExcelOps.releaseObject(wks);
        }
    }
}
