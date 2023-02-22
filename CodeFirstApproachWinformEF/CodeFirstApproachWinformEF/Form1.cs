using CodeFirstApproachWinformEF.Model;
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

namespace CodeFirstApproachWinformEF
{
    public partial class Form1 : Form
    {
        int Id = 0;
        Employee model = new Employee();
        DatabaseContext db = new DatabaseContext();
        public Form1()
        {
            InitializeComponent();
            bindGridView();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        void bindGridView()
        {
            dataGridView1.DataSource = db.Employees.ToList<Employee>();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void InsertButton_Click(object sender, EventArgs e)
        {
            model.Name = NametextBox.Text;
            model.Gender = GenderComboBox.SelectedItem.ToString();
            model.Age = Convert.ToInt32(AgetextBox.Text);
            model.Designation = DesigtextBox.Text;
            db.Employees.Add(model);
            int a = db.SaveChanges();
            if ( a > 0)
            {
                MessageBox.Show("Data Inserted !!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                bindGridView();
                ResetControls();
            }
            else
            {
                MessageBox.Show("Data Not Inserted !!");
            }
        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            model.Id = Id;
            model.Name = NametextBox.Text;
            model.Gender=(GenderComboBox.SelectedItem.ToString());
            model.Age = Convert.ToInt32(AgetextBox.Text);
            model.Designation = DesigtextBox.Text;
            db.Entry(model).State = EntityState.Modified;
            int a = db.SaveChanges();
            if (a > 0)
            {
                MessageBox.Show("Data Updated !!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                bindGridView();
                ResetControls();
            }
            else
            {
                MessageBox.Show("Data Not Updated !!");
            }
        }
        void ResetControls()
        {
            NametextBox.Clear();
            GenderComboBox.SelectedItem = null;
            AgetextBox.Clear();
            DesigtextBox.Clear();
        }

        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);
            model = db.Employees.Where (x => x.Id == Id).FirstOrDefault();
            NametextBox.Text = model.Name;
            GenderComboBox.SelectedItem = model.Gender;
            AgetextBox.Text = model.Age.ToString();
            DesigtextBox.Text = model.Designation;
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Are you sure to delete data??", "Alert", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dr == DialogResult.Yes)
            {
                model = db.Employees.Where(x => x.Id == Id).FirstOrDefault();
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
