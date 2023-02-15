using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RADIO_BUTTON
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(radioButton1.Checked == true)
            {
                MessageBox.Show("You have selected: " + radioButton1.Text);
            }
            else if(radioButton2.Checked == true)
            {
                MessageBox.Show("You have selected: " + radioButton2.Text);
            }
            else if (radioButton3.Checked == true)
            {
                MessageBox.Show("You have selected: " + radioButton3.Text);
            }
            else if(radioButton4.Checked == true)
            {
                MessageBox.Show("You have selected: " + radioButton4.Text);
            }
            else
            {
                MessageBox.Show("Please select a country!!");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(radioButton5.Checked == true)
            {
                groupBox1.BackColor = Color.Red;
            }
            else if(radioButton6.Checked == true)
            {
                groupBox1.BackColor = Color.Blue;
            }
            else if(radioButton7.Checked == true)
            {
                groupBox1.BackColor = Color.Green;
            }
            else
            {
                MessageBox.Show("Please select a color!!");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(radioButton8.Checked == true)
            {
                this.BackColor = System.Drawing.Color.Orange;
            }
            else if (radioButton9.Checked == true)
            {
                this.BackColor = System.Drawing.Color.Purple;
            }
            else if (radioButton10.Checked == true)
            {
                this.BackColor = System.Drawing.Color.Brown;
            }
            else
            {
                MessageBox.Show("Please select a color!!");
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
