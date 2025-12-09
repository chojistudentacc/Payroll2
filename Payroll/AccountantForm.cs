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

            //payrollButt.PerformClick();
            wTaxTB.Text = "0";
            sssTB.Text = "0";
            pagibigTB.Text = "0";
            phTB.Text = "0";
            absTB.Text = "0";
            caTB.Text = "0";

            textBox25.GotFocus += (s, e) => {
                this.SelectNextControl(textBox1, true, true, true, true);
            };
            totalDeductionsTB.GotFocus += (s, e) => {
                this.SelectNextControl(textBox1, true, true, true, true);
            };
            textBox27.GotFocus += (s, e) => {
                this.SelectNextControl(textBox1, true, true, true, true);
            };

        }

        // PAYSLIP
        private void payslipButt_Click(object sender, EventArgs e)
        {
            hideAllPanels();
            payslipPanel.Visible = true;
            wTaxTB.Text = "0";
            sssTB.Text = "0";
            pagibigTB.Text = "0";
            phTB.Text = "0";
            absTB.Text = "0";
            caTB.Text = "0";
        }

        private void createPayslipButt_Click(object sender, EventArgs e)
        {
            if (textBox4.Text != "" && textBox5.Text != "" && textBox6.Text != "" && textBox8.Text != "" &&
                textBox9.Text != "" && textBox10.Text != "" && textBox11.Text != "" &&
                basicsalTB.Text != "" && otTB.Text != "" && otrdTB.Text != "" && otndTB.Text != "" && otrhTB.Text != "" &&
                otshTB.Text != "" && bonusTB.Text != "" && wTaxTB.Text != "" && sssTB.Text != "" && pagibigTB.Text != "" &&
                phTB.Text != "" && absTB.Text != "" && caTB.Text != "" && textBox25.Text != "" && totalDeductionsTB.Text != "" &&
                textBox27.Text != "" && richTextBox1.Text != "")
            {

                if (repo.EmployeeExists(textBox4.Text))
                {
                    bool success = repo.InsertEmployeeFinanceData(
                        textBox4.Text,
                        textBox5.Text,
                        textBox6.Text,
                        textBox11.Text,
                        textBox10.Text,
                        textBox9.Text,
                        dateTimePicker2.Value,
                        dateTimePicker3.Value,
                        Convert.ToDecimal(textBox7.Text),
                        Convert.ToDecimal(textBox8.Text),
                        Convert.ToDecimal(basicsalTB.Text),
                        Convert.ToInt32(otTB.Text),
                        Convert.ToDecimal(otrdTB.Text),
                        Convert.ToDecimal(otndTB.Text),
                        Convert.ToDecimal(otrhTB.Text),
                        Convert.ToDecimal(otshTB.Text),
                        Convert.ToDecimal(bonusTB.Text),
                        Convert.ToDecimal(wTaxTB.Text),
                        Convert.ToDecimal(sssTB.Text),
                        Convert.ToDecimal(pagibigTB.Text),
                        Convert.ToDecimal(phTB.Text),
                        Convert.ToDecimal(absTB.Text),
                        Convert.ToDecimal(caTB.Text),
                        Convert.ToDecimal(textBox25.Text),
                        Convert.ToDecimal(totalDeductionsTB.Text),
                        Convert.ToDecimal(textBox27.Text),
                        richTextBox1.Text
                    );

                    if (success)
                        MessageBox.Show("Payroll Entry Saved!");
                    else
                        MessageBox.Show("Failed to save.");
                }
                else
                {
                    MessageBox.Show("Employee ID does not exist.");
                }

            }
            else
            {
                MessageBox.Show("Please fill in all required fields.");
            }
        }

        private void getEmployeeName_Click(object sender, EventArgs e)
        {
            if (textBox4.Text != "")
            {
                var emp = repo.GetEmployeeInfo(textBox4.Text);

                if (emp != null)
                {
                    textBox11.Text = emp.Value.FullName;
                    textBox10.Text = emp.Value.Position;
                }
                else
                {
                    MessageBox.Show("Employee not found");
                }

            }
            else
            {
                MessageBox.Show("Please enter Employee ID.");
            }
        }

        private void cancelPayslipButt_Click(object sender, EventArgs e)
        {
            ClearPayrollFields();
        }

        private void ClearPayrollFields()
        {
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox8.Text = "";
            textBox9.Text = "";
            textBox10.Text = "";
            textBox11.Text = "";

            basicsalTB.Text = "";
            otTB.Text = "";
            otrdTB.Text = "";
            otndTB.Text = "";
            otrhTB.Text = "";
            otshTB.Text = "";
            bonusTB.Text = "";
            wTaxTB.Text = "0";
            sssTB.Text = "0";
            pagibigTB.Text = "0";
            phTB.Text = "0";
            absTB.Text = "0";
            caTB.Text = "0";
            textBox25.Text = "";
            totalDeductionsTB.Text = "";
            textBox27.Text = "";
            richTextBox1.Text = "";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            // --- Read Salary and Overtime ---
            decimal basicSalary = decimal.TryParse(basicsalTB.Text, out var bSal) ? bSal : 0;
            decimal otReg = decimal.TryParse(otTB.Text, out var oTR) ? oTR : 0;
            decimal otNight = decimal.TryParse(otndTB.Text, out var oTN) ? oTN : 0;
            decimal otRHoliday = decimal.TryParse(otrhTB.Text, out var oTRH) ? oTRH : 0;
            decimal otSHoliday = decimal.TryParse(otshTB.Text, out var oTSH) ? oTSH : 0;
            decimal bonus = decimal.TryParse(bonusTB.Text, out var bns) ? bns : 0;

            decimal totalEarnings = basicSalary + otReg + otNight + otRHoliday + otSHoliday + bonus;

            // --- Compute Deductions ---
            decimal sss = ComputeSSSDeduction(basicSalary);
            decimal philHealth = ComputePhilHealth(basicSalary);
            decimal pagibig = ComputePagIBIG(basicSalary);
            decimal wTax = ComputeWithholdingTax(totalEarnings);

            decimal absences = decimal.TryParse(absTB.Text, out var ab) ? ab : 0;
            decimal cashAdvance = decimal.TryParse(caTB.Text, out var ca) ? ca : 0;

            decimal totalDeductions = sss + philHealth + pagibig + wTax + absences + cashAdvance;

            // --- Update Deduction TextBoxes ---
            sssTB.Text = sss.ToString("F2");
            phTB.Text = philHealth.ToString("F2");
            pagibigTB.Text = pagibig.ToString("F2");
            wTaxTB.Text = wTax.ToString("F2");

            totalDeductionsTB.Text = totalDeductions.ToString("F2");

            // --- Update Net Pay ---
            decimal netPay = totalEarnings - totalDeductions;
            textBox27.Text = netPay.ToString("F2");
        }

        private void createPayslipComputeButt_Click(object sender, EventArgs e)
        {
            // --- EARNINGS ---
            decimal basicSalary = decimal.TryParse(basicsalTB.Text, out var bSal) ? bSal : 0;
            decimal otReg = decimal.TryParse(otTB.Text, out var oTR) ? oTR : 0;
            decimal otNight = decimal.TryParse(otndTB.Text, out var oTN) ? oTN : 0;
            decimal otRHoliday = decimal.TryParse(otrhTB.Text, out var oTRH) ? oTRH : 0;
            decimal otSHoliday = decimal.TryParse(otshTB.Text, out var oTSH) ? oTSH : 0;
            decimal bonus = decimal.TryParse(bonusTB.Text, out var bns) ? bns : 0;

            decimal totalOT = otReg + otNight + otRHoliday + otSHoliday;
            decimal totalEarnings = basicSalary + totalOT + bonus;
            textBox25.Text = totalEarnings.ToString("F2");

            // --- DEDUCTIONS ---
            decimal wTax = decimal.TryParse(wTaxTB.Text, out var wt) ? wt : 0;
            decimal sss = decimal.TryParse(sssTB.Text, out var s) ? s : 0;
            decimal pagibig = decimal.TryParse(pagibigTB.Text, out var pi) ? pi : 0;
            decimal philHealth = decimal.TryParse(phTB.Text, out var ph) ? ph : 0;
            decimal absences = decimal.TryParse(absTB.Text, out var ab) ? ab : 0;
            decimal cashAdvance = decimal.TryParse(caTB.Text, out var ca) ? ca : 0;

            decimal totalDeductions = wTax + sss + pagibig + philHealth + absences + cashAdvance;
            totalDeductionsTB.Text = totalDeductions.ToString("F2");

            // --- NET PAY ---
            decimal netPay = totalEarnings - totalDeductions;
            textBox27.Text = netPay.ToString("F2");
        }

        private decimal ComputeSSSDeduction(decimal salary)
        {
            if (salary <= 5250) return 250;
            int steps = (int)((salary - 5250) / 500);
            return 275 + 25 * steps;
        }

        private decimal ComputePhilHealth(decimal salary)
        {
            return salary * 0.025m;
        }

        private decimal ComputePagIBIG(decimal salary)
        {
            return salary <= 1500 ? salary * 0.01m : salary * 0.02m;
        }

        private decimal ComputeWithholdingTax(decimal totalEarnings)
        {
            if (totalEarnings <= 20833) return 0;
            if (totalEarnings <= 33333) return (totalEarnings - 20833) * 0.20m;
            if (totalEarnings <= 66666) return 2500 + (totalEarnings - 33333) * 0.25m;
            if (totalEarnings <= 166666) return 10833 + (totalEarnings - 66666) * 0.30m;
            if (totalEarnings <= 666666) return 40833 + (totalEarnings - 166666) * 0.32m;
            return 200833 + (totalEarnings - 666666) * 0.35m;
        }


        private void messagesButt_Click(object sender, EventArgs e)
        {
            hideAllPanels();
        }

        private void initializeItems()
        {
            ID = repo.getAccountantID(userName);
            idLabel.Text = "Account ID: " + ID;
            hideAllPanels();
        }

        private void hideAllPanels()
        {
            payrollPanel.Visible = false;
            payslipPanel.Visible = false;
            deductionsPanel.Visible = false;
            reportPanel.Visible = false;
            archivedPanel.Visible = false;
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
            payrollPanel.Visible = true;
        }

        private void deductButt_Click(object sender, EventArgs e)
        {
            hideAllPanels();
            deductionsPanel.Visible = true;
            GenerateSSSTable();
        }

        private void reportButt_Click(object sender, EventArgs e)
        {
            hideAllPanels();
            reportPanel.Visible = true;
        }

        private void archivedButton_Click(object sender, EventArgs e)
        {
            hideAllPanels();
            archivedPanel.Visible = true;
        }

        private void phButt_Click(object sender, EventArgs e)
        {
            taxLabel.Text = "PhilHealth Contribution";
            GeneratePhilHealthTable();
        }

        private void sssButton_Click(object sender, EventArgs e)
        {
            taxLabel.Text = "SSS Contribution";
            GenerateSSSTable();
        }

        private void pagibigButt_Click(object sender, EventArgs e)
        {
            taxLabel.Text = "Pag-IBIG Contribution";
            GeneratePagIBIGTable();

        }

        private void taxButt_Click(object sender, EventArgs e)
        {
            taxLabel.Text = "Withholding Tax Table";
            GenerateWithholdingTaxTable();

        }

        private void viewButt_Click(object sender, EventArgs e)
        {
            hideAllPanels();
            viewpayslipPanel.Visible = true;
            payrollButt.Enabled = false;
            payslipButt.Enabled = false;
            deductButt.Enabled = false;
            reportButt.Enabled = false;
        }

        private void closeButt_Click(object sender, EventArgs e)
        {
            hideAllPanels();
            panel.Visible = true;
            payrollButt.Enabled = true;
            payslipButt.Enabled = true;
            deductButt.Enabled = true;
            reportButt.Enabled = true;
        }

        //public void CalculateTotalEarnings()
        //{
        //    double basic = 0, regularday = 0, nightdiff = 0, regholiday = 0, specholiday = 0, bonus = 0;
        //    int overtimeHours = 0;

        //    if (!string.IsNullOrEmpty(basicsalTB.Text))
        //        basic = double.Parse(basicsalTB.Text);

        //    if (!string.IsNullOrEmpty(otTB.Text))
        //        overtimeHours = int.Parse(otTB.Text);

        //    if (!string.IsNullOrEmpty(otrdTB.Text))
        //        regularday = double.Parse(otrdTB.Text);

        //    if (!string.IsNullOrEmpty(otndTB.Text))
        //        nightdiff = double.Parse(otndTB.Text);

        //    if (!string.IsNullOrEmpty(otrhTB.Text))
        //        regholiday = double.Parse(otrhTB.Text);

        //    if (!string.IsNullOrEmpty(otshTB.Text))
        //        specholiday = double.Parse(otshTB.Text);

        //    if (!string.IsNullOrEmpty(bonusTB.Text))
        //        bonus = double.Parse(bonusTB.Text);

        //    double totalEarnings = basic + (overtimeHours * (regularday + nightdiff + regholiday + specholiday)) + bonus;

        //    //totalearningLbl.Text = totalEarnings.ToString("N2");
        //}

        //private void button6_Click(object sender, EventArgs e)
        //{
        //    double sss = 0, pagibig = 0, philhealth = 0, tax = 0, others = 0;
        //    if (!string.IsNullOrEmpty(sssTB.Text))
        //        sss = double.Parse(sssTB.Text);
        //    if (!string.IsNullOrEmpty(pagibigTB.Text))
        //        pagibig = double.Parse(pagibigTB.Text);
        //    if (!string.IsNullOrEmpty(phTB.Text))
        //        philhealth = double.Parse(phTB.Text);
        //    if (!string.IsNullOrEmpty(wTaxTB.Text))
        //        tax = double.Parse(wTaxTB.Text);
        //    if (!string.IsNullOrEmpty(caTB.Text))
        //        others = double.Parse(caTB.Text);
        //    double totalDeductions = sss + pagibig + philhealth + tax + others;
        //    totalDeductionsTB.Text = "₱" + totalDeductions.ToString("N2");
        //}

        

        private void payslipButt_MouseHover(object sender, EventArgs e)
        {
            deductButt.Location = new Point(0, 437);
            reportButt.Location = new Point(0, 511);
            archivedButton.Location = new Point(0, 658);
        }

        private void payslipButt_MouseLeave(object sender, EventArgs e)
        {
            deductButt.Location = new Point(0, 321);
            reportButt.Location = new Point(0, 395);
            archivedButton.Location = new Point(0, 468);
        }


        private void GenerateSSSTable()
        {
            double startMin = 5250;
            double startMax = 5749.99;

            double deductionStart = 275;
            double deductionStep = 25;

            int rows = 50;


            dataGridView1.Columns.Clear();


            dataGridView1.Columns.Add("Range", "Salary Range");
            dataGridView1.Columns.Add("Employer", "Employer Share");
            dataGridView1.Columns.Add("Employee", "Employee Share");


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

        private void GeneratePhilHealthTable()
        {
            if (dataGridView1.Columns.Count == 0)
            {
                dataGridView1.Columns.Add("Range", "Salary Range");
                dataGridView1.Columns.Add("Employer", "Employer Share (2.5%)");
                dataGridView1.Columns.Add("Employee", "Employee Share (2.5%)");
            }

            dataGridView1.Rows.Clear();

            // Salary ranges
            dataGridView1.Rows.Add("0 - 9,999", "2.5%", "2.5%");
            dataGridView1.Rows.Add("10,000 - 99,999", "2.5%", "2.5%");
            dataGridView1.Rows.Add("100,000 and above", "2.5%", "2.5%");

        }

        private void GeneratePagIBIGTable()
        {
            if (dataGridView1.Columns.Count == 0)
            {
                dataGridView1.Columns.Add("Range", "Salary Range");
                dataGridView1.Columns.Add("Employer", "Employer Share");
                dataGridView1.Columns.Add("Employee", "Employee Share");
            }
            dataGridView1.Rows.Clear();
            // Salary ranges
            dataGridView1.Rows.Add("500 - 1,500", "2%", "1%");
            dataGridView1.Rows.Add("1-501 Above", "2%", "2%");
        }

        private void GenerateWithholdingTaxTable()
        {
            double startMin = 0;
            double startMax = 20833;

            double[] nextRanges = { 33333, 66666, 166666, 666666 };
            double[] rates = { 0, 20, 25, 30, 32, 35 };

            string[] formulas =
                {
                "NONE",
                "20% excess over 20,833",
                "2,500 + 25% excess",
                "10,833 + 30% excess",
                "40,833 + 32% excess",
                "200,833 + 35% excess"
            };

            dataGridView1.Columns.Clear();

            dataGridView1.Columns.Add("Range", "Salary Range");
            dataGridView1.Columns.Add("Rate", "Deduction Rate");
            dataGridView1.Columns.Add("Compute", "Tax Computation");

            dataGridView1.Rows.Clear();


            // FIRST ROW (0 - 20,833)
            dataGridView1.Rows.Add("0 - 20,833", "0%", "NONE");

            double min = 20833;
            double max;

            // MIDDLE ROWS (20,833 – 666,666)
            for (int i = 0; i < nextRanges.Length; i++)
            {
                max = nextRanges[i];

                string rangeText = $"{min:N0} - {max:N0}";
                string rateText = rates[i + 1] + "%";
                string formulaText = formulas[i + 1];

                dataGridView1.Rows.Add(rangeText, rateText, formulaText);

                min = max;
            }

            dataGridView1.Rows.Add("Above 666,666", "35%", "200,833 + 35% excess");
        }

        
    }
}