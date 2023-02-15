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

namespace EXTRACTING_NUMBERS
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int total = 0;
            string pattern = @"\d+"; 

            foreach (string s in listBox1.SelectedItems)
            {
                total += int.Parse(Regex.Match(s, pattern).Value);
            }
            label2.Text = "Total price of items: " + total.ToString();
            label2.Visible= true;
        }
    }
}
