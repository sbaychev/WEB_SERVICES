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
    public partial class ReserveBookForm : Form
    {
        private BookDataSource info;
        private Library_Exchange mainForm;

        public ReserveBookForm(BookDataSource info, Library_Exchange mainForm)
        {
            InitializeComponent();

            this.info = info;
            this.mainForm = mainForm;

            txtTitle.Text = info.Title;
            txtAuthor.Text = info.Author;
            txtGenre.Text = info.Genre;
            txtType.Text = info.Type;
            txtIsbn.Text = info.Isbn;
            txtYearPublished.Text = info.Year;
            txtOwner.Text = info.Book.User.FirstName + " " + info.Book.User.LastName;
            txtLocation.Text = info.Book.User.Location.Country + " " +
                               info.Book.User.Location.City + " " + 
                               info.Book.User.Location.PostCode + " " +
                               info.Book.User.Location.Address;
        }

        private void btnReserve_Click(object sender, EventArgs e)
        {
            try
            {
                OperationResult result = mainForm.WebServiceProxy.ReserveBook(info.Book, mainForm.UserName, mainForm.Guid);
                if (result.Error.Equals(OperationResultErrorEnum.None))
                {
                    MessageBox.Show("Book successfully reserved");
                    this.Close();
                }
                else
                {
                    MessageBox.Show(result.ErrorString);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Some error occured while reserving book.");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
