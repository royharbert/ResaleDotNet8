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
using Excel = Microsoft.Office.Interop.Excel;
using System.Security;

namespace ResaleV8
{ 
    public partial class frmTest : Form
    {
        public frmTest()
        {
            InitializeComponent();
            //cboInput.SelectedIndex = 0;
            GV.conString = "server=localhost;uid=dbUser;pwd=dbUser;database=MagicFinds";
        }


        private void button1_Click(object sender, EventArgs e)
        {
            var xlApp = ComInteropHelper.GetActiveObject("Excel.Application");

        }


        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
        }
    }
}
