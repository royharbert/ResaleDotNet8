using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using System.Runtime.InteropServices;
using ResaleV8_ClassLibrary;
using ResaleV8_ClassLibrary.Models;
using Microsoft.Office.Interop.Excel;
using System.Runtime.InteropServices.ComTypes;
using static System.Collections.Specialized.BitVector32;

namespace ResaleV8_ClassLibrary.ExcelOps    
{
    public class ExcelOps
    {
        public static Excel.Application makeExcelApp()
        {
            Excel.Application xlApp = new Excel.Application();
            xlApp.Visible = true;
            return xlApp;
        }

        public static Excel.Workbook makeExcelWorkbook(Excel.Application xlApp)
        {
            Excel.Workbook workbook = xlApp.Workbooks.Add();
            return workbook;
        }

        public static Excel.Worksheet makeExcelWorksheet(Excel.Workbook workbook, string sheetName)
        {
            Excel.Worksheet wks = (Excel.Worksheet)workbook.Sheets.Add();
            wks.Name = sheetName;
            return wks;
        }

        public static void setCellWidth(Excel.Worksheet wks, int[] width)
        {
            for (int col = 1; col <= width.Length; col++)
            {
                wks.Columns[col].ColumnWidth = width[col - 1];
            }
        }

        public static void insertDataTable(Worksheet wks, int startRow, int startCol, System.Data.DataTable dt,
            bool isSoldReport)
        {
            int row = startRow;
            int col = startCol;
            row = row + 1;
            foreach (System.Data.DataRow dataRow in dt.Rows)

                col = startCol;
            for (row = startRow; row < (dt.Rows.Count + startRow); row++)
            {
                for (col = 1; col <= dt.Columns.Count; col++)
                {
                    wks.Cells[row, col].Value = dt.Rows[row - startRow][col - 1];
                }
                placeProfitInCell(wks, row, 9);
                placeDaysHeldInCell(wks, row, 10);
            }

        }

        public static int placeDaysHeldInCell(Excel.Worksheet wks, int row, int col)
        {
            DateTime purchaseDate = (DateTime)wks.Cells[row, 4].Value;
            DateTime saleDate = (DateTime)wks.Cells[row, 6].Value;
            if (saleDate.Year == 1900)
            {
                saleDate = DateTime.Now;
            }
            return wks.Cells[row, col].Value = (saleDate - purchaseDate).Days;
        }

        public static double placeProfitInCell(Excel.Worksheet wks, int row, int col)
        {
            return wks.Cells[row, col].Value = wks.Cells[row, 7].Value - wks.Cells[row, 5].Value;
        }

        public static object GetCellValue(Excel.Worksheet wks, int row, int column)
        {
            object obj = wks.Cells[row, column].Value;
            return obj;
        }

        /// <summary>
        /// Places text in worksheet at specified row, col
        /// </summary>
        /// <param name="wks"></param>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <param name="txt"></param>
        public static void PlaceTextInWorksheet(Worksheet wks, int row, int col, string txt)
        {
            wks.Cells[row, col].Value = txt;
        }
        /// <summary>
        /// Returns column number of first occurence of searchTerm in range
        /// </summary>
        /// <param name="wks"></param>
        /// <param name="searchTerm"></param>
        /// <param name="range"></param>
        /// <returns></returns>
        public static int GetColumn(Worksheet wks, string searchTerm, Excel.Range range)
        {
            Excel.Range result = range.Find(searchTerm);

            return result.Column;
        }

        /// <summary>
        /// Returns row first number containing searchTerm
        /// </summary>
        /// <param name="range"></param>
        /// <param name="searchTerm"></param>
        /// <returns></returns>
        public static int FindHeaderRow(Excel.Range range, string searchTerm)
        {
            Excel.Range result = range.Find(searchTerm);
            return result.Row;
        }

        //Finds last used row in spreadsheet
        public static int FindLastSpreadsheetRow(Worksheet wks)
        {
            int rowIndex = wks.Cells.Find("*", System.Reflection.Missing.Value, System.Reflection.Missing.Value, System.Reflection.Missing.Value,
                XlSearchOrder.xlByRows, Microsoft.Office.Interop.Excel.XlSearchDirection.xlPrevious, false, System.Reflection.Missing.Value,
                System.Reflection.Missing.Value).Row;

            return rowIndex;
        }
        public static void setDollarDecimalPlaces(Worksheet wks, int decimals, int startRow, int stopRow,
            int startCol, int stopCol)
        {
            int[] bounds = { startRow, stopRow, startCol, stopCol };
            decimal val;
            for (int i = startRow; i <= stopRow; i++)
            {
                for (int j = startCol; j <= stopCol; j++)
                {
                    val = (decimal)wks.Cells[i, j].Value;
                    val = val * 100;
                    val = Math.Round(val, decimals);
                    val = val / 100;
                    wks.Cells[i, j].Value = val;
                }

                string formatString = "$#,###,###.00";
                //string decimalString = "";
                //if (decimals > 0)
                //{
                //    decimalString = ".00" + new string('#', decimals) + decimalString;
                //}
                Excel.Range range = wks.Range[wks.Cells[bounds[0], bounds[2]], wks.Cells[bounds[1], bounds[3]]];
                //formatString = formatString + decimalString;
                range.NumberFormat = formatString;
            }
        }

