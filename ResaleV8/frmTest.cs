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

namespace ResaleV8
{
    public partial class frmTest : Form
    {
        public frmTest()
        {
            InitializeComponent();
            //cboInput.SelectedIndex = 0;
            GV.conString = "server=localhost;uid=dbUser;pwd=dbUser;database=MagicFinds";
            List<GenericModel> list = DataAccess.GetDropDownList("Brand");
            cboInput.DataSource = list;
            cboInput.DisplayMember = "Data";
        }


        private void button1_Click(object sender, EventArgs e)
        {
            Process[] processes = Process.GetProcessesByName("excel");
            if (processes.Length > 0)            
            {
                MessageBox.Show(processes.Length + " instances of Excel are running.\nMain Window is " + 
                    processes[0].MainWindowTitle);
            }
            else
            {
                // Avoid compile-time ambiguity between different interop assemblies by creating Excel via COM ProgID
                Type excelType = Type.GetTypeFromProgID("Excel.Application");
                if (excelType != null)
                {
                    object xlApp = Activator.CreateInstance(excelType);
                    try
                    {
                        // use xlApp as dynamic if you need to call members:
                        dynamic app = xlApp;
                        app.Visible = true;
                    }
                    finally
                    {
                        //    try { Marshal.ReleaseComObject(xlApp); } catch { }
                        //    xlApp = null;
                    }
                }
                else
                {
                    MessageBox.Show("Excel is not available on this machine.");
                }
            }
        }


        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
        }
    }
}
