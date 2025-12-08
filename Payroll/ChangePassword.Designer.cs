namespace Payroll
{
    partial class ChangePassword
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChangePassword));
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            CurrentPassTextBox = new TextBox();
            NewPassTextBox = new TextBox();
            ConfirmPassTextBox = new TextBox();
            button1 = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Georgia", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.FromArgb(99, 27, 27);
            label1.Location = new Point(148, 101);
            label1.Name = "label1";
            label1.Size = new Size(128, 15);
            label1.TabIndex = 0;
            label1.Text = "Current Password:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Georgia", 9F, FontStyle.Bold);
            label2.ForeColor = Color.FromArgb(99, 27, 27);
            label2.Location = new Point(148, 148);
            label2.Name = "label2";
            label2.Size = new Size(101, 15);
            label2.TabIndex = 1;
            label2.Text = "New Password:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Georgia", 9F, FontStyle.Bold);
            label3.ForeColor = Color.FromArgb(99, 27, 27);
            label3.Location = new Point(148, 196);
            label3.Name = "label3";
            label3.Size = new Size(129, 15);
            label3.TabIndex = 2;
            label3.Text = "Confirm Password:";
            // 
            // CurrentPassTextBox
            // 
            CurrentPassTextBox.Font = new Font("Times New Roman", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            CurrentPassTextBox.Location = new Point(167, 118);
            CurrentPassTextBox.Margin = new Padding(3, 2, 3, 2);
            CurrentPassTextBox.Name = "CurrentPassTextBox";
            CurrentPassTextBox.Size = new Size(242, 21);
            CurrentPassTextBox.TabIndex = 3;
            // 
            // NewPassTextBox
            // 
            NewPassTextBox.Font = new Font("Times New Roman", 7.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            NewPassTextBox.Location = new Point(167, 165);
            NewPassTextBox.Margin = new Padding(3, 2, 3, 2);
            NewPassTextBox.Name = "NewPassTextBox";
            NewPassTextBox.Size = new Size(242, 19);
            NewPassTextBox.TabIndex = 4;
            // 
            // ConfirmPassTextBox
            // 
            ConfirmPassTextBox.Font = new Font("Times New Roman", 8.25F);
            ConfirmPassTextBox.Location = new Point(167, 213);
            ConfirmPassTextBox.Margin = new Padding(3, 2, 3, 2);
            ConfirmPassTextBox.Name = "ConfirmPassTextBox";
            ConfirmPassTextBox.Size = new Size(242, 20);
            ConfirmPassTextBox.TabIndex = 5;
            // 
            // button1
            // 
            button1.BackgroundImage = Properties.Resources.loginButtonImage;
            button1.BackgroundImageLayout = ImageLayout.Stretch;
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Georgia", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button1.ForeColor = Color.Snow;
            button1.Location = new Point(225, 249);
            button1.Margin = new Padding(3, 2, 3, 2);
            button1.Name = "button1";
            button1.Size = new Size(121, 37);
            button1.TabIndex = 7;
            button1.Text = "CONFIRM";
            button1.UseVisualStyleBackColor = true;
            // 
            // ChangePassword
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(562, 321);
            Controls.Add(button1);
            Controls.Add(ConfirmPassTextBox);
            Controls.Add(NewPassTextBox);
            Controls.Add(CurrentPassTextBox);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Margin = new Padding(3, 2, 3, 2);
            Name = "ChangePassword";
            Text = "ChangePassword";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox CurrentPassTextBox;
        private TextBox NewPassTextBox;
        private TextBox ConfirmPassTextBox;
        private Button button1;
    }
}