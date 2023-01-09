using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace First_Project
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }
        secondform sf = new secondform();

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = textBoxuser.Text;
            string password = textBoxpassword.Text;

            if(username=="reetika" && password == "12345")
            {
                MessageBox.Show("Successfully login");
                this.Hide();
                sf.Show();
            }
            else
            {
                MessageBox.Show("please enter the valid username and password");
            }

           
        }
    }
}
