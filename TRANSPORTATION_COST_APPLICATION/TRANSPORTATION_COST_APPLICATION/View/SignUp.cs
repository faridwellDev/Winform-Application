using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TRANSPORTATION_COST_APPLICATION.View
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

        private void SignUp_Load(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void fName_TextChanged(object sender, EventArgs e)
        {

        }

        private void fName_Leave(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(fName.Text) == true)
            {
                fName.Focus();
                errorProvider1.SetError(this.fName, "Please fill the First Name!");
            }
            else
            {
                errorProvider1.Clear();
            }
        }

        private void lName_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(lName.Text) == true)
            {
                lName.Focus();
                errorProvider2.SetError(this.lName, "Please fill the Last Name!");
            }
            else
            {
                errorProvider2.Clear();
            }
        }

        private void dateTimePicker1_Leave(object sender, EventArgs e)
        {
            DateTime selectedDate = dateTimePicker1.Value;

            // Perform some validation or processing on the selected date
            if (selectedDate > DateTime.Today)
            {
                MessageBox.Show("Please select a date in the past.");
                dateTimePicker1.Focus();
            }
            else
            {
                // The selected date is valid, so do something with it
                // (e.g. store it in a variable or database)
            }
        }

        private void email_Leave(object sender, EventArgs e)
        {
            if (Regex.IsMatch(email.Text, pattern) == false)
            {
                email.Focus();
                errorProvider3.SetError(this.email, "Invalid Email");
            }
            else
            {
                errorProvider3.Clear();
            }
        }

        private void pass_Leave(object sender, EventArgs e)
        {
            if(Regex.IsMatch(pass.Text, pattern) == false)
            {
                pass.Focus();
                errorProvider4.SetError(this.pass, "Invalid Password!");
            }
            else
            {
                errorProvider4.Clear();
            }
        }

        private void phoneNumber_Leave(object sender, EventArgs e)
        { 
            // Define a regular expression pattern for a US phone number
            string regexPattern = @"^\d{5}-\d{6}$";

            // Check if the phone number matches the regular expression pattern
            if(Regex.IsMatch(phoneNumber.Text, regexPattern) == false)
            {
                pass.Focus();
                errorProvider5.SetError(this.pass, "Invalid Phone Number!");
            }
            else
            {
                errorProvider5.Clear();
            }
        }

        private void dateTimePicker2_Leave(object sender, EventArgs e)
        {
            DateTime selectedDate = dateTimePicker2.Value;

            // Perform some validation or processing on the selected date
            if (selectedDate > DateTime.Today)
            {
                MessageBox.Show("Please select a date in the past.");
                dateTimePicker2.Focus();
            }
            else
            {
                // The selected date is valid, so do something with it
                // (e.g. store it in a variable or database)
            } 
        }
    }
}
