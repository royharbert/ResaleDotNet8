using ResaleV8_ClassLibrary.Models;
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

namespace ResaleV8
{
    public partial class frmMarkSold : Form
    {
        public ItemModel model { get; set; }

        public frmMarkSold()
        {
            InitializeComponent();
            this.AcceptButton = btnDone;
        }

        private void LoadModel()
        {
            model.SaleDate = dtpSaleDate.Value;
            model.SalePrice = Convert.ToDecimal(txtSalePrice.Text);
        }

        private void btnDone_Click(object sender, EventArgs e)
        {
            LoadModel();
        }
    }
}
