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
            timer1 = new System.Windows.Forms.Timer(components);
            panel2 = new Panel();
            label1 = new Label();
            employeeName = new Label();
            dashboardButt = new Button();
            attendanceButt = new Button();
            payslipButton = new Button();
            leavesButton = new Button();
            profileButton = new Button();
            panel1 = new Panel();
            label2 = new Label();
            panel2.SuspendLayout();
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
            panel2.Name = "panel2";
            panel2.Size = new Size(273, 821);
            panel2.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI", 14.5F);
            label1.ForeColor = Color.White;
            label1.Location = new Point(82, 23);
            label1.Name = "label1";
            label1.Size = new Size(97, 28);
            label1.TabIndex = 0;
            label1.Text = "Welcome,";
            // 
            // employeeName
            // 
            employeeName.AutoSize = true;
            employeeName.BackColor = Color.Transparent;
            employeeName.Font = new Font("Segoe UI", 14.5F);
            employeeName.ForeColor = Color.White;
            employeeName.Location = new Point(56, 65);
            employeeName.Name = "employeeName";
            employeeName.Size = new Size(150, 28);
            employeeName.TabIndex = 1;
            employeeName.Text = "employeeName";
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
            dashboardButt.Location = new Point(0, 182);
            dashboardButt.Name = "dashboardButt";
            dashboardButt.Size = new Size(273, 74);
            dashboardButt.TabIndex = 6;
            dashboardButt.Text = "Dashboard";
            dashboardButt.UseVisualStyleBackColor = false;
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
            attendanceButt.Location = new Point(0, 256);
            attendanceButt.Name = "attendanceButt";
            attendanceButt.Size = new Size(273, 74);
            attendanceButt.TabIndex = 7;
            attendanceButt.Text = "Attendance";
            attendanceButt.UseVisualStyleBackColor = false;
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
            payslipButton.Location = new Point(0, 404);
            payslipButton.Name = "payslipButton";
            payslipButton.Size = new Size(273, 74);
            payslipButton.TabIndex = 9;
            payslipButton.Text = "Payslips";
            payslipButton.UseVisualStyleBackColor = false;
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
            leavesButton.Location = new Point(0, 330);
            leavesButton.Name = "leavesButton";
            leavesButton.Size = new Size(273, 74);
            leavesButton.TabIndex = 8;
            leavesButton.Text = "Leaves";
            leavesButton.UseVisualStyleBackColor = false;
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
            profileButton.Location = new Point(0, 478);
            profileButton.Name = "profileButton";
            profileButton.Size = new Size(273, 74);
            profileButton.TabIndex = 10;
            profileButton.Text = "My Profile";
            profileButton.UseVisualStyleBackColor = false;
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.Location = new Point(289, 23);
            panel1.Name = "panel1";
            panel1.Size = new Size(1092, 771);
            panel1.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(279, 5);
            label2.Name = "label2";
            label2.Size = new Size(70, 15);
            label2.TabIndex = 3;
            label2.Text = "profilePanel";
            // 
            // EmployeeForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(224, 224, 224);
            ClientSize = new Size(1405, 821);
            ControlBox = false;
            Controls.Add(label2);
            Controls.Add(panel1);
            Controls.Add(panel2);
            Name = "EmployeeForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "EmployeeForm";
            Load += EmployeeForm_Load;
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
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
    }
}