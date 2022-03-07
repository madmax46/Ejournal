using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Ejournal
{
    public partial class FormAddNewTest : Form
    {
        public FormAddNewTest()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            dateTimePicker.Value = DateTime.Now;
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            if (FullNameTextBox.TextLength == 0 || ShortNameTextBox.TextLength == 0)
            {
                ErrorLabel.Visible = true;
            }
            else
                DialogResult = DialogResult.OK;

        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void FullNameTextBox_TextChanged(object sender, EventArgs e)
        {
            ErrorLabel.Visible = false;
        }

        private void ShortNameTextBox_TextChanged(object sender, EventArgs e)
        {
            ErrorLabel.Visible = false;
        }
    }
}
