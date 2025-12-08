namespace Payroll
{
    partial class HumanResourcesForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HumanResourcesForm));
            sidePanel = new Panel();
            profileButt = new Button();
            welcomeLabelAdmin = new Label();
            adminPictureBox = new PictureBox();
            archivedButton = new Button();
            reportButt = new Button();
            attendanceButt = new Button();
            dashboardButt = new Button();
            idLabel = new Label();
            requestButt = new Button();
            employeeButt = new Button();
            createpayslipButton = new Button();
            draftButton = new Button();
            dashboardPanel = new Panel();
            attendancePanel = new Panel();
            employeePanel = new Panel();
            requestPanel = new Panel();
            reportPanel = new Panel();
            archivedPanel = new Panel();
            profilePanel = new Panel();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label33 = new Label();
            s = new Label();
            label7 = new Label();
            sidePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)adminPictureBox).BeginInit();
            dashboardPanel.SuspendLayout();
            attendancePanel.SuspendLayout();
            employeePanel.SuspendLayout();
            requestPanel.SuspendLayout();
            reportPanel.SuspendLayout();
            archivedPanel.SuspendLayout();
            profilePanel.SuspendLayout();
            SuspendLayout();
            // 
            // sidePanel
            // 
            sidePanel.BackColor = Color.FromArgb(51, 55, 64);
            sidePanel.BackgroundImage = Properties.Resources.PanelBG;
            sidePanel.BackgroundImageLayout = ImageLayout.Stretch;
            sidePanel.Controls.Add(profileButt);
            sidePanel.Controls.Add(welcomeLabelAdmin);
            sidePanel.Controls.Add(adminPictureBox);
            sidePanel.Controls.Add(archivedButton);
            sidePanel.Controls.Add(reportButt);
            sidePanel.Controls.Add(attendanceButt);
            sidePanel.Controls.Add(dashboardButt);
            sidePanel.Controls.Add(idLabel);
            sidePanel.Controls.Add(requestButt);
            sidePanel.Controls.Add(employeeButt);
            sidePanel.Controls.Add(createpayslipButton);
            sidePanel.Controls.Add(draftButton);
            sidePanel.Dock = DockStyle.Left;
            sidePanel.Location = new Point(0, 0);
            sidePanel.Name = "sidePanel";
            sidePanel.Size = new Size(273, 782);
            sidePanel.TabIndex = 5;
            // 
            // profileButt
            // 
            profileButt.BackColor = Color.FromArgb(163, 47, 54);
            profileButt.BackgroundImage = (Image)resources.GetObject("profileButt.BackgroundImage");
            profileButt.BackgroundImageLayout = ImageLayout.Stretch;
            profileButt.FlatAppearance.BorderSize = 0;
            profileButt.FlatStyle = FlatStyle.Flat;
            profileButt.Font = new Font("Georgia", 15.75F, FontStyle.Bold);
            profileButt.ForeColor = Color.White;
            profileButt.Location = new Point(0, 616);
            profileButt.Name = "profileButt";
            profileButt.Size = new Size(273, 74);
            profileButt.TabIndex = 14;
            profileButt.Text = "My Profile";
            profileButt.UseVisualStyleBackColor = false;
            // 
            // welcomeLabelAdmin
            // 
            welcomeLabelAdmin.AutoSize = true;
            welcomeLabelAdmin.BackColor = Color.Transparent;
            welcomeLabelAdmin.Font = new Font("Georgia", 15.75F, FontStyle.Italic, GraphicsUnit.Point, 0);
            welcomeLabelAdmin.ForeColor = Color.White;
            welcomeLabelAdmin.Location = new Point(150, 69);
            welcomeLabelAdmin.Name = "welcomeLabelAdmin";
            welcomeLabelAdmin.Size = new Size(80, 25);
            welcomeLabelAdmin.TabIndex = 13;
            welcomeLabelAdmin.Text = "(name)";
            // 
            // adminPictureBox
            // 
            adminPictureBox.BackColor = Color.White;
            adminPictureBox.BackgroundImageLayout = ImageLayout.Stretch;
            adminPictureBox.Location = new Point(12, 26);
            adminPictureBox.Name = "adminPictureBox";
            adminPictureBox.Size = new Size(107, 93);
            adminPictureBox.TabIndex = 11;
            adminPictureBox.TabStop = false;
            // 
            // archivedButton
            // 
            archivedButton.BackColor = Color.FromArgb(163, 47, 54);
            archivedButton.BackgroundImage = (Image)resources.GetObject("archivedButton.BackgroundImage");
            archivedButton.BackgroundImageLayout = ImageLayout.Stretch;
            archivedButton.FlatAppearance.BorderSize = 0;
            archivedButton.FlatStyle = FlatStyle.Flat;
            archivedButton.Font = new Font("Georgia", 15.75F, FontStyle.Bold);
            archivedButton.ForeColor = Color.White;
            archivedButton.Location = new Point(0, 542);
            archivedButton.Name = "archivedButton";
            archivedButton.Size = new Size(273, 74);
            archivedButton.TabIndex = 7;
            archivedButton.Text = "Archived";
            archivedButton.UseVisualStyleBackColor = false;
            // 
            // reportButt
            // 
            reportButt.BackColor = Color.FromArgb(163, 47, 54);
            reportButt.BackgroundImage = (Image)resources.GetObject("reportButt.BackgroundImage");
            reportButt.BackgroundImageLayout = ImageLayout.Stretch;
            reportButt.FlatAppearance.BorderSize = 0;
            reportButt.FlatStyle = FlatStyle.Flat;
            reportButt.Font = new Font("Georgia", 15.75F, FontStyle.Bold);
            reportButt.ForeColor = Color.White;
            reportButt.Location = new Point(0, 468);
            reportButt.Name = "reportButt";
            reportButt.Size = new Size(273, 74);
            reportButt.TabIndex = 6;
            reportButt.Text = "Reports";
            reportButt.UseVisualStyleBackColor = false;
            // 
            // attendanceButt
            // 
            attendanceButt.BackColor = Color.FromArgb(163, 47, 54);
            attendanceButt.BackgroundImage = (Image)resources.GetObject("attendanceButt.BackgroundImage");
            attendanceButt.BackgroundImageLayout = ImageLayout.Stretch;
            attendanceButt.FlatAppearance.BorderSize = 0;
            attendanceButt.FlatStyle = FlatStyle.Flat;
            attendanceButt.Font = new Font("Georgia", 15.75F, FontStyle.Bold);
            attendanceButt.ForeColor = Color.White;
            attendanceButt.Location = new Point(0, 321);
            attendanceButt.Name = "attendanceButt";
            attendanceButt.Size = new Size(273, 74);
            attendanceButt.TabIndex = 5;
            attendanceButt.Text = "Attendance";
            attendanceButt.UseVisualStyleBackColor = false;
            // 
            // dashboardButt
            // 
            dashboardButt.BackColor = Color.FromArgb(163, 47, 54);
            dashboardButt.BackgroundImage = (Image)resources.GetObject("dashboardButt.BackgroundImage");
            dashboardButt.BackgroundImageLayout = ImageLayout.Stretch;
            dashboardButt.FlatAppearance.BorderSize = 0;
            dashboardButt.FlatStyle = FlatStyle.Flat;
            dashboardButt.Font = new Font("Georgia", 15.75F, FontStyle.Bold);
            dashboardButt.ForeColor = Color.White;
            dashboardButt.Location = new Point(0, 176);
            dashboardButt.Name = "dashboardButt";
            dashboardButt.Size = new Size(273, 74);
            dashboardButt.TabIndex = 4;
            dashboardButt.Text = "Dashboard";
            dashboardButt.UseVisualStyleBackColor = false;
            // 
            // idLabel
            // 
            idLabel.AutoSize = true;
            idLabel.BackColor = Color.Transparent;
            idLabel.Font = new Font("Georgia", 18F, FontStyle.Bold | FontStyle.Italic);
            idLabel.ForeColor = Color.White;
            idLabel.Location = new Point(125, 35);
            idLabel.Name = "idLabel";
            idLabel.Size = new Size(135, 29);
            idLabel.TabIndex = 0;
            idLabel.Text = "Welcome,";
            // 
            // requestButt
            // 
            requestButt.BackColor = Color.FromArgb(163, 47, 54);
            requestButt.BackgroundImage = (Image)resources.GetObject("requestButt.BackgroundImage");
            requestButt.BackgroundImageLayout = ImageLayout.Stretch;
            requestButt.FlatAppearance.BorderSize = 0;
            requestButt.FlatStyle = FlatStyle.Flat;
            requestButt.Font = new Font("Georgia", 15.75F, FontStyle.Bold);
            requestButt.ForeColor = Color.White;
            requestButt.Location = new Point(0, 395);
            requestButt.Name = "requestButt";
            requestButt.Size = new Size(273, 74);
            requestButt.TabIndex = 3;
            requestButt.Text = "Requests";
            requestButt.UseVisualStyleBackColor = false;
            // 
            // employeeButt
            // 
            employeeButt.BackColor = Color.FromArgb(163, 47, 54);
            employeeButt.BackgroundImage = (Image)resources.GetObject("employeeButt.BackgroundImage");
            employeeButt.BackgroundImageLayout = ImageLayout.Stretch;
            employeeButt.FlatAppearance.BorderSize = 0;
            employeeButt.FlatStyle = FlatStyle.Flat;
            employeeButt.Font = new Font("Georgia", 15.75F, FontStyle.Bold);
            employeeButt.ForeColor = Color.White;
            employeeButt.Location = new Point(0, 250);
            employeeButt.Name = "employeeButt";
            employeeButt.Size = new Size(273, 74);
            employeeButt.TabIndex = 2;
            employeeButt.Text = "Employee";
            employeeButt.UseVisualStyleBackColor = false;
            // 
            // createpayslipButton
            // 
            createpayslipButton.BackColor = Color.FromArgb(163, 47, 54);
            createpayslipButton.FlatAppearance.BorderSize = 0;
            createpayslipButton.FlatStyle = FlatStyle.Flat;
            createpayslipButton.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            createpayslipButton.ForeColor = Color.White;
            createpayslipButton.Location = new Point(0, 323);
            createpayslipButton.Name = "createpayslipButton";
            createpayslipButton.Size = new Size(273, 57);
            createpayslipButton.TabIndex = 9;
            createpayslipButton.Text = "Create";
            createpayslipButton.UseVisualStyleBackColor = false;
            // 
            // draftButton
            // 
            draftButton.BackColor = Color.FromArgb(163, 47, 54);
            draftButton.FlatAppearance.BorderSize = 0;
            draftButton.FlatStyle = FlatStyle.Flat;
            draftButton.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            draftButton.ForeColor = Color.White;
            draftButton.Location = new Point(0, 380);
            draftButton.Name = "draftButton";
            draftButton.Size = new Size(273, 57);
            draftButton.TabIndex = 10;
            draftButton.Text = "Draft";
            draftButton.UseVisualStyleBackColor = false;
            // 
            // dashboardPanel
            // 
            dashboardPanel.Controls.Add(label1);
            dashboardPanel.Location = new Point(274, 0);
            dashboardPanel.Name = "dashboardPanel";
            dashboardPanel.Size = new Size(1117, 782);
            dashboardPanel.TabIndex = 6;
            // 
            // attendancePanel
            // 
            attendancePanel.Controls.Add(label3);
            attendancePanel.Location = new Point(274, 0);
            attendancePanel.Name = "attendancePanel";
            attendancePanel.Size = new Size(1117, 782);
            attendancePanel.TabIndex = 7;
            // 
            // employeePanel
            // 
            employeePanel.Controls.Add(label2);
            employeePanel.Location = new Point(274, 0);
            employeePanel.Name = "employeePanel";
            employeePanel.Size = new Size(1117, 782);
            employeePanel.TabIndex = 8;
            // 
            // requestPanel
            // 
            requestPanel.Controls.Add(label4);
            requestPanel.Location = new Point(274, 0);
            requestPanel.Name = "requestPanel";
            requestPanel.Size = new Size(1117, 782);
            requestPanel.TabIndex = 9;
            // 
            // reportPanel
            // 
            reportPanel.Controls.Add(label33);
            reportPanel.Location = new Point(274, 0);
            reportPanel.Name = "reportPanel";
            reportPanel.Size = new Size(1117, 782);
            reportPanel.TabIndex = 10;
            // 
            // archivedPanel
            // 
            archivedPanel.Controls.Add(s);
            archivedPanel.Location = new Point(274, 0);
            archivedPanel.Name = "archivedPanel";
            archivedPanel.Size = new Size(1117, 782);
            archivedPanel.TabIndex = 9;
            // 
            // profilePanel
            // 
            profilePanel.Controls.Add(label7);
            profilePanel.Location = new Point(274, 0);
            profilePanel.Name = "profilePanel";
            profilePanel.Size = new Size(1117, 782);
            profilePanel.TabIndex = 9;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(3, 10);
            label1.Name = "label1";
            label1.Size = new Size(92, 15);
            label1.TabIndex = 0;
            label1.Text = "dashboardPanel";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(3, 11);
            label2.Name = "label2";
            label2.Size = new Size(88, 15);
            label2.TabIndex = 1;
            label2.Text = "employeePanel";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(3, 2);
            label3.Name = "label3";
            label3.Size = new Size(95, 15);
            label3.TabIndex = 2;
            label3.Text = "attendancePanel";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(3, 8);
            label4.Name = "label4";
            label4.Size = new Size(75, 15);
            label4.TabIndex = 11;
            label4.Text = "requestPanel";
            // 
            // label33
            // 
            label33.AutoSize = true;
            label33.Location = new Point(3, 9);
            label33.Name = "label33";
            label33.Size = new Size(68, 15);
            label33.TabIndex = 12;
            label33.Text = "reportPanel";
            // 
            // s
            // 
            s.AutoSize = true;
            s.Location = new Point(3, 9);
            s.Name = "s";
            s.Size = new Size(81, 15);
            s.TabIndex = 11;
            s.Text = "archivedPanel";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(3, 8);
            label7.Name = "label7";
            label7.Size = new Size(70, 15);
            label7.TabIndex = 11;
            label7.Text = "profilePanel";
            // 
            // HumanResourcesForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(224, 224, 224);
            ClientSize = new Size(1389, 782);
            Controls.Add(profilePanel);
            Controls.Add(archivedPanel);
            Controls.Add(reportPanel);
            Controls.Add(requestPanel);
            Controls.Add(employeePanel);
            Controls.Add(sidePanel);
            Controls.Add(dashboardPanel);
            Controls.Add(attendancePanel);
            Name = "HumanResourcesForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "HumanResourcesForm";
            FormClosed += HumanResourcesForm_FormClosed;
            sidePanel.ResumeLayout(false);
            sidePanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)adminPictureBox).EndInit();
            dashboardPanel.ResumeLayout(false);
            dashboardPanel.PerformLayout();
            attendancePanel.ResumeLayout(false);
            attendancePanel.PerformLayout();
            employeePanel.ResumeLayout(false);
            employeePanel.PerformLayout();
            requestPanel.ResumeLayout(false);
            requestPanel.PerformLayout();
            reportPanel.ResumeLayout(false);
            reportPanel.PerformLayout();
            archivedPanel.ResumeLayout(false);
            archivedPanel.PerformLayout();
            profilePanel.ResumeLayout(false);
            profilePanel.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel sidePanel;
        private Button profileButt;
        private Label welcomeLabelAdmin;
        public PictureBox adminPictureBox;
        private Button archivedButton;
        private Button reportButt;
        private Button attendanceButt;
        private Button dashboardButt;
        private Label idLabel;
        private Button requestButt;
        private Button employeeButt;
        private Button createpayslipButton;
        private Button draftButton;
        private Panel dashboardPanel;
        private Label label1;
        private Panel attendancePanel;
        private Panel employeePanel;
        private Label label2;
        private Panel requestPanel;
        private Panel reportPanel;
        private Panel archivedPanel;
        private Panel profilePanel;
        private Label label3;
        private Label label4;
        private Label label33;
        private Label s;
        private Label label7;
    }
}