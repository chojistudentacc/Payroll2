using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.CompilerServices;

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
            viewpayslipPanel.Visible = false;
            deductionPanel.Visible = false;
            reportPanel.Visible = false;
            messagesPanel.Visible = false;
            payrollpanel.Visible = false;
        }

        private void showLogin()
        {
            login.Visible = true;
        }

        private void AccountantForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            showLogin();
        }

        private void payrollButt_Click(object sender, EventArgs e)
        {
            hideAllPanels();
            payrollpanel.Visible = true;
        }

        private void deductButt_Click(object sender, EventArgs e)
        {
            hideAllPanels();
            deductionPanel.Visible = true;
        }

        private void reportButt_Click(object sender, EventArgs e)
        {
            hideAllPanels();
            reportPanel.Visible = true;
        }

        private void phButt_Click(object sender, EventArgs e)
        {
            taxLabel.Text = "PhilHealth Contribution";
        }

        private void sssButton_Click(object sender, EventArgs e)
        {
            taxLabel.Text = "SSS Contribution";
        }

        private void pagibigButt_Click(object sender, EventArgs e)
        {
            taxLabel.Text = "Pag-IBIG Contribution";
        }

        private void taxButt_Click(object sender, EventArgs e)
        {
            taxLabel.Text = "Witholding Tax";
        }

        private void viewButt_Click(object sender, EventArgs e)
        {
            hideAllPanels();
            viewpayslipPanel.Visible = true;
            payrollButt.Enabled = false;
            payslipButt.Enabled = false;
            deductButt.Enabled = false;
            reportButt.Enabled = false;
            messagesButt.Enabled = false;
        }

        private void closeButt_Click(object sender, EventArgs e)
        {
            hideAllPanels();
            payrollpanel.Visible = true;
            payrollButt.Enabled = true;
            payslipButt.Enabled = true;
            deductButt.Enabled = true;
            reportButt.Enabled = true;
            messagesButt.Enabled = true;
        }
    }
}