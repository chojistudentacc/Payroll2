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

            SetupFilterControls();
        }

        private void SetupFilterControls()
        {
            // Setup Combo Box
            cmbFilterStatus.Items.Clear();
            cmbFilterStatus.Items.Add("All");
            cmbFilterStatus.Items.Add("Present");
            cmbFilterStatus.Items.Add("Late");
            cmbFilterStatus.Items.Add("Overtime");
            cmbFilterStatus.Items.Add("Undertime");
            cmbFilterStatus.Items.Add("Absent");
            cmbFilterStatus.SelectedIndex = 0; // Default to All

            // FIX 3: Set the TextBox to Today's date immediately
            textBox29.Text = DateTime.Now.ToString("MM/dd/yyyy");
        }

        private void FormatDataGridView()
        {
            // 1. Check if there is data to format
            if (userDataGridView.DataSource == null) return;

            // 2. STYLE: Match the red/brown theme from the screenshot
            userDataGridView.EnableHeadersVisualStyles = false;
            userDataGridView.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(120, 40, 40); // Dark Red/Brown
            userDataGridView.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            userDataGridView.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            userDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // 3. RENAME COLUMNS: Change database names to nice headers
            // (Check your database column names and update the text in quotes if needed)

            if (userDataGridView.Columns.Contains("employeeID"))
                userDataGridView.Columns["employeeID"].HeaderText = "Emp ID";

            // Assuming your query returns a combined name or just generic names
            if (userDataGridView.Columns.Contains("firstName"))
                userDataGridView.Columns["firstName"].HeaderText = "Name";
            else if (userDataGridView.Columns.Contains("fullName"))
                userDataGridView.Columns["fullName"].HeaderText = "Name";

            if (userDataGridView.Columns.Contains("timeIn"))
                userDataGridView.Columns["timeIn"].HeaderText = "Clock In";

            if (userDataGridView.Columns.Contains("timeOut"))
                userDataGridView.Columns["timeOut"].HeaderText = "Clock Out";

            if (userDataGridView.Columns.Contains("date"))
                userDataGridView.Columns["date"].HeaderText = "Date";

            if (userDataGridView.Columns.Contains("status"))
                userDataGridView.Columns["status"].HeaderText = "Status";
        }

        private void FilterData()
        {
            string dateInput = textBox29.Text.Trim();
            string statusInput = cmbFilterStatus.SelectedItem != null ? cmbFilterStatus.Text : "All";
            DateTime validDate;

            if (DateTime.TryParse(dateInput, out validDate))
            {
                DataTable dt = repo.GetAttendanceByFilter(validDate, statusInput);

                if (dt != null)
                {
                    userDataGridView.DataSource = dt;
                    FormatDataGridView();
                }
                else
                {
                    userDataGridView.DataSource = null;
                }
            }
            else
            {
                userDataGridView.DataSource = null;
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
            showEmployeesPanel.Visible = false;
            hideEmployeeSubMenu();
            showEmployeesPanel.Visible = true;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            showEmployeesPanel.Visible = false;
            hideEmployeeSubMenu();
            editEmployeesPanel.Visible = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            showEmployeesPanel.Visible = false;
            hideEmployeeSubMenu();
            promotionEmployeePanel.Visible = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            hideEmployeeSubMenu();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            hideEmployeeSubMenu();

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

                    employeeProfileUserIDLabel.Text = hrData["userName"].ToString(); // ✅ Correct column name

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

        private void userPanelDataGrid_Paint(object sender, PaintEventArgs e)
        {

        }

        private void userDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox29_TextChanged(object sender, EventArgs e)
        {
            FilterData();
        }

        private void HumanResourcesForm_Load(object sender, EventArgs e)
        {
            cmbFilterStatus.Items.Clear();
            cmbFilterStatus.Items.Add("All");
            cmbFilterStatus.Items.Add("Present");
            cmbFilterStatus.Items.Add("Late");
            cmbFilterStatus.Items.Add("Overtime");
            cmbFilterStatus.Items.Add("Undertime");
            cmbFilterStatus.Items.Add("Absent");
            cmbFilterStatus.SelectedIndex = 0;


            userDataGridView.Text = DateTime.Now.ToString("MM/dd/yyyy");


            FilterData();

        }

        private void cmbFilterStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            FilterData();
        }

        private void comboBox10_SelectedIndexChanged(object sender, EventArgs e)
        {
            FilterData();
        }
    }
}
