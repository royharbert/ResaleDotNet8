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
        public frmSellThru()
        {
            InitializeComponent();
            graphPane = zgc.GraphPane;
            graphPane.Title.Text = "Sell Thru by Brand";
            graphPane.XAxis.Title.Text = "Brand";
            graphPane.YAxis.Title.Text = "Sell Thru %";
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
            {   case 0: // Brand
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
    }
}
