using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace My_First_Form
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            label3.Text = textBox1.Text;
            label3.Visible = true; 

            //MessageBox.Show("Hello " + textBox1.Text);
            //MessageBox.Show("WELCOME TO WINFORMS!!");
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
