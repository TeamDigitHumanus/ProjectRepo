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
            decimal sum = 0;
            string prdID = (txtEntry1.Text);
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
                if (prdID.Equals(prdArray[i, 0])) //Checking if the product ID exists in the array
                {
                    richtxtEntries.AppendText(prdArray[i, 1] + "       " + prdArray[i, 2] + " " + prdArray[i, 3] + "\r");
                }
            }
            string[] separator = { " ", "\n", "kr" };  //Reading the values from the text box
            string[] allLines = richtxtEntries.Text.Split(separator, StringSplitOptions.RemoveEmptyEntries);
            ////float price = Array.FindIndex(allLines, element => element.Contains("."));
            foreach (string pris in allLines)  //Getting the element that is the price and sum up the values
            {
                if (pris.Contains("."))
                {
                    sum = sum + decimal.Parse(pris);
                }
            }
            txtSum.Text = sum.ToString() + " " + prdArray[0,3];
            txtEntry1.Focus();
            txtEntry1.Clear();
        }
        private void txtSum_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            richtxtEntries.Clear();
            txtSum.Clear();
        }
    }
}
