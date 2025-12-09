using Payroll.Models;
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
    public partial class HumanResourcesForm : Form
    {
        private string userName;
        private string ID;
        LoginForm login;
        Repository repo;
        string currentUserName;
        string actualPassword;
        string currentEmployeeID;
        private Image currentImage;
        bool isPasswordVisible = false;

        public HumanResourcesForm(LoginForm login, string name)
        {
            InitializeComponent();
            this.userName = name;
            this.currentUserName = name;
            this.login = login;
            repo = new Repository();

            initializeItems();
            dashboardPanel.Visible = true;
        }

        private void initializeItems()
        {
            ID = repo.getHRID(userName);
            welcomeLabelAdmin.Text = "HR ID: " + ID;

            hideAllPanels();
            hideEmployeeSubMenu();
            LoadEmployeeProfile();
            SetupAttendanceControls();
        }

        private void SetupAttendanceControls()
        {
            // Setup Status ComboBox
            cmbFilterStatus.Items.Clear();
            cmbFilterStatus.Items.Add("All");
            cmbFilterStatus.Items.Add("Present");
            cmbFilterStatus.Items.Add("Late");
            cmbFilterStatus.Items.Add("Overtime");
            cmbFilterStatus.Items.Add("Undertime");
            cmbFilterStatus.Items.Add("Absent");
            cmbFilterStatus.SelectedIndex = 0;

            // Set placeholder text for search
            attendanceSearchTB.Text = "Search by Employee ID, Name, or Date (MM/dd/yyyy)";
            attendanceSearchTB.ForeColor = Color.Gray;

            // Add focus events for placeholder
            attendanceSearchTB.GotFocus += AttendanceSearchTB_GotFocus;
            attendanceSearchTB.LostFocus += AttendanceSearchTB_LostFocus;
        }

        private void AttendanceSearchTB_GotFocus(object sender, EventArgs e)
        {
            if (attendanceSearchTB.Text == "Search by Employee ID, Name, or Date (MM/dd/yyyy)")
            {
                attendanceSearchTB.Text = "";
                attendanceSearchTB.ForeColor = Color.Black;
            }
        }

        private void AttendanceSearchTB_LostFocus(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(attendanceSearchTB.Text))
            {
                attendanceSearchTB.Text = "Search by Employee ID, Name, or Date (MM/dd/yyyy)";
                attendanceSearchTB.ForeColor = Color.Gray;
            }
        }

        private void SearchAttendance()
        {
            string searchInput = attendanceSearchTB.Text.Trim();

            // Ignore placeholder text
            if (searchInput == "Search by Employee ID, Name, or Date (MM/dd/yyyy)" || string.IsNullOrEmpty(searchInput))
            {
                LoadAllAttendance();
                return;
            }

            DateTime parsedDate;
            DataTable dt;

            // Try multiple date formats
            string[] dateFormats = { "MM/dd/yyyy", "dd/MM/yyyy", "yyyy-MM-dd" };

            if (DateTime.TryParseExact(searchInput, dateFormats,
                System.Globalization.CultureInfo.InvariantCulture,
                System.Globalization.DateTimeStyles.None,
                out parsedDate))
            {
                // Search by date with status filter
                string statusFilter = cmbFilterStatus.SelectedItem?.ToString() ?? "All";
                dt = repo.GetAttendanceByFilter(parsedDate, statusFilter);

                if (dt == null || dt.Rows.Count == 0)
                {
                    userDataGridView.DataSource = null;
                    MessageBox.Show($"No attendance records found for: {parsedDate:MMMM dd, yyyy}\n\nStatus Filter: {statusFilter}",
                        "No Records Found", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
            else
            {
                // Search by employee ID or name
                dt = repo.SearchAttendanceByEmployeeOrDate(searchInput);

                if (dt == null || dt.Rows.Count == 0)
                {
                    userDataGridView.DataSource = null;
                    MessageBox.Show($"No attendance records found for: {searchInput}\n\n" +
                        "For date search, use one of these formats:\n" +
                        "• MM/dd/yyyy (12/09/2025)\n" +
                        "• dd/MM/yyyy (09/12/2025)\n" +
                        "• yyyy-MM-dd (2025-12-09)",
                        "No Records Found", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }

            userDataGridView.DataSource = dt;
            FormatAttendanceDataGridView();
        }

        private void LoadAllAttendance()
        {
            // Load today's attendance by default
            string statusFilter = cmbFilterStatus.SelectedItem?.ToString() ?? "All";
            DataTable dt = repo.GetAttendanceByFilter(DateTime.Now, statusFilter);

            if (dt != null && dt.Rows.Count > 0)
            {
                userDataGridView.DataSource = dt;
                FormatAttendanceDataGridView();
            }
            else
            {
                userDataGridView.DataSource = null;
            }
        }

        private void FormatAttendanceDataGridView()
        {
            if (userDataGridView.DataSource == null) return;

            // Apply styling
            userDataGridView.EnableHeadersVisualStyles = false;
            userDataGridView.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(120, 40, 40);
            userDataGridView.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            userDataGridView.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            userDataGridView.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            userDataGridView.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            userDataGridView.ReadOnly = true;
            userDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            // Remove or change AutoSizeColumnsMode
            userDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;

            // Set column widths if they exist
            if (userDataGridView.Columns.Contains("Emp ID"))
            {
                userDataGridView.Columns["Emp ID"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                userDataGridView.Columns["Emp ID"].Width = 100;
            }

            if (userDataGridView.Columns.Contains("Name"))
            {
                userDataGridView.Columns["Name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                userDataGridView.Columns["Name"].Width = 150;
            }

            if (userDataGridView.Columns.Contains("Date"))
            {
                userDataGridView.Columns["Date"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                userDataGridView.Columns["Date"].Width = 120;
            }

            if (userDataGridView.Columns.Contains("Clock In"))
            {
                userDataGridView.Columns["Clock In"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                userDataGridView.Columns["Clock In"].Width = 100;
            }

            if (userDataGridView.Columns.Contains("Clock Out"))
            {
                userDataGridView.Columns["Clock Out"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                userDataGridView.Columns["Clock Out"].Width = 100;
            }

            if (userDataGridView.Columns.Contains("Hours Worked"))
            {
                userDataGridView.Columns["Hours Worked"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                userDataGridView.Columns["Hours Worked"].Width = 100;
            }

            if (userDataGridView.Columns.Contains("Status"))
            {
                userDataGridView.Columns["Status"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                userDataGridView.Columns["Status"].Width = 120;
            }
        }
        private void HumanResourcesForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (login != null && !login.IsDisposed)
            {
                login.Show();
            }
            else
            {
                new LoginForm().Show();
            }
        }

        private void hideAllPanels()
        {
            dashboardPanel.Visible = false;
            employeePanel.Visible = false;
            attendancePanel.Visible = false;
            requestPanel.Visible = false;
            reportPanel.Visible = false;
            archivedPanel.Visible = false;
            profilePanel.Visible = false;
        }

        private void dashboardButt_Click(object sender, EventArgs e)
        {
            hideAllPanels();
            dashboardPanel.Visible = true;
        }

        private void employeeButt_Click(object sender, EventArgs e)
        {
            hideAllPanels();
            employeePanel.Visible = true;
        }

        private void attendanceButt_Click(object sender, EventArgs e)
        {
            hideAllPanels();
            attendancePanel.Visible = true;
            LoadAllAttendance(); // Load attendance when panel opens
        }

        private void requestButt_Click(object sender, EventArgs e)
        {
            hideAllPanels();
            requestPanel.Visible = true;
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

        private void profileButt_Click(object sender, EventArgs e)
        {
            hideAllPanels();
            profilePanel.Visible = true;
        }

        private void hideEmployeeSubMenu()
        {
            addEmployeesPanel.Visible = false;
            viewEmployeesPanel.Visible = false;
            promotionEmployeePanel.Visible = false;
            editEmployeesPanel.Visible = false;
        }

        private void addEmpButt_Click(object sender, EventArgs e)
        {
            hideEmployeeSubMenu();
            addEmployeesPanel.Visible = true;
        }

        private void employeeViewButton_Click(object sender, EventArgs e)
        {
            hideEmployeeSubMenu();
            viewEmployeesPanel.Visible = true;
        }

        private void saveChangesButton_Click(object sender, EventArgs e)
        {
            hideEmployeeSubMenu();
            showEmployeesPanel.Visible = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            hideEmployeeSubMenu();
            editEmployeesPanel.Visible = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            hideEmployeeSubMenu();
            promotionEmployeePanel.Visible = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            hideEmployeeSubMenu();
        }
        private void clearCre()
        {
            lastNameTB.Text = "";
            firstNameTB.Text = "";
            middleNameTB.Text = "";
            addressTB.Text = "";
            contactNoTB.Text = "";
            emailTB.Text = "";

        }


        private void saveButton_Click(object sender, EventArgs e)
        {
            if (lastNameTB.Text != "" &&
                firstNameTB.Text != "" &&
                middleNameTB.Text != "" &&
                addressTB.Text != "" &&
                contactNoTB.Text != "" &&
                emailTB.Text != "" &&
                positionCB.Text != "" &&
                pictureBox2.Image != null)
            {
                if (positionCB.Text.Equals("Employee"))
                {
                    Employee emp = new Employee();
                    emp.LastName = lastNameTB.Text;
                    emp.FirstName = firstNameTB.Text;
                    emp.MiddleName = middleNameTB.Text;
                    emp.Address = addressTB.Text;
                    emp.ContactNum = long.Parse(contactNoTB.Text);
                    emp.Email = emailTB.Text;
                    repo.AddEmployee(emp);
                    repo.SavePictureToProject(repo.getEmployeeID(emp.UserName), currentImage);

                    string activity = "Add Employee";
                    string logDetails = $"Added Employee: {emp.FirstName} {emp.LastName} \nUsername: {emp.UserName} \nStatus: {emp.Status}";
                    repo.AddLog(repo.getAdminID(userName), activity, logDetails);

                    clearCre();

                }
                else if (positionCB.Text.Equals("Accountant"))
                {
                    Accountant acc = new Accountant();
                    acc.LastName = lastNameTB.Text;
                    acc.FirstName = firstNameTB.Text;
                    acc.MiddleName = middleNameTB.Text;
                    acc.Address = addressTB.Text;
                    acc.ContactNum = long.Parse(contactNoTB.Text);
                    acc.Email = emailTB.Text;
                    repo.AddAccountant(acc);
                    repo.SavePictureToProject(repo.getAccountantID(acc.UserName), currentImage);

                    string activity = "Add Accountant";
                    string logDetails = $"Added Accountant: {acc.FirstName} {acc.LastName} \nUsername: {acc.UserName} \nStatus: {acc.Status}";
                    repo.AddLog(repo.getAdminID(userName), activity, logDetails);

                    clearCre();
                }
            }
            else
            {
                MessageBox.Show("Please fill in all fields");
            }
        }



        private void cancelButton_Click(object sender, EventArgs e)
        {
            hideEmployeeSubMenu();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            hideEmployeeSubMenu();
            showEmployeesPanel.Visible = true;
        }

        private void LoadEmployeeProfile()
        {
            try
            {
                DataRow hrData = repo.GetHRProfileData(currentUserName);

                if (hrData != null)
                {
                    currentEmployeeID = hrData["employeeID"].ToString();

                    employeeProfileIDLabel.Text = hrData["employeeID"].ToString();
                    employeeProfileNameLabel.Text = $"{hrData["firstName"]} {hrData["middleName"]} {hrData["lastName"]}";
                    welcomeLabelAdmin.Text = $"{hrData["employeeID"]}";
                    welcomeLabelAdmin.AutoSize = false;
                    welcomeLabelAdmin.TextAlign = ContentAlignment.MiddleCenter;

                    employeeProfileUserIDLabel.Text = hrData["userName"].ToString();

                    actualPassword = hrData["password"].ToString();
                    employeeProfilePasswordTB.Text = "Hidden";
                    employeeProfilePasswordTB.ReadOnly = true;

                    employeeEmailLabel.Text = hrData["email"].ToString();
                    employeeContactLabel.Text = hrData["contactNum"].ToString();
                    employeeAddressLabel.Text = hrData["address"].ToString();

                    employeeProfilePositionLabel.Text = "Human Resources";
                    employeeProfileDepartmentLabel.Text = "HR Department";
                    employeeTypeLabel.Text = "Human Resources";

                    employeTinLabel.Text = "None";
                    employeeSSSLabel.Text = "None";
                    label22.Text = "None";
                    label21.Text = "None";

                    repo.LoadPicture(currentEmployeeID, pictureBox1);
                    pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                }
                else
                {
                    MessageBox.Show("HR profile not found.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading HR profile: " + ex.Message);
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

        private void changePasswordButton_Click(object sender, EventArgs e)
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

        // Event handlers for attendance search
        private void attendanceSearchTB_TextChanged(object sender, EventArgs e)
        {
            // Only search when user stops typing (implement debounce if needed)
            // For now, search on every change
            if (attendanceSearchTB.Text != "Search by Employee ID, Name, or Date (MM/dd/yyyy)")
            {
                SearchAttendance();
            }
        }

        private void attendanceSearchTB_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Search when Enter is pressed
            if (e.KeyChar == (char)Keys.Enter)
            {
                SearchAttendance();
                e.Handled = true; // Prevent beep sound
            }
        }

        private void cmbFilterStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            SearchAttendance();
        }

        private void HumanResourcesForm_Load(object sender, EventArgs e)
        {
            // Load initial attendance data
            LoadAllAttendance();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dlg = new OpenFileDialog())
            {
                dlg.Filter = "Image Files | *.jpg; *.png; *.jpeg";

                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    Image img = Image.FromFile(dlg.FileName);

                    pictureBox2.Image = img;
                    currentImage = img;

                }
            }
        }
    }
}
