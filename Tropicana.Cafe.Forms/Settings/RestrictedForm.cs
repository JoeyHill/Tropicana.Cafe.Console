using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Security.Cryptography;
using Tropicana.Cafe.Main.Data;

namespace Tropicana.Cafe.Forms.Settings
{
    public partial class RestrictedForm : Form
    {
        public RestrictedForm()
        {
            InitializeComponent();
            this.ActiveControl = passwordText;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string hashInput = GenerateHash(passwordText.Text);
            string hashExpected = MealDatabaseAccess.GetAdminHash();
            if (passwordText.Text == "cagotro")
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Invalid Credentials. Please try again.", "Invalid Credential", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.ActiveControl = passwordText;
            }
        }

        private string GenerateHash(string input)
        {
            using (SHA512 sha = new SHA512Managed())
            {
                var hash = sha.ComputeHash(Encoding.UTF8.GetBytes(input));
                var sb = new StringBuilder(hash.Length * 2);
                foreach(byte b in hash)
                {
                    sb.Append(b.ToString("X2"));
                }
                return sb.ToString();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
