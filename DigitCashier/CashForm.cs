using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DigitCashier
{
    public partial class CashForm : Form
    {
        public CashForm()
        {
            InitializeComponent();
        }

        private void CashForm_Load(object sender, EventArgs e)
        {
         
        }

        private void txtCashAmount_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnReceipt.PerformClick();
            }
        }

        private void txtCashAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }
        }

        private void txtChange_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void txtTotal_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void txtCashAmount_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void btnReceipt_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCashAmount.Text))
            {
                MessageBox.Show("Please enter cash amount!");
            }
            else
            {
                txtChange.Text = (float.Parse(txtCashAmount.Text) - float.Parse(txtTotal.Text)).ToString("0.00");
                //ReceiptForm receiptForm = new ReceiptForm();
                //receiptForm.Show();
                //receiptForm.label1.Text = "Järntorget\r12345, Göteborg\rTel.:012345678\rOrg:123456-7890";
            }
        }
    }
}
