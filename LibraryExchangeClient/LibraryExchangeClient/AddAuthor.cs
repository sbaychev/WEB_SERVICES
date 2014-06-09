using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LibraryExchangeClient.BookManagement;

namespace LibraryExchangeClient
{
    public partial class AddAuthor : Form
    {
        private Library_Exchange mainForm;

        public AddAuthor(Library_Exchange mainForm)
        {
            InitializeComponent();
            this.mainForm = mainForm;
        }

        private void btnAddAuthor_Click(object sender, EventArgs e)
        {
            Author author = new Author();
            author.FirstName = txtFirstName.Text;
            author.LastName = txtLastName.Text;
            DateTime birth = dtpBirthYear.Value;
            DateTime death = dtpDeathYear.Value;
            author.BornDate = birth.ToString();
            author.DeathDate = death.ToString();

            try
            {
                OperationResult or = mainForm.WebServiceProxy.AddAuthor(author, mainForm.UserName, mainForm.Guid);
                if (or.Error.Equals(OperationResultErrorEnum.None))
                {
                    MessageBox.Show("Author successfully added!");
                    this.Close();
                }
                else
                {
                    MessageBox.Show(or.ErrorString);
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Some error occured during adding author.");
            }
        }

        private void AddAuthor_Load(object sender, EventArgs e)
        {

        }

        private void dtpBirthYear_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dtpDeathYear_ValueChanged(object sender, EventArgs e)
        {

        }

        private void txtFirstName_TextChanged(object sender, EventArgs e)
        {

        }
    }
    //public string FirstName;
    //    public string LastName;
    //    public DateTime BornDate;
    //    public DateTime DeathDate;
}