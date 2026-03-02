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
    public partial class frmTest : Form
    {
        public frmTest()
        {
            InitializeComponent();
        }

        public DropDownEventArgs ControlEscapeChars()
        {
            string input = txtInput.Text;
            int caretPos = 0;
            int selStart = -1;
            int inputLength = input.Length;
            DropDownEventArgs args = new DropDownEventArgs();
            args.originalItem = txtInput.Text;

            //Loop through input strings and locate instance of espcaped single quotes
            caretPos = input.IndexOf('\'', caretPos);
            int oldPos = 0;
            while (caretPos != -1 && caretPos != oldPos)
            {
                oldPos = caretPos;
                args.escapedItem = input.Replace("'", "''");
                args.unescapedItem = input;
                caretPos = input.IndexOf('\'', caretPos);
            }
            return args;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DropDownEventArgs args = ControlEscapeChars();
        }
    }
}
