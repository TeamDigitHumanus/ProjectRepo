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
    public partial class Cashier : Form
    {
        public Cashier()
        {
            InitializeComponent();
            timer1.Start();
            lblTime.Text = DateTime.Now.ToLongTimeString();
            lblDate.Text = DateTime.Now.ToString("yyyy/MM/dd");
        }

        private void btnZero_Click(object sender, EventArgs e)
        {
            txtEntry1.Text += "0";
        }

        private void btnNine_Click(object sender, EventArgs e)
        {
            txtEntry1.Text += "9";
        }

        private void txtEntries2_TextChanged(object sender, EventArgs e)
        {

        }

        private void Cashier_Load(object sender, EventArgs e)
        {

        }

        private void txtEntry1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnOne_Click(object sender, EventArgs e)
        {
            txtEntry1.Text += "1";
        }

        private void btnTwo_Click(object sender, EventArgs e)
        {
            txtEntry1.Text += "2";
        }

        private void btnThree_Click(object sender, EventArgs e)
        {
            txtEntry1.Text += "3";
        }

        private void btnFour_Click(object sender, EventArgs e)
        {
            txtEntry1.Text += "4";
        }

        private void btnFive_Click(object sender, EventArgs e)
        {
            txtEntry1.Text += "5";
        }

        private void btnSix_Click(object sender, EventArgs e)
        {
            txtEntry1.Text += "6";
        }

        private void btnSeven_Click(object sender, EventArgs e)
        {
            txtEntry1.Text += "7";
        }

        private void btnEight_Click(object sender, EventArgs e)
        {
            txtEntry1.Text += "8";
        }

        private void btnAsterisk_Click(object sender, EventArgs e)
        {
            txtEntry1.Text += "*";
        }

        private void btnHash_Click(object sender, EventArgs e)
        {
            txtEntry1.Text += "#";
        }

        private void fILEToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void lOGOUTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoginForm login = new LoginForm();
            login.Show();
            this.Close();
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            float sum = 0;
            string prdID = txtEntry1.Text;
            //Reading the file
            string items = File.ReadAllText(@"C:\Users\Giannis\Documents\digitcashierproj\products.txt");
            items = items.Replace('\n', '\r');
            string[] lines = items.Split(new char[] { '\r' }, StringSplitOptions.RemoveEmptyEntries);
            // See how many rows and columns there are
            int numrows = lines.Length;
            int numcols = lines[0].Split(',').Length; //Separating columns using the commas as delimiter
            // Create array and load it with data
            string[,] prdArray = new string[numrows, numcols];
            for (int r = 0; r < numrows; r++)
            {
                string[] line_r = lines[r].Split(',');
                for (int c = 0; c < numcols; c++)
                {
                    prdArray[r, c] = line_r[c];
                }
            }
            for (int i = 0; i < prdArray.GetLength(0); i++)
            {
                if ((prdID.Equals(prdArray[i, 0])) && (prdArray[i, 3].Contains("kg"))) //Checking if product is priced by weight
                {
                    DialogBoxForm dialogBoxForm = new DialogBoxForm();
                    dialogBoxForm.Text = prdArray[i, 1];
                    DialogResult dialogResult = dialogBoxForm.ShowDialog(this);
                    if (dialogResult == DialogResult.OK)    //Calculating the price according to weight
                    {
                        float kg = float.Parse(dialogBoxForm.GetKG);
                        richtxtEntries.AppendText(prdArray[i, 1] + "        " + (float.Parse(prdArray[i, 2]) * kg).ToString("0.00") + "\r");
                    }
                }
                else if (prdID.Equals(prdArray[i, 0])) //Checking if the product ID exists in the array
                {
                    richtxtEntries.AppendText(prdArray[i, 1] + "        " + prdArray[i, 2] + "\r");
                }
            }
            
            string[] separator = { " ", "\n" };  //Reading the values from the text box
            string[] allLines = richtxtEntries.Text.Split(separator, StringSplitOptions.RemoveEmptyEntries);
            ////float price = Array.FindIndex(allLines, element => element.Contains("."));
            foreach (string pris in allLines)  //Getting the element that is the price and sum up the values
            {
                if (pris.Contains("."))
                {
                    sum = sum + float.Parse(pris);
                }
            }
            txtSum.Text = sum.ToString("0.00");
            float dis = float.Parse(txtBoxDis.Text);
            if (txtBoxDis.Text == null)
            {
                txtTotal.Text = sum.ToString("0.00");
            }
            else
            {
                txtTotal.Text = (sum - (sum * dis / 100)).ToString("0.00");
            }
            txtEntry1.Focus();
            txtEntry1.Clear();
        }

        private void txtSum_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            richtxtEntries.Clear();
            txtSum.Text = "0";
            txtEntry1.Clear();
            txtBoxDis.Text = "0";
            txtTotal.Text = "0";
            txtEntry1.Focus();
        }

        private void btnDisCoup_Click(object sender, EventArgs e)
        {
            DisCodeForm disCodeForm = new DisCodeForm();
            DialogResult dialogResult = disCodeForm.ShowDialog(this);
            if (dialogResult == DialogResult.OK)    //Calculating the price according to weight
            {
                txtBoxDis.Text = disCodeForm.GetDis;
            }
            float dis = float.Parse(txtBoxDis.Text);
            float sum = float.Parse(txtSum.Text);
            txtTotal.Text = (sum - (sum * dis / 100)).ToString("0.00");
        }

        private void txtBoxDis_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtTotal_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblDateTime_Click(object sender, EventArgs e)
        {
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblTime.Text = DateTime.Now.ToLongTimeString();
            timer1.Start();
        }

        private void txtEntry1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnAdd.PerformClick();
            }
        }

        private void txtEntry1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void richtxtEntries_TextChanged(object sender, EventArgs e)
        {
            richtxtEntries.SelectionStart = richtxtEntries.Text.Length;
            richtxtEntries.ScrollToCaret();
        }

        public string GetEntries
        {
            get { return richtxtEntries.Text; }
            set { richtxtEntries.Text = value; }
        }

        private void btnCash_Click(object sender, EventArgs e)
        {
            CashForm cashForm = new CashForm();
            cashForm.Show();
            cashForm.txtTotal.Text = txtTotal.Text;
        }
    }
}
