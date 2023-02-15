using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VALIDATIONS_TEXTBOX
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar; //KeyChar property
            if(Char.IsDigit(ch))
            {
                e.Handled = false;
            }
            else if(ch == 8) //8 is enumeration of backspace
            {
                 e.Handled = false; // It gives access backspace
            }
            else
            {
                e.Handled = true; //Badha deya(if we write number only then it write otherwise not) and also not accept backspace
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if(Char.IsLetter(ch))
            {
                e.Handled = false;
            }
            else if(ch == 8 || ch == 32)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if (Char.IsLetter(ch) || Char.IsDigit(ch))
            {
                e.Handled = false;
            }
            else if (ch == 8 || ch == 32)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }
    }
}
