using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace COMBO_BOX
{
    public partial class MyComboBox : Form
    {
        public MyComboBox()
        {
            InitializeComponent();
        }

        private void HobbiesComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string lbl = HobbiesComboBox.SelectedItem.ToString();
            label3.Text = "Your Selected item is: " + lbl;
            label3.Visible = true;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                if (HobbiesComboBox.Items.Contains(textBox1.Text))
                {
                    MessageBox.Show("It's already in the list! Add new item");
                }
                else
                {
                    HobbiesComboBox.Items.Add(textBox1.Text);
                    textBox1.Clear();
                    textBox1.Focus();
                }

            }
            else
            {
                MessageBox.Show("Please enter a value !!");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int count = HobbiesComboBox.Items.Count;
            MessageBox.Show(count.ToString());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            HobbiesComboBox.Items.Remove(HobbiesComboBox.SelectedItem);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            HobbiesComboBox.Items.Clear();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            HobbiesComboBox.Sorted = true;
        }
    }
}
