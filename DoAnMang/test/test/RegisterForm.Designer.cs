namespace test
{
    partial class RegisterForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.back2login = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btn_clear = new System.Windows.Forms.Button();
            this.btn_register = new System.Windows.Forms.Button();
            this.checkpass = new System.Windows.Forms.CheckBox();
            this.txt_cfpassword = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_password = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_username = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // back2login
            // 
            this.back2login.AutoSize = true;
            this.back2login.Cursor = System.Windows.Forms.Cursors.Hand;
            this.back2login.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.back2login.ForeColor = System.Drawing.Color.DodgerBlue;
            this.back2login.Location = new System.Drawing.Point(58, 442);
            this.back2login.Name = "back2login";
            this.back2login.Size = new System.Drawing.Size(127, 23);
            this.back2login.TabIndex = 23;
            this.back2login.Text = "Back to LOGIN";
            this.back2login.Click += new System.EventHandler(this.back2login_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(26, 423);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(205, 23);
            this.label5.TabIndex = 22;
            this.label5.Text = "Already have an account";
            // 
            // btn_clear
            // 
            this.btn_clear.BackColor = System.Drawing.Color.White;
            this.btn_clear.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_clear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_clear.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_clear.ForeColor = System.Drawing.Color.DodgerBlue;
            this.btn_clear.Location = new System.Drawing.Point(22, 373);
            this.btn_clear.Name = "btn_clear";
            this.btn_clear.Size = new System.Drawing.Size(216, 35);
            this.btn_clear.TabIndex = 21;
            this.btn_clear.Text = "CLEAR";
            this.btn_clear.UseVisualStyleBackColor = false;
            this.btn_clear.Click += new System.EventHandler(this.btn_clear_Click);
            // 
            // btn_register
            // 
            this.btn_register.BackColor = System.Drawing.Color.DodgerBlue;
            this.btn_register.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_register.FlatAppearance.BorderSize = 0;
            this.btn_register.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_register.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_register.ForeColor = System.Drawing.Color.White;
            this.btn_register.Location = new System.Drawing.Point(22, 322);
            this.btn_register.Name = "btn_register";
            this.btn_register.Size = new System.Drawing.Size(216, 35);
            this.btn_register.TabIndex = 20;
            this.btn_register.Text = "REGISTER";
            this.btn_register.UseVisualStyleBackColor = false;
            this.btn_register.Click += new System.EventHandler(this.btn_register_Click);
            // 
            // checkpass
            // 
            this.checkpass.AutoSize = true;
            this.checkpass.Cursor = System.Windows.Forms.Cursors.Hand;
            this.checkpass.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkpass.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.checkpass.Location = new System.Drawing.Point(94, 278);
            this.checkpass.Name = "checkpass";
            this.checkpass.Size = new System.Drawing.Size(153, 27);
            this.checkpass.TabIndex = 19;
            this.checkpass.Text = "Show password";
            this.checkpass.UseVisualStyleBackColor = true;
            this.checkpass.CheckedChanged += new System.EventHandler(this.checkpass_CheckedChanged);
            // 
            // txt_cfpassword
            // 
            this.txt_cfpassword.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(231)))), ((int)(((byte)(233)))));
            this.txt_cfpassword.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_cfpassword.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_cfpassword.Location = new System.Drawing.Point(22, 246);
            this.txt_cfpassword.Name = "txt_cfpassword";
            this.txt_cfpassword.Size = new System.Drawing.Size(216, 32);
            this.txt_cfpassword.TabIndex = 18;
            this.txt_cfpassword.UseSystemPasswordChar = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(18, 222);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(157, 23);
            this.label4.TabIndex = 17;
            this.label4.Text = "Confirm password";
            // 
            // txt_password
            // 
            this.txt_password.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(231)))), ((int)(((byte)(233)))));
            this.txt_password.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_password.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_password.Location = new System.Drawing.Point(22, 172);
            this.txt_password.Name = "txt_password";
            this.txt_password.Size = new System.Drawing.Size(216, 32);
            this.txt_password.TabIndex = 16;
            this.txt_password.UseSystemPasswordChar = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(18, 148);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 23);
            this.label3.TabIndex = 15;
            this.label3.Text = "Password";
            // 
            // txt_username
            // 
            this.txt_username.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(231)))), ((int)(((byte)(233)))));
            this.txt_username.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_username.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_username.Location = new System.Drawing.Point(22, 100);
            this.txt_username.Name = "txt_username";
            this.txt_username.Size = new System.Drawing.Size(216, 32);
            this.txt_username.TabIndex = 14;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(18, 76);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 23);
            this.label2.TabIndex = 13;
            this.label2.Text = "Username";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DodgerBlue;
            this.label1.Location = new System.Drawing.Point(35, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(186, 46);
            this.label1.TabIndex = 12;
            this.label1.Text = "WELCOME";
            // 
            // RegisterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(261, 490);
            this.Controls.Add(this.back2login);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btn_clear);
            this.Controls.Add(this.btn_register);
            this.Controls.Add(this.checkpass);
            this.Controls.Add(this.txt_cfpassword);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txt_password);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txt_username);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "RegisterForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RegisterForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label back2login;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btn_clear;
        private System.Windows.Forms.Button btn_register;
        private System.Windows.Forms.CheckBox checkpass;
        private System.Windows.Forms.TextBox txt_cfpassword;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_password;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_username;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}