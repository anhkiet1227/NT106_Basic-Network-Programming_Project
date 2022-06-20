using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace test
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }
        private void checkpass_CheckedChanged(object sender, EventArgs e)
        {
            if (checkpass.Checked)
            {
                txt_password.UseSystemPasswordChar = false;
            }
            else
            {
                txt_password.UseSystemPasswordChar = true;
            }
        }
        AesCryptoServiceProvider crpt = new AesCryptoServiceProvider();
        void setup()
        {
            string skey = "AXe8YwuIn1zxt3FPWTZFlAa14EHdPAdN9FaZ9RQWihc="; // 256 bit key
            string siv = "bsxnWolsAyO7kCfWuyrnqg=="; // 128 bit iv
            // set up
            crpt.Mode = CipherMode.CBC;
            crpt.Padding = PaddingMode.PKCS7;
            crpt.Key = Convert.FromBase64String(skey);
            crpt.IV = Convert.FromBase64String(siv);
        }

        string Encrypt(string password)
        {
            setup();
            // encrypt
            ICryptoTransform cryptoTransform = crpt.CreateEncryptor();
            byte[] bpassword = Encoding.ASCII.GetBytes(password);
            byte[] encrypted = cryptoTransform.TransformFinalBlock(bpassword, 0, bpassword.Length);
            return Convert.ToBase64String(encrypted); // max 20 ki tu = 44 ki tu base64
        }

        OleDbConnection dbConnect = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=db_user.mdb");
        OleDbCommand dbCommand = new OleDbCommand();
        OleDbDataAdapter dbDataAdapter = new OleDbDataAdapter();

        private void btn_login_Click(object sender, EventArgs e)
        {
            string username = txt_username.Text;
            string password = txt_password.Text;
            password = Encrypt(password);

            dbConnect.Open();
            string login = "SELECT * FROM Table1 WHERE username= '" + username + "' and password= '" + password + "'";
            dbCommand = new OleDbCommand(login, dbConnect);
            OleDbDataReader dbDataReader = dbCommand.ExecuteReader();

            if (username.Trim() == "" || password.Trim() == "")
            {
                MessageBox.Show("Username or password is empty", "Login failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_username.Focus();
                dbConnect.Close();
            }              
            else
            {
                if (dbDataReader.Read() == true)
                {
                    MessageBox.Show("Login successful", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Hide();
                    var tmpForm = new MainForm();
                    tmpForm.Closed += (s, args) => this.Close();
                    tmpForm.Show();
                    dbConnect.Close();
                }
                else
                {
                    MessageBox.Show("Username or Password is not correct", "Login failed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txt_username.Text = "";
                    txt_password.Text = "";
                    txt_username.Focus();
                    dbConnect.Close();
                }
            }
            
        }

        private void checkpass_CheckedChanged_1(object sender, EventArgs e)
        {
            if (checkpass.Checked)
            {
                txt_password.UseSystemPasswordChar = false;
            }
            else
            {
                txt_password.UseSystemPasswordChar = true;
            }
        }

        private void btn_clear_Click(object sender, EventArgs e)
        {
            txt_username.Clear();
            txt_password.Clear();
            txt_username.Focus();
        }

        private void create_acc_Click(object sender, EventArgs e)
        {
            new RegisterForm().Show();
            this.Hide();
        }

        private void btn_quit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to quit?", "Quitting", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                Application.Exit();
        }
    }
}
