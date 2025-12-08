using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Payroll
{
    public partial class ChangePassword : Form
    {
        public string NewPassword { get; private set; }
        public ChangePassword()
        {
            InitializeComponent();
            RoundButtonCorners(ConfirmButton, 50);
        }

        private void ConfirmButton_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(NewPassTextBox.Text))
            {
                MessageBox.Show("Password cannot be empty.");
                return;
            }

            if (NewPassTextBox.Text != NewPassTextBox.Text)
            {
                MessageBox.Show("Passwords do not match.");
                NewPassTextBox.Clear();
                NewPassTextBox.Clear();
                NewPassTextBox.Focus();
                return;
            }

            this.NewPassword = NewPassTextBox.Text;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void exitButt_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void RoundButtonCorners(Button button, int radius)
        {
            var path = new GraphicsPath();
            path.AddArc(0, 0, radius, radius, 180, 90);
            path.AddArc(button.Width - radius, 0, radius, radius, 270, 90);
            path.AddArc(button.Width - radius, button.Height - radius, radius, radius, 0, 90);
            path.AddArc(0, button.Height - radius, radius, radius, 90, 90);
            path.CloseAllFigures();
            button.Region = new Region(path);
        }
    }
}
