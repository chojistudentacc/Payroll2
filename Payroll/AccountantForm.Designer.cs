namespace Payroll
{
    partial class AccountantForm
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
            idLabel = new Label();
            payslipPanel = new Panel();
            payslipTitleLabel = new Label();
            payslipButt = new Button();
            messagesButt = new Button();
            messagesPanel = new Panel();
            messagesTitleLabel = new Label();
            payslipPanel.SuspendLayout();
            messagesPanel.SuspendLayout();
            SuspendLayout();
            // 
            // idLabel
            // 
            idLabel.AutoSize = true;
            idLabel.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            idLabel.Location = new Point(12, 35);
            idLabel.Name = "idLabel";
            idLabel.Size = new Size(146, 25);
            idLabel.TabIndex = 0;
            idLabel.Text = "Accountant ID: ";
            // 
            // payslipPanel
            // 
            payslipPanel.BackColor = SystemColors.ActiveCaption;
            payslipPanel.Controls.Add(payslipTitleLabel);
            payslipPanel.Location = new Point(283, 12);
            payslipPanel.Name = "payslipPanel";
            payslipPanel.Size = new Size(1094, 758);
            payslipPanel.TabIndex = 1;
            // 
            // payslipTitleLabel
            // 
            payslipTitleLabel.AutoSize = true;
            payslipTitleLabel.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            payslipTitleLabel.Location = new Point(14, 14);
            payslipTitleLabel.Name = "payslipTitleLabel";
            payslipTitleLabel.Size = new Size(72, 25);
            payslipTitleLabel.TabIndex = 1;
            payslipTitleLabel.Text = "payslip";
            // 
            // payslipButt
            // 
            payslipButt.Location = new Point(12, 81);
            payslipButt.Name = "payslipButt";
            payslipButt.Size = new Size(75, 23);
            payslipButt.TabIndex = 2;
            payslipButt.Text = "Payslip";
            payslipButt.UseVisualStyleBackColor = true;
            payslipButt.Click += payslipButt_Click;
            // 
            // messagesButt
            // 
            messagesButt.Location = new Point(12, 119);
            messagesButt.Name = "messagesButt";
            messagesButt.Size = new Size(75, 23);
            messagesButt.TabIndex = 3;
            messagesButt.Text = "Messages";
            messagesButt.UseVisualStyleBackColor = true;
            messagesButt.Click += messagesButt_Click;
            // 
            // messagesPanel
            // 
            messagesPanel.BackColor = Color.RosyBrown;
            messagesPanel.Controls.Add(messagesTitleLabel);
            messagesPanel.Location = new Point(283, 12);
            messagesPanel.Name = "messagesPanel";
            messagesPanel.Size = new Size(1094, 758);
            messagesPanel.TabIndex = 2;
            // 
            // messagesTitleLabel
            // 
            messagesTitleLabel.AutoSize = true;
            messagesTitleLabel.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            messagesTitleLabel.Location = new Point(14, 14);
            messagesTitleLabel.Name = "messagesTitleLabel";
            messagesTitleLabel.Size = new Size(94, 25);
            messagesTitleLabel.TabIndex = 1;
            messagesTitleLabel.Text = "messages";
            // 
            // AccountantForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1389, 782);
            Controls.Add(payslipPanel);
            Controls.Add(messagesPanel);
            Controls.Add(messagesButt);
            Controls.Add(payslipButt);
            Controls.Add(idLabel);
            Name = "AccountantForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "AccountantForm";
            FormClosed += AccountantForm_FormClosed;
            payslipPanel.ResumeLayout(false);
            payslipPanel.PerformLayout();
            messagesPanel.ResumeLayout(false);
            messagesPanel.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label idLabel;
        private Panel payslipPanel;
        private Label payslipTitleLabel;
        private Button payslipButt;
        private Button messagesButt;
        private Panel messagesPanel;
        private Label messagesTitleLabel;
    }
}