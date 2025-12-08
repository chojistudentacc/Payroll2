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
            panela.Visible = true;
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
            panela.Visible = false;
            viewpayslipPanel.Visible = false;
            SSSPanel.Visible = false;
            reportPanel.Visible = false;
            messagesPanel.Visible = false;
            panel.Visible = false;
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
            panel.Visible = true;
        }

        private void deductButt_Click(object sender, EventArgs e)
        {
            hideAllPanels();
            SSSPanel.Visible = true;
            GenerateSSSTable();
        }

        private void reportButt_Click(object sender, EventArgs e)
        {
            hideAllPanels();
            reportPanel.Visible = true;
        }

        private void phButt_Click(object sender, EventArgs e)
        {

        }

        private void sssButton_Click(object sender, EventArgs e)
        {
            taxLabel.Text = "SSS Contribution";
            GenerateSSSTable();
        }

        private void pagibigButt_Click(object sender, EventArgs e)
        {


        }

        private void taxButt_Click(object sender, EventArgs e)
        {


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
            panel.Visible = true;
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
            archivedButton.Location = new Point(0, 658);
        }

        private void payslipButt_MouseLeave(object sender, EventArgs e)
        {
            deductButt.Location = new Point(0, 321);
            reportButt.Location = new Point(0, 395);
            messagesButt.Location = new Point(0, 468);
            archivedButton.Location = new Point(0, 542);
        }


        private void GenerateSSSTable()
        {
            double startMin = 5250;
            double startMax = 5749.99;

            double deductionStart = 275;   
            double deductionStep = 25;

            int rows = 50;


            if (dataGridView1.Columns.Count == 0)
            {
                dataGridView1.Columns.Add("Range", "Salary Range");
                dataGridView1.Columns.Add("Employer", "Employer Share");
                dataGridView1.Columns.Add("Employee", "Employee Share");
            }

            dataGridView1.Rows.Clear();


            string belowRange = "Below 5250";
            string employee = "250";      
            string employer = "500";      

            dataGridView1.Rows.Add(belowRange, employee, employer);


            for (int i = 0; i < rows; i++)
            {
                double minRange = startMin + (i * 500);
                double maxRange = startMax + (i * 500);
                double employeeShare = deductionStart + (i * deductionStep);

                double employerShare = employeeShare * 2;

                string rangeText = $"{minRange:F2} - {maxRange:F2}";
                string employeeText = employeeShare.ToString("F2");
                string employerText = employerShare.ToString("F2");

                dataGridView1.Rows.Add(rangeText, employerText, employeeText);
            }
        }



    }
}