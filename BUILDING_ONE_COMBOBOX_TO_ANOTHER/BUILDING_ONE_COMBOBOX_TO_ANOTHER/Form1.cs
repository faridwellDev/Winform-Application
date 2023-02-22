using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;

namespace BUILDING_ONE_COMBOBOX_TO_ANOTHER
{
    public partial class Form1 : Form
    {
        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
        DataRow dr;
        public Form1()
        {
            InitializeComponent();
            BindCountryCombo();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        void BindCountryCombo()
        {
            SqlConnection con = new SqlConnection(cs);
            string query = "select * from Countries";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);

            DataTable data = new DataTable();
            sda.Fill(data);
            dr = data.NewRow();
            dr.ItemArray = new object[] { 0, "--Select Country--" };
            data.Rows.InsertAt(dr, 0);
            comboBox1.DisplayMember= "Name";
            comboBox1.ValueMember= "COUNTRY_ID";
            comboBox1.DataSource = data;
        }

        void BindCitiesCombo(int CountryId)
        {
            SqlConnection con = new SqlConnection(cs);
            string query = "select * from Cities where Country_Id = @C_ID";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            sda.SelectCommand.Parameters.AddWithValue("@C_ID", CountryId);

            DataTable data = new DataTable();
            sda.Fill(data);
            dr = data.NewRow();
            dr.ItemArray = new object[] { 0, "--Select City--" };
            data.Rows.InsertAt(dr, 0);
            comboBox2.DisplayMember = "Name";
            comboBox2.ValueMember = "CITY_ID";
            comboBox2.DataSource = data;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBox1.SelectedValue.ToString() != null)
            {
                int CountryId = Convert.ToInt32(comboBox1.SelectedValue.ToString());
                BindCitiesCombo(CountryId);
            }
        }
    }
}
