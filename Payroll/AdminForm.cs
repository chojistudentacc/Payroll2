using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Payroll.Models;

namespace Payroll
{
    public partial class AdminForm : Form
    {
        LoginForm login;
        string userName;
        Repository repo;
        ToolTip toolTip;
        private string selectedID = "";
        private string selectedRole = "";
        private string selectedPassword = "";
        private string selectedDepartmentName = "";
        private string originalDepartmentName = "";

        public AdminForm(LoginForm login, string userName)
        {
            InitializeComponent();
            repo = new Repository();
            this.login = login;
            this.userName = userName;
            InitializeSomething();
        }

        private void revertButtonColors()
        {
            dashboardButt.BackColor = Color.FromArgb(163, 47, 54);
            userButt.BackColor = Color.FromArgb(163, 47, 54);
            departmentButt.BackColor = Color.FromArgb(163, 47, 54);
            reportButt.BackColor = Color.FromArgb(163, 47, 54);
            logButt.BackColor = Color.FromArgb(163, 47, 54);

            dashboardButt.BackgroundImage = null;
            userButt.BackgroundImage = null;
            departmentButt.BackgroundImage = null;
            reportButt.BackgroundImage = null;
            logButt.BackgroundImage = null;
        }

        private void InitializeSomething()
        {
            toolTip = new ToolTip();
            toolTip.AutoPopDelay = 5000;
            toolTip.InitialDelay = 500;
            toolTip.ShowAlways = true;

            welcomeLabel.Text = "Welcome, " + repo.getAdminID(userName);
            roleComboBox.Items.Add("Employee");
            roleComboBox.Items.Add("Human Resources");
            roleComboBox.Items.Add("Accountant");
            roleComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            toolTip.SetToolTip(roleComboBox, "Sort by position");

            positionComboBox.Items.Add("Employee");
            positionComboBox.Items.Add("Accountant");
            positionComboBox.Items.Add("Human Resources");
            positionComboBox.DropDownStyle = ComboBoxStyle.DropDownList;

            // reports combo box
            reportsDropDownCB.Items.Add("Inbox");
            reportsDropDownCB.Items.Add("Unread");
            reportsDropDownCB.Items.Add("HR Dept.");
            reportsDropDownCB.Items.Add("Accounting");
            reportsDropDownCB.Items.Add("Drafts");
            reportsDropDownCB.Items.Add("Archive");
            reportsDropDownCB.DropDownStyle = ComboBoxStyle.DropDownList;
            toolTip.SetToolTip(reportsDropDownCB, "Select by category");

            // Date pickers initialization
            dateTimePicker1.Value = DateTime.Today.AddDays(-30); // Default to last 30 days
            dateTimePicker2.Value = DateTime.Today;
            dateTimePicker1.ValueChanged += DateTimePicker_ValueChanged;
            dateTimePicker2.ValueChanged += DateTimePicker_ValueChanged;
            toolTip.SetToolTip(dateTimePicker1, "Start date");
            toolTip.SetToolTip(dateTimePicker2, "End date");

            // labas total employees
            UpdateEmployeeCount();

            // para lumabas agad dashboard
            hideallPanels();
            dashPanel.Visible = true;
        }

        private void DateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            FilterLogsByDateRange();
        }

        private void FilterLogsByDateRange()
        {
            if (dateTimePicker1.Value > dateTimePicker2.Value)
            {
                MessageBox.Show("Start date cannot be after end date.");
                return;
            }

            DataTable filteredLogs = repo.GetLogsByDateRange(dateTimePicker1.Value, dateTimePicker2.Value);
            logDataGridView.DataSource = filteredLogs;
        }

        private void UpdateEmployeeCount()
        {
            allEmpLB.Text = repo.GetTotalEmployeeCount().ToString();
        }

