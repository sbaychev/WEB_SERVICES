using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LibraryExchangeClient.AuthenticationService;

namespace LibraryExchangeClient
{
    public partial class Authentication : Form
    {
        private Library_Exchange mainForm;
        
        public Authentication(Library_Exchange mainForm)
        {
            this.mainForm = mainForm;
            InitializeComponent();
        }

        private void button2Register_Click(object sender, EventArgs e)
        {
            Register register = new Register(mainForm);
            register.Show();
        }

        private void button1Login_Click(object sender, EventArgs e)
        {
            try
            {
                OperationResultValueOfString token = mainForm.AuthServiceProxy.IsUserValid(textBox1Username.Text, textBox1Password.Text);
                if (token.Error.Equals(AuthenticationService.ErrorEnum.None))
                {
                    if (!String.IsNullOrEmpty(token.ResultValue))
                    {
                        MessageBox.Show("Successful Login!!!");
                        mainForm.Guid = token.ResultValue;
                        mainForm.UserName = textBox1Username.Text;
                    }
                    else
                    {
                        MessageBox.Show("Invalid Username or Password.");
                    }
                }
                else
                {
                    MessageBox.Show(token.ErrorString);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Some error occured during user authentication.");
            }
        }
    }
}