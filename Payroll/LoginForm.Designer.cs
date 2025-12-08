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
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            exitButt = new Button();
            loginButt = new Button();
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
            // loginButt
            // 
            loginButt.BackColor = Color.Transparent;
            loginButt.BackgroundImage = Properties.Resources.loginButtonImage;
            loginButt.BackgroundImageLayout = ImageLayout.Stretch;
            loginButt.FlatStyle = FlatStyle.Flat;
            loginButt.Font = new Font("Georgia", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            loginButt.ForeColor = Color.White;
            loginButt.Location = new Point(346, 526);
            loginButt.Name = "loginButt";
            loginButt.Size = new Size(220, 57);
            loginButt.TabIndex = 9;
            loginButt.Text = "Login";
            loginButt.UseVisualStyleBackColor = false;
            loginButt.Click += LoginPanel_Click;
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(17, 24, 34);
            BackgroundImage = Properties.Resources.LoginScreen;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1405, 821);
            Controls.Add(loginButt);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(exitButt);
            Controls.Add(label5);
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
        private Label label3;
        private Label label4;
        private Label label5;
        private Button exitButt;
        public TextBox usernameTB;
        public TextBox passwordTB;
        private Button loginButt;
    }
}
