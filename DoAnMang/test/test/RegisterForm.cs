using System;
using System.Data.OleDb;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace test
{
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();
        }
        OleDbConnection dbConnect = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=db_user.mdb");
        OleDbCommand dbCommand = new OleDbCommand();
        OleDbDataAdapter dbDataAdapter = new OleDbDataAdapter();

        private void checkpass_CheckedChanged(object sender, EventArgs e)
        {
            if (checkpass.Checked)
            {
                txt_password.UseSystemPasswordChar = false;
                txt_cfpassword.UseSystemPasswordChar = false;
            }
            else
            {
                txt_password.UseSystemPasswordChar = true;
                txt_cfpassword.UseSystemPasswordChar = true;
            }
        }
        public bool checkAccount(string ac)
        {
            // check username, password
            // chỉ cho phép nhập a-z, A-Z, 0-9, tối thiểu 3 và tối đa 20 kí tự
            return Regex.IsMatch(ac, "^[a-zA-Z0-9]{3,20}$");
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
            return Convert.ToBase64String(encrypted); 
        }

        private void btn_register_Click(object sender, EventArgs e)
        {
            string username = txt_username.Text;
            string password = txt_password.Text;
            string cfpassword = txt_cfpassword.Text;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(cfpassword))
            {
                MessageBox.Show("Some fields are empty");
            }
            else if (!checkAccount(username))
            {
                MessageBox.Show("Use capitalize/lowercase letter, number and 3-20 length", "Invalid username");
            }
            else if (!checkAccount(password))
            {
                MessageBox.Show("Use capitalize/lowercase letter, number and 3-20 length", "Invalid password");

            }
            else if (txt_password.Text != txt_cfpassword.Text)
            {
                MessageBox.Show("Password does not match", "Registration failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_password.Clear();
                txt_cfpassword.Clear();
                txt_password.Focus();
            }
            else
            {
                password = Encrypt(password);
                dbConnect.Open();
                string register = "INSERT INTO Table1 VALUES ('" + username + "','" + password + "')";
                dbCommand = new OleDbCommand(register, dbConnect);
                dbCommand.ExecuteNonQuery();
                dbConnect.Close();
                txt_username.Text = "";
                txt_password.Text = "";
                txt_cfpassword.Text = "";
                if (MessageBox.Show("Do you want to login?", "Registration successful", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    new LoginForm().Show();
                    this.Close();
                }
            }
        }

        private void btn_clear_Click(object sender, EventArgs e)
        {
            txt_username.Clear();
            txt_password.Clear();
            txt_cfpassword.Clear();
            txt_username.Focus();
        }

        private void back2login_Click(object sender, EventArgs e)
        {
            new LoginForm().Show();
            this.Close();
        }
    }
}
