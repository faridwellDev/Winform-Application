using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MOUSE_HOVER
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_MouseHover(object sender, EventArgs e)
        {
            label1.Text = "Mouse in on the button!!";
            button1.BackColor = Color.Green;
            button1.ForeColor = Color.White;
            button1.Font = new Font("hobo std", 15);
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            label1.Text = "Mouse is left from the button!!";
            button1.BackColor = Color.Silver;
            button1.ForeColor = Color.Black;
            button1.Font = new Font("hobo std", 11);
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
