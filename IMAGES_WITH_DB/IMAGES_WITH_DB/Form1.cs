using IMAGES_WITH_DB.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IMAGES_WITH_DB
{
    public partial class Form1 : Form
    {
        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
        public Form1()
        {
            InitializeComponent();
            BindGridView();
        }

        /*
        FILTER PROPERTY PATTERN

        FOR PNG FORMAT: "PNG FILE (*.png) | *.png"

        FOR JPG FORMAT: "JPG FILE (*.jpg) | *.jpg"

        FOR BMP FORMAT: "BMP FILE (*.bmp) | *.bmp"

        FOR GIF FORMAT: "GIF FILE (*.gif) | *.gif"

        FOR 4 IMAGE FORMATS: "Image File (*.png;*.jpg;*.bmp; *.gif;) | *.png;*.jpg;*.bmp;*.gif"

        FOR ALL FILES: "All files (*.*)|*.*"
         */


        /*
         * Creating Column For Image
         * DataGridViewImageColumn dgv = new DataGridViewImageColumn();
         * dgv = (DataGridViewImageColumn)dataGridView1.Columns[3];
         * dgv.ImageLayout = DataGridViewImageCellLayout.Stretch;
         * 
         * Adjusting All Columns in One Data Grid View Window
         * 
         * dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
         * 
         * Increasing the height of rows
         * 
         * dataGridView1.RowTemplate.Height = 50;
         */

        private void button5_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog(); //openFileDialog for image browsing
            ofd.Title = "Select Image";
            ofd.Filter = "All files (*.*)|*.*";

            if(ofd.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = new Bitmap(ofd.FileName);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(cs);
            string query = "insert into student_details values(@id,@name,@age,@img)";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@id", textBox1.Text);
            cmd.Parameters.AddWithValue("@name", textBox2.Text);
            cmd.Parameters.AddWithValue("@age", numericUpDown1.Value);
            cmd.Parameters.AddWithValue("@img", SavePhoto());

            conn.Open();
            int a = cmd.ExecuteNonQuery();
            if (a > 0)
            {
                MessageBox.Show("Date Inserted!!");
                BindGridView();
                ResetControls();
            }
            else
            {
                MessageBox.Show("Data not Inserted!!");
            }
        }

        private byte[] SavePhoto()
        {
            MemoryStream ms = new MemoryStream();
            pictureBox1.Image.Save(ms, pictureBox1.Image.RawFormat);
            return ms.GetBuffer();
        }

        void BindGridView()
        {
            SqlConnection con = new SqlConnection(cs);
            string query = "select * from student_details";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
            DataGridViewImageColumn dgv = new DataGridViewImageColumn();
            dgv = (DataGridViewImageColumn)dataGridView1.Columns[3];
            dgv.ImageLayout = DataGridViewImageCellLayout.Stretch;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.RowTemplate.Height = 50;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ResetControls();
        }

        void ResetControls()
        {
            textBox1.Clear();
            textBox2.Clear();
            numericUpDown1.Value = 0;
            pictureBox1.Image = Resources._21_February_Pic_1;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(cs);
            string query = "update student_details set id = @id, name = @name, age = @age, picture = @img where id = @id";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@id", textBox1.Text);
            cmd.Parameters.AddWithValue("@name", textBox2.Text);
            cmd.Parameters.AddWithValue("@age", numericUpDown1.Value);
            cmd.Parameters.AddWithValue("@img", SavePhoto());

            conn.Open();
            int a = cmd.ExecuteNonQuery();
            if (a > 0)
            {
                MessageBox.Show("Date Updated!!");
                BindGridView();
                ResetControls();
            }
            else
            {
                MessageBox.Show("Data not Updated!!");
            }
        }

        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            textBox1.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            numericUpDown1.Value = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[2].Value);
            pictureBox1.Image = GetPhoto((byte[])dataGridView1.SelectedRows[0].Cells[3].Value);
        }

        private Image GetPhoto(byte[] photo)
        {
             MemoryStream ms = new MemoryStream(photo);
             return Image.FromStream(ms);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(cs);
            string query = "delete student_details where id = @id";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@id", textBox1.Text);

            conn.Open();
            int a = cmd.ExecuteNonQuery();
            if (a > 0)
            {
                MessageBox.Show("Date Deleted!!");
                BindGridView();
                ResetControls();
            }
            else
            {
                MessageBox.Show("Data not Deleted!!");
            }
        }
    }
}
