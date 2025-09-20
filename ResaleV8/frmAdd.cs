using MySql.Data.MySqlClient;
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
using System.Threading;

namespace ResaleV8
{
    public partial class frmAdd : Form
    {
        ItemModel model = new ItemModel();

        public frmAdd()
        {
            InitializeComponent();
        }

        private ItemModel loadModel()
        {
            model.Item_Desc = txtDesc.Text;
            model.Purchase_Date = dtpBuy.Value;
            model.Purchase_Price = float.Parse(txtPurchasePrice.Text);
            model.Quantity = int.Parse(txtQuantity.Text);
            model.storage_location = cboStorage.Text;

            return model;
        }



        private void btnSave_Click(object sender, EventArgs e)
        {
            loadModel();
            int newID = DataAccess.addItemToDatabase(model);
            txtID.Text = newID.ToString();
            Application.DoEvents();
            Thread.Sleep(500);
            //this.Close();
        }

        private void resetForm()
        {
            txtID.Text = "";
            txtDesc.Text = "";
            dtpBuy.Value = DateTime.Now;
            txtPurchasePrice.Text = "";
            txtQuantity.Text = "";
            cboStorage.Text = "";
        }

        private void btnSaveAdd_Click(object sender, EventArgs e)
        {
            loadModel();
            DataAccess.addItemToDatabase(model);
            //MySqlConnection con = ConnectToDB(GV.conString);
            //DataAccess.getData(); // Use the correct namespace/class as per your existing usage above
            resetForm();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }       
    }
}
