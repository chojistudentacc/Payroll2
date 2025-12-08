using System;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using Microsoft.VisualBasic.Logging;

namespace Payroll
{
    public partial class LoginForm : Form
    {
        private string userName;
        private string password;
        Repository repo;

        public LoginForm()
        {
            InitializeComponent();
            RoundButtonCorners(loginButt, 50);
        }

        private void LoginPanel_Click(object sender, EventArgs e)
        {
            userName = usernameTB.Text.Trim();
            password = passwordTB.Text.Trim();

            if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter both username and password");
                return;
            }

            repo = new Repository();
            string userType = repo.AuthenticateUser(userName, password);

            if (userType == "employee")
            {
                MessageBox.Show("Employee");
                usernameTB.Text = "";
                passwordTB.Text = "";
                EmployeeForm empForm = new EmployeeForm(this);
                empForm.SetCurrentUserName(userName);
                empForm.Show();
                this.Visible = false;
            }
            else if (userType == "accountant")
            {
                MessageBox.Show("Accountant");
                usernameTB.Text = "";
                passwordTB.Text = "";
                AccountantForm accForm = new AccountantForm(userName, this);
                accForm.Show();
                this.Visible = false;
            }
            else if (userType == "admin")
            {
                MessageBox.Show("Admin");
                usernameTB.Text = "";
                passwordTB.Text = "";
                AdminForm adForm = new AdminForm(this, userName);
                adForm.Show();
                this.Visible = false;
            }
            else if (userType == "hr")
            {
                MessageBox.Show("Human Resources");
                usernameTB.Text = "";
                passwordTB.Text = "";
            }
            else
            {
                MessageBox.Show("Invalid username or password");
            }
        }

        private void RoundButtonCorners(Button button, int radius)
        {
            var path = new GraphicsPath();
            path.AddArc(0, 0, radius, radius, 180, 90);
            path.AddArc(button.Width - radius, 0, radius, radius, 270, 90);
            path.AddArc(button.Width - radius, button.Height - radius, radius, radius, 0, 90);
            path.AddArc(0, button.Height - radius, radius, radius, 90, 90);
            path.CloseAllFigures();
            button.Region = new Region(path);
        }

        private void exitButt_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }
    }
}
