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
    public partial class EditBooks : Form
    {
        
        private Library_Exchange mainForm;

        public EditBooks(Library_Exchange mainForm)
        {
            InitializeComponent();

            this.mainForm = mainForm;
            
            SetGridColumns();

            try
            {
                OperationResultSetOfBookUcBWdBTS books = mainForm.WebServiceProxy.GetAllBooksByUser(mainForm.UserName, mainForm.Guid);
                gridViewBooks.DataSource = readBooks(books);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Some error occured during getting all client`s books");
            }
        }

        private List<BookDataSource> readBooks(OperationResultSetOfBookUcBWdBTS books)
        {
            if (books.Error.Equals(OperationResultErrorEnum.None))
            {
                List<BookDataSource> result = new List<BookDataSource>();
                foreach (Book book in books.ResultSet.ToList<Book>())
                {
                    result.Add(new BookDataSource(book));
                }
                return result;
            }
            else
            {
                MessageBox.Show(books.ErrorString);
                return null;
            }
        }

        private void gridViewBooks_DoubleClick(object sender, System.EventArgs e)
        {
            BookDataSource item = ((DataGridView)sender).Rows[(int)((DataGridView)sender).CurrentCell.RowIndex].DataBoundItem as BookDataSource;

            EditBookForm form = new EditBookForm(item, mainForm);
            form.ShowDialog();

            try
            {
                OperationResultSetOfBookUcBWdBTS books = mainForm.WebServiceProxy.GetAllBooksByUser(mainForm.UserName, mainForm.Guid);
                gridViewBooks.DataSource = readBooks(books);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Some error occured during getting all client`s books");
            }
        }

        private void SetGridColumns()
        {
            gridViewBooks.AutoGenerateColumns = false;
            DataGridViewTextBoxColumn dgvcTitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            dgvcTitle.DataPropertyName = "Title";
            dgvcTitle.Name = "Title";
            dgvcTitle.HeaderText = "Title";
            dgvcTitle.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            gridViewBooks.Columns.Add(dgvcTitle);
            DataGridViewTextBoxColumn dgvcAuthor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            dgvcAuthor.DataPropertyName = "Author";
            dgvcAuthor.Name = "Author";
            dgvcAuthor.HeaderText = "Author";
            dgvcAuthor.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            gridViewBooks.Columns.Add(dgvcAuthor);
            DataGridViewTextBoxColumn dgvcType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            dgvcType.DataPropertyName = "Type";
            dgvcType.Name = "Type";
            dgvcType.HeaderText = "Type";
            dgvcType.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            gridViewBooks.Columns.Add(dgvcType);
            DataGridViewTextBoxColumn dgvcGenre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            dgvcGenre.DataPropertyName = "Genre";
            dgvcGenre.Name = "Genre";
            dgvcGenre.HeaderText = "Genre";
            dgvcGenre.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            gridViewBooks.Columns.Add(dgvcGenre);
            DataGridViewTextBoxColumn dgvcYear = new System.Windows.Forms.DataGridViewTextBoxColumn();
            dgvcYear.DataPropertyName = "Year";
            dgvcYear.Name = "Year";
            dgvcYear.HeaderText = "Year";
            dgvcYear.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            gridViewBooks.Columns.Add(dgvcYear);
            DataGridViewTextBoxColumn dgvcIsbn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            dgvcIsbn.DataPropertyName = "Isbn";
            dgvcIsbn.Name = "Isbn";
            dgvcIsbn.HeaderText = "Isbn";
            dgvcIsbn.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            gridViewBooks.Columns.Add(dgvcIsbn);
            DataGridViewTextBoxColumn dgvcReserved = new System.Windows.Forms.DataGridViewTextBoxColumn();
            dgvcReserved.DataPropertyName = "Reserved";
            dgvcReserved.Name = "Reserved";
            dgvcReserved.HeaderText = "Reserved";
            dgvcReserved.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            gridViewBooks.Columns.Add(dgvcReserved);
        }
    }
}
