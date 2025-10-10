using ResaleV8_ClassLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ResaleV8
{
    public partial class frmListEditor : Form
    {
        public string cboName { get; set; }
        public frmListEditor()
        {
            InitializeComponent();
        }

        private void frmListEditor_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();

            switch (cboName)
            {
                case "cboCategory":
                    dt = DataAccess.GetComboItemList("categories");
                    break;
                case "cboStorage":
                    dt = DataAccess.GetComboItemList("storageLocations");
                    break;
                case "cboPurchaseSource":
                    dt = DataAccess.GetComboItemList("purchasesources");
                    break;
                case "cboBrand":
                    dt = DataAccess.GetComboItemList("brands");
                    break;
                case "cboWhereListed":
                    dt = DataAccess.GetComboItemList("whereListed");
                    break;
            }
            dgvEditor.DataSource = dt;
            formatDGV();
        }

        private void formatDGV()
        {
            dgvEditor.Columns[0].Visible = false;
            dgvEditor.Columns[1].Width = 200;
            dgvEditor.Columns[1].HeaderText = "Item";
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dgvEditor_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int rowIndex = e.RowIndex;
            if (rowIndex >= 0) // Ensure the row index is valid
            {
                DataGridViewRow selectedRow = dgvEditor.Rows[rowIndex];
                txtItem.Text = selectedRow.Cells[1].Value.ToString();
            }
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            DataTable dt = (DataTable)dgvEditor.DataSource;
            if (dgvEditor.CurrentRow != null)
            {
                int selectedIndex = dgvEditor.CurrentRow.Index;
                int id = Convert.ToInt32(dt.Rows[selectedIndex]["ID"]);
                string newValue = txtItem.Text.Trim();
                if (!string.IsNullOrEmpty(newValue))
                {
                    dt.Rows[selectedIndex][1] = newValue;
                    //DataAccess.UpdateComboItem(cboName, id, newValue);
                    MessageBox.Show("Item updated successfully.");
                }
                else
                {
                    MessageBox.Show("Item cannot be empty.");
                }
            }
            else
            {
                MessageBox.Show("No row selected.");
            }
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            DataAccess.addListToDropDownTable("test", GV.categories);
        }
    }
}
