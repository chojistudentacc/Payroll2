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
        Repository repo;
        string currentUserName;
        string actualPassword;
        string currentEmployeeID;
        bool isPasswordVisible = false;

        public EmployeeForm(LoginForm form)
        {
            InitializeComponent();
            this.login = form;
            repo = new Repository();
        }

        public void SetCurrentUserName(string userName)
        {
            currentUserName = userName;
        }

        private void EmployeeForm_Load(object sender, EventArgs e)
        {
            hideAllPanels();
            LoadEmployeeProfile();
            LoadAttendanceData();
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
            LoadAttendanceData();
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

        private void LoadEmployeeProfile()
        {
            try
            {
                DataRow employeeData = repo.GetEmployeeProfileData(currentUserName);

                if (employeeData != null)
                {
                    currentEmployeeID = employeeData["employeeID"].ToString();

                    employeeProfileIDLabel.Text = employeeData["employeeID"].ToString();
                    employeeProfileNameLabel.Text = $"{employeeData["firstName"]} {employeeData["middleName"]} {employeeData["lastName"]}";
                    employeeName.Text = $"{employeeData["firstName"]}";

                    employeeProfileUserIDLabel.Text = employeeData["username"].ToString();

                    actualPassword = employeeData["password"].ToString();
                    employeeProfilePasswordTB.Text = "Hidden";
                    employeeProfilePasswordTB.ReadOnly = true;

                    employeeEmailLabel.Text = employeeData["email"].ToString();
                    employeeContactLabel.Text = employeeData["contactNum"].ToString();
                    employeeAddressLabel.Text = employeeData["address"].ToString();

                    employeeProfilePositionLabel.Text = "Employee";
                    employeeProfileDepartmentLabel.Text = "None";
                    employeeTypeLabel.Text = "Employee";

                    employeTinLabel.Text = "None";
                    employeeSSSLabel.Text = "None";
                    label22.Text = "None";
                    label21.Text = "None";
                }
                else
                {
                    MessageBox.Show("Employee profile not found.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading employee profile: " + ex.Message);
            }
        }

        private void showPasswordButton_Click(object sender, EventArgs e)
        {
            if (isPasswordVisible)
            {
                employeeProfilePasswordTB.Text = "Hidden";
                showPasswordButton.Text = "Show";
                isPasswordVisible = false;
            }
            else
            {
                employeeProfilePasswordTB.Text = actualPassword;
                showPasswordButton.Text = "Hide";
                isPasswordVisible = true;
            }
        }


        private void changePasswordButton_Click_1(object sender, EventArgs e)
        {
            string userInput = Microsoft.VisualBasic.Interaction.InputBox("Enter your name:", "User Input", "Default Name");
            if (!string.IsNullOrEmpty(userInput))
            {
                MessageBox.Show("You entered: " + userInput);
            }
            employeeProfilePasswordTB.ReadOnly = false;
            employeeProfilePasswordTB.Clear();
            employeeProfilePasswordTB.Focus();
        }

        public void LoadAttendanceData()
        {
            if (string.IsNullOrEmpty(currentEmployeeID)) return;

            DataTable dt = repo.GetEmployeeAttendance(currentEmployeeID);
            logDataGridView.DataSource = dt;
        }

        private void ClockInButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(currentEmployeeID)) return;

            if (repo.ClockInEmployee(currentEmployeeID))
            {
                MessageBox.Show("Clock In Successful!");
                LoadAttendanceData();
            }
        }

        private void ClockouButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(currentEmployeeID)) return;

            DialogResult dr = MessageBox.Show("Are you sure you want to clock out?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                if (repo.ClockOutEmployee(currentEmployeeID))
                {
                    MessageBox.Show("Clock Out Successful!");
                    LoadAttendanceData();
                }
            }
        }
    }
}
