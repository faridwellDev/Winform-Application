﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PASSING_DATA_TO_ANOTHER_FORM
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            label2.Text = Form1.Text1;
            label2.Visible= true;
            label3.Text = Form1.Text2;
            label3.Visible= true;
            label4.Text = Form1.Text3;
            label4.Visible= true;
            
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
