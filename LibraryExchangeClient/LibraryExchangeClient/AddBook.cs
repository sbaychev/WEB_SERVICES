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
using System.Web.UI.WebControls;

namespace LibraryExchangeClient
{
    public partial class AddBook : Form
    {
        private Library_Exchange mainForm;

        public AddBook(Library_Exchange mainForm)
        {
            InitializeComponent();

            this.mainForm = mainForm;

            try
            {
                LibraryExchangeClient.BookManagement.OperationResultSetOfstring booktypes = mainForm.WebServiceProxy.GetAllTypes(mainForm.UserName, mainForm.Guid);
                if (booktypes.Error.Equals(OperationResultErrorEnum.None))
                {
                    cmbType.DataSource = booktypes.ResultSet;
                    cmbType.Refresh();
                }
                else
                {
                    MessageBox.Show(booktypes.ErrorString);
                }

                if (booktypes.Error.Equals(OperationResultErrorEnum.NotAuthenticated))
                {
                    return;
                }

                LibraryExchangeClient.BookManagement.OperationResultSetOfstring bookgenres = mainForm.WebServiceProxy.GetAllGenres(mainForm.UserName, mainForm.Guid);
                if (booktypes.Error.Equals(OperationResultErrorEnum.None))
                {
                    cmbGenre.DataSource = bookgenres.ResultSet;
                    cmbGenre.Refresh();
                }
                else
                {
                    MessageBox.Show(booktypes.ErrorString);
                }

                LibraryExchangeClient.BookManagement.OperationResultSetOfAuthorUcBWdBTS bookauthors = mainForm.WebServiceProxy.GetAllAuthors(mainForm.UserName, mainForm.Guid);

                if (booktypes.Error.Equals(OperationResultErrorEnum.None))
                {
                    cmbAuthor.DataSource = bookauthors.ResultSet;
                    cmbAuthor.DisplayMember = "AuthorInfo";
                    cmbAuthor.Refresh();
                }
                else
                {
                    MessageBox.Show(booktypes.ErrorString);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Some error occured during initializing data");
            }
        }

        private void txtTitle_TextChanged(object sender, EventArgs e)
        {
            string textBoxContents = txtTitle.Text;
        }

        private bool ValidateAdd()
        {
            ErrorProvider errorProvider = new ErrorProvider();
            if (String.IsNullOrEmpty(mainForm.UserName) || String.IsNullOrEmpty(mainForm.Guid))
            {
                MessageBox.Show("Please authenticate first.");
                return false;
            }
            if (String.IsNullOrEmpty(txtTitle.Text))
            {
                errorProvider.SetError(txtTitle, "This field is required.");
                return false;
            }
            if ((Author)cmbAuthor.SelectedItem == null)
            {
                errorProvider.SetError(cmbAuthor, "This field is required.");
                return false;
            }
            if (String.IsNullOrEmpty((string)cmbGenre.SelectedItem))
            {
                errorProvider.SetError(cmbGenre, "This field is required.");
                return false;
            }
            if (String.IsNullOrEmpty((string)cmbType.SelectedItem))
            {
                errorProvider.SetError(cmbType, "This field is required.");
                return false;
            }
            if (String.IsNullOrEmpty(txtIsbn.Text))
            {
                errorProvider.SetError(txtIsbn, "This field is required.");
                return false;
            }
            return true;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!ValidateAdd())
            {
                return;
            }
            Book book = new Book();

            book.Title = txtTitle.Text;
            book.Author = (Author)cmbAuthor.SelectedItem;
            book.Genre = (string)cmbGenre.SelectedItem;
            book.Type = (string)cmbType.SelectedItem;
            int year;
            if (!String.IsNullOrEmpty(txtYearPublished.Text) && int.TryParse(txtYearPublished.Text, out year))
            {
                book.Year = year;
                book.YearSpecified = true;
            }
            book.Isbn = txtIsbn.Text;
            book.Reserved = false;
            User user = new User();
            user.UserName = mainForm.UserName;
            book.User = user;
            //978-1-4028-9462-6
            ISBNService.ISBNService oService = new ISBNService.ISBNService();
            bool res = false;
            try
            {
                res = oService.IsValidISBN13(txtIsbn.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Some error occured while validating book ISBN");
            }
            if (!res)
                MessageBox.Show("Invalid format of the 13 digit ISBN. Example: 978-1-4028-9462-6, try again!!");
            else
            {
                try
                {
                    OperationResult or = mainForm.WebServiceProxy.AddBook(book, mainForm.UserName, mainForm.Guid);
                    if (or.Error.Equals(OperationResultErrorEnum.None))
                    {
                        MessageBox.Show("Book successfully added!");
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show(or.ErrorString);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Some error occured during adding a book.");
                }
            }
        }

        private void chckMissingAuthor_CheckedChanged(object sender, EventArgs e)
        {
           AddAuthor addAuthorForm = new AddAuthor(mainForm);
           addAuthorForm.ShowDialog();
           try
           {
               LibraryExchangeClient.BookManagement.OperationResultSetOfAuthorUcBWdBTS bookauthors = mainForm.WebServiceProxy.GetAllAuthors(mainForm.UserName, mainForm.Guid);

               cmbAuthor.DataSource = bookauthors.ResultSet;
               cmbAuthor.DisplayMember = "AuthorInfo";
               cmbAuthor.Refresh();
           }
           catch (Exception ex)
           {
               MessageBox.Show("Some error occured during initializing authors");
           }
        }

        private void AddBook_Load(object sender, EventArgs e)
        {

        }
    }
}