        private void AdminForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            login.Visible = true;
        }

        private void hideallPanels()
        {
            dashPanel.Visible = false;
            userPanel.Visible = false;
            departmentPanel.Visible = false;
            reportsPanel.Visible = false;
            logsPanel.Visible = false;

        }

        private void dashboardButt_Click(object sender, EventArgs e)
        {
            hideallPanels();
            revertButtonColors();
            dashboardButt.BackgroundImage = Properties.Resources.shineImage;
            dashPanel.Visible = true;
            UpdateEmployeeCount();
        }

        private void userButt_Click(object sender, EventArgs e)
        {
            hideallPanels();
            revertButtonColors();
            userButt.BackgroundImage = Properties.Resources.shineImage;
            userPanel.Visible = true;
            roleComboBox.Text = "Employee";
            fillDataGridView();
        }

        private void fillDataGridView()
        {
            if (roleComboBox.Text.Equals("Employee"))
            {
                userDataGridView.DataSource = repo.GetAllEmployee();
            }
            else if (roleComboBox.Text.Equals("Accountant"))
            {
                userDataGridView.DataSource = repo.GetAllAccountant();
            }
            else if (roleComboBox.Text.Equals("Human Resources"))
            {
                userDataGridView.DataSource = repo.GetAllHR();
            }
        }

        private void addEmpButt_Click(object sender, EventArgs e)
        {
            userPanelDataGrid.Visible = false;
            userPanelAdd.Visible = true;
            editEmployeePanel.Visible = false;
        }

        private void roleComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            fillDataGridView();
        }

        private void generateCredetials_Click(object sender, EventArgs e)
        {
            Random rand = new Random();

            string randomUser = "user" + rand.Next(0, 1000000).ToString("D6");
            string randomPass = "pass" + rand.Next(0, 1000000).ToString("D6");

            userNameTB.Text = randomUser;
            passTB.Text = randomPass;
        }

        private void radioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (sender == activeRadioButt && activeRadioButt.Checked)
            {
                inactiveRadioButt.Checked = false;
            }
            else if (sender == inactiveRadioButt && inactiveRadioButt.Checked)
            {
                activeRadioButt.Checked = false;
            }
        }

        private void radioButton_CheckedChanged2(object sender, EventArgs e)
        {
            if (sender == editEmployeeActiveRB && editEmployeeActiveRB.Checked)
            {
                editEmployeeInactiveRB.Checked = false;
            }
            else if (sender == editEmployeeInactiveRB && editEmployeeInactiveRB.Checked)
            {
                editEmployeeActiveRB.Checked = false;
            }
        }

        private void clearButt_Click(object sender, EventArgs e)
        {
            clearCre();
        }

        private void clearCre()
        {
            lastNameTB.Text = "";
            firstNameTB.Text = "";
            middleNameTB.Text = "";
            addressTB.Text = "";
            contactNoTB.Text = "";
            emailTB.Text = "";
            userNameTB.Text = "";
            passTB.Text = "";
            positionComboBox.Text = "";
            activeRadioButt.Checked = false;
            inactiveRadioButt.Checked = false;
        }

        private void saveButt_Click(object sender, EventArgs e)
        {
            if (lastNameTB.Text != "" &&
                firstNameTB.Text != "" &&
                middleNameTB.Text != "" &&
                addressTB.Text != "" &&
                contactNoTB.Text != "" &&
                emailTB.Text != "" &&
                userNameTB.Text != "" &&
                passTB.Text != "" &&
                positionComboBox.Text != "" &&
                (activeRadioButt.Checked || inactiveRadioButt.Checked))
            {
                if (positionComboBox.Text.Equals("Employee"))
                {
                    Employee emp = new Employee();
                    emp.LastName = lastNameTB.Text;
                    emp.FirstName = firstNameTB.Text;
                    emp.MiddleName = middleNameTB.Text;
                    emp.Address = addressTB.Text;
                    emp.ContactNum = long.Parse(contactNoTB.Text);
                    emp.Email = emailTB.Text;
                    emp.UserName = userNameTB.Text;
                    emp.Password = passTB.Text;
                    emp.Status = activeRadioButt.Checked ? "Active" : "Inactive";
                    repo.AddEmployee(emp);

                    string activity = "Add Employee";
                    string logDetails = $"Added Employee: {emp.FirstName} {emp.LastName} \nUsername: {emp.UserName} \nStatus: {emp.Status}";
                    repo.AddLog(repo.getAdminID(userName), activity, logDetails);

                    clearCre();
                    userPanelDataGrid.Visible = true;
                    userPanelAdd.Visible = false;
                    fillDataGridView();
                    UpdateEmployeeCount();
                }
                else if (positionComboBox.Text.Equals("Accountant"))
                {
                    Accountant acc = new Accountant();
                    acc.LastName = lastNameTB.Text;
                    acc.FirstName = firstNameTB.Text;
                    acc.MiddleName = middleNameTB.Text;
                    acc.Address = addressTB.Text;
                    acc.ContactNum = long.Parse(contactNoTB.Text);
                    acc.Email = emailTB.Text;
                    acc.UserName = userNameTB.Text;
                    acc.Password = passTB.Text;
                    acc.Status = activeRadioButt.Checked ? "Active" : "Inactive";
                    repo.AddAccountant(acc);

                    string activity = "Add Accountant";
                    string logDetails = $"Added Accountant: {acc.FirstName} {acc.LastName} \nUsername: {acc.UserName} \nStatus: {acc.Status}";
                    repo.AddLog(repo.getAdminID(userName), activity, logDetails);

                    clearCre();
                    userPanelDataGrid.Visible = true;
                    userPanelAdd.Visible = false;
                    fillDataGridView();
                    UpdateEmployeeCount();
                }
                else if (positionComboBox.Text.Equals("Human Resources"))
                {
                    HumanResources hr = new HumanResources();
                    hr.LastName = lastNameTB.Text;
                    hr.FirstName = firstNameTB.Text;
                    hr.MiddleName = middleNameTB.Text;
                    hr.Address = addressTB.Text;
                    hr.ContactNum = long.Parse(contactNoTB.Text);
                    hr.Email = emailTB.Text;
                    hr.UserName = userNameTB.Text;
                    hr.Password = passTB.Text;
                    hr.Status = activeRadioButt.Checked ? "Active" : "Inactive";
                    repo.addHr(hr);

                    string activity = "Add HR";
                    string logDetails = $"Added HR: {hr.FirstName} {hr.LastName} \nUsername: {hr.UserName} \nStatus: {hr.Status}";
                    repo.AddLog(repo.getAdminID(userName), activity, logDetails);

                    clearCre();
                    userPanelDataGrid.Visible = true;
                    userPanelAdd.Visible = false;
                    fillDataGridView();
                    UpdateEmployeeCount();
                }
            }
            else
            {
                MessageBox.Show("Please fill in all fields and select a status.");
            }
        }

        private void cancelButt_Click(object sender, EventArgs e)
        {
            clearCre();
            userPanelDataGrid.Visible = true;
            userPanelAdd.Visible = false;
            fillDataGridView();
        }

        private void departmentButt_Click(object sender, EventArgs e)
        {
            hideallPanels();
            revertButtonColors();
            departmentButt.BackgroundImage = Properties.Resources.shineImage;

            departmentPanel.Visible = true;
            departmentDataGridPanel.Visible = true;
            departmentAddPanel.Visible = false;
            departmentEditPanel.Visible = false;
            selectedDepartmentName = "";
            LoadDepartmentDataGridView();
        }


        private void LoadDepartmentDataGridView()
        {
            try
            {
                DataTable departments = repo.GetAllDepartments();
                departmentDataGridView.DataSource = departments;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading departments: " + ex.ToString());
            }
        }

        private void addDepartmentButton_Click(object sender, EventArgs e)
        {
            departmentDataGridPanel.Visible = false;
            departmentAddPanel.Visible = true;
            PopulateManagerComboBox();
            ClearDepartmentForm();
        }

        private void PopulateManagerComboBox()
        {
            try
            {
                DataTable hrManagers = repo.GetHRNames();
                cbManager.DataSource = hrManagers;
                cbManager.DisplayMember = "EmployeeName";
                cbManager.ValueMember = "employeeID";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading HR managers: " + ex.ToString());
            }
        }

        private void ClearDepartmentForm()
        {
            departmentNameTB.Text = "";
            departmentDescription.Text = "";
        }

        private void saveDepartmentButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(departmentNameTB.Text) ||
                cbManager.SelectedIndex == -1 ||
                string.IsNullOrWhiteSpace(departmentDescription.Text))
            {
                MessageBox.Show("Please fill in all fields.");
                return;
            }

            string departmentName = departmentNameTB.Text;
            string assignedManager = cbManager.SelectedValue.ToString();
            string managerName = cbManager.Text;
            string description = departmentDescription.Text;

            if (repo.AddDepartment(departmentName, assignedManager, managerName, description))
            {
                string activity = "Add Department";
                string logDetails = $"Added Department: {departmentName} \nManager: {managerName} \nDescription: {description}";
                repo.AddLog(repo.getAdminID(userName), activity, logDetails);

                MessageBox.Show("Department added successfully!");
                ClearDepartmentForm();
                departmentAddPanel.Visible = false;
                departmentDataGridPanel.Visible = true;
                LoadDepartmentDataGridView();
            }
            else
            {
                MessageBox.Show("Failed to add department.");
            }
        }

        private void PopulateEditManagerComboBox()
        {
            try
            {
                DataTable managers = repo.GetAssignedManagers();
                cbEditManager.DataSource = managers;
                cbEditManager.DisplayMember = "EmployeeName";
                cbEditManager.ValueMember = "employeeID";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading assigned managers: " + ex.ToString());
            }
        }

        private void cancelDepartmentButton_Click(object sender, EventArgs e)
        {
            ClearDepartmentForm();
            departmentAddPanel.Visible = false;
            departmentDataGridPanel.Visible = true;
        }

        private void cancelDepartmentEditButton_Click(object sender, EventArgs e)
        {
            departmentEditPanel.Visible = false;
            departmentDataGridPanel.Visible = true;
            selectedDepartmentName = "";
            LoadDepartmentDataGridView();
        }

        private void editDepartmentButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(selectedDepartmentName))
            {
                MessageBox.Show("Please select a department row.");
                return;
            }

            departmentDataGridPanel.Visible = false;
            departmentEditPanel.Visible = true;
            PopulateEditManagerComboBox();
            PopulateEditDepartmentFields();
        }

        private void PopulateEditDepartmentFields()
        {
            try
            {
                if (departmentDataGridView.CurrentRow == null)
                {
                    MessageBox.Show("Error retrieving department data.");
                    return;
                }

                DataGridViewRow row = departmentDataGridView.CurrentRow;

                originalDepartmentName = row.Cells["Department"].Value?.ToString() ?? "";
                departmentNameEditTB.Text = originalDepartmentName;
                departmentEditDescription.Text = row.Cells["description"].Value?.ToString() ?? "";

                string managerID = row.Cells["ManagerID"].Value?.ToString() ?? "";

                if (!string.IsNullOrEmpty(managerID) && cbEditManager.Items.Count > 0)
                {
                    cbEditManager.SelectedValue = managerID;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error populating department fields: " + ex.Message);
            }
        }

        private void searchDataGridTB_TextChanged(object sender, EventArgs e)
        {
            string keyword = searchDataGridTB.Text.Trim();
            string role = roleComboBox.Text;

            if (keyword == "")
            {
                fillDataGridView();
            }
            else
            {
                userDataGridView.DataSource = repo.SearchEmployees(role, keyword);
            }
        }

        private void emptyEditEmployeeTB()
        {
            editEmployeeLastNameTB.Text = "";
            editEmployeeFirstNameTB.Text = "";
            editEmployeeMiddleNameTB.Text = "";
            editEmployeeAdressTB.Text = "";
            editEmployeeContactNoTB.Text = "";
            editEmployeeEmailTB.Text = "";
            editEmployeePasswordTB.Text = "";
            selectedPassword = "";
            selectedRole = "";
            selectedID = "";
        }

        private void editEmployeeButt_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(selectedID))
            {
                MessageBox.Show("No selected row.");
                return;
            }

            userPanelDataGrid.Visible = false;
            userPanelAdd.Visible = false;
            editEmployeePanel.Visible = true;
        }

        private void userDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow row = userDataGridView.Rows[e.RowIndex];

            selectedID = row.Cells["employeeID"].Value.ToString();
            selectedRole = roleComboBox.Text;
            selectedPassword = repo.getPassword(selectedID, selectedRole);
            editEmployeePasswordTB.Text = "Hidden";

            editEmployeeLastNameTB.Text = row.Cells["lastName"].Value.ToString();
            editEmployeeFirstNameTB.Text = row.Cells["firstName"].Value.ToString();
            editEmployeeMiddleNameTB.Text = row.Cells["middleName"].Value.ToString();
            editEmployeeAdressTB.Text = row.Cells["address"].Value.ToString();
            editEmployeeContactNoTB.Text = row.Cells["contactNum"].Value.ToString();
            editEmployeeEmailTB.Text = row.Cells["email"].Value.ToString();
            positionComboBox.Text = selectedRole;

            string status = row.Cells["status"].Value.ToString();
            editEmployeeActiveRB.Checked = (status == "Active");
            editEmployeeInactiveRB.Checked = (status == "Inactive");
        }

        private void editEmployeeResetPasswordButt_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
            "Previous password data will be permanently lost when commited",
            "Are you sure?",
            MessageBoxButtons.YesNo
            );

            if (result == DialogResult.Yes)
            {
                Random rand = new Random();

                string random =
                "pass" +
                rand.Next(0, 10000).ToString("D3");

                selectedPassword = random;
                editEmployeePasswordTB.Text = selectedPassword;
            }
            else if (result == DialogResult.No)
            {

            }
        }

        private void editEmployeeSaveButt_Click(object sender, EventArgs e)
        {
            if (editEmployeeFirstNameTB.Text != "" &&
                editEmployeeLastNameTB.Text != "" &&
                editEmployeeMiddleNameTB.Text != "" &&
                editEmployeeContactNoTB.Text != "" &&
                editEmployeeAdressTB.Text != "" &&
                editEmployeeEmailTB.Text != "" &&
                editEmployeePasswordTB.Text != "" &&
                (editEmployeeActiveRB.Checked || editEmployeeInactiveRB.Checked))
            {
                DialogResult result = MessageBox.Show(
                "Are you sure to commit now?",
                "Are you sure?",
                MessageBoxButtons.YesNo
                );

                if (result == DialogResult.Yes)
                {
                    if (selectedRole.Equals("Employee"))
                    {
                        Employee r = new Employee();
                        r.EmployeeID = selectedID;
                        r.FirstName = editEmployeeFirstNameTB.Text;
                        r.LastName = editEmployeeLastNameTB.Text;
                        r.MiddleName = editEmployeeMiddleNameTB.Text;
                        r.ContactNum = long.Parse(editEmployeeContactNoTB.Text);
                        r.Address = editEmployeeAdressTB.Text;
                        r.Email = editEmployeeEmailTB.Text;
                        r.Password = selectedPassword;
                        r.Status = editEmployeeActiveRB.Checked ? "Active" : "Inactive";
                        repo.UpdateEmployee(r);

                        string activity = "Update Employee";
                        string logDetails = $"Updated Employee: {r.FirstName} {r.LastName} \nEmployee ID: {r.EmployeeID} \nStatus: {r.Status}";
                        repo.AddLog(repo.getAdminID(userName), activity, logDetails);

                        emptyEditEmployeeTB();
                        userPanelDataGrid.Visible = true;
                        editEmployeePanel.Visible = false;
                        fillDataGridView();
                    }
                    else if (selectedRole.Equals("Accountant"))
                    {
                        Accountant r = new Accountant();
                        r.EmployeeID = selectedID;
                        r.FirstName = editEmployeeFirstNameTB.Text;
                        r.LastName = editEmployeeLastNameTB.Text;
                        r.MiddleName = editEmployeeMiddleNameTB.Text;
                        r.ContactNum = long.Parse(editEmployeeContactNoTB.Text);
                        r.Address = editEmployeeAdressTB.Text;
                        r.Email = editEmployeeEmailTB.Text;
                        r.Password = selectedPassword;
                        r.Status = editEmployeeActiveRB.Checked ? "Active" : "Inactive";
                        repo.UpdateAccountant(r);

                        string activity = "Update Accountant";
                        string logDetails = $"Updated Accountant: {r.FirstName} {r.LastName} \nEmployee ID: {r.EmployeeID} \nStatus: {r.Status}";
                        repo.AddLog(repo.getAdminID(userName), activity, logDetails);

                        emptyEditEmployeeTB();
                        userPanelDataGrid.Visible = true;
                        editEmployeePanel.Visible = false;
                        fillDataGridView();
                    }
                    else if (selectedRole.Equals("Human Resources"))
                    {
                        HumanResources r = new HumanResources();
                        r.EmployeeID = selectedID;
                        r.FirstName = editEmployeeFirstNameTB.Text;
                        r.LastName = editEmployeeLastNameTB.Text;
                        r.MiddleName = editEmployeeMiddleNameTB.Text;
                        r.ContactNum = long.Parse(editEmployeeContactNoTB.Text);
                        r.Address = editEmployeeAdressTB.Text;
                        r.Email = editEmployeeEmailTB.Text;
                        r.Password = selectedPassword;
                        r.Status = editEmployeeActiveRB.Checked ? "Active" : "Inactive";
                        repo.UpdateHR(r);

                        string activity = "Update HR";
                        string logDetails = $"Updated HR: {r.FirstName} {r.LastName} \nEmployee ID: {r.EmployeeID} \nStatus: {r.Status}";
                        repo.AddLog(repo.getAdminID(userName), activity, logDetails);

                        emptyEditEmployeeTB();
                        userPanelDataGrid.Visible = true;
                        editEmployeePanel.Visible = false;
                        fillDataGridView();
                    }
                }
                else if (result == DialogResult.No)
                {

                }
            }
            else
            {
                MessageBox.Show("Please fill in all fields and select a status.");
            }
        }

        private void editEmployeeCancelButt_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
            "Cancel edit?",
            "Are you sure?",
             MessageBoxButtons.YesNo
             );
            if (result == DialogResult.Yes)
            {
                emptyEditEmployeeTB();
                userPanelDataGrid.Visible = true;
                editEmployeePanel.Visible = false;
                fillDataGridView();
            }
            else if (result == DialogResult.No)
            {

            }

        }

        private void dropEmployeeButt_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(selectedID))
            {
                MessageBox.Show("Please select an employee.");
                return;
            }

            string status = repo.GetStatus(selectedID, selectedRole);

            if (status != "Inactive")
            {
                MessageBox.Show("Employee can only be dropped if their status is INACTIVE.");
                return;
            }

            DialogResult confirm = MessageBox.Show(
                "This employee will be removed permanently. Continue?",
                "Confirm Drop",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (confirm == DialogResult.No) return;

            DataRowView drv = (DataRowView)userDataGridView.CurrentRow.DataBoundItem;
            DataRow employeeRow = drv.Row;

            string role = roleComboBox.Text;
            string employeeName = $"{employeeRow["firstName"]} {employeeRow["lastName"]}";

            repo.ExportEmployeeToArchive(employeeRow, role);

            if (repo.DropEmployee(selectedID, selectedRole))
            {
                string activity = "Delete Employee";
                string logDetails = $"Deleted {selectedRole}: {employeeName} \nEmployee ID: {selectedID}";
                repo.AddLog(repo.getAdminID(userName), activity, logDetails);

                MessageBox.Show("Employee dropped and archived.");
                fillDataGridView();
                selectedID = "";
            }
            else
            {
                MessageBox.Show("Failed to drop employee.");
            }
        }

        private void departmentDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow row = departmentDataGridView.Rows[e.RowIndex];

            selectedDepartmentName = row.Cells["Department"].Value.ToString();
        }

        private void editDepartmentSaveButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(departmentNameEditTB.Text) ||
                cbEditManager.SelectedIndex == -1 ||
                string.IsNullOrWhiteSpace(departmentEditDescription.Text))
            {
                MessageBox.Show("Please fill in all fields.");
                return;
            }

            string departmentName = departmentNameEditTB.Text.Trim();
            string assignedManager = cbEditManager.SelectedValue?.ToString() ?? "";
            string managerName = cbEditManager.Text.Trim();
            string description = departmentEditDescription.Text.Trim();

            if (repo.UpdateDepartment(originalDepartmentName, departmentName, assignedManager, managerName, description))
            {
                string activity = "Update Department";
                string logDetails = $"Updated Department: {departmentName} \nManager: {managerName} \nDescription: {description}";
                repo.AddLog(repo.getAdminID(userName), activity, logDetails);

                MessageBox.Show("Department updated successfully!");
                departmentEditPanel.Visible = false;
                departmentDataGridPanel.Visible = true;
                selectedDepartmentName = "";
                originalDepartmentName = "";
                LoadDepartmentDataGridView();
            }
            else
            {
                MessageBox.Show("Failed to update department.");
            }
        }

        private void deleteDepartmentButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(selectedDepartmentName))
            {
                MessageBox.Show("Please select a department to delete.");
                return;
            }

            DialogResult confirm = MessageBox.Show(
                $"Are you sure you want to delete the department '{selectedDepartmentName}'? This action cannot be undone.",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (confirm == DialogResult.No) return;

            if (repo.DeleteDepartment(selectedDepartmentName))
            {
                string activity = "Delete Department";
                string logDetails = $"Deleted Department: {selectedDepartmentName}";
                repo.AddLog(repo.getAdminID(userName), activity, logDetails);

                MessageBox.Show("Department deleted successfully!");
                selectedDepartmentName = "";
                LoadDepartmentDataGridView();
            }
            else
            {
                MessageBox.Show("Failed to delete department.");
            }
        }

        private void reportButt_Click(object sender, EventArgs e)
        {
            hideallPanels();
            revertButtonColors();
            reportButt.BackgroundImage = Properties.Resources.shineImage;

            reportsPanel.Visible = true;
            reportsDropDownCB.Text = "Inbox";
            fillReportInboxPanel();
        }

        private void fillReportInboxPanel()
        {
            DataTable inboxData = repo.GetAllEmailData();
            inboxPanel.AutoScroll = true;

            int startY = 16;
            int spacing = 20;
            int boxHeight = 127;
            int boxWidth = 628;

            for (int i = 0; i < inboxData.Rows.Count; i++)
            {
                DataRow row = inboxData.Rows[i];

                string header = row["header"].ToString();
                string body = row["body"].ToString();
                string tail = row["tail"].ToString();
                string sender = row["senderFullName"].ToString();
                string date = Convert.ToDateTime(row["date"]).ToString("MM/dd/yyyy");

                RichTextBox rich = new RichTextBox();
                rich.Size = new Size(boxWidth, boxHeight);
                rich.Location = new Point(14, startY + i * (boxHeight + spacing + 35));
                rich.ReadOnly = true;
                rich.TabStop = false;
                rich.Cursor = Cursors.Default;
                rich.Font = new Font("Segoe UI Semibold", 10f, FontStyle.Bold);
                rich.GotFocus += (s, e) => inboxPanel.Focus();
                rich.Name = $"rich{i + 1}";

                rich.Text = $"{header}\n\nFrom: {sender}";

                inboxPanel.Controls.Add(rich);

                Button viewButton = new Button();
                viewButton.Size = new Size(80, 30);
                viewButton.Location = new Point(rich.Left, rich.Bottom + 5);
                viewButton.Text = "View";
                viewButton.Name = $"btnView{i + 1}";

                viewButton.Click += (senderObj, eObj) =>
                {
                    reportsPanelInbox.Visible = false;
                    reportsPanelViewMessage.Visible = true;
                    viewMessageRichTB.TabStop = false;
                    viewMessageRichTB.Cursor = Cursors.Default;
                    viewMessageRichTB.GotFocus += (s, e) => viewMessagePanel.Focus();

                    string fullMessage =
                        $"📌 {header}\n" +
                        $"From: {sender}\n" +
                        $"Sent: {date}\n\n" +
                        $"{body}\n\n" +
                        $"-- {tail}";

                    viewMessageRichTB.Text = fullMessage;
                };

                inboxPanel.Controls.Add(viewButton);
            }
        }

        private void viewMessageBackButt_Click(object sender, EventArgs e)
        {
            reportsPanelInbox.Visible = true;
            reportsPanelViewMessage.Visible = false;

            viewMessageRichTB.Text = "";
        }

        private void logButt_Click(object sender, EventArgs e)
        {
            hideallPanels();
            revertButtonColors();
            logButt.BackgroundImage = Properties.Resources.shineImage;

            logsPanel.Visible = true;
            dateTimePicker1.Value = DateTime.Today.AddDays(-30);
            dateTimePicker2.Value = DateTime.Today;
            FilterLogsByDateRange();
        }

        
    }
}
