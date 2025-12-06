using Microsoft.VisualBasic.Logging;
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

        LoginForm login;

        public EmployeeForm(LoginForm form)
        {
            InitializeComponent();
            this.login = form;
        }

        private void EmployeeForm_Load(object sender, EventArgs e)
        {
            hideAllPanels();
            dashboardPanel.Visible = true;
        }

        private void hideAllPanels()
        {
            dashboardPanel.Visible = false;
            attendancePanel.Visible = false;
            leavePanel.Visible = false;
            payslipPanel.Visible = false;
            profilePanel.Visible = false;
        }

        private void profileButton_Click(object sender, EventArgs e)
        {
            hideAllPanels();
            profilePanel.Visible = true;
        }

        private void payslipButton_Click_1(object sender, EventArgs e)
        {
            hideAllPanels();
            payslipPanel.Visible = true;
        }

        private void leavesButton_Click(object sender, EventArgs e)
        {
            hideAllPanels();
            leavePanel.Visible = true;
        }

        private void attendanceButt_Click(object sender, EventArgs e)
        {
            hideAllPanels();
            attendancePanel.Visible = true;
        }

        private void dashboardButt_Click(object sender, EventArgs e)
        {
            hideAllPanels();
            dashboardPanel.Visible = true;
        }

        private void EmployeeForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            login.Visible = true;
        }
    }
}
