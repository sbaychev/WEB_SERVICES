using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LibraryExchangeClient.BookOfInterest;

namespace LibraryExchangeClient
{
    public partial class MyBooksOfInterest : Form
    {
        private Library_Exchange mainForm;

        public MyBooksOfInterest(Library_Exchange mainForm)
        {
            InitializeComponent();

            this.mainForm = mainForm;

            SetGridColumns();

            try
            {
                List<Book> booksOfInterest = BookOfInterestServ.GetInstance().GetAllBooksOfInterestByUser(mainForm.UserName, mainForm.Guid);
                gridViewBooks.DataSource = booksOfInterest;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Some internal error occured during getting data for user`s books of interest.");
            }
        }

        private void SetGridColumns()
        {
            gridViewBooks.AutoGenerateColumns = false;
            gridViewBooks.ScrollBars = ScrollBars.Vertical;
            DataGridViewTextBoxColumn dgvcTitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            dgvcTitle.DataPropertyName = "Title";
            dgvcTitle.Name = "Title";
            dgvcTitle.HeaderText = "Title";
            dgvcTitle.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            gridViewBooks.Columns.Add(dgvcTitle);
            DataGridViewTextBoxColumn dgvcAuthor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            dgvcAuthor.DataPropertyName = "AuthorName";
            dgvcAuthor.Name = "AuthorName";
            dgvcAuthor.HeaderText = "Author";
            dgvcAuthor.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            gridViewBooks.Columns.Add(dgvcAuthor);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (BookOfInterestServ.GetInstance().AddBookOfInterest(
                mainForm.UserName,
                mainForm.Guid,
                txtTitle.Text,
                txtAuthor.Text))
            {
                MessageBox.Show("Book of interest successfully added");

                try
                {
                    List<Book> booksOfInterest = BookOfInterestServ.GetInstance().GetAllBooksOfInterestByUser(mainForm.UserName, mainForm.Guid);
                    gridViewBooks.DataSource = booksOfInterest;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Some internal error occured during getting data for user`s books of interest.");
                }
            }
            else
            {
                MessageBox.Show("Some problem occured during adding book of interest");
            }
        }

        private void gridViewBooks_DoubleClick(object sender, System.EventArgs e)
        {
            Book item = ((DataGridView)sender).Rows[(int)((DataGridView)sender).CurrentCell.RowIndex].DataBoundItem as Book;

            try
            {
                List<User> users = BookOfInterestServ.GetInstance().CheckBookOfInterest(mainForm.UserName, mainForm.Guid, item.BookId);
                StringBuilder sb = new StringBuilder();
                if (users == null || users.Count == 0)
                {
                    sb.Append("No users have this book");
                }
                else
                {
                    sb.Append("Users which have this book:\n");
                    foreach (User user in users)
                    {
                        sb.Append("First Name: ").Append(user.FirstName).Append("\n");
                        sb.Append("Last Name: ").Append(user.LastName).Append("\n");
                        sb.Append("Address: ").Append(user.Location.Country).Append(" ").Append(user.Location.City)
                            .Append(" ").Append(user.Location.PostCode).Append(" ").Append(user.Location.Address).Append("\n");
                        sb.Append("Phone: ").Append(user.Phone).Append("\n");
                        sb.Append("Email: ").Append(user.Email).Append("\n\n");
                    }
                }
                MessageBox.Show(sb.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Some internal error occured during checking for book of interest existance");
            }
        }
    }
}