        public static void formatColumnAsCurrency(Worksheet wks, int[] cols)
        {
            foreach (var col in cols)
            {
                Excel.Range range = wks.Columns[col];
                string formatString = "$#,###,###.00";
                range.NumberFormat = formatString;
            }
        }

        private static void setDecimalPlaces(Excel.Worksheet wks, int decimals, int startRow, int stopRow, int startCol, int stopCol)
        {
            int[] bounds = { startRow, stopRow, startCol, stopCol };
            decimal val;
            for (int i = startRow; i <= stopRow; i++)
            {
                for (int j = startCol; j <= stopCol; j++)
                {
                    val = (decimal)wks.Cells[i, j].Value;
                    val = val * 100;
                    val = Math.Round(val, decimals);
                    val = val / 100;
                    wks.Cells[i, j].Value = val;
                }

                string formatString = "#,###,###,##0";
                string decimalString = "";
                if (decimals > 0)
                {
                    decimalString = ".0" + new string('#', decimals) + decimalString;
                }
                Excel.Range range = wks.Range[wks.Cells[bounds[0], bounds[2]], wks.Cells[bounds[1], bounds[3]]];
                formatString = formatString + decimalString;
                range.NumberFormat = formatString;
            }
        }

        private static void setPercentDecimalPlaces(Excel.Worksheet wks, int decimals, int startRow, int stopRow, int startCol, int stopCol)
        {
            int[] bounds = { startRow, stopRow, startCol, stopCol };
            decimal val;
            for (int i = startRow; i <= stopRow; i++)
            {
                for (int j = startCol; j <= stopCol; j++)
                {
                    val = (decimal)wks.Cells[i, j].Value;
                    val = val * 100;
                    val = Math.Round(val, decimals);
                    val = val / 100;
                    wks.Cells[i, j].Value = val;
                }
            }
            //*
            Excel.Range range = wks.Range[wks.Cells[bounds[0], bounds[2]], wks.Cells[bounds[1], bounds[3]]];
            /*/
            Excel.Range range = wks.Range[wks.Cells[bounds[0], bounds[2]], wks.Cells[bounds[1], bounds[3]]];
            //*/
            string formatString = "##0";
            string decimalString = "%";
            if (decimals > 0)
            {
                decimalString = ".0" + new string('#', decimals) + decimalString;
            }

            formatString = formatString + decimalString;
            range.NumberFormat = formatString;
        }
        public static int makeTitle(Excel.Worksheet wks, int row, int rightmostCol, string title,
            string[] columnHeaders)
        {
            wks.Cells[row, 1].Value = title;
            wks.Cells[row, 1].Font.Size = 20;
            wks.Cells[row, 1].Font.Bold = true;
            var headerRow = wks.Cells[row + 1, 1];
            headerRow.RowHeight = 45;
            Excel.Range range = wks.Range[wks.Cells[row, 1], wks.Cells[row + 1, rightmostCol]];
            Excel.Range titleRow = wks.Range[wks.Cells[row, 1], wks.Cells[row, rightmostCol]];
            titleRow.Cells.Merge();
            range.Cells.HorizontalAlignment = HorizontalAlignment.Center;

            int col = 1;
            foreach (var column in columnHeaders)
            {
                wks.Cells[row + 1, col].Value = columnHeaders[col - 1];
                col = col + 1;
            }
            range.Font.Bold = true;
            range.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            range.Interior.Color = ColorTranslator.ToOle(System.Drawing.Color.LightSkyBlue);
            range.WrapText = true;
            row = row + 2;
            return row;
        }

        public static Excel.Application OpenExcelWorkbook(Excel.Application xlApp, string WorkbookName)
        {

            Excel.Workbook workbook = xlApp.Workbooks.Open(WorkbookName);
            return xlApp;
        }

        public static void releaseObject(object obj)
        {
            try
            {
                Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
                MessageBox.Show("Unable to release the Object " + ex.ToString());
            }
            finally
            {
                GC.Collect();
            }
        }

        public static void createExcelSheet(System.Data.DataTable dt, string title, bool isSoldReport,
            string[] hiddenColumns)
        {
            Excel.Application xlApp = ExcelOps.makeExcelApp();
            Workbook workbook = ExcelOps.makeExcelWorkbook(xlApp);
            Worksheet wks = ExcelOps.makeExcelWorksheet(workbook, "Sold Report");
            string[] headers = { "ID", "Item Description", "Quantity", "Purchase Date",
                "Purchase Price", "Sale Date", "Sale Price", "Storage Location"," Profit", "Days Held" };
            int[] colWidth = { 5, 30, 10, 15, 15, 15, 15, 30, 10, 10 };
            int dataStartRow = ExcelOps.makeTitle(wks, 1, headers.Length, title, headers);
            setCellWidth(wks, colWidth);
            insertDataTable(wks, dataStartRow, 1, dt, isSoldReport);
            int[] currencyCols = { 5, 7, 9 };
            ExcelOps.formatColumnAsCurrency(wks, currencyCols);
            hideColumns(wks, hiddenColumns);

            ExcelOps.releaseObject(wks);
        }

        public static void hideColumns(Worksheet wks, string[] hiddenColumns)
        {
            Excel.Range headerRange = wks.Rows[2];
            foreach (var hiddenColumn in hiddenColumns)
            {
                int col = GetColumn(wks, hiddenColumn, headerRange);
                wks.Columns[col].EntireColumn.Hidden = true;
            }
        }
    }
}
