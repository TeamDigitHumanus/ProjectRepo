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
using System.Text.RegularExpressions;

namespace DigitCashier
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("Please enter code to login!");
            }
            else
            {
                List<string> lista = new List<string>();
                using (StreamReader sr = new StreamReader(@"C:\Users\Giannis\Documents\digitcashierproj\usercodes.txt"))
                {
                    string line = sr.ReadLine();
                    while ((line = sr.ReadLine()) != null)
                    {
                        lista.Add(line);
                    }
                    string code = (textBox1.Text);
                    if (lista.Contains(code))
                    {
                        MessageBox.Show("Welcome user: " + code);
                    }
                    else
                    {
                        MessageBox.Show("User not found!");
                    }
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            textBox1.MaxLength = 3;
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
