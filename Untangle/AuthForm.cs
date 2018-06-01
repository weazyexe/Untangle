using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Untangle
{
    public partial class AuthForm : Form
    {
        public AuthForm()
        {
            InitializeComponent();
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            if (NameTextBox.Text != "")
            {
                GameForm.name = NameTextBox.Text;
                DialogResult = DialogResult.OK;
                Close();
            }
            else MessageBox.Show("enter the name!", "error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
