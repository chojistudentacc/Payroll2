namespace Payroll
{
    partial class EmployeeForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            timer1 = new System.Windows.Forms.Timer(components);
            panel2 = new Panel();
            profileButton = new Button();
            payslipButton = new Button();
            leavesButton = new Button();
            attendanceButt = new Button();
            dashboardButt = new Button();
            employeeName = new Label();
            label1 = new Label();
            panel1 = new Panel();
            panel5 = new Panel();
            label21 = new Label();
            label22 = new Label();
            employeeSSSLabel = new Label();
            employeTinLabel = new Label();
            label26 = new Label();
            label27 = new Label();
            label28 = new Label();
            label29 = new Label();
            panel4 = new Panel();
            employeeAddressLabel = new Label();
            employeeEmailLabel = new Label();
            employeeContactLabel = new Label();
            label10 = new Label();
            employeeTypeLabel = new Label();
            label14 = new Label();
            label15 = new Label();
            label19 = new Label();
            panel3 = new Panel();
            employeeProfileUserIDLabel = new Label();
            employeeProfilePasswordTB = new TextBox();
            employeeProfileDepartmentLabel = new Label();
            employeeProfilePositionLabel = new Label();
            employeeProfileNameLabel = new Label();
            employeeProfileIDLabel = new Label();
            changePasswordButton = new Button();
            showPasswordButton = new Button();
            label9 = new Label();
            label8 = new Label();
            label7 = new Label();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            pictureBox1 = new PictureBox();
            label3 = new Label();
            panel8 = new Panel();
            label2 = new Label();
            panel = new Panel();
            panel10 = new Panel();
            panel6 = new Panel();
            panel12 = new Panel();
            label16 = new Label();
            panel11 = new Panel();
            label13 = new Label();
            panel9 = new Panel();
            label12 = new Label();
            panel7 = new Panel();
            label11 = new Label();
            profilePanel = new Panel();
            dashboardPanel = new Panel();
            panel13 = new Panel();
            label24 = new Label();
            label17 = new Label();
            attendancePanel = new Panel();
            panel14 = new Panel();
            logDataGridView = new DataGridView();
            label25 = new Label();
            button2 = new Button();
            button1 = new Button();
            panel15 = new Panel();
            label20 = new Label();
            leavePanel = new Panel();
            alabel = new Label();
            payslipPanel = new Panel();
            label23 = new Label();
            panel2.SuspendLayout();
            panel1.SuspendLayout();
            panel5.SuspendLayout();
            panel4.SuspendLayout();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel.SuspendLayout();
            panel6.SuspendLayout();
            panel12.SuspendLayout();
            panel11.SuspendLayout();
            panel9.SuspendLayout();
            panel7.SuspendLayout();
            profilePanel.SuspendLayout();
            dashboardPanel.SuspendLayout();
            panel13.SuspendLayout();
            attendancePanel.SuspendLayout();
            panel14.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)logDataGridView).BeginInit();
            leavePanel.SuspendLayout();
            payslipPanel.SuspendLayout();
            SuspendLayout();
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(51, 55, 64);
            panel2.BackgroundImage = Properties.Resources.PanelBG;
            panel2.Controls.Add(profileButton);
            panel2.Controls.Add(payslipButton);
            panel2.Controls.Add(leavesButton);
            panel2.Controls.Add(attendanceButt);
            panel2.Controls.Add(dashboardButt);
            panel2.Controls.Add(employeeName);
            panel2.Controls.Add(label1);
            panel2.Dock = DockStyle.Left;
            panel2.Location = new Point(0, 0);
            panel2.Margin = new Padding(6);
            panel2.Name = "panel2";
            panel2.Size = new Size(507, 1751);
            panel2.TabIndex = 1;
            // 
            // profileButton
            // 
            profileButton.BackColor = Color.FromArgb(163, 47, 54);
            profileButton.FlatAppearance.BorderSize = 0;
            profileButton.FlatAppearance.MouseDownBackColor = Color.Black;
            profileButton.FlatAppearance.MouseOverBackColor = Color.Black;
            profileButton.FlatStyle = FlatStyle.Flat;
            profileButton.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            profileButton.ForeColor = Color.White;
            profileButton.Location = new Point(0, 1020);
            profileButton.Margin = new Padding(6);
            profileButton.Name = "profileButton";
            profileButton.Size = new Size(507, 158);
            profileButton.TabIndex = 10;
            profileButton.Text = "My Profile";
            profileButton.UseVisualStyleBackColor = false;
            profileButton.Click += profileButton_Click;
            // 
            // payslipButton
            // 
            payslipButton.BackColor = Color.FromArgb(163, 47, 54);
            payslipButton.FlatAppearance.BorderSize = 0;
            payslipButton.FlatAppearance.MouseDownBackColor = Color.Black;
            payslipButton.FlatAppearance.MouseOverBackColor = Color.Black;
            payslipButton.FlatStyle = FlatStyle.Flat;
            payslipButton.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            payslipButton.ForeColor = Color.White;
            payslipButton.Location = new Point(0, 862);
            payslipButton.Margin = new Padding(6);
            payslipButton.Name = "payslipButton";
            payslipButton.Size = new Size(507, 158);
            payslipButton.TabIndex = 9;
            payslipButton.Text = "Payslips";
            payslipButton.UseVisualStyleBackColor = false;
            payslipButton.Click += payslipButton_Click_1;
            // 
            // leavesButton
            // 
            leavesButton.BackColor = Color.FromArgb(163, 47, 54);
            leavesButton.FlatAppearance.BorderSize = 0;
            leavesButton.FlatAppearance.MouseDownBackColor = Color.Black;
            leavesButton.FlatAppearance.MouseOverBackColor = Color.Black;
            leavesButton.FlatStyle = FlatStyle.Flat;
            leavesButton.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            leavesButton.ForeColor = Color.White;
            leavesButton.Location = new Point(0, 704);
            leavesButton.Margin = new Padding(6);
            leavesButton.Name = "leavesButton";
            leavesButton.Size = new Size(507, 158);
            leavesButton.TabIndex = 8;
            leavesButton.Text = "Leaves";
            leavesButton.UseVisualStyleBackColor = false;
            leavesButton.Click += leavesButton_Click;
            // 
            // attendanceButt
            // 
            attendanceButt.BackColor = Color.FromArgb(163, 47, 54);
            attendanceButt.FlatAppearance.BorderSize = 0;
            attendanceButt.FlatAppearance.MouseDownBackColor = Color.Black;
            attendanceButt.FlatAppearance.MouseOverBackColor = Color.Black;
            attendanceButt.FlatStyle = FlatStyle.Flat;
            attendanceButt.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            attendanceButt.ForeColor = Color.White;
            attendanceButt.Location = new Point(0, 546);
            attendanceButt.Margin = new Padding(6);
            attendanceButt.Name = "attendanceButt";
            attendanceButt.Size = new Size(507, 158);
            attendanceButt.TabIndex = 7;
            attendanceButt.Text = "Attendance";
            attendanceButt.UseVisualStyleBackColor = false;
            attendanceButt.Click += attendanceButt_Click;
            // 
            // dashboardButt
            // 
            dashboardButt.BackColor = Color.FromArgb(163, 47, 54);
            dashboardButt.FlatAppearance.BorderSize = 0;
            dashboardButt.FlatAppearance.MouseDownBackColor = Color.Black;
            dashboardButt.FlatAppearance.MouseOverBackColor = Color.Black;
            dashboardButt.FlatStyle = FlatStyle.Flat;
            dashboardButt.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            dashboardButt.ForeColor = Color.White;
            dashboardButt.Location = new Point(0, 388);
            dashboardButt.Margin = new Padding(6);
            dashboardButt.Name = "dashboardButt";
            dashboardButt.Size = new Size(507, 158);
            dashboardButt.TabIndex = 6;
            dashboardButt.Text = "Dashboard";
            dashboardButt.UseVisualStyleBackColor = false;
            dashboardButt.Click += dashboardButt_Click;
            // 
            // employeeName
            // 
            employeeName.AutoSize = true;
            employeeName.BackColor = Color.Transparent;
            employeeName.Font = new Font("Segoe UI", 14.5F);
            employeeName.ForeColor = Color.White;
            employeeName.Location = new Point(104, 139);
            employeeName.Margin = new Padding(6, 0, 6, 0);
            employeeName.Name = "employeeName";
            employeeName.Size = new Size(293, 52);
            employeeName.TabIndex = 1;
            employeeName.Text = "employeeName";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI", 14.5F);
            label1.ForeColor = Color.White;
            label1.Location = new Point(152, 49);
            label1.Margin = new Padding(6, 0, 6, 0);
            label1.Name = "label1";
            label1.Size = new Size(188, 52);
            label1.TabIndex = 0;
            label1.Text = "Welcome,";
            // 
            // panel1
            // 
            panel1.BackColor = Color.Snow;
            panel1.Controls.Add(panel5);
            panel1.Controls.Add(panel4);
            panel1.Controls.Add(panel3);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(panel8);
            panel1.ForeColor = Color.Black;
            panel1.Location = new Point(24, 61);
            panel1.Margin = new Padding(6);
            panel1.Name = "panel1";
            panel1.Size = new Size(2028, 1649);
            panel1.TabIndex = 2;
            // 
            // panel5
            // 
            panel5.BackColor = Color.White;
            panel5.BorderStyle = BorderStyle.FixedSingle;
            panel5.Controls.Add(label21);
            panel5.Controls.Add(label22);
            panel5.Controls.Add(employeeSSSLabel);
            panel5.Controls.Add(employeTinLabel);
            panel5.Controls.Add(label26);
            panel5.Controls.Add(label27);
            panel5.Controls.Add(label28);
            panel5.Controls.Add(label29);
            panel5.ForeColor = Color.FromArgb(163, 47, 54);
            panel5.Location = new Point(84, 1088);
            panel5.Margin = new Padding(6);
            panel5.Name = "panel5";
            panel5.Size = new Size(1859, 235);
            panel5.TabIndex = 19;
            // 
            // label21
            // 
            label21.AutoSize = true;
            label21.Font = new Font("Segoe UI", 14.25F);
            label21.ForeColor = Color.Black;
            label21.Location = new Point(1528, 134);
            label21.Margin = new Padding(6, 0, 6, 0);
            label21.Name = "label21";
            label21.Size = new Size(114, 51);
            label21.TabIndex = 17;
            label21.Text = "None";
            // 
            // label22
            // 
            label22.AutoSize = true;
            label22.Font = new Font("Segoe UI", 14.25F);
            label22.ForeColor = Color.Black;
            label22.Location = new Point(1528, 47);
            label22.Margin = new Padding(6, 0, 6, 0);
            label22.Name = "label22";
            label22.Size = new Size(114, 51);
            label22.TabIndex = 16;
            label22.Text = "None";
            // 
            // employeeSSSLabel
            // 
            employeeSSSLabel.AutoSize = true;
            employeeSSSLabel.Font = new Font("Segoe UI", 14.25F);
            employeeSSSLabel.ForeColor = Color.Black;
            employeeSSSLabel.Location = new Point(407, 134);
            employeeSSSLabel.Margin = new Padding(6, 0, 6, 0);
            employeeSSSLabel.Name = "employeeSSSLabel";
            employeeSSSLabel.Size = new Size(114, 51);
            employeeSSSLabel.TabIndex = 14;
            employeeSSSLabel.Text = "None";
            // 
            // employeTinLabel
            // 
            employeTinLabel.AutoSize = true;
            employeTinLabel.Font = new Font("Segoe UI", 14.25F);
            employeTinLabel.ForeColor = Color.Black;
            employeTinLabel.Location = new Point(407, 47);
            employeTinLabel.Margin = new Padding(6, 0, 6, 0);
            employeTinLabel.Name = "employeTinLabel";
            employeTinLabel.Size = new Size(114, 51);
            employeTinLabel.TabIndex = 13;
            employeTinLabel.Text = "None";
            // 
            // label26
            // 
            label26.AutoSize = true;
            label26.Font = new Font("Segoe UI", 14.25F);
            label26.ForeColor = Color.Black;
            label26.Location = new Point(1179, 134);
            label26.Margin = new Padding(6, 0, 6, 0);
            label26.Name = "label26";
            label26.Size = new Size(317, 51);
            label26.TabIndex = 9;
            label26.Text = "Pag-Ibig Number:";
            // 
            // label27
            // 
            label27.AutoSize = true;
            label27.Font = new Font("Segoe UI", 14.25F);
            label27.ForeColor = Color.Black;
            label27.Location = new Point(1150, 47);
            label27.Margin = new Padding(6, 0, 6, 0);
            label27.Name = "label27";
            label27.Size = new Size(349, 51);
            label27.TabIndex = 8;
            label27.Text = "PhilHealth Number:";
            // 
            // label28
            // 
            label28.AutoSize = true;
            label28.Font = new Font("Segoe UI", 14.25F);
            label28.ForeColor = Color.Black;
            label28.Location = new Point(43, 134);
            label28.Margin = new Padding(6, 0, 6, 0);
            label28.Name = "label28";
            label28.Size = new Size(238, 51);
            label28.TabIndex = 5;
            label28.Text = "SSS Number:";
            // 
            // label29
            // 
            label29.AutoSize = true;
            label29.Font = new Font("Segoe UI", 14.25F);
            label29.ForeColor = Color.Black;
            label29.Location = new Point(41, 47);
            label29.Margin = new Padding(6, 0, 6, 0);
            label29.Name = "label29";
            label29.Size = new Size(236, 51);
            label29.TabIndex = 4;
            label29.Text = "TIN Number:";
            // 
            // panel4
            // 
            panel4.BackColor = Color.White;
            panel4.BorderStyle = BorderStyle.FixedSingle;
            panel4.Controls.Add(employeeAddressLabel);
            panel4.Controls.Add(employeeEmailLabel);
            panel4.Controls.Add(employeeContactLabel);
            panel4.Controls.Add(label10);
            panel4.Controls.Add(employeeTypeLabel);
            panel4.Controls.Add(label14);
            panel4.Controls.Add(label15);
            panel4.Controls.Add(label19);
            panel4.ForeColor = Color.FromArgb(163, 47, 54);
            panel4.Location = new Point(84, 786);
            panel4.Margin = new Padding(6);
            panel4.Name = "panel4";
            panel4.Size = new Size(1859, 241);
            panel4.TabIndex = 17;
            // 
            // employeeAddressLabel
            // 
            employeeAddressLabel.AutoSize = true;
            employeeAddressLabel.Font = new Font("Segoe UI", 14.25F);
            employeeAddressLabel.ForeColor = Color.Black;
            employeeAddressLabel.Location = new Point(407, 134);
            employeeAddressLabel.Margin = new Padding(6, 0, 6, 0);
            employeeAddressLabel.Name = "employeeAddressLabel";
            employeeAddressLabel.Size = new Size(114, 51);
            employeeAddressLabel.TabIndex = 18;
            employeeAddressLabel.Text = "None";
            // 
            // employeeEmailLabel
            // 
            employeeEmailLabel.AutoSize = true;
            employeeEmailLabel.Font = new Font("Segoe UI", 14.25F);
            employeeEmailLabel.ForeColor = Color.Black;
            employeeEmailLabel.Location = new Point(1529, 134);
            employeeEmailLabel.Margin = new Padding(6, 0, 6, 0);
            employeeEmailLabel.Name = "employeeEmailLabel";
            employeeEmailLabel.Size = new Size(114, 51);
            employeeEmailLabel.TabIndex = 17;
            employeeEmailLabel.Text = "None";
            // 
            // employeeContactLabel
            // 
            employeeContactLabel.AutoSize = true;
            employeeContactLabel.Font = new Font("Segoe UI", 14.25F);
            employeeContactLabel.ForeColor = Color.Black;
            employeeContactLabel.Location = new Point(1529, 47);
            employeeContactLabel.Margin = new Padding(6, 0, 6, 0);
            employeeContactLabel.Name = "employeeContactLabel";
            employeeContactLabel.Size = new Size(114, 51);
            employeeContactLabel.TabIndex = 16;
            employeeContactLabel.Text = "None";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 14.25F);
            label10.ForeColor = Color.Black;
            label10.Location = new Point(158, 137);
            label10.Margin = new Padding(6, 0, 6, 0);
            label10.Name = "label10";
            label10.Size = new Size(164, 51);
            label10.TabIndex = 15;
            label10.Text = "Address:";
            // 
            // employeeTypeLabel
            // 
            employeeTypeLabel.AutoSize = true;
            employeeTypeLabel.Font = new Font("Segoe UI", 14.25F);
            employeeTypeLabel.ForeColor = Color.Black;
            employeeTypeLabel.Location = new Point(407, 47);
            employeeTypeLabel.Margin = new Padding(6, 0, 6, 0);
            employeeTypeLabel.Name = "employeeTypeLabel";
            employeeTypeLabel.Size = new Size(114, 51);
            employeeTypeLabel.TabIndex = 13;
            employeeTypeLabel.Text = "None";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Font = new Font("Segoe UI", 14.25F);
            label14.ForeColor = Color.Black;
            label14.Location = new Point(1233, 137);
            label14.Margin = new Padding(6, 0, 6, 0);
            label14.Name = "label14";
            label14.Size = new Size(263, 51);
            label14.TabIndex = 9;
            label14.Text = "Email Address:";
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Font = new Font("Segoe UI", 14.25F);
            label15.ForeColor = Color.Black;
            label15.Location = new Point(1269, 47);
            label15.Margin = new Padding(6, 0, 6, 0);
            label15.Name = "label15";
            label15.Size = new Size(229, 51);
            label15.TabIndex = 8;
            label15.Text = "Contact No.:";
            // 
            // label19
            // 
            label19.AutoSize = true;
            label19.Font = new Font("Segoe UI", 14.25F);
            label19.ForeColor = Color.Black;
            label19.Location = new Point(41, 47);
            label19.Margin = new Padding(6, 0, 6, 0);
            label19.Name = "label19";
            label19.Size = new Size(281, 51);
            label19.TabIndex = 4;
            label19.Text = "Employee Type:";
            // 
            // panel3
            // 
            panel3.BackColor = Color.White;
            panel3.BorderStyle = BorderStyle.FixedSingle;
            panel3.Controls.Add(employeeProfileUserIDLabel);
            panel3.Controls.Add(employeeProfilePasswordTB);
            panel3.Controls.Add(employeeProfileDepartmentLabel);
            panel3.Controls.Add(employeeProfilePositionLabel);
            panel3.Controls.Add(employeeProfileNameLabel);
            panel3.Controls.Add(employeeProfileIDLabel);
            panel3.Controls.Add(changePasswordButton);
            panel3.Controls.Add(showPasswordButton);
            panel3.Controls.Add(label9);
            panel3.Controls.Add(label8);
            panel3.Controls.Add(label7);
            panel3.Controls.Add(label6);
            panel3.Controls.Add(label5);
            panel3.Controls.Add(label4);
            panel3.Controls.Add(pictureBox1);
            panel3.ForeColor = Color.FromArgb(163, 47, 54);
            panel3.Location = new Point(84, 318);
            panel3.Margin = new Padding(6);
            panel3.Name = "panel3";
            panel3.Size = new Size(1859, 412);
            panel3.TabIndex = 5;
            // 
            // employeeProfileUserIDLabel
            // 
            employeeProfileUserIDLabel.AutoSize = true;
            employeeProfileUserIDLabel.Font = new Font("Segoe UI", 14.25F);
            employeeProfileUserIDLabel.ForeColor = Color.Black;
            employeeProfileUserIDLabel.Location = new Point(1346, 47);
            employeeProfileUserIDLabel.Margin = new Padding(6, 0, 6, 0);
            employeeProfileUserIDLabel.Name = "employeeProfileUserIDLabel";
            employeeProfileUserIDLabel.Size = new Size(114, 51);
            employeeProfileUserIDLabel.TabIndex = 18;
            employeeProfileUserIDLabel.Text = "None";
            // 
            // employeeProfilePasswordTB
            // 
            employeeProfilePasswordTB.Font = new Font("Segoe UI", 14.25F);
            employeeProfilePasswordTB.Location = new Point(1346, 134);
            employeeProfilePasswordTB.Name = "employeeProfilePasswordTB";
            employeeProfilePasswordTB.Size = new Size(424, 58);
            employeeProfilePasswordTB.TabIndex = 17;
            // 
            // employeeProfileDepartmentLabel
            // 
            employeeProfileDepartmentLabel.AutoSize = true;
            employeeProfileDepartmentLabel.Font = new Font("Segoe UI", 14.25F);
            employeeProfileDepartmentLabel.ForeColor = Color.Black;
            employeeProfileDepartmentLabel.Location = new Point(637, 314);
            employeeProfileDepartmentLabel.Margin = new Padding(6, 0, 6, 0);
            employeeProfileDepartmentLabel.Name = "employeeProfileDepartmentLabel";
            employeeProfileDepartmentLabel.Size = new Size(114, 51);
            employeeProfileDepartmentLabel.TabIndex = 16;
            employeeProfileDepartmentLabel.Text = "None";
            // 
            // employeeProfilePositionLabel
            // 
            employeeProfilePositionLabel.AutoSize = true;
            employeeProfilePositionLabel.Font = new Font("Segoe UI", 14.25F);
            employeeProfilePositionLabel.ForeColor = Color.Black;
            employeeProfilePositionLabel.Location = new Point(637, 228);
            employeeProfilePositionLabel.Margin = new Padding(6, 0, 6, 0);
            employeeProfilePositionLabel.Name = "employeeProfilePositionLabel";
            employeeProfilePositionLabel.Size = new Size(114, 51);
            employeeProfilePositionLabel.TabIndex = 15;
            employeeProfilePositionLabel.Text = "None";
            // 
            // employeeProfileNameLabel
            // 
            employeeProfileNameLabel.AutoSize = true;
            employeeProfileNameLabel.Font = new Font("Segoe UI", 14.25F);
            employeeProfileNameLabel.ForeColor = Color.Black;
            employeeProfileNameLabel.Location = new Point(637, 134);
            employeeProfileNameLabel.Margin = new Padding(6, 0, 6, 0);
            employeeProfileNameLabel.Name = "employeeProfileNameLabel";
            employeeProfileNameLabel.Size = new Size(114, 51);
            employeeProfileNameLabel.TabIndex = 14;
            employeeProfileNameLabel.Text = "None";
            // 
            // employeeProfileIDLabel
            // 
            employeeProfileIDLabel.AutoSize = true;
            employeeProfileIDLabel.Font = new Font("Segoe UI", 14.25F);
            employeeProfileIDLabel.ForeColor = Color.Black;
            employeeProfileIDLabel.Location = new Point(637, 58);
            employeeProfileIDLabel.Margin = new Padding(6, 0, 6, 0);
            employeeProfileIDLabel.Name = "employeeProfileIDLabel";
            employeeProfileIDLabel.Size = new Size(114, 51);
            employeeProfileIDLabel.TabIndex = 13;
            employeeProfileIDLabel.Text = "None";
            // 
            // changePasswordButton
            // 
            changePasswordButton.BackColor = Color.FromArgb(163, 47, 54);
            changePasswordButton.FlatAppearance.BorderSize = 0;
            changePasswordButton.FlatAppearance.MouseDownBackColor = Color.Black;
            changePasswordButton.FlatAppearance.MouseOverBackColor = Color.Black;
            changePasswordButton.FlatStyle = FlatStyle.Flat;
            changePasswordButton.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            changePasswordButton.ForeColor = Color.White;
            changePasswordButton.Location = new Point(1567, 218);
            changePasswordButton.Margin = new Padding(6);
            changePasswordButton.Name = "changePasswordButton";
            changePasswordButton.Size = new Size(171, 64);
            changePasswordButton.TabIndex = 12;
            changePasswordButton.Text = "Change";
            changePasswordButton.UseVisualStyleBackColor = false;
            // 
            // showPasswordButton
            // 
            showPasswordButton.BackColor = Color.FromArgb(163, 47, 54);
            showPasswordButton.FlatAppearance.BorderSize = 0;
            showPasswordButton.FlatAppearance.MouseDownBackColor = Color.Black;
            showPasswordButton.FlatAppearance.MouseOverBackColor = Color.Black;
            showPasswordButton.FlatStyle = FlatStyle.Flat;
            showPasswordButton.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            showPasswordButton.ForeColor = Color.White;
            showPasswordButton.Location = new Point(1346, 218);
            showPasswordButton.Margin = new Padding(6);
            showPasswordButton.Name = "showPasswordButton";
            showPasswordButton.Size = new Size(171, 64);
            showPasswordButton.TabIndex = 11;
            showPasswordButton.Text = "Show";
            showPasswordButton.UseVisualStyleBackColor = false;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 14.25F);
            label9.ForeColor = Color.Black;
            label9.Location = new Point(1116, 134);
            label9.Margin = new Padding(6, 0, 6, 0);
            label9.Name = "label9";
            label9.Size = new Size(185, 51);
            label9.TabIndex = 9;
            label9.Text = "Password:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 14.25F);
            label8.ForeColor = Color.Black;
            label8.Location = new Point(1150, 47);
            label8.Margin = new Padding(6, 0, 6, 0);
            label8.Name = "label8";
            label8.Size = new Size(152, 51);
            label8.TabIndex = 8;
            label8.Text = "User ID:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 14.25F);
            label7.ForeColor = Color.Black;
            label7.Location = new Point(299, 314);
            label7.Margin = new Padding(6, 0, 6, 0);
            label7.Name = "label7";
            label7.Size = new Size(232, 51);
            label7.TabIndex = 7;
            label7.Text = "Department:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 14.25F);
            label6.ForeColor = Color.Black;
            label6.Location = new Point(299, 228);
            label6.Margin = new Padding(6, 0, 6, 0);
            label6.Name = "label6";
            label6.Size = new Size(163, 51);
            label6.TabIndex = 6;
            label6.Text = "Position:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 14.25F);
            label5.ForeColor = Color.Black;
            label5.Location = new Point(299, 134);
            label5.Margin = new Padding(6, 0, 6, 0);
            label5.Name = "label5";
            label5.Size = new Size(303, 51);
            label5.TabIndex = 5;
            label5.Text = "Employee Name:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 14.25F);
            label4.ForeColor = Color.Black;
            label4.Location = new Point(299, 47);
            label4.Margin = new Padding(6, 0, 6, 0);
            label4.Name = "label4";
            label4.Size = new Size(240, 51);
            label4.TabIndex = 4;
            label4.Text = "Employee ID:";
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(43, 58);
            pictureBox1.Margin = new Padding(6);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(223, 256);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 25F);
            label3.Location = new Point(903, 194);
            label3.Margin = new Padding(6, 0, 6, 0);
            label3.Name = "label3";
            label3.Size = new Size(226, 89);
            label3.TabIndex = 4;
            label3.Text = "Profile";
            // 
            // panel8
            // 
            panel8.BackgroundImage = Properties.Resources.PanelBG;
            panel8.BackgroundImageLayout = ImageLayout.Stretch;
            panel8.Location = new Point(-2, 2);
            panel8.Margin = new Padding(6);
            panel8.Name = "panel8";
            panel8.Size = new Size(2028, 143);
            panel8.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 14);
            label2.Margin = new Padding(6, 0, 6, 0);
            label2.Name = "label2";
            label2.Size = new Size(140, 32);
            label2.TabIndex = 3;
            label2.Text = "profilePanel";
            // 
            // panel
            // 
            panel.BackColor = Color.Snow;
            panel.Controls.Add(panel10);
            panel.Controls.Add(panel6);
            panel.Location = new Point(42, 61);
            panel.Name = "panel";
            panel.Size = new Size(2028, 777);
            panel.TabIndex = 4;
            // 
            // panel10
            // 
            panel10.BackgroundImage = Properties.Resources.TopPanelBg;
            panel10.BackgroundImageLayout = ImageLayout.Stretch;
            panel10.Location = new Point(0, 2);
            panel10.Margin = new Padding(6);
            panel10.Name = "panel10";
            panel10.Size = new Size(2028, 143);
            panel10.TabIndex = 3;
            // 
            // panel6
            // 
            panel6.BackColor = Color.White;
            panel6.Controls.Add(panel12);
            panel6.Controls.Add(panel11);
            panel6.Controls.Add(panel9);
            panel6.Controls.Add(panel7);
            panel6.Location = new Point(56, 260);
            panel6.Name = "panel6";
            panel6.Size = new Size(1887, 395);
            panel6.TabIndex = 0;
            // 
            // panel12
            // 
            panel12.BackgroundImage = Properties.Resources.PanelBG;
            panel12.Controls.Add(label16);
            panel12.Location = new Point(1511, 88);
            panel12.Name = "panel12";
            panel12.Size = new Size(303, 183);
            panel12.TabIndex = 3;
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.BackColor = Color.Transparent;
            label16.Font = new Font("Segoe UI", 14.25F);
            label16.ForeColor = Color.White;
            label16.Location = new Point(29, 23);
            label16.Name = "label16";
            label16.Size = new Size(256, 51);
            label16.TabIndex = 0;
            label16.Text = "Next Pay Date";
            // 
            // panel11
            // 
            panel11.BackgroundImage = Properties.Resources.PanelBG;
            panel11.Controls.Add(label13);
            panel11.Location = new Point(1045, 88);
            panel11.Name = "panel11";
            panel11.Size = new Size(303, 183);
            panel11.TabIndex = 2;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.BackColor = Color.Transparent;
            label13.Font = new Font("Segoe UI", 14.25F);
            label13.ForeColor = Color.White;
            label13.Location = new Point(85, 23);
            label13.Name = "label13";
            label13.Size = new Size(133, 51);
            label13.TabIndex = 0;
            label13.Text = "Leaves";
            // 
            // panel9
            // 
            panel9.BackgroundImage = Properties.Resources.PanelBG;
            panel9.Controls.Add(label12);
            panel9.Location = new Point(552, 88);
            panel9.Name = "panel9";
            panel9.Size = new Size(303, 183);
            panel9.TabIndex = 1;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.BackColor = Color.Transparent;
            label12.Font = new Font("Segoe UI", 14.25F);
            label12.ForeColor = Color.White;
            label12.Location = new Point(43, 23);
            label12.Name = "label12";
            label12.Size = new Size(216, 51);
            label12.TabIndex = 0;
            label12.Text = "Attendance";
            // 
            // panel7
            // 
            panel7.BackgroundImage = Properties.Resources.PanelBG;
            panel7.Controls.Add(label11);
            panel7.Location = new Point(72, 88);
            panel7.Name = "panel7";
            panel7.Size = new Size(303, 183);
            panel7.TabIndex = 0;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.BackColor = Color.Transparent;
            label11.Font = new Font("Segoe UI", 14.25F);
            label11.ForeColor = Color.White;
            label11.Location = new Point(84, 23);
            label11.Name = "label11";
            label11.Size = new Size(150, 51);
            label11.TabIndex = 0;
            label11.Text = "Net Pay";
            // 
            // profilePanel
            // 
            profilePanel.Controls.Add(label2);
            profilePanel.Controls.Add(panel1);
            profilePanel.Location = new Point(507, 0);
            profilePanel.Name = "profilePanel";
            profilePanel.Size = new Size(2107, 1751);
            profilePanel.TabIndex = 5;
            // 
            // dashboardPanel
            // 
            dashboardPanel.Controls.Add(panel13);
            dashboardPanel.Controls.Add(label17);
            dashboardPanel.Controls.Add(panel);
            dashboardPanel.Location = new Point(507, 0);
            dashboardPanel.Name = "dashboardPanel";
            dashboardPanel.Size = new Size(2107, 1751);
            dashboardPanel.TabIndex = 6;
            // 
            // panel13
            // 
            panel13.BackColor = Color.Snow;
            panel13.Controls.Add(label24);
            panel13.Location = new Point(45, 893);
            panel13.Name = "panel13";
            panel13.Size = new Size(2028, 707);
            panel13.TabIndex = 5;
            // 
            // label24
            // 
            label24.AutoSize = true;
            label24.Font = new Font("Segoe UI", 14.25F);
            label24.Location = new Point(925, 34);
            label24.Margin = new Padding(6, 0, 6, 0);
            label24.Name = "label24";
            label24.Size = new Size(244, 51);
            label24.TabIndex = 6;
            label24.Text = "Latest Payslip";
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Location = new Point(20, 15);
            label17.Margin = new Padding(6, 0, 6, 0);
            label17.Name = "label17";
            label17.Size = new Size(183, 32);
            label17.TabIndex = 5;
            label17.Text = "dashboardPanel";
            // 
            // attendancePanel
            // 
            attendancePanel.Controls.Add(panel14);
            attendancePanel.Controls.Add(label20);
            attendancePanel.Location = new Point(507, 0);
            attendancePanel.Name = "attendancePanel";
            attendancePanel.Size = new Size(2107, 1751);
            attendancePanel.TabIndex = 7;
            // 
            // panel14
            // 
            panel14.BackColor = Color.White;
            panel14.Controls.Add(logDataGridView);
            panel14.Controls.Add(label25);
            panel14.Controls.Add(button2);
            panel14.Controls.Add(button1);
            panel14.Controls.Add(panel15);
            panel14.Location = new Point(30, 81);
            panel14.Name = "panel14";
            panel14.Size = new Size(2025, 1552);
            panel14.TabIndex = 1;
            // 
            // logDataGridView
            // 
            logDataGridView.AllowUserToAddRows = false;
            logDataGridView.AllowUserToDeleteRows = false;
            logDataGridView.AllowUserToResizeColumns = false;
            logDataGridView.AllowUserToResizeRows = false;
            logDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            logDataGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            logDataGridView.BackgroundColor = Color.FromArgb(146, 45, 51);
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(146, 45, 51);
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle1.ForeColor = Color.White;
            dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(179, 79, 84);
            dataGridViewCellStyle1.SelectionForeColor = Color.FromArgb(255, 209, 211);
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            logDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            logDataGridView.ColumnHeadersHeight = 29;
            logDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(146, 45, 51);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(179, 79, 84);
            dataGridViewCellStyle2.SelectionForeColor = Color.FromArgb(255, 209, 211);
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            logDataGridView.DefaultCellStyle = dataGridViewCellStyle2;
            logDataGridView.EnableHeadersVisualStyles = false;
            logDataGridView.GridColor = Color.White;
            logDataGridView.Location = new Point(21, 465);
            logDataGridView.Margin = new Padding(6);
            logDataGridView.Name = "logDataGridView";
            logDataGridView.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = Color.FromArgb(146, 45, 51);
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = Color.White;
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(179, 79, 84);
            dataGridViewCellStyle3.SelectionForeColor = Color.FromArgb(255, 209, 211);
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            logDataGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            logDataGridView.RowHeadersVisible = false;
            logDataGridView.RowHeadersWidth = 51;
            logDataGridView.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            logDataGridView.Size = new Size(1974, 1015);
            logDataGridView.TabIndex = 9;
            // 
            // label25
            // 
            label25.AutoSize = true;
            label25.Font = new Font("Segoe UI", 14.25F);
            label25.Location = new Point(750, 382);
            label25.Name = "label25";
            label25.Size = new Size(216, 51);
            label25.TabIndex = 8;
            label25.Text = "Attendance";
            // 
            // button2
            // 
            button2.BackColor = Color.FromArgb(163, 47, 54);
            button2.FlatAppearance.BorderSize = 0;
            button2.FlatAppearance.MouseDownBackColor = Color.Black;
            button2.FlatAppearance.MouseOverBackColor = Color.Black;
            button2.FlatStyle = FlatStyle.Flat;
            button2.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            button2.ForeColor = Color.White;
            button2.Location = new Point(415, 188);
            button2.Margin = new Padding(6);
            button2.Name = "button2";
            button2.Size = new Size(299, 98);
            button2.TabIndex = 7;
            button2.Text = "Clock Out";
            button2.UseVisualStyleBackColor = false;
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(163, 47, 54);
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatAppearance.MouseDownBackColor = Color.Black;
            button1.FlatAppearance.MouseOverBackColor = Color.Black;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            button1.ForeColor = Color.White;
            button1.Location = new Point(68, 188);
            button1.Margin = new Padding(6);
            button1.Name = "button1";
            button1.Size = new Size(299, 98);
            button1.TabIndex = 6;
            button1.Text = "Clock In";
            button1.UseVisualStyleBackColor = false;
            // 
            // panel15
            // 
            panel15.BackgroundImage = Properties.Resources.TopPanelBg;
            panel15.BackgroundImageLayout = ImageLayout.Stretch;
            panel15.Location = new Point(0, 4);
            panel15.Margin = new Padding(6);
            panel15.Name = "panel15";
            panel15.Size = new Size(2028, 143);
            panel15.TabIndex = 3;
            // 
            // label20
            // 
            label20.AutoSize = true;
            label20.Location = new Point(30, 22);
            label20.Name = "label20";
            label20.Size = new Size(190, 32);
            label20.TabIndex = 0;
            label20.Text = "attendancePanel";
            // 
            // leavePanel
            // 
            leavePanel.Controls.Add(alabel);
            leavePanel.Location = new Point(507, 0);
            leavePanel.Name = "leavePanel";
            leavePanel.Size = new Size(2107, 1751);
            leavePanel.TabIndex = 8;
            // 
            // alabel
            // 
            alabel.AutoSize = true;
            alabel.Location = new Point(27, 29);
            alabel.Name = "alabel";
            alabel.Size = new Size(127, 32);
            alabel.TabIndex = 0;
            alabel.Text = "leavePanel";
            // 
            // payslipPanel
            // 
            payslipPanel.Controls.Add(label23);
            payslipPanel.Location = new Point(507, 0);
            payslipPanel.Name = "payslipPanel";
            payslipPanel.Size = new Size(2107, 1751);
            payslipPanel.TabIndex = 9;
            // 
            // label23
            // 
            label23.AutoSize = true;
            label23.Location = new Point(28, 27);
            label23.Name = "label23";
            label23.Size = new Size(145, 32);
            label23.TabIndex = 0;
            label23.Text = "payslipPanel";
            // 
            // EmployeeForm
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(224, 224, 224);
            ClientSize = new Size(2609, 1751);
            Controls.Add(panel2);
            Controls.Add(profilePanel);
            Controls.Add(payslipPanel);
            Controls.Add(leavePanel);
            Controls.Add(attendancePanel);
            Controls.Add(dashboardPanel);
            Margin = new Padding(6);
            Name = "EmployeeForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "EmployeeForm";
            FormClosed += EmployeeForm_FormClosed;
            Load += EmployeeForm_Load;
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel.ResumeLayout(false);
            panel6.ResumeLayout(false);
            panel12.ResumeLayout(false);
            panel12.PerformLayout();
            panel11.ResumeLayout(false);
            panel11.PerformLayout();
            panel9.ResumeLayout(false);
            panel9.PerformLayout();
            panel7.ResumeLayout(false);
            panel7.PerformLayout();
            profilePanel.ResumeLayout(false);
            profilePanel.PerformLayout();
            dashboardPanel.ResumeLayout(false);
            dashboardPanel.PerformLayout();
            panel13.ResumeLayout(false);
            panel13.PerformLayout();
            attendancePanel.ResumeLayout(false);
            attendancePanel.PerformLayout();
            panel14.ResumeLayout(false);
            panel14.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)logDataGridView).EndInit();
            leavePanel.ResumeLayout(false);
            leavePanel.PerformLayout();
            payslipPanel.ResumeLayout(false);
            payslipPanel.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private System.Windows.Forms.Timer timer1;
        private Panel panel2;
        private Label employeeName;
        private Label label1;
        private Button dashboardButt;
        private Button payslipButton;
        private Button leavesButton;
        private Button attendanceButt;
        private Button profileButton;
        private Panel panel1;
        private Label label2;
        private Panel panel8;
        private Label label3;
        private Panel panel3;
        private Label label4;
        private PictureBox pictureBox1;
        private Label label7;
        private Label label6;
        private Label label5;
        private Button changePasswordButton;
        private Button showPasswordButton;
        private Label label9;
        private Label label8;
        private Label employeeProfileDepartmentLabel;
        private Label employeeProfilePositionLabel;
        private Label employeeProfileNameLabel;
        private Label employeeProfileIDLabel;
        private Panel panel5;
        private Label label21;
        private Label label22;
        private Label employeeSSSLabel;
        private Label employeTinLabel;
        private Label label26;
        private Label label27;
        private Label label28;
        private Label label29;
        private Panel panel4;
        private Label employeeAddressLabel;
        private Label employeeEmailLabel;
        private Label employeeContactLabel;
        private Label label10;
        private Label employeeTypeLabel;
        private Label label14;
        private Label label15;
        private Label label19;
        private Panel panel;
        private Panel panel6;
        private Panel panel10;
        private Panel panel7;
        private Label label11;
        private Panel panel12;
        private Label label16;
        private Panel panel11;
        private Label label13;
        private Panel panel9;
        private Label label12;
        private Panel profilePanel;
        private Panel dashboardPanel;
        private Label label17;
        private Panel attendancePanel;
        private Label label20;
        private Panel leavePanel;
        private Label alabel;
        private Panel payslipPanel;
        private Label label23;
        private Panel panel13;
        private Label label24;
        private Panel panel14;
        private Panel panel15;
        private Label label25;
        private Button button2;
        private Button button1;
        private DataGridView logDataGridView;
        private Label employeeProfileUserIDLabel;
        private TextBox employeeProfilePasswordTB;
    }
}