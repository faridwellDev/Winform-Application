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


namespace AUTO_COMPLETE_TEXTBOX
{
    public partial class Form1 : Form
    {
        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            AutoCompleteTB();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //AutoCompleteTB();
        }

        void AutoCompleteTB()
        {

            //string[] hobbies = { "Swimming", "Writing", "Reading", "Walking", "Sleeping", "Eating" };
            //textBox1.AutoCompleteSource = AutoCompleteSource.CustomSource;
            //textBox1.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            //textBox1.AutoCompleteCustomSource.AddRange(hobbies);

            SqlConnection conn = new SqlConnection(cs);
            string query = "select * from hobbies";
            SqlCommand cmd = new SqlCommand(query, conn);
            conn.Open();
            AutoCompleteStringCollection coll = new AutoCompleteStringCollection();
            SqlDataReader dr = cmd.ExecuteReader();
            

            while(dr.Read())
            {
                coll.Add(dr.GetString(0)); //0 means first table
            }
            
            textBox1.AutoCompleteSource = AutoCompleteSource.CustomSource;
            textBox1.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            textBox1.AutoCompleteCustomSource = coll;

            conn.Close();
        }
    }


}
