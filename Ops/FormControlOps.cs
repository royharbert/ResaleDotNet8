using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ResaleDB_ClassLibrary.Ops
{
    public static class FormControlOps
    {
        public static void clearDTPicker(DateTimePicker dtp)
        {
            dtp.Value = GV.emptyDate;
            dtp.Format = DateTimePickerFormat.Custom;
            dtp.CustomFormat = " ";
        }

        public static string dtpValueToString(DateTimePicker dtp)
        {
            if (dtp.Value == GV.emptyDate)
            {
                return "NULL";
            }
            else
            {
                return "'" + dtp.Value.ToString("yyyy-MM-dd") + "'";
            }
        }

        public static void formatDGV(System.Windows.Forms.DataGridView dgv, string[] headers,
            string[] hiddenColumns)
        {
            for (int i = 0; i < headers.Length; i++)
            {
                if (i < dgv.Columns.Count)
                {
                    dgv.Columns[i].HeaderText = headers[i];
                }
            }
            dgv.ColumnHeadersDefaultCellStyle.Alignment = 
                DataGridViewContentAlignment.MiddleCenter;
            foreach (var hiddenColumn in hiddenColumns)
            {
                if (dgv.Columns.Contains(hiddenColumn))
                {
                    dgv.Columns[hiddenColumn].Visible = false;
                }
            }
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            //dgv.AutoResizeColumns();
            dgv.AllowUserToAddRows = false;
            dgv.AllowUserToDeleteRows = false;
            dgv.ReadOnly = true;
            dgv.MultiSelect = false;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv.RowHeadersVisible = true;
            dgv.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            foreach (System.Windows.Forms.DataGridViewColumn col in dgv.Columns)
            {
                col.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            }

        }

        public static void enableDisableControls(Control[] ctls, bool enable)
        {
            foreach (var control in ctls)
            {
                control.Enabled = enable;
            }
        }
    }
}