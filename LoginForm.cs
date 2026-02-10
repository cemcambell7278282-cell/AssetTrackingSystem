using System;
using System.Windows.Forms;
using AssetTrackingSystem.Data;
using AssetTrackingSystem.Security;

namespace AssetTrackingSystem
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text.Trim();
            string password = txtPassword.Text;

            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter email and password.");
                return;
            }

            var user = DatabaseHelper.GetUserByEmail(email);

            if (user == null)
            {
                MessageBox.Show("Invalid email or password.");
                return;
            }

            string hash = PasswordHelper.HashPassword(password);

            if (user.PasswordHash != hash)
            {
                MessageBox.Show("Invalid email or password.");
                return;
            }

            // ✅ Login success
            Session.CurrentUser = user;

            this.Hide();

            MainForm mainForm = new MainForm();
            mainForm.FormClosed += (s, args) => this.Close();
            mainForm.Show();
        }
    }
}
