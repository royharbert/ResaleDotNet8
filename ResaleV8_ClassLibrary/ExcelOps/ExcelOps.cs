using Org.BouncyCastle.Bcpg.OpenPgp;
using ResaleV8;
using ResaleV8_ClassLibrary;
using ResaleV8_ClassLibrary.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZstdSharp.Unsafe;
using static System.Collections.Specialized.BitVector32;
using Microsoft.Office.Interop.Excel;
using Excel = Microsoft.Office.Interop.Excel;

namespace ResaleV8_ClassLibrary.ExcelOps      
{
    public class ExcelOps
    {
        public static Excel.Application SetExcelInstance()
        {
            Excel.Application? xlApp = null;
            //See if excel is already open. If so, use that instance. Else, create new instance.
            Process[] processes = Process.GetProcessesByName("excel");
            if (processes.Length > 0)
            {
                try
                {
                    xlApp = ComInteropHelper.GetActiveObject("Excel.Application") as Excel.Application;
                }
                catch (Exception)
                {
                    xlApp = new Excel.Application();
                }
                if (xlApp.ActiveSheet != null && xlApp.ActiveWorkbook.Name != "sales_activity_report.xlsx" )
                {
                    xlApp = OpenExcelFile(xlApp);
                }
            }
            else
            {
                xlApp = xlApp = new Excel.Application();
            }

            return xlApp;  
        }

