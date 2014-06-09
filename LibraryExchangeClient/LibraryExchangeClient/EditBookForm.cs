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
    public partial class EditBookForm : Form
    {
        private BookDataSource book;
        private Library_Exchange mainForm;

        public EditBookForm(BookDataSource book, Library_Exchange mainForm)
        {
            InitializeComponent();

            this.mainForm = mainForm;
            this.book = book;

            txtIsbn.Text = book.Isbn;
            txtTitle.Text = book.Title;
            txtYearPublished.Text = book.Year;

            try
            {
                LibraryExchangeClient.BookManagement.OperationResultSetOfstring booktypes = mainForm.WebServiceProxy.GetAllTypes(mainForm.UserName, mainForm.Guid);
                cmbType.DataSource = booktypes.ResultSet;
                cmbType.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Some internal error occured during getting data for book types.");
            }
            cmbType.Text = book.Type;  

            try
            {
                LibraryExchangeClient.BookManagement.OperationResultSetOfstring bookgenres = mainForm.WebServiceProxy.GetAllGenres(mainForm.UserName, mainForm.Guid);
                cmbGenre.DataSource = bookgenres.ResultSet;
                cmbGenre.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Some internal error occured during getting data for genres.");
            }
            cmbGenre.Text = book.Genre;

            try
            {
                LibraryExchangeClient.BookManagement.OperationResultSetOfAuthorUcBWdBTS bookauthors = mainForm.WebServiceProxy.GetAllAuthors(mainForm.UserName, mainForm.Guid);
                cmbAuthor.DataSource = bookauthors.ResultSet;
                cmbAuthor.DisplayMember = "AuthorInfo";
                cmbAuthor.ValueMember = "AuthorInfo";
                cmbAuthor.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Some internal error occured during getting data for authors.");
            }
            cmbAuthor.Text = book.Book.Author.AuthorInfo;

            if (book.Book.Reserved)
            {
                rbtnReservedYes.Checked = true;
            }
            else
            {
                rbtnReservedNo.Checked = true;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            book.Book.Title = txtTitle.Text;
            book.Book.Author = (Author)cmbAuthor.SelectedItem;
            book.Book.Genre = cmbGenre.SelectedItem.ToString();
            book.Book.Type = cmbType.SelectedItem.ToString();
            int year;
            if (!String.IsNullOrEmpty(txtYearPublished.Text) && int.TryParse(txtYearPublished.Text, out year))
            {
                book.Book.Year = year;
                book.Book.YearSpecified = true;
            }
            book.Book.Isbn = txtIsbn.Text;
            book.Book.Reserved = rbtnReservedYes.Checked ? true : false;
            //978-1-4028-9462-6
            bool res = false;
            try
            {
                ISBNService.ISBNService oService = new ISBNService.ISBNService();
                res = oService.IsValidISBN13(txtIsbn.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Some internal error occured during validating book isbn.");
            }
            if (!res)
                MessageBox.Show("Invalid format of the 13 digit ISBN. Example: 978-1-4028-9462-6, try again!!");
            else
            {
                try
                {
                    OperationResult or = mainForm.WebServiceProxy.EditBook(book.Book, mainForm.UserName, mainForm.Guid);
                    if (or.Error.Equals(OperationResultErrorEnum.None))
                    {
                        MessageBox.Show("Book successfully edited!");
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show(or.ErrorString);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Some internal error occured during saving the edited book.");
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
    }
}
