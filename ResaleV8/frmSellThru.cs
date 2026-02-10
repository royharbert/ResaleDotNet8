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

namespace ResaleV8
{
    public partial class frmSellThru : Form
    {
        public frmSellThru()
        {
            InitializeComponent();
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
    }
}
