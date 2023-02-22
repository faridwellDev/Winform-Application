using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;

namespace CHECKBOX_DATA_IN_DB
{
    public partial class Form1 : Form
    {
        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand("SP_INSERT_MY_TABLE", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@name",textBox1.Text);
            cmd.Parameters.AddWithValue("@cricket", checkBox1.Checked);
            cmd.Parameters.AddWithValue("@hockey", checkBox2.Checked);
            cmd.Parameters.AddWithValue("@football", checkBox3.Checked);
            cmd.Parameters.AddWithValue("@wrestling", checkBox4.Checked);
            conn.Open();
            int a = cmd.ExecuteNonQuery();
            if (a > 0)
            {
                MessageBox.Show("Inserted!!");
            }
            else
            {
                MessageBox.Show("Not Inserted!!");
            }
            conn.Close();
        }
    }
}
