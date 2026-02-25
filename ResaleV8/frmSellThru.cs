using Google.Protobuf.WellKnownTypes;
using ResaleV8_ClassLibrary;
using ResaleV8_ClassLibrary.Models;
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
using ZedGraph;

namespace ResaleV8
{
    public partial class frmSellThru : Form
    {
        GraphPane graphPane;
        private frmMain parent;
        public frmSellThru()
        {
            parent = GV.MainForm as frmMain;
            InitializeComponent();
            parent.OnDatabaseModeChanged += Parent_OnDatabaseModeChanged;

            graphPane = zgc.GraphPane;


            List<string> brands = DataAccess.GetAllBrands();
            List<SellThruModel> sellThrus = Operations.DoBrandsSellThru(brands);
            dgvSellThru.DataSource = sellThrus;
            Operations.FormatSellThruDGV(dgvSellThru);

            // Build the bar series from the sellThrus list
            //graphPane.CurveList.Clear();
            //graphPane.GraphObjList.Clear();

            // Create bar and add points safely
            //BarItem bar = graphPane.AddBar("Sell Thru %", null, null, Color.Blue);
            //for (int i = 0; i < sellThrus.Count; i++)
            //{
            //     Use X = category index, Y = sell-thru value
            //    bar.AddPoint(i, sellThrus[i].SellThruPct);
            //}
            // Show brand names as text labels along the X axis (adjust if you prefer them on Y)
            //graphPane.YAxis.Type = AxisType.Text;
            //graphPane.YAxis.Scale.TextLabels = sellThrus.Select(s => s.Brand).ToArray();

            //zgc.AxisChange();
            //zgc.Invalidate();


            // prepare pane
            graphPane = zgc.GraphPane;
            graphPane.Title.Text = "Sell Thru by Brand";
            graphPane.XAxis.Title.Text = "Sell Thru %";
            graphPane.YAxis.Title.Text = "Brand";

            // clear existing curves/objects
            graphPane.CurveList.Clear();
            graphPane.GraphObjList.Clear();

            // create bar series
            BarItem bar = graphPane.AddBar("Sell Thru %", null, null, Color.SteelBlue);

            // add points: X = sell-thru value (bar length), Y = ordinal index (category)
            for (int i = 0; i < sellThrus.Count; i++)
            {
                double value = sellThrus[i].SellThruPct;   // bar length on X
                bar.AddPoint(value, i);                    // category index on Y                
            }

            // make Y axis show brand names
            graphPane.YAxis.Type = AxisType.Text;
            graphPane.YAxis.Scale.TextLabels = sellThrus.Select(s => s.Brand).ToArray();

            // optional styling
            bar.Bar.Fill = new Fill(Color.SteelBlue);
            bar.Bar.Border.Color = Color.Black;

            // refresh
            zgc.AxisChange();
            zgc.Invalidate();
        }

        private void Parent_OnDatabaseModeChanged(object? sender, DataModeChangedEventArgs e)
        {
            FormControlOps.SetDBModeIndicator(lblDBMode, e);
        }

        private void frmSellThru_Load(object sender, EventArgs e)
        {
            List<string> brands = DataAccess.GetAllBrands();
            List<SellThruModel> sellThrus = Operations.DoBrandsSellThru(brands);
            dgvSellThru.DataSource = sellThrus;
            Operations.FormatSellThruDGV(dgvSellThru);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dgvSellThru_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int colIndex = e.ColumnIndex;
            List<SellThruModel> sellThruList = (List<SellThruModel>)dgvSellThru.DataSource;
            switch (colIndex)
            {
                case 0: // Brand
                    sellThruList = sellThruList.OrderByDescending(s => s.Brand).ToList();
                    break;
                case 1: // Total Items
                    sellThruList = sellThruList.OrderByDescending(s => s.TotalItems).ToList();
                    break;
                case 2: // Total Sold
                    sellThruList = sellThruList.OrderByDescending(s => s.TotalSold).ToList();
                    break;
                case 3: // Sell Thru %
                    sellThruList = sellThruList.OrderByDescending(s => s.SellThruPct).ToList();
                    break;
                case 4: // Profit %
                    sellThruList = sellThruList.OrderByDescending(s => s.ProfitPct).ToList();
                    break;
                case 5: // Financial Position
                    sellThruList = sellThruList.OrderByDescending(s => s.FinancialPosition).ToList();
                    break;
            }
            dgvSellThru.DataSource = null;
            dgvSellThru.DataSource = sellThruList;
            Operations.FormatSellThruDGV(dgvSellThru);
        }

        private void frmSellThru_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }

        private void frmSellThru_VisibleChanged(object sender, EventArgs e)
        {
            DataModeChangedEventArgs ea = new DataModeChangedEventArgs();
            ea.conString = GV.conString;
            ea.NewDataMode = GV.dbMode;
            Parent_OnDatabaseModeChanged(this, ea);
        }
    }
}
