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

namespace LINK_LABEL
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void MyLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //Process.Start("http://www.google.com");

            Form2 f2 = new Form2();
            f2.Show();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.MyLink.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
        }
    }
}
