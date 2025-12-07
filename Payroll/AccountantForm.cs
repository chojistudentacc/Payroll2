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

            payrollButt.PerformClick();


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

        public void CalculateTotalEarnings()
        {
            double basic = 0, regularday = 0, nightdiff = 0, regholiday = 0, specholiday = 0, bonus = 0;
            int overtimeHours = 0;

            if (!string.IsNullOrEmpty(basicsalTB.Text))
                basic = double.Parse(basicsalTB.Text);

            if (!string.IsNullOrEmpty(otTB.Text))
                overtimeHours = int.Parse(otTB.Text);

            if (!string.IsNullOrEmpty(otrdTB.Text))
                regularday = double.Parse(otrdTB.Text);

            if (!string.IsNullOrEmpty(otndTB.Text))
                nightdiff = double.Parse(otndTB.Text);

            if (!string.IsNullOrEmpty(otrhTB.Text))
                regholiday = double.Parse(otrhTB.Text);

            if (!string.IsNullOrEmpty(otshTB.Text))
                specholiday = double.Parse(otshTB.Text);

            if (!string.IsNullOrEmpty(bonusTB.Text))
                bonus = double.Parse(bonusTB.Text);

            double totalEarnings = basic + (overtimeHours * (regularday + nightdiff + regholiday + specholiday)) + bonus;

            //totalearningLbl.Text = totalEarnings.ToString("N2");
        }




        private void button6_Click(object sender, EventArgs e)
        {
            double sss = 0, pagibig = 0, philhealth = 0, tax = 0, others = 0;
            if (!string.IsNullOrEmpty(sssTB.Text))
                sss = double.Parse(sssTB.Text);
            if (!string.IsNullOrEmpty(pagibigTB.Text))
                pagibig = double.Parse(pagibigTB.Text);
            if (!string.IsNullOrEmpty(phTB.Text))
                philhealth = double.Parse(phTB.Text);
            if (!string.IsNullOrEmpty(wTaxTB.Text))
                tax = double.Parse(wTaxTB.Text);
            if (!string.IsNullOrEmpty(caTB.Text))
                others = double.Parse(caTB.Text);
            double totalDeductions = sss + pagibig + philhealth + tax + others;
            totalDeductionsTB.Text = "₱" + totalDeductions.ToString("N2");
        }

        private void payslipButt_MouseHover(object sender, EventArgs e)
        {
            deductButt.Location = new Point(0, 437);
            reportButt.Location = new Point(0, 511);
            messagesButt.Location = new Point(0, 584);
            archievedButton.Location = new Point(0, 658);
        }

        private void payslipButt_MouseLeave(object sender, EventArgs e)
        {
            deductButt.Location = new Point(0, 321);
            reportButt.Location = new Point(0, 395);
            messagesButt.Location = new Point(0, 468);
            archievedButton.Location = new Point(0, 542);
        }
    }
}