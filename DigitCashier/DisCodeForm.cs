using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace DigitCashier
{
    public partial class DisCodeForm : Form
    {
        public DisCodeForm()
        {
            InitializeComponent();
        }

        private void DisCodeForm_Load(object sender, EventArgs e)
        {

        }

        private void txtBoxDisCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnOK1.PerformClick();
            }
        }

        private void txtBoxDisCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtBoxDisCode_TextChanged(object sender, EventArgs e)
        {
            txtBoxDisCode.MaxLength = 4;
        }

        public string GetDis
        {
            get { return txtBoxDis.Text; }
            set { txtBoxDis.Text = value; }
        }

        public void btnOK1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtBoxDisCode.Text))
            {
                MessageBox.Show("Please enter a value!");
            }
            string items = File.ReadAllText(@"C:\Users\Giannis\Documents\digitcashierproj\discountcodes.txt");
            items = items.Replace('\n', '\r');
            string[] lines = items.Split(new char[] { '\r' }, StringSplitOptions.RemoveEmptyEntries);
            int numrows = lines.Length;
            int numcols = lines[0].Split(',').Length;
            string[,] dcArray = new string[numrows, numcols];
            for (int r = 0; r < numrows; r++)
            {
                string[] line_r = lines[r].Split(',');
                for (int c = 0; c < numcols; c++)
                {
                    dcArray[r, c] = line_r[c];
                }
            }
            for (int i = 0; i < dcArray.GetLength(0); i++)
            {
                if (txtBoxDisCode.Text.Equals(dcArray[i,0]))
                {
                    this.btnOK1.DialogResult = DialogResult.OK;
                    txtBoxDis.Text = dcArray[i, 1];
                }
            }
        }

        private void txtBoxDis_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
