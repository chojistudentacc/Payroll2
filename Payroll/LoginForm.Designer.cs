namespace Payroll
{
    partial class LoginForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            usernameTB = new TextBox();
            passwordTB = new TextBox();
            LoginPanel = new Panel();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            exitButt = new Button();
            SuspendLayout();
            // 
            // usernameTB
            // 
            usernameTB.BackColor = Color.White;
            usernameTB.Font = new Font("Times New Roman", 18F);
            usernameTB.ForeColor = Color.Black;
            usernameTB.Location = new Point(236, 363);
            usernameTB.Name = "usernameTB";
            usernameTB.Size = new Size(460, 35);
            usernameTB.TabIndex = 0;
            // 
            // passwordTB
            // 
            passwordTB.BackColor = Color.White;
            passwordTB.Font = new Font("Times New Roman", 18F);
            passwordTB.ForeColor = Color.Black;
            passwordTB.Location = new Point(236, 449);
            passwordTB.Name = "passwordTB";
            passwordTB.PasswordChar = '*';
            passwordTB.Size = new Size(460, 35);
            passwordTB.TabIndex = 1;
            // 
            // LoginPanel
            // 
            LoginPanel.BackColor = Color.FromArgb(230, 231, 232);
            LoginPanel.Location = new Point(358, 537);
            LoginPanel.Margin = new Padding(3, 2, 3, 2);
            LoginPanel.Name = "LoginPanel";
            LoginPanel.Size = new Size(197, 58);
            LoginPanel.TabIndex = 3;
            LoginPanel.Click += LoginPanel_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Georgia", 18F, FontStyle.Bold);
            label3.ForeColor = Color.FromArgb(99, 27, 27);
            label3.Location = new Point(185, 331);
            label3.Name = "label3";
            label3.Size = new Size(149, 29);
            label3.TabIndex = 5;
            label3.Text = "Username:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Transparent;
            label4.Font = new Font("Georgia", 18F, FontStyle.Bold);
            label4.ForeColor = Color.FromArgb(99, 27, 27);
            label4.Location = new Point(185, 417);
            label4.Name = "label4";
            label4.Size = new Size(141, 29);
            label4.TabIndex = 4;
            label4.Text = "Password:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Microsoft Sans Serif", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.White;
            label5.Location = new Point(334, 34);
            label5.Name = "label5";
            label5.Size = new Size(0, 29);
            label5.TabIndex = 6;
            // 
            // exitButt
            // 
            exitButt.Font = new Font("Georgia", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            exitButt.ForeColor = Color.FromArgb(143, 48, 48);
            exitButt.Location = new Point(12, 774);
            exitButt.Name = "exitButt";
            exitButt.Size = new Size(90, 35);
            exitButt.TabIndex = 8;
            exitButt.Text = "Exit";
            exitButt.UseVisualStyleBackColor = true;
            exitButt.Click += exitButt_Click;
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(17, 24, 34);
            BackgroundImage = Properties.Resources.LoginScreen;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1405, 821);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(exitButt);
            Controls.Add(label5);
            Controls.Add(LoginPanel);
            Controls.Add(passwordTB);
            Controls.Add(usernameTB);
            FormBorderStyle = FormBorderStyle.None;
            Name = "LoginForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            Load += LoginForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Panel LoginPanel;
        private Label label3;
        private Label label4;
        private Label label5;
        private Button exitButt;
        public TextBox usernameTB;
        public TextBox passwordTB;
    }
}
