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
            RoundPanelCorners(LoginPanel, 20);
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

        private void RoundPanelCorners(Panel panel, int radius)
        {
            GraphicsPath path = new GraphicsPath();

            int w = panel.Width;
            int h = panel.Height;

            path.StartFigure();

            path.AddArc(0, 0, radius * 2, radius * 2, 180, 90);
            path.AddLine(radius, 0, w - radius, 0);

            path.AddArc(w - radius * 2, 0, radius * 2, radius * 2, 270, 90);
            path.AddLine(w, radius, w, h - radius);

            path.AddArc(w - radius * 2, h - radius * 2, radius * 2, radius * 2, 0, 90);
            path.AddLine(w - radius, h, radius, h);

            path.AddArc(0, h - radius * 2, radius * 2, radius * 2, 90, 90);
            path.AddLine(0, h - radius, 0, radius);

            path.CloseFigure();

            panel.Region = new Region(path);
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
