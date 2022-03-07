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
    public partial class FormAddNewDate : Form
    {
        public FormAddNewDate()
        {
            InitializeComponent();
        }

        private void FormAddNewDate_Load(object sender, EventArgs e)
        {
            dateTimePicker1.Value = DateTime.Now;
        }
    }
}
