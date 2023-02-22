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

namespace INSERT_UPDATE_DELETE
{
    public partial class Form1 : Form
    {
        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString; //connection string
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void insert_btn_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(cs);
            string query2 = "select * from Employee where id = @id";
            SqlCommand cmd2 = new SqlCommand(query2, conn);
            cmd2.Parameters.AddWithValue("@id", id_tb.Text);
            conn.Open();

            SqlDataReader dr = cmd2.ExecuteReader();
            if(dr.HasRows == true)
            {
                MessageBox.Show(id_tb.Text + " Id already exists!!", "Failure!!",  MessageBoxButtons.OK, MessageBoxIcon.Information);
                conn.Close();
            }
            else
            {
                conn.Close();


                string query = "insert into Employee values(@id,@name,@gender,@age,@desig,@salary)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", id_tb.Text);
                cmd.Parameters.AddWithValue("@name", name_tb.Text);
                cmd.Parameters.AddWithValue("@gender", gender_combo.SelectedItem);
                cmd.Parameters.AddWithValue("@age", age_ud.Value);
                cmd.Parameters.AddWithValue("@desig", desig_combo.SelectedItem);
                cmd.Parameters.AddWithValue("@salary", salary_tb.Text);

                conn.Open();

                int a = cmd.ExecuteNonQuery(); //for crud operation
                if (a > 0)
                {
                    MessageBox.Show("Inserted Successfully!!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    BindGridView();
                }
                else
                {
                    MessageBox.Show("Insertion Failed!!", "Failure", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                conn.Close();
                ResetControls();
            }
            

        }

        void BindGridView()
        {
            SqlConnection conn = new SqlConnection(cs);
            string query = "select * from Employee";
            SqlDataAdapter sda = new SqlDataAdapter(query, conn);
            DataTable dt = new DataTable(); 
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void view_btn_Click(object sender, EventArgs e)
        {
            BindGridView();
        }

        private void update_btn_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(cs);
            string query = "update Employee set id = @id, name = @name, gender = @gender, age = @age, designation = @desig, salary = @salary where id = @id";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@id", id_tb.Text);
            cmd.Parameters.AddWithValue("@name", name_tb.Text);
            cmd.Parameters.AddWithValue("@gender", gender_combo.SelectedItem);
            cmd.Parameters.AddWithValue("@age", age_ud.Value);
            cmd.Parameters.AddWithValue("@desig", desig_combo.SelectedItem);
            cmd.Parameters.AddWithValue("@salary", salary_tb.Text);

            conn.Open();

            int a = cmd.ExecuteNonQuery(); //for crud operation
            if (a > 0)
            {
                MessageBox.Show("Updated Successfully!!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                BindGridView();
            }
            else
            {
                MessageBox.Show("Updation Failed!!", "Failure", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            conn.Close();
            ResetControls();
            id_tb.Focus();
        }

        private void dataGridView1_MouseLeave(object sender, EventArgs e)
        {
            
        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            id_tb.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            name_tb.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            gender_combo.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            age_ud.Value = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[3].Value);
            desig_combo.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            salary_tb.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
        }

        private void delet_btn_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(cs);
            string query = "delete from Employee where id = @id";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@id", id_tb.Text);

            conn.Open();

            int a = cmd.ExecuteNonQuery(); //for crud operation
            if (a > 0)
            {
                MessageBox.Show("Deleted Successfully!!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                BindGridView();

            }
            else
            {
                MessageBox.Show("Deletion Failed!!", "Failure", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            conn.Close();
            ResetControls();
            id_tb.Focus();
        }

        private void reset_btn_Click(object sender, EventArgs e)
        {
            ResetControls();
        }

        void ResetControls()
        {
            id_tb.Clear();
            name_tb.Clear();
            gender_combo.SelectedItem = null;
            age_ud.Value = 20;
            desig_combo.SelectedItem = null;
            salary_tb.Clear() ;
            id_tb.Focus();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void SearchBtn_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(cs);
            string query = "select * from Employee where name like @name + '%'";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            sda.SelectCommand.Parameters.AddWithValue("@name", SearchTb.Text.Trim());
            DataTable data = new DataTable();
            sda.Fill(data);
            if(data.Rows.Count > 0)
            {
                dataGridView1.DataSource = data;
            }
            else
            {
                MessageBox.Show("No rows found!!");
                dataGridView1.DataSource = null;
            }
            
        }

        private void SearchTb_TextChanged(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(cs);
            string query = "select * from Employee where name like @name + '%'";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            sda.SelectCommand.Parameters.AddWithValue("@name", SearchTb.Text.Trim());
            DataTable data = new DataTable();
            sda.Fill(data);
            if (data.Rows.Count > 0)
            {
                dataGridView1.DataSource = data;
            }
            else
            {
                MessageBox.Show("No rows found!!");
                dataGridView1.DataSource = null;
            }
        }
    }
}
