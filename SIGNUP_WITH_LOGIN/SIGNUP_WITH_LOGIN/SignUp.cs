using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SIGNUP_WITH_LOGIN
{
    public partial class SignUp : Form
    {
        string pattern = "^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9-]+(?:\\.[a-zA-Z0-9-]+)*$";
        string passPattern = "^(?=.*[0-9])(?=.*[a-z])(?=.*[A-Z])(?=.*[*.!@$%^&(){}[]:;<>,.?/~_+-=|\\]).{8,32}$";
        /// <summary>
        /// ^                                          Match the beginning of the string
        //(?=.*[0-9])                                  Require that at least one digit appear anywhere in the string
        //(?=.*[a-z])                                  Require that at least one lowercase letter appear anywhere in the string
        //(?=.*[A-Z])                                  Require that at least one uppercase letter appear anywhere in the string
        //(?=.*[*.!@$%^&(){}
        //[]:;<>,.?/~_+-=|\])                          Require that at least one special character appear anywhere in the string
        //.{8,32}
        //                                             The password must be at least 8 characters long, but no more than 32
        //$                                            Match the end of the string.
        /// </summary>
        public SignUp()
        {
            InitializeComponent();
        }

        private void id_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(id.Text) == true)
            {
                id.Focus();
                errorProvider1.SetError(this.id, "Please fill the id!");
            }
            else
            {
                errorProvider1.Clear();
            }
        }

        private void SignUp_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void id_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (Char.IsDigit(ch) == true)
            {
                e.Handled = false; //
            }
            else if (ch == 8)
            {
                e.Handled = false; //for backspace
            }
            else
            {
                e.Handled = true;
            }
        }

        private void name_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(name.Text) == true)
            {
                name.Focus();
                errorProvider2.SetError(this.name, "Please fill the name!");
            }
            else
            {
                errorProvider2.Clear();
            }
        }

        private void name_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (Char.IsLetter(ch) == true)
            {
                e.Handled = false; //
            }
            else if (ch == 8)
            {
                e.Handled = false; //for backspace
            }
            else if (ch == 32)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void fname_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(fname.Text) == true)
            {
                fname.Focus();
                errorProvider3.SetError(this.fname, "Please fill the name!");
            }
            else
            {
                errorProvider3.Clear();
            }
        }

        private void fname_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (Char.IsLetter(ch) == true)
            {
                e.Handled = false; //
            }
            else if (ch == 8)
            {
                e.Handled = false; //for backspace
            }
            else if (ch == 32)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void surname_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(surname.Text) == true)
            {
                surname.Focus();
                errorProvider4.SetError(this.surname, "Please fill the name!");
            }
            else
            {
                errorProvider4.Clear();
            }
        }

        private void surname_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (Char.IsLetter(ch) == true)
            {
                e.Handled = false; //
            }
            else if (ch == 8)
            {
                e.Handled = false; //for backspace
            }
            else if (ch == 32)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void gender_Leave(object sender, EventArgs e)
        {
            if (gender.SelectedItem == null)
            {
                gender.Focus();
                errorProvider5.SetError(this.gender, "Plase select a gender");
            }
            else
            {
                errorProvider5.Clear();
            }
        }

        private void standard_Leave(object sender, EventArgs e)
        {
            if (standard.Value == 0)
            {
                standard.Focus();
                errorProvider6.SetError(this.standard, "Please select a class");
            }
            else
            {
                errorProvider6.Clear();
            }
        }

        private void email_Leave(object sender, EventArgs e)
        {
            if (Regex.IsMatch(email.Text, pattern) == false)
            {
                email.Focus();
                errorProvider7.SetError(this.email, "Invalid Email");
            }
            else
            {
                errorProvider7.Clear();
            }
        }

        private void pass_TextChanged(object sender, EventArgs e)
        {

        }

        private void pass_Leave(object sender, EventArgs e)
        {
            if (Regex.IsMatch(pass.Text, pattern) == false)
            {
                pass.Focus();
                errorProvider8.SetError(this.pass, "Invalid Password!!");
            }
            else
            {
                errorProvider8.Clear();
            }
        }

        private void cpass_Leave(object sender, EventArgs e)
        {
            if (cpass.Text != pass.Text)
            {
                cpass.Focus();
                errorProvider9.SetError(this.cpass, "Password is not matched!!");
            }
            else
            {
                errorProvider9.Clear();
            }
        }

        private void submit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(id.Text) == true)
            {
                id.Focus();
                errorProvider1.SetError(this.id, "Please fill the id!");
            }
            else if (string.IsNullOrEmpty(name.Text) == true)
            {
                name.Focus();
                errorProvider2.SetError(this.name, "Please fill the name!");
            }

            else if (string.IsNullOrEmpty(fname.Text) == true)
            {
                fname.Focus();
                errorProvider3.SetError(this.fname, "Please fill the name!");
            }

            else if (string.IsNullOrEmpty(surname.Text) == true)
            {
                surname.Focus();
                errorProvider4.SetError(this.surname, "Please fill the name!");
            }

            else if (gender.SelectedItem == null)
            {
                gender.Focus();
                errorProvider5.SetError(this.gender, "Plase select a gender");
            }

            else if (standard.Value == 0)
            {
                standard.Focus();
                errorProvider6.SetError(this.standard, "Please select a class");
            }

            else if (standard.Value == 0)
            {
                standard.Focus();
                errorProvider6.SetError(this.standard, "Please select a class");
            }

            else if (Regex.IsMatch(email.Text, pattern) == false)
            {
                email.Focus();
                errorProvider7.SetError(this.email, "Invalid Email");
            }

            else if (Regex.IsMatch(pass.Text, pattern) == false)
            {
                pass.Focus();
                errorProvider8.SetError(this.pass, "Invalid Password!!");
            }

            else if (cpass.Text != pass.Text)
            {
                cpass.Focus();
                errorProvider9.SetError(this.cpass, "Password is not matched!!");
            }

            else
            {
                string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
                SqlConnection con = new SqlConnection(cs);

                string query2 = "select * from signup where id = @id";
                SqlCommand cmd2 = new SqlCommand(query2, con);
                cmd2.Parameters.AddWithValue("@id", id.Text);
                con.Open();
                SqlDataReader rd = cmd2.ExecuteReader();
                if (rd.HasRows == true)
                {
                    MessageBox.Show(id.Text + " Id Already Exists!!", "Failure", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    con.Close();
                }
                else
                {
                    con.Close();
                    string query = "insert into signup values(@id,@name,@fname,@surname,@gender,@class,@email,@pass)";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@id", id.Text);
                    cmd.Parameters.AddWithValue("@name", name.Text);
                    cmd.Parameters.AddWithValue("@fname", fname.Text);
                    cmd.Parameters.AddWithValue("@surname", surname.Text);
                    cmd.Parameters.AddWithValue("@gender", gender.SelectedItem);
                    cmd.Parameters.AddWithValue("@class", standard.Value);
                    cmd.Parameters.AddWithValue("@email", email.Text);
                    cmd.Parameters.AddWithValue("@pass", pass.Text);

                    con.Open();
                    int a = cmd.ExecuteNonQuery();
                    if (a > 0)
                    {
                        MessageBox.Show("Register Succesfull!!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        MessageBox.Show("Your Email is: " + email.Text , "\n \n" + "Your password is: " + pass.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Hide(); //Hide sign up form
                        Login page = new Login();
                        page.Show();
                    }
                    else
                    {
                        MessageBox.Show("Registration failed!!", "Failure", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    con.Close();
                }

            }

        }

        private void reset_Click(object sender, EventArgs e)
        {
            id.Clear();
            name.Clear();
            fname.Clear();
            surname.Clear();
            gender.SelectedItem = null;
            standard.Value = 0;
            email.Clear();
            pass.Clear();
            cpass.Clear();
        }

        private void SignUp_Load(object sender, EventArgs e)
        {

        }
    }
}
