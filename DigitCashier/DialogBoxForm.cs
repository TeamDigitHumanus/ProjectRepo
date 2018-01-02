using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace DigitCashier
{
    public partial class DialogBoxForm : Form
    {

        public DialogBoxForm()
        {
            InitializeComponent();
        }

        public void txtBoxKG_TextChanged(object sender, EventArgs e)
        {
            txtBoxKG.MaxLength = 6;
        }
        private void txtBoxKG_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }
        }
        private void txtBoxKG_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnOK.PerformClick();
            }
        }
        public string GetKG
        {
            get { return txtBoxKG.Text; }
            set { txtBoxKG.Text = value; }
        }

        public void btnOK_Click(object sender, EventArgs e)
        {
            this.btnOK.DialogResult = DialogResult.OK;
            if (string.IsNullOrWhiteSpace(txtBoxKG.Text))
            {
                MessageBox.Show("Please enter a value!");
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void DialogBoxForm_Load(object sender, EventArgs e)
        {

        }
    }
}
