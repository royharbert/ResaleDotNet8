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
            model.Item_Category = cboCategory.Text;
            model.Purchase_Date = dtpBuy.Value;
            model.Purchase_Price = float.Parse(txtPurchasePrice.Text);
            model.Quantity = int.Parse(txtQuantity.Text);
            model.storage_location = cboStorage.Text;
            model.Sale_Date = new DateTime(1900, 01, 01);
            model.Sale_Price = 0.0f;

            return model;
        }



        private void btnSave_Click(object sender, EventArgs e)
        {
            loadModel();
            int newID = DataAccess.addItemToDatabase(model);
            txtID.Text = newID.ToString();
            //Application.DoEvents();
            //Thread.Sleep(500);
            //this.Close();
        }

        private void resetForm()
        {
            txtID.Text = "";
            txtDesc.Text = "";
            dtpBuy.Value = DateTime.Now;
            txtPurchasePrice.Text = "";
            txtQuantity.Text = "";
            cboStorage.SelectedIndex = -1;
            cboCategory.SelectedIndex = -1;
        }

        private void btnSaveAdd_Click(object sender, EventArgs e)
        {
            loadModel();
            DataAccess.addItemToDatabase(model);
            resetForm();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmAdd_Load(object sender, EventArgs e)
        {
            cboCategory.DataSource = GV.categories;
            cboCategory.SelectedIndex = -1;
        }

        private void comboListMaintenance(object sender, EventArgs e)
        {
            /*
             * Check to see if text is in items collection
             * If not, add it to list
             *  Insert it into data table
             */
            ComboBox cbo = sender as ComboBox;
            ddEventArgs ea = new ddEventArgs();
            if (!cbo.Items.Contains (cbo.Text) && cbo.Text != "")
            {
                GV.categories.Add(cbo.Text);
                GV.categories.Sort();
                if (cbo.Name == "cboCategory")
                {
                    {
                        ea.newItem = cboCategory.Text;
                        ea.tableName = "Categories";
                        ea.columnName = "CategoryList";
                    } 
                }
                ;

                if (true)
                {
                    DataAccess.addDropDownItemToTable(ea.newItem, ea.columnName, ea.tableName);
                }

    
                cboCategory.DataSource = null;
                cboCategory.DataSource = GV.categories;
                cboCategory.SelectedItem = model.Item_Category;
            }
        }
    }
}

class ddEventArgs : EventArgs
{
    public string newItem { get; set; }
    public string tableName { get; set; }
    public string columnName { get; set; }
    public List<string> gvList { get; set; }
}
