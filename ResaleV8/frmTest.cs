using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
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
            args.escapedItem = input;
            args.unescapedItem = input;

            //Loop through input strings and locate instance of espcaped single quotes
            if (input.Contains("''"))
            {
                args.unescapedItem = input.Replace("''", "'");
            }
            else
            {
                caretPos = input.IndexOf('\'', caretPos);
                int oldPos = 0;
                while (caretPos != -1 && caretPos != oldPos)
                {
                    oldPos = caretPos;
                    args.escapedItem = input.Replace("'", "''");
                    args.unescapedItem = input;
                    caretPos = input.IndexOf('\'', caretPos);
                }

            }

            return args;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            DropDownEventArgs args = ControlEscapeChars();
            textBox1.Text = args.unescapedItem;
            textBox2.Text = args.escapedItem;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
        }
    }
}
