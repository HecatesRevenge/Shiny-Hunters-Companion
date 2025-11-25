using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Shiny_Hunters_Companion
{
    public partial class LoginForm : Form
    {

        public User AuthenticatedUser { get; set; }

        private UserDB userDb = new UserDB();
        public LoginForm()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                lblError.Text = "Please enter username and password.";
                return;
            }

            User user = userDb.VerifyLogin(username, password);

            if (user != null)
            {
                AuthenticatedUser = user;
                //TODO: Change later and possibly add custom label to the form that returns a success message
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                lblError.Text = "Invalid username or password";
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            string username=txtUsername.Text.Trim();
            string password=txtPassword.Text.Trim();

            if (string.IsNullOrEmpty (username) || string.IsNullOrEmpty(password)) 
            {   lblError.Text = string.Empty; 
                return; 
            }
            if (userDb.RegisterUser(username, password))
            {
                MessageBox.Show("Successfully Registered! Login");
            }
            else
            {
                lblError.Text = "Username already exists";
            }

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}

