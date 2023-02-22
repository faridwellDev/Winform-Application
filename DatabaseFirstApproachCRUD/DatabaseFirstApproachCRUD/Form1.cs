using DatabaseFirstApproachCRUD.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DatabaseFirstApproachCRUD
{
    public partial class Form1 : Form
    {
        int Id = 0;
        Student model = new Student();
        DatabaseFirstDBEntities db = new DatabaseFirstDBEntities();
        public Form1()
        {
            InitializeComponent();
            bindGridView();
        }

        void bindGridView()
        {
            dataGridView1.DataSource = db.Students.ToList<Student>();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            model.Name = NametextBox.Text.Trim();
            model.Gender = GendercomboBox.SelectedItem.ToString();
            model.Age = Convert.ToInt32(AgetextBox.Text.Trim());
            model.Standard = Convert.ToInt32(ClasstextBox.Text.Trim());
            db.Students.Add(model);
            int a = db.SaveChanges();
            if(a > 0 )
            {
                MessageBox.Show("Data Inserted!!","Succesful",MessageBoxButtons.OK,MessageBoxIcon.Information);
                bindGridView();
                ResetControls();
            }
            else
            {
                MessageBox.Show("Data Insertion Failed!!", "Failed!!", MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
        }

        void ResetControls()
        {
            NametextBox.Clear();
            GendercomboBox.SelectedItem = null;
            AgetextBox.Clear();
            ClasstextBox.Clear();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ResetControls();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            model.Id = Id;
            model.Name = NametextBox.Text.Trim();
            model.Gender = GendercomboBox.SelectedItem.ToString();
            model.Age = Convert.ToInt32(AgetextBox.Text.Trim());
            model.Standard = Convert.ToInt32(ClasstextBox.Text.Trim());
            db.Entry(model).State = EntityState.Modified;
            int a = db.SaveChanges();
            if (a > 0)
            {
                MessageBox.Show("Data Updated!!", "Succesful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                bindGridView();
                ResetControls();
            }
            else
            {
                MessageBox.Show("Data Updation Failed!!", "Failed!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);
            model = db.Students.Where(x => x.Id == Id).FirstOrDefault();
            NametextBox.Text = model.Name;
            GendercomboBox.SelectedItem = model.Gender;
            AgetextBox.Text = model.Age.ToString();
            ClasstextBox.Text = model.Standard.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Are you sure to delete data??", "Alert", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dr == DialogResult.Yes)
            {
                model = db.Students.Where(x => x.Id == Id).FirstOrDefault();
                db.Entry(model).State = EntityState.Deleted;
                int a = db.SaveChanges();
                if (a > 0)
                {
                    MessageBox.Show("Data Deleted !!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    bindGridView();
                    ResetControls();
                }
                else
                {
                    MessageBox.Show("Data Not Deleted !!");
                }
            }
            else
            {
                MessageBox.Show("You have canceled the delete operation!!");
            }
        }
    }
}
