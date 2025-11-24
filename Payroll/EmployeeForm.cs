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
    public partial class EmployeeForm : Form
    {

        LoginForm form;

        public EmployeeForm(LoginForm form)
        {
            InitializeComponent();
            currentDateLabel.Text = DateTime.Now.ToString("MMMM dd, yyyy");
            this.form = form;
        }

        private void EmployeeForm_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            form.Show();
        }

        private void hideAllPanels()
        {
            payslipPanel.Visible = false;
            dashboardPanel.Visible = false;
        }

        private void dashboardButton_Click(object sender, EventArgs e)
        {
            hideAllPanels();
            dashboardPanel.Visible = true;
        }

        private void payslipButton_Click(object sender, EventArgs e)
        {
            hideAllPanels();
            payslipPanel.Visible = true;
        }

        private void employeesButton_Click(object sender, EventArgs e)
        {
            hideAllPanels();
            employeesPanel.Visible = true;
        }
    }
}
