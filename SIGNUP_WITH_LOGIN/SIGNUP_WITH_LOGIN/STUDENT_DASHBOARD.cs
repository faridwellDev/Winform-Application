using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SIGNUP_WITH_LOGIN
{
    public partial class STUDENT_DASHBOARD : Form
    {
        public STUDENT_DASHBOARD()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();

            Login f1 = new Login();
            f1.Show();
        }
    }
}
