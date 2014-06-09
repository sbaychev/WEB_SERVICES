namespace LibraryExchangeClient
{
    partial class Authentication
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
            this.label1Username = new System.Windows.Forms.Label();
            this.label2Password = new System.Windows.Forms.Label();
            this.textBox1Password = new System.Windows.Forms.TextBox();
            this.textBox1Username = new System.Windows.Forms.TextBox();
            this.button1Login = new System.Windows.Forms.Button();
            this.button2Register = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1Username
            // 
            this.label1Username.AutoSize = true;
            this.label1Username.Location = new System.Drawing.Point(32, 38);
            this.label1Username.Name = "label1Username";
            this.label1Username.Size = new System.Drawing.Size(73, 17);
            this.label1Username.TabIndex = 0;
            this.label1Username.Text = "Username";
            // 
            // label2Password
            // 
            this.label2Password.AutoSize = true;
            this.label2Password.Location = new System.Drawing.Point(32, 91);
            this.label2Password.Name = "label2Password";
            this.label2Password.Size = new System.Drawing.Size(69, 17);
            this.label2Password.TabIndex = 1;
            this.label2Password.Text = "Password";
            // 
            // textBox1Password
            // 
            this.textBox1Password.Location = new System.Drawing.Point(177, 86);
            this.textBox1Password.Name = "textBox1Password";
            this.textBox1Password.Size = new System.Drawing.Size(121, 22);
            this.textBox1Password.TabIndex = 2;
            this.textBox1Password.Text = "Password....";
            // 
            // textBox1Username
            // 
            this.textBox1Username.Location = new System.Drawing.Point(177, 38);
            this.textBox1Username.Name = "textBox1Username";
            this.textBox1Username.Size = new System.Drawing.Size(121, 22);
            this.textBox1Username.TabIndex = 3;
            this.textBox1Username.Text = "Username...";
            // 
            // button1Login
            // 
            this.button1Login.Location = new System.Drawing.Point(35, 141);
            this.button1Login.Name = "button1Login";
            this.button1Login.Size = new System.Drawing.Size(121, 32);
            this.button1Login.TabIndex = 4;
            this.button1Login.Text = "Login";
            this.button1Login.UseVisualStyleBackColor = true;
            this.button1Login.Click += new System.EventHandler(this.button1Login_Click);
            // 
            // button2Register
            // 
            this.button2Register.Location = new System.Drawing.Point(177, 141);
            this.button2Register.Name = "button2Register";
            this.button2Register.Size = new System.Drawing.Size(121, 32);
            this.button2Register.TabIndex = 5;
            this.button2Register.Text = "Need Login?";
            this.button2Register.UseVisualStyleBackColor = true;
            this.button2Register.Click += new System.EventHandler(this.button2Register_Click);
            // 
            // Authentication
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(330, 217);
            this.Controls.Add(this.button2Register);
            this.Controls.Add(this.button1Login);
            this.Controls.Add(this.textBox1Username);
            this.Controls.Add(this.textBox1Password);
            this.Controls.Add(this.label2Password);
            this.Controls.Add(this.label1Username);
            this.Name = "Authentication";
            this.Text = "Authentication";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1Username;
        private System.Windows.Forms.Label label2Password;
        private System.Windows.Forms.TextBox textBox1Password;
        private System.Windows.Forms.TextBox textBox1Username;
        private System.Windows.Forms.Button button1Login;
        private System.Windows.Forms.Button button2Register;
    }
}