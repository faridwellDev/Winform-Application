using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EMPLOYEE_PAYROLL
{
    
    public partial class Form1 : Form
    {
        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
        public Form1()
        {
            InitializeComponent();
            BindGridView();
            Total_NetSalary();
            Total_Employees();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void IDtextBox_Leave(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(IDtextBox.Text))
            {
                IDtextBox.Focus();
                errorProvider1.SetError(this.IDtextBox, "Please Enter ID!!");
            }
            else
            {
                errorProvider1.Clear();
            }
        }

        private void NametextBox_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(NametextBox.Text))
            {
                NametextBox.Focus();
                errorProvider2.SetError(this.NametextBox, "Please Enter Your Name!!");
            }
            else
            {
                errorProvider2.Clear();
            }
        }

        private void DesigtextBox_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(DesigtextBox.Text))
            {
                DesigtextBox.Focus();
                errorProvider3.SetError(this.DesigtextBox, "Please Enter Your Designation!!");
            }
            else
            {
                errorProvider3.Clear();
            }
        }

        private void BPtextBox_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(BPtextBox.Text))
            {
                BPtextBox.Focus();
                errorProvider4.SetError(this.BPtextBox, "Please Enter Your Basic Pay!!");
            }
            else
            {
                errorProvider4.Clear();
            }
        }

        private void BPtextBox_TextChanged(object sender, EventArgs e)
        {
            int CA, MA, HR, grossPay, IT, netSalary;
            int basicPay = 0;
            if (string.IsNullOrEmpty(BPtextBox.Text))
            {
                BPtextBox.Focus();
                errorProvider4.SetError(this.BPtextBox, "Please fill the box");
            }
            else
            {
                errorProvider4.Clear();
                basicPay = Convert.ToInt32(BPtextBox.Text);
            }
            
            if (basicPay >= 40000)
            {
                CA = (int)(basicPay * 0.40);
                ContextBox.Text = CA.ToString();
                MA = (int)(basicPay * 0.30);
                MedtextBox.Text = MA.ToString();
                HR = (int)(basicPay * 0.20);
                HRtextBox.Text = HR.ToString();
                grossPay = basicPay + CA + MA + HR;
                GPtextBox.Text = grossPay.ToString();

                if (grossPay >= 60000)
                {
                    IT = (int)(grossPay * 0.03);
                    ITtextBox.Text = IT.ToString();
                    netSalary = grossPay - IT;
                    NStextBox.Text = netSalary.ToString();
                }
                else if (grossPay >= 50000)
                {
                    IT = (int)(grossPay * 0.02);
                    ITtextBox.Text = IT.ToString();
                    netSalary = grossPay - IT;
                    NStextBox.Text = netSalary.ToString();
                }
            }
            else if (basicPay >= 30000)
            {
                CA = (int)(basicPay * 0.35);
                ContextBox.Text = CA.ToString();
                MA = (int)(basicPay * 0.25);
                MedtextBox.Text = MA.ToString();
                HR = (int)(basicPay * 0.15);
                HRtextBox.Text = HR.ToString();
                grossPay = basicPay + CA + MA + HR;
                GPtextBox.Text = grossPay.ToString();

                if (grossPay >= 60000)
                {
                    IT = (int)(grossPay * 0.03);
                    ITtextBox.Text = IT.ToString();
                    netSalary = grossPay - IT;
                    NStextBox.Text = netSalary.ToString();
                }
                else if (grossPay >= 50000)
                {
                    IT = (int)(grossPay * 0.02);
                    ITtextBox.Text = IT.ToString();
                    netSalary = grossPay - IT;
                    NStextBox.Text = netSalary.ToString();
                }
            }
            else
            {
                CA = 3000;
                ContextBox.Text = CA.ToString();
                MA = 2000;
                MedtextBox.Text = MA.ToString();
                HR = 1000;
                HRtextBox.Text = HR.ToString();
                grossPay = basicPay + CA + MA + HR;
                GPtextBox.Text = grossPay.ToString();

                ITtextBox.Text = "No Tax Applied!!";
                netSalary = grossPay;
                NStextBox.Text = netSalary.ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            IDtextBox.Clear();
            NametextBox.Clear();
            DesigtextBox.Clear();
            BPtextBox.Clear();
            HRtextBox.Clear();
            ContextBox.Clear();
            MedtextBox.Clear();
            GPtextBox.Clear();
            ITtextBox.Clear();
            NStextBox.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(cs);
            string query = "insert into employee_details values(@id,@name,@designation,@basic_pay,@conveyance,@medical,@house_rent,@gross_pay,@income_tax,@net_salary)";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@id",IDtextBox.Text);
            cmd.Parameters.AddWithValue("@name",NametextBox.Text);
            cmd.Parameters.AddWithValue("@designation", DesigtextBox.Text);
            cmd.Parameters.AddWithValue("@basic_pay", BPtextBox.Text);
            cmd.Parameters.AddWithValue("@conveyance", ContextBox.Text);
            cmd.Parameters.AddWithValue("@medical", MedtextBox.Text);
            cmd.Parameters.AddWithValue("@house_rent", HRtextBox.Text);
            cmd.Parameters.AddWithValue("@gross_pay", GPtextBox.Text);
            cmd.Parameters.AddWithValue("@income_tax", ITtextBox.Text);
            cmd.Parameters.AddWithValue("@net_salary", NStextBox.Text);

            conn.Open();
            int a = cmd.ExecuteNonQuery();

            if ( a > 0)
            {
                MessageBox.Show("Data Inserted!!");
                BindGridView();
                Total_NetSalary();
                Total_Employees();
            }
            else
            {
                MessageBox.Show("Data Not Inserted!!");
            }
        }

        void BindGridView()
        {
            SqlConnection con = new SqlConnection(cs);
            string query = "select * from employee_details";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        void Total_NetSalary()
        {
            SqlConnection conn = new SqlConnection(cs);
            string query = "select sum(net_salary) from employee_details"; //here some is scalar function
            SqlCommand cmd = new SqlCommand(query, conn);
            conn.Open();
            int a = Convert.ToInt32(cmd.ExecuteScalar());
            textBox2.Text = a.ToString();
            conn.Close();
        }
        void Total_Employees()
        {
            SqlConnection conn = new SqlConnection(cs);
            string query = "select count(id) from employee_details"; //here some is scalar function
            SqlCommand cmd = new SqlCommand(query, conn);
            conn.Open();
            int a = Convert.ToInt32(cmd.ExecuteScalar());
            textBox1.Text = a.ToString();
            conn.Close();
        }
    }
}
