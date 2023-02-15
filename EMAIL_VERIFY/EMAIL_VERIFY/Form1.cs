using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EMAIL_VERIFY
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        string pattern = "^[\\w-\\.]+@([\\w-]+\\.)+[\\w-]{2,4}$";
        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(textBox1.Text) == true)
            {
                textBox1.Focus();
                errorProvider1.SetError(this.textBox1, "Please fill the name!");
            }
            else
            {
                errorProvider1.Clear();
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if(Regex.IsMatch(textBox2.Text, pattern) == false)
            {
                textBox2.Focus();
                errorProvider2.SetError(this.textBox2,"Invalid Email");
            }
            else
            {
                errorProvider2.Clear();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text) == true)
            {
                textBox1.Focus();
                errorProvider1.SetError(this.textBox1, "Please fill the name!");
            }

            else if (Regex.IsMatch(textBox2.Text, pattern) == false)
            {
                textBox2.Focus();
                errorProvider2.SetError(this.textBox2, "Invalid Email");
            }
            else
            {
                MessageBox.Show("Welcome", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            
        }
    }
}
