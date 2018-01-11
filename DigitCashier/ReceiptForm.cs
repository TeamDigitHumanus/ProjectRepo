using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Printing;

namespace DigitCashier
{
    public partial class ReceiptForm : Form
    {
        public ReceiptForm()
        {
            InitializeComponent();
        }

        private void ReceiptForm_Load(object sender, EventArgs e)
        {
            label11.Text = "---------------------------------------------------------------------------";
            label12.Text = "---------------------------------------------------------------------------";
        }

        public void CreateReceipt(object sender, PrintPageEventArgs e)
        {
            Graphics graphic = e.Graphics;
            Font font = new Font("Courier New", 12);
            float fontHeight = font.GetHeight();

            int startX = 10;
            int startY = 10;
            int offset = 40;
            
            graphic.DrawString(label2.Text, new Font("Courier New", 16), new SolidBrush(Color.Black), startX, startY);
            offset = offset + 5;
            graphic.DrawString("Järntorget", new Font("Courier New", 10), new SolidBrush(Color.Black), startX, startY + offset);
            offset = offset + 15;
            graphic.DrawString("12345, Göteborg", new Font("Courier New", 10), new SolidBrush(Color.Black), startX, startY + offset);
            offset = offset + 15;
            graphic.DrawString("Tel.:012345678", new Font("Courier New", 10), new SolidBrush(Color.Black), startX, startY + offset);
            offset = offset + 15;
            graphic.DrawString("Org:123456-7890", new Font("Courier New", 10), new SolidBrush(Color.Black), startX, startY + offset);
            offset = offset + (int)fontHeight;
            graphic.DrawString("----------------------------------", font, new SolidBrush(Color.Black), startX, startY + offset);
            offset = offset + (int)fontHeight + 5;
            graphic.DrawString(label10.Text.PadLeft(20), font, new SolidBrush(Color.Black), startX, startY + offset);
            foreach (char line in label10.Text)
            {
                offset = offset + 1;
            }
            offset = offset + (int)fontHeight;
            graphic.DrawString("----------------------------------", font, new SolidBrush(Color.Black), startX, startY + offset);
            offset = offset + (int)fontHeight + 5;
            offset = offset + 20;

            graphic.DrawString(label4.Text.PadRight(15) + label3.Text.PadRight(7) + label13.Text, new Font("Courier New", 12, FontStyle.Bold), new SolidBrush(Color.Black), startX, startY + offset);

            offset = offset + 30;
            graphic.DrawString(label5.Text.PadRight(15) + label7.Text, font, new SolidBrush(Color.Black), startX, startY + offset);
            offset = offset + 15;
            graphic.DrawString(label6.Text.PadRight(15) + label8.Text, font, new SolidBrush(Color.Black), startX, startY + offset);
            offset = offset + 50;
            graphic.DrawString(label14.Text.PadRight(10) + label16.Text.PadRight(10) + label18.Text.PadRight(10) + label20.Text.PadRight(10), new Font("Courier New", 10), new SolidBrush(Color.Black), startX, startY + offset);
            offset = offset + 15;
            graphic.DrawString(label15.Text.PadRight(10) + label17.Text.PadRight(10) + label19.Text.PadRight(10) + label21.Text.PadRight(10), new Font("Courier New", 10), new SolidBrush(Color.Black), startX, startY + offset);
            offset = offset + 50;
            graphic.DrawString(label22.Text, font, new SolidBrush(Color.Black), startX, startY + offset);
            offset = offset + 35;
            graphic.DrawString("Save the receipt\r\nThank you for choosing us", font, new SolidBrush(Color.Black), startX, startY + offset);
        }


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            PrintDialog printDialog = new PrintDialog();
            PrintDocument printDocument = new PrintDocument();
            printDialog.Document = printDocument;   
            printDocument.PrintPage += new PrintPageEventHandler(CreateReceipt);
            DialogResult result = printDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                printDocument.Print();
            }
            this.Hide();
        }
    }
}
