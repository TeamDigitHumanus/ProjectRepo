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
    public partial class CardForm : Form
    {
        public CardForm()
        {
            InitializeComponent();
        }

        private void btnReceipt_Click(object sender, EventArgs e)
        {
            ReceiptForm receiptForm = new ReceiptForm();
            receiptForm.Show();
            receiptForm.label1.Text = "Järntorget\r12345, Göteborg\rTel.:012345678\rOrg:123456-7890";
            receiptForm.label3.Text = txtTotal.Text;
            receiptForm.label9.Text = "Save the receipt\rThank you for choosing us";
            receiptForm.label10.Text = label2.Text;
            receiptForm.label15.Text = "6";
            receiptForm.label17.Text = (float.Parse(txtTotal.Text) * 6 / 100).ToString("0.00");
            receiptForm.label19.Text = (float.Parse(txtTotal.Text) - float.Parse(receiptForm.label17.Text)).ToString("0.00");
            receiptForm.label21.Text = txtTotal.Text;
            receiptForm.label22.Text = label3.Text + "\r\n" + label4.Text;
            receiptForm.label5.Text = "Card payment";
            receiptForm.label7.Text = txtTotal.Text;
            receiptForm.label8.Text = "";
            receiptForm.label6.Text = "";
            this.Hide();
        }

        private void prgBar1_Click(object sender, EventArgs e)
        {

        }

        private void CardForm_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            timer1.Start();
            timer1.Interval = 2000;
            timer1.Tick += new EventHandler(timer1_Tick);

            prgBar1.Minimum = 1;
            prgBar1.Maximum = 70;
            prgBar1.Value = 1;
            prgBar1.Step = 1;
            for (int x = 1; x <= 70; x++)
            {
                prgBar1.PerformStep();
            }
        }

        void timer1_Tick(object sender, EventArgs e)
        {
            if (prgBar1.Value != 70)
            {
                prgBar1.Value++;
            }
            else
            {
                timer1.Stop();
                btnReceipt.PerformClick();
            }
        }
    }
}
