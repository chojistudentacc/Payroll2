using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Payroll
{
    public partial class AccountantForm : Form
    {

        private string userName;
        private string ID;
        LoginForm login;
        Repository repo;

        public AccountantForm(string name, LoginForm login)
        {
            InitializeComponent();
            this.userName = name;
            repo = new Repository();
            initializeItems();
            this.login = login;
        }

        private void payslipButt_Click(object sender, EventArgs e)
        {
            hideAllPanels();
            payslipPanel.Visible = true;
        }

        private void messagesButt_Click(object sender, EventArgs e)
        {
            hideAllPanels();
            messagesPanel.Visible = true;
        }

        private void initializeItems()
        {
            ID = repo.getAccountantID(userName);
            idLabel.Text = "Account ID: " + ID;
            hideAllPanels();
        }

        private void hideAllPanels()
        {
            payslipPanel.Visible = false;
            messagesPanel.Visible = false;
        }

        private void showLogin()
        {
            login.Visible = true;
        }

        private void AccountantForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            showLogin();
        }
    }
}
