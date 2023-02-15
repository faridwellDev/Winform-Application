using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CHECK_BOX
{
    public partial class Form1 : Form
    {
        string Text1 = "";
        string Text2 = "";
        string Text3 = "";
        string Text4 = "";
        public Form1()
        {
            InitializeComponent();
        }

        private void OnePlusChk_CheckedChanged(object sender, EventArgs e)
        {
            if (OnePlusChk.Checked == true)
            {
                Text4 = OnePlusChk.Text;
            }
            else
            {
                Text4 = "";
            }
        }

        private void SamsungChk_CheckedChanged(object sender, EventArgs e)
        {
            if(SamsungChk.Checked == true)
            {
                Text1 = SamsungChk.Text;
            }
            else
            {
                Text1 = "";
            }
        }

        private void AppleChk_CheckedChanged(object sender, EventArgs e)
        {
            if (AppleChk.Checked == true)
            {
                Text2 = AppleChk.Text;
            }
            else
            {
                Text2 = "";
            }
        }

        private void SonyChk_CheckedChanged(object sender, EventArgs e)
        {
            if (SonyChk.Checked == true)
            {
                Text3 = SonyChk.Text;
            }
            else
            {
                Text3 = "";
            }
        }

        private void SubmitChk_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Your selected Companies are: " + Text1 + " " + Text2 + " " + Text3 + " " + Text4);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            button1.Enabled = checkBox1.Checked;
        }
    }
}
