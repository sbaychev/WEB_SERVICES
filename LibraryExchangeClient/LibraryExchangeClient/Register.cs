using LibraryExchangeClient.AuthenticationService;
using LibraryExchangeClient.BookManagement;
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

namespace LibraryExchangeClient
{
    public partial class Register : Form
    {
        private Library_Exchange mainForm;
        
        public Register(Library_Exchange mainForm)
        {
            InitializeComponent();
            this.mainForm = mainForm;
        }
     
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Register_Load(object sender, EventArgs e)
        {

        }
        private void button1Register_Click(object sender, EventArgs e)
        {
            #region TextBoxMissingInputChecks
            if (textBox1Username.Text == "")
            {
                MessageBox.Show("Username can't be empty!");
                textBox1Username.Focus();
            }
            else if (textBox2Password.Text == "")
            {
                MessageBox.Show("Password can't be empty");
                textBox2Password.Focus();
            }
            else if (textBox3FirstName.Text == "")
            {
                MessageBox.Show("First Name can't be empty");
                textBox3FirstName.Focus();
            }
            else if (textBox4LastName.Text == "")
            {
                MessageBox.Show("Last Name can't be empty");
                textBox4LastName.Focus();
            }
            else if (textBox1Country.Text == "")
            {
                MessageBox.Show("Country can't be empty");
                textBox1Country.Focus();
            }
            else if (textBox1Postcode.Text == "")
            {
                MessageBox.Show("PostCode can't be empty");
                textBox1Postcode.Focus();
            }
            #endregion
            else
            {
                string country = textBox1Country.Text;
                string city = textBox1City.Text;
                string postcode = textBox1Postcode.Text;
                string address = textBox1Address.Text;
                User user = new User();
                Location location = new Location();
                location.Country = textBox1Country.Text;
                location.City = textBox1City.Text;
                location.PostCode = textBox1Postcode.Text;
                location.Address = textBox1Address.Text;

                user.UserName = textBox1Username.Text;
                user.Email = textBox1Email.Text;
                user.FirstName = textBox3FirstName.Text;
                user.LastName = textBox4LastName.Text;
                user.Phone = textBox1PhoneNumber.Text;
                user.Location = location;
             
                try
                {
                    LibraryExchangeClient.AuthenticationService.OperationResult orvsAuth = mainForm.AuthServiceProxy.AddUser(
                        user.Location.Country, user.Location.City, user.Location.PostCode, 
                        user.Location.Address, user.UserName, textBox2Password.Text, user.Email, 
                        user.FirstName, user.LastName, user.Phone);
                    if (orvsAuth.Error.Equals(AuthenticationService.ErrorEnum.None))
                    {
                        MessageBox.Show("User successfully added!");
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show(orvsAuth.ErrorString);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Some error occured during adding a User.");
                }
            }
        }
    }
}