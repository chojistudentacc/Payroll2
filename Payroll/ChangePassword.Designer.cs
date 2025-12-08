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
            ConfirmButton = new Button();
            exitButt = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Georgia", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.FromArgb(99, 27, 27);
            label1.Location = new Point(169, 135);
            label1.Name = "label1";
            label1.Size = new Size(153, 18);
            label1.TabIndex = 0;
            label1.Text = "Current Password:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Georgia", 9F, FontStyle.Bold);
            label2.ForeColor = Color.FromArgb(99, 27, 27);
            label2.Location = new Point(169, 197);
            label2.Name = "label2";
            label2.Size = new Size(126, 18);
            label2.TabIndex = 1;
            label2.Text = "New Password:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Georgia", 9F, FontStyle.Bold);
            label3.ForeColor = Color.FromArgb(99, 27, 27);
            label3.Location = new Point(169, 261);
            label3.Name = "label3";
            label3.Size = new Size(156, 18);
            label3.TabIndex = 2;
            label3.Text = "Confirm Password:";
            // 
            // CurrentPassTextBox
            // 
            CurrentPassTextBox.Font = new Font("Times New Roman", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            CurrentPassTextBox.Location = new Point(191, 157);
            CurrentPassTextBox.Name = "CurrentPassTextBox";
            CurrentPassTextBox.Size = new Size(276, 25);
            CurrentPassTextBox.TabIndex = 3;
            // 
            // NewPassTextBox
            // 
            NewPassTextBox.Font = new Font("Times New Roman", 7.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            NewPassTextBox.Location = new Point(191, 220);
            NewPassTextBox.Name = "NewPassTextBox";
            NewPassTextBox.Size = new Size(276, 22);
            NewPassTextBox.TabIndex = 4;
            // 
            // ConfirmPassTextBox
            // 
            ConfirmPassTextBox.Font = new Font("Times New Roman", 8.25F);
            ConfirmPassTextBox.Location = new Point(191, 284);
            ConfirmPassTextBox.Name = "ConfirmPassTextBox";
            ConfirmPassTextBox.Size = new Size(276, 23);
            ConfirmPassTextBox.TabIndex = 5;
            // 
            // ConfirmButton
            // 
            ConfirmButton.BackgroundImage = Properties.Resources.loginButtonImage;
            ConfirmButton.BackgroundImageLayout = ImageLayout.Stretch;
            ConfirmButton.FlatAppearance.BorderSize = 0;
            ConfirmButton.FlatStyle = FlatStyle.Flat;
            ConfirmButton.Font = new Font("Georgia", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ConfirmButton.ForeColor = Color.Snow;
            ConfirmButton.Location = new Point(257, 332);
            ConfirmButton.Name = "ConfirmButton";
            ConfirmButton.Size = new Size(138, 49);
            ConfirmButton.TabIndex = 7;
            ConfirmButton.Text = "CONFIRM";
            ConfirmButton.UseVisualStyleBackColor = true;
            ConfirmButton.Click += ConfirmButton_Click;
            // 
            // exitButt
            // 
            exitButt.BackColor = Color.Transparent;
            exitButt.FlatAppearance.BorderSize = 0;
            exitButt.FlatStyle = FlatStyle.Flat;
            exitButt.Font = new Font("Georgia", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            exitButt.ForeColor = Color.FromArgb(143, 48, 48);
            exitButt.Location = new Point(502, 24);
            exitButt.Margin = new Padding(3, 4, 3, 4);
            exitButt.Name = "exitButt";
            exitButt.Size = new Size(72, 34);
            exitButt.TabIndex = 9;
            exitButt.Text = "X";
            exitButt.UseVisualStyleBackColor = false;
            exitButt.Click += exitButt_Click;
            // 
            // ChangePassword
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(642, 428);
            Controls.Add(exitButt);
            Controls.Add(ConfirmButton);
            Controls.Add(ConfirmPassTextBox);
            Controls.Add(NewPassTextBox);
            Controls.Add(CurrentPassTextBox);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.None;
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
        private Button ConfirmButton;
        private Button exitButt;
    }
}