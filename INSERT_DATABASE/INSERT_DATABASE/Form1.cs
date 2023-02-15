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

namespace INSERT_DATABASE
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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text) == true)
            {
                textBox1.Focus();
                errorProvider1.SetError(this.textBox1, "Please fill the id!!");
            }
            else if (string.IsNullOrEmpty(textBox2.Text) == true)
            {
                textBox2.Focus();
                errorProvider2.SetError(this.textBox2, "Please fill the name!!");
            }

            else if (comboBox1.SelectedItem == null)
            {
                comboBox1.Focus();
                errorProvider3.SetError(this.comboBox1, "Please select a value!!");
            }
            else if (string.IsNullOrEmpty(textBox4.Text) == true)
            {
                textBox4.Focus();
                errorProvider4.SetError(this.textBox4, "Please fill the address!!");
            }
            else
            {
                string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
                SqlConnection con = new SqlConnection(cs);

                string query2 = "select * from customer where c_id = @c_id";
                SqlCommand cmd2 = new SqlCommand(query2, con);
                cmd2.Parameters.AddWithValue("@c_id", textBox1.Text);
                con.Open();
                SqlDataReader rd = cmd2.ExecuteReader(); //select 
                if (rd.HasRows == true)
                {
                    MessageBox.Show(textBox1.Text + " id already exists!!");
                }

                else
                {
                    con.Close();
                    string query = "insert into customer values(@c_id,@c_name,@c_gender,@c_address)";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@c_id", textBox1.Text);
                    cmd.Parameters.AddWithValue("@c_name", textBox2.Text);
                    cmd.Parameters.AddWithValue("@c_gender", comboBox1.Text);
                    cmd.Parameters.AddWithValue("@c_address", textBox4.Text);

                    con.Open();

                    int a = cmd.ExecuteNonQuery(); //It is used for insert, delete, update

                    if (a > 0)
                    {
                        MessageBox.Show("Customer has been Added !!!");
                    }
                    else
                    {
                        MessageBox.Show("Customer insertion failed !!!");
                    }

                    con.Close();
                }
            }

        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text) == true)
            {
                textBox1.Focus();
                errorProvider1.SetError(this.textBox1, "Please fill the id!!");
            }
            else
            {
                errorProvider1.Clear();
            }
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox2.Text) == true)
            {
                textBox2.Focus();
                errorProvider2.SetError(this.textBox2, "Please fill the name!!");
            }
            else
            {
                errorProvider2.Clear();
            }
        }

        private void comboBox1_Leave(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem == null)
            {
                comboBox1.Focus();
                errorProvider3.SetError(this.comboBox1, "Please select a value!!");
            }
            else
            {
                errorProvider3.Clear();
            }
        }

        private void textBox4_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox4.Text) == true)
            {
                textBox4.Focus();
                errorProvider4.SetError(this.textBox4, "Please fill the address!!");
            }
            else
            {
                errorProvider4.Clear();
            }
        }
    }
}
