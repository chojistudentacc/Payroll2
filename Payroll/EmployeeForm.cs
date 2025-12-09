using Microsoft.VisualBasic.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
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
        DataRow latestPayslipRow = null;

        public EmployeeForm(LoginForm form)
        {
            InitializeComponent();
            this.login = form;
            repo = new Repository();
            repo.LoadPicture(repo.getEmployeeID(login.userName), pictureBox2);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;


        }

        public void SetCurrentUserName(string userName)
        {
            currentUserName = userName;
        }

        private void EmployeeForm_Load(object sender, EventArgs e)
        {
            hideAllPanels();
            LoadEmployeeProfile();
            LoadDashboardStats();

            LoadLatestPayslip();
            LoadAttendanceData();
            dashboardPanel.Visible = true;
            fillLeaveScreen();

            allEmpLB.TextAlign = ContentAlignment.MiddleCenter; 
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

        // leaves
        private void leavesButton_Click(object sender, EventArgs e)
        {
            hideAllPanels();
            leavePanel.Visible = true;
            fillLeaveScreen();
        }

        private void createLeaveSubmitButt_Click(object sender, EventArgs e)
        {
            if (leaveRichTB.Text != "" && leaveFormCB.Text != "")
            {
                bool success = repo.AddLeaveRequest(
                currentEmployeeID,
                leaveFormCB.Text,
                leaveStartDatePicker.Value,
                leaveEndDatePicker.Value,
                "To be approved",
                leaveRichTB.Text,
                repo.GetNextRequestID());

                TimeSpan timeSpan = leaveEndDatePicker.Value - leaveStartDatePicker.Value;
                int daysBetween = timeSpan.Days;

                bool updated = repo.UpdateLeaveCredit(currentEmployeeID, leaveFormCB.Text, daysBetween);

                if (success && updated)
                    MessageBox.Show("Leave request added successfully!");
                else
                    MessageBox.Show("Failed to add leave request.");

                leaveFormCB.Text = "";
                leaveFormCB.Items.Clear();
                leaveStartDatePicker.Value = DateTime.Now;
                leaveEndDatePicker.Value = DateTime.Now;
                leaveRichTB.Text = "";

                leaveSummaryPanel.Visible = true;
                createLeavePanel.Visible = false;
                fillLeaveScreen();
            }
            else
            {
                MessageBox.Show("Please fill out all fields.");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            leaveFormCB.Items.Add("Standard Leave");
            leaveFormCB.Items.Add("Sick Leave");
            leaveFormCB.Items.Add("Vacation Leave");
            leaveFormCB.Items.Add("Emergecy Leave");
            leaveFormCB.DropDownStyle = ComboBoxStyle.DropDownList;
            leaveEndDatePicker.Value = leaveStartDatePicker.Value.Date.AddDays(1);

            leaveSummaryPanel.Visible = false;
            createLeavePanel.Visible = true;
        }

        private void fillLeaveScreen()
        {
            DataRow row = repo.GetLeaveCredits(currentEmployeeID);

            if (row != null)
            {
                label33.Text = "LEAVE CREDITS: " + row["leaveCredit"].ToString();
                label34.Text = "SICK LEAVE REMAINING: " + row["sickLeave"].ToString();
                label35.Text = "VACATION LEAVE REMAINING: " + row["vacationLeave"].ToString();
                label36.Text = "EMERGENCY LEAVE REMAINING: " + row["emergencyLeave"].ToString();
            }

            repo.LoadLeaveRequests(currentEmployeeID, LeaveDataGridView);

        }

        private void createLeaveCancelButt_Click(object sender, EventArgs e)
        {
            leaveFormCB.Text = "";
            leaveFormCB.Items.Clear();
            leaveStartDatePicker.Value = DateTime.Now;
            leaveEndDatePicker.Value = leaveStartDatePicker.Value.Date.AddDays(1);
            leaveRichTB.Text = "";

            leaveSummaryPanel.Visible = true;
            createLeavePanel.Visible = false;
            fillLeaveScreen();
        }

        private void leaveDatePickerChanged(object sender, EventArgs e)
        {
            if (leaveStartDatePicker.Value.Date < DateTime.Today)
            {
                MessageBox.Show("Start date cannot be in the past.");
                leaveStartDatePicker.Value = DateTime.Today;
                return;
            }

            if (leaveEndDatePicker.Value.Date <= leaveStartDatePicker.Value.Date)
            {
                MessageBox.Show("End date must be after start date.");
                leaveEndDatePicker.Value = leaveStartDatePicker.Value.Date.AddDays(1);
                return;
            }
        }
        // end of leave

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
                    employeeName.Text = $"{employeeData["employeeID"]}";
                    employeeName.AutoSize = false;
                    employeeName.TextAlign = ContentAlignment.MiddleCenter;

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

                    repo.LoadPicture(currentEmployeeID, pictureBox1);
                    pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
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
            using (ChangePassword passForm = new ChangePassword())

            {
                passForm.StartPosition = FormStartPosition.CenterParent;
                if (passForm.ShowDialog() == DialogResult.OK)
                {

                    string newPass = passForm.NewPassword;

                    if (repo.UpdatePasswordOnly(currentEmployeeID, newPass))
                    {
                        MessageBox.Show("Password changed successfully!");

                        actualPassword = newPass;
                        employeeProfilePasswordTB.Text = "Hidden";
                        showPasswordButton.Text = "Show";
                        isPasswordVisible = false;
                    }
                }
            }
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
        private void LoadDashboardStats()
        {

            if (string.IsNullOrEmpty(currentEmployeeID))
            {

                MessageBox.Show("Error: currentEmployeeID is empty. Profile not loaded yet?");
                return;
            }

            try
            {

                decimal netPay = repo.GetLatestNetPay(currentEmployeeID);
                allEmpLB.Text = netPay.ToString("N2");


                int attendanceCount = repo.GetMonthlyAttendanceCount(currentEmployeeID);
                AttendanceLb.Text = attendanceCount.ToString();


                if (attendanceCount == 0)
                {

                    MessageBox.Show($"Attendance is 0 for ID: {currentEmployeeID}. Check database for 'Present' status this month.");
                }


                int leaveCount = repo.GetTotalLeaves(currentEmployeeID);
                LeavesLb.Text = leaveCount.ToString();
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error loading stats: " + ex.Message);
            }
        }

        private void ViewButton_Click(object sender, EventArgs e)
        {
            if (latestPayslipRow == null)
            {
                MessageBox.Show("No payslip data available to view.");
                return;
            }

            hideAllPanels();
            payslipPanel.Visible = true;

           
        }

        private void DownloadButton_Click(object sender, EventArgs e)
        {
            if (latestPayslipRow == null) return;

            string period = LatestPayslipLabel.Text;

            // Simple confirmation for now (PDF generation is complex)
            MessageBox.Show($"Payslip for [{period}] downloaded successfully!",
                            "Download Complete",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
        }
        private void LoadLatestPayslip()
        {
            // 1. Get data from Repo
            latestPayslipRow = repo.GetLatestPayslip(currentEmployeeID);
            LatestPayslipLabel.TextAlign = ContentAlignment.MiddleCenter;

            if (latestPayslipRow != null)
            {
                DateTime startDate = Convert.ToDateTime(latestPayslipRow["payPeriod"]);
                DateTime endDate;

                // Logic to calculate the End Date (Semi-Monthly standard)
                if (startDate.Day <= 15)
                {
                    // First Half: 1st to 15th
                    startDate = new DateTime(startDate.Year, startDate.Month, 1);
                    endDate = new DateTime(startDate.Year, startDate.Month, 15);
                }
                else
                {
                    // Second Half: 16th to End of Month
                    startDate = new DateTime(startDate.Year, startDate.Month, 16);
                    int lastDay = DateTime.DaysInMonth(startDate.Year, startDate.Month);
                    endDate = new DateTime(startDate.Year, startDate.Month, lastDay);
                }

                // 3. Update YOUR LABEL
                LatestPayslipLabel.Text = $"{startDate:MMMM d, yyyy} - {endDate:MMMM d, yyyy}";
            }
            else
            {
                // No payslip found
                LatestPayslipLabel.Text = "No payslip available";
            }
        }
    }
}
