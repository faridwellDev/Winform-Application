using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }


        private void AddButton_Click(object sender, EventArgs e)
        {
            if(textBox1.Text != "" && textBox2.Text != "")
            {
                int num1 = int.Parse(textBox1.Text);
                int num2 = int.Parse(textBox2.Text);

                int result = num1 + num2;

                //MessageBox.Show("Addition result is: " + result.ToString());


                label4.Text = "Additon result is: " + result.ToString();
                label4.Visible = true;
            }
            else
            {
                MessageBox.Show("Please fill both fields !!");
            }
        }

        private void SubtractButton_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "")
            {
                int num1 = int.Parse(textBox1.Text);
                int num2 = int.Parse(textBox2.Text);

                int result = num1 - num2;

                //MessageBox.Show("Subtraction result is: " + result.ToString());


                label4.Text = "Subtraction result is: " + result.ToString();
                label4.Visible = true;
            }
            else
            {
                MessageBox.Show("Please fill both fields !!");
            }
        }

        private void MultiplyButton_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "")
            {
                int num1 = int.Parse(textBox1.Text);
                int num2 = int.Parse(textBox2.Text);

                int result = num1 * num2;

                //MessageBox.Show("Addition result is: " + result.ToString());


                label4.Text = "Multiplication result is: " + result.ToString();
                label4.Visible = true;
            }
            else
            {
                MessageBox.Show("Please fill both fields !!");
            }
        }

        private void DivisionButton_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "")
            {
                int num1 = int.Parse(textBox1.Text);
                int num2 = int.Parse(textBox2.Text);

                int result = num1 / num2;

                //MessageBox.Show("Addition result is: " + result.ToString());


                label4.Text = "Division result is: " + result.ToString();
                label4.Visible = true;
            }
            else
            {
                MessageBox.Show("Please fill both fields !!");
            }
        }

        
    }
}
