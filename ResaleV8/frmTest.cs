using ResaleV8_ClassLibrary;
using ResaleV8_ClassLibrary.Models;
using ResaleV8_ClassLibrary.Ops;
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
            //cboInput.SelectedIndex = 0;
            GV.conString = "server=localhost;uid=dbUser;pwd=dbUser;database=resale";
            List<GenericModel> list = DataAccess.GetDropDownList("Brands");
            cboInput.DataSource = list;
            cboInput.DisplayMember = "Data";
        }

        public DropDownEventArgs ControlEscapeChars()
        {
            string input = cboInput.Text;
            int caretPos = 0;
            //int selStart = -1;
            int inputLength = input.Length;
            DropDownEventArgs args = new DropDownEventArgs();
            args.originalItem = cboInput.Text;
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

        //public DropDownEventArgs RecursiveControlEscapeChars()
        //{
        //    string input = cboInput.Text;

        //    bool firstPass;

        //    int caretPos = 0;
        //    //int selStart = -1;
        //    int inputLength = input.Length;
        //    DropDownEventArgs args = new DropDownEventArgs();
        //    args.originalItem = cboInput.Text;
        //    //args.escapedItem = "";
        //    //args.unescapedItem = "";

        //    while (input.Length > 0)
        //    {

        //        if (loops == 0) args.StringToProcess = args.originalItem;
        //        //Loop through input strings and locate instance of espcaped single quotes
        //        if (input.Contains("''"))
        //        {
        //            args.unescapedItem = input.Replace("''", "'");
        //        }
        //        else
        //        {
        //            caretPos = args.StringToProcess.IndexOf('\'', caretPos);
        //            int oldPos = 0;
        //            while (caretPos != -1 && caretPos != oldPos)
        //            {
        //                oldPos = caretPos;
        //                args.escapedItem += input.Replace("'", "''");
        //                args.unescapedItem += input;
        //                caretPos = input.IndexOf('\'', caretPos);
        //                args.StringToProcess = input.Substring(caretPos + 1);
        //            }
        //            RecursiveControlEscapeChars();
        //        } 
        //    }

        //    return args;
        //}

        public DropDownEventArgs RecursiveControlEscapeChars()
        {
            DropDownEventArgs args = new DropDownEventArgs();
            args.originalItem = cboInput.Text;
            args.StringToProcess = args.originalItem;
            args.escapedItem = "";
            args.unescapedItem = "";
            args.FirstPass = true;
            args.CaretPos = 0;
            ProcessDDItem(args);

            return args;
        }



        private DropDownEventArgs ProcessDDItem(DropDownEventArgs args)
        {
            args.FirstPass = false;
            //Loop through input strings and locate instance of espcaped single quotes
            if (args.StringToProcess.Contains("''"))
            {
                args.unescapedItem = args.StringToProcess.Replace("''", "\'");
                args.escapedItem = args.StringToProcess;
                args.StringToProcess = "";
                // C#
                if (!string.IsNullOrEmpty(args.StringToProcess) && args.StringToProcess.IndexOf('\'') != -1)
                {
                    ProcessDDItem(args);
                }
            }
            else
            {
                if(args.StringToProcess.IndexOf('\'') == -1)
                {
                    args.escapedItem += args.StringToProcess;
                    args.unescapedItem += args.StringToProcess;
                    args.StringToProcess = "";
                    return args;
                }
                args.CaretPos = args.StringToProcess.IndexOf('\'', args.CaretPos);
                if (args.StringToProcess[args.CaretPos + 1] == '\'')
                {
                    args.StringToProcess =
                        args.StringToProcess.Substring(args.CaretPos + 2);
                }
                while (args.StringToProcess.IndexOf('\'') != -1)
                {
                    args.escapedItem += args.StringToProcess.Replace("'", "''");
                    args.unescapedItem += args.StringToProcess;
                    args.StringToProcess = args.StringToProcess.Substring(args.CaretPos + 1);
                    if (args.StringToProcess[args.CaretPos + 1] == '\'')
                    {
                        args.StringToProcess =
                            args.StringToProcess.Substring(args.CaretPos + 2);
                    }
                    args.CaretPos = args.StringToProcess.IndexOf('\'', args.CaretPos);

                    if (!string.IsNullOrEmpty(args.StringToProcess) && args.StringToProcess.IndexOf('\'') != -1)
                    {
                        ProcessDDItem(args);
                    }
                }
            }
            // C#
            return args;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            //DropDownEventArgs args = RecursiveControlEscapeChars();
            //textBox1.Text = args.unescapedItem;
            //textBox2.Text = args.escapedItem;

           
            bool exists = Operations.IsExistingItem(cboInput, textBox1.Text);
            textBox2.Text = exists.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
        }
    }
}
