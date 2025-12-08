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

        public HumanResourcesForm(LoginForm login, string name)
        {
            InitializeComponent();
            this.userName = name;
            repo = new Repository();
            initializeItems();
            this.login = login;
            dashboardPanel.Visible = true;
        }

        private void initializeItems()
        {
            ID = repo.getHRID(userName);
            welcomeLabelAdmin.Text = "HR ID: " + ID;
            hideAllPanels();
            hideEmployeeSubMenu();
        }

        private void HumanResourcesForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
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
    }
}