        public static Excel.Application OpenExcelFile(Excel.Application xlApp)
        {
            //Get excel file path from user
            //Open file dialog to select excel file
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                openFileDialog.Filter = "Excel files (*.xlsx)|*.xlsx|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 1;
                openFileDialog.RestoreDirectory = true;
                openFileDialog.Multiselect = false;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string file = openFileDialog.FileName;
                    if (System.IO.File.Exists(file))
                    {
                        xlApp.Workbooks.Open(file);
                    }
                }
            }
            return xlApp;
        }

        public static ImportRangeModel GetImportRange(Worksheet wks)
        {
            ImportRangeModel model = new ImportRangeModel();
            model.StartRow = GetFirstSalesReportRow(wks, "Listing Date");
            model.StopRow = GetLastSalesReportRow(wks, "Totals");
            return model;
        }


        public static void ImportPoshmarkSalesReportToDB(int startRow, int stopRow, ProgressBar pb)
        {
            Cursor.Current = Cursors.WaitCursor;
            string filePath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) +
                @"\sales_activity_report";
            //create excel app
            Excel.Application xlApp = SetExcelInstance();
            Workbook wkb = xlApp.ActiveWorkbook;
            Worksheet wks = null;
            //If no active workbook, prompt user to select file. Else, check if active workbook is sales report.
            //If not, prompt user to select file. If it is, set wks to sales report sheet.
            if (wkb == null)
            {
                xlApp = OpenExcelFile(xlApp);
                //wkb = xlApp.ActiveWorkbook;
            }
            else
            {
                if (xlApp.ActiveWorkbook.Name != "sales_activity_report.xlsx")
                {
                    OpenExcelFile(xlApp);
                    wkb = xlApp.ActiveWorkbook;
                }
                wks = wkb.Worksheets["sales_activity_report.xlsx"];
                wks.Activate();
            }
            Cursor.Current = Cursors.Default;
            //Create ItemModel
            ItemModel model = new ItemModel();
            //Create model map to excel cells
            //Loop through rows in excel file and create ItemModel for each row
            MapXLSheetAndItemModel(wks, startRow, stopRow, pb);
            //Add each ItemModel to database
            releaseObject(xlApp);
        }

        public static int GetFirstSalesReportRow(Worksheet wks, string stringToFind)
        {
            var range = (Excel.Range)wks.Columns["A:A"];
            var result = range.Find(stringToFind, LookAt: Excel.XlLookAt.xlWhole);
            var address = result.Address;//cell address
            string[] parts = address.Split('$');
            int row = int.Parse(parts[2]) + 1;
            return row;
        }

        public static int GetLastSalesReportRow(Worksheet wks, string stringToFind)
            {
                var range = (Excel.Range)wks.Columns["A:A"];
                var result = range.Find(stringToFind, LookAt: Excel.XlLookAt.xlWhole);
                var address = result.Address;//cell address
                string[] parts = address.Split('$');
                int row = int.Parse(parts[2]) - 2;
            return row;
            }
        
        private static void MapXLSheetAndItemModel(Worksheet wks, int startRow, int stopRow, ProgressBar pb)
        {
            int lastRow = GetLastSalesReportRow(wks, "Totals");
            List<ItemModel> modelList = new List<ItemModel>();
            for (int row = startRow; row <= stopRow; row++)
            {
                    ItemModel model = new ItemModel();
                    if (wks.Cells[row, 12].Value == "Y")
                    {
                        model.DiscountPct = GV.BundleDiscount;
                    }
                    if (wks.Cells[row, 3].Value != null)
                    {
                        model.StorageLocation = wks.Cells[row, 3].Value.ToString(); 
                    }
                if (wks.Cells[row, 1].Value != null)                   
                {
                    model.DateListed = wks.Cells[row, 1].Value; 
                }
                    if (wks.Cells[row, 2].Value != null)
                    {
                        model.SaleDate = wks.Cells[row, 2].Value;
                    }
                    model.WhereListed = "Poshmark";
                    model.Category = wks.Cells[row, 7].Value;
                    if (wks.Cells[row, 9].Value != null)
                    {
                        model.Brand = wks.Cells[row, 9].Value.ToString();
                    }
                    else
                    {
                        model.Brand = "Unbranded";
                    }
                    if (wks.Cells[row, 27].Value != null)
                    {
                        model.PurchaseSource = wks.Cells[row, 27].Value.ToString(); 
                    }
                    model.ItemDesc = wks.Cells[row, 5].Value;
                    
                    if (wks.Cells[row, 15].Value != null)
                    {
                        model.PurchasePrice = wks.Cells[row, 15].Value;
                    }
                    model.Color = wks.Cells[row, 10].Value;
                if (wks.Cells[row,17].Value != null)
                {
                    model.ListPrice = wks.Cells[row, 17].Value; 
                }
                if (wks.Cells[row, 16].Value != null)
                {
                    model.SalePrice = wks.Cells[row, 16].Value;
                }

                    model.CostOfSale = model.SalePrice * .2m;
                    model.Quantity = 1;

                    DataAccess.addItemToDatabase(model);
                pb.PerformStep();
                    model = null;
                
            }
        }

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

        public static void insertDataTable(Worksheet wks, int startRow, int startCol, List<ItemModel> dt,
            ExportType exportType)
        {
            int row = startRow;
            int col = startCol;

            foreach (var item in dt)
            {
                col = startCol;
                wks.Cells[row, col++].Value = item.ItemID;
                wks.Cells[row, col++].Value = item.PurchaseSource;
                wks.Cells[row, col++].Value = item.Category;
                wks.Cells[row, col++].Value = item.Brand;
                wks.Cells[row, col++].Value = item.ItemDesc;
                wks.Cells[row, col++].Value = item.Quantity;
                wks.Cells[row, col++].Value = item.PurchaseDate.ToShortDateString();
                wks.Cells[row, col++].Value = item.PurchasePrice;
                wks.Cells[row, col++].Value = item.SaleDate.ToShortDateString();
                wks.Cells[row, col++].Value = item.SalePrice;
                wks.Cells[row, col++].Value = item.CostOfSale;
                wks.Cells[row, col++].Value = item.StorageLocation;
                wks.Cells[row, col++].Value = item.WhereListed;
                wks.Cells[row, col++].Value = item.DateListed.ToShortDateString();
                wks.Cells[row, col++].Value = item.ListPrice;
                wks.Cells[row, col++].Value = item.Profit;
                wks.Cells[row, col++].Value = item.ProductAge;
                row = row + 1;
            }
            row++;

            switch (exportType)
            {
                case ExportType.Sold:
                    if (GV.BusinessSummary != null)
                    {
                        wks.Cells[row, 3].Value = "Total Sales";
                        wks.Cells[row, 4].Value = GV.BusinessSummary.TotalSales;
                        row++;
                        wks.Cells[row, 3].Value = "Total Cost";
                        wks.Cells[row, 4].Value = GV.BusinessSummary.TotalCost;
                        row++;
                        wks.Cells[row, 3].Value = "Total Profit";
                        wks.Cells[row, 4].Value = GV.BusinessSummary.TotalMargin;
                        row++;
                        wks.Cells[row, 3].Value = "Profit Margin %";
                        wks.Cells[row, 4].Value = GV.BusinessSummary.MarginPercentage;
                        setDollarDecimalPlaces(wks, 2, row - 3, row - 1, 4, 4);
                        setPercentDecimalPlaces(wks, 2, row, row, 4, 4);
                    }
                    break;
                case ExportType.Unsold:
                    wks.Cells[row, 3].Value = "Unsold Items Cost";
                    wks.Cells[row, 4].Value = GV.BusinessSummary.UnsoldCost;
                    row++;
                    wks.Cells[row, 3].Value = "Average Age of Unsold Items";
                    wks.Cells[row, 4].Value = GV.BusinessSummary.AvgUnsoldAge;
                    row++;
                    wks.Cells[row, 3].Value = "Unsold Item Count";
                    wks.Cells[row, 4].Value = GV.BusinessSummary.UnsoldItemsCount;
                    setDollarDecimalPlaces(wks, 2, row - 2, row - 2, 4, 4);
                    setDecimalPlaces(wks, 2, row - 1, row - 1, 4, 4);
                    break;
                case ExportType.SearchResults:
                    wks.Cells[row, 3].Value = "Items Cost";
                    wks.Cells[row, 4].Value = GV.BusinessSummary.TotalCost;
                    row++;
                    wks.Cells[row, 3].Value = "Average Age of Unsold Items";
                    wks.Cells[row, 4].Value = GV.BusinessSummary.AvgUnsoldAge;
                    row++;
                    wks.Cells[row, 3].Value = "Unsold Item Count";
                    wks.Cells[row, 4].Value = GV.BusinessSummary.UnsoldItemsCount;
                    setDollarDecimalPlaces(wks, 2, row - 2, row - 2, 4, 4);
                    setDecimalPlaces(wks, 2, row - 1, row - 1, 4, 4);
                    break;                    

            }
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
                XlSearchOrder.xlByRows, XlSearchDirection.xlPrevious, false, System.Reflection.Missing.Value,
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
                
                Excel.Range range = wks.Range[wks.Cells[bounds[0], bounds[2]], wks.Cells[bounds[1], bounds[3]]];
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
                    //val = val * 100;
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

        public static void releaseObject(object? obj)
        {
            try
            {
                if (obj != null)
                {
                    Marshal.ReleaseComObject(obj);
                    obj = null;
                }
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

        public static void createExcelSheet(List<ItemModel> dt, string title,
            string[] hiddenColumns, ExportType reportType, string sheetName)
        {
            Excel.Application xlApp = ExcelOps.makeExcelApp();
            Workbook workbook = ExcelOps.makeExcelWorkbook(xlApp);
            
            
            Worksheet wks = ExcelOps.makeExcelWorksheet(workbook, sheetName);
            
            
            string[] headers = { "ID", "Purchase Source", "Item Category", "Brand", "Item Description", "Quantity", "Purchase Date",
            "Purchase Price", "Sale Date", "Sale Price", "Cost of Sale", "Storage Location", "Where Listed", "Date Listed", "List Price", "Profit", "Days Held" };
            //                 1  2   3   4   5   6   7   8   9   10  11  12  13  14  15
            int[] colWidth = { 5, 30, 30, 15, 30, 10, 10, 15, 12, 12, 15, 20, 15, 12, 12 };
            int dataStartRow = ExcelOps.makeTitle(wks, 1, headers.Length, title, headers);
            setCellWidth(wks, colWidth);
            insertDataTable(wks, dataStartRow, 1, dt, reportType);
            int[] currencyCols = { 8, 10 };
            ExcelOps.formatColumnAsCurrency(wks, currencyCols);
            hideColumns(wks, hiddenColumns);
            MessageBox.Show("Operation complete. " + dt.Count.ToString() + " items imported.");

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
