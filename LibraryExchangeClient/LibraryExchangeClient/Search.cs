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
    public partial class Search : Form
    {
        private Library_Exchange mainForm;

        public Search(Library_Exchange mainForm)
        {
            InitializeComponent();
            this.mainForm = mainForm;
            SetGridColumns();
            try
            {
                OperationResultSetOfBookUcBWdBTS books = mainForm.WebServiceProxy.GetAllBooks(mainForm.UserName, mainForm.Guid);
                gridViewBooks.DataSource = readBooks(books);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Some internal error occured during getting data for all books.");
            }
            
            SetSearchBoxesState();
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
            dgvcIsbn.HeaderText = "ISBN";
            dgvcIsbn.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            gridViewBooks.Columns.Add(dgvcIsbn);
        }

        private void SetSearchBoxesState()
        {
            textBox1Author.Text = "";
            textBox1Author.Enabled = false;
            textBox1Title.Text = "";
            textBox1Title.Enabled = false;
            textBox2Type.Text = "";
            textBox2Type.Enabled = false;
            textBox3Genre.Text = "";
            textBox3Genre.Enabled = false;

            if (radioButton1Author.Checked)
            {
                textBox1Author.Enabled = true;
            }
            else if (radioButton2Title.Checked)
            {
                textBox1Title.Enabled = true;
            }
            else if (radioButton3Type.Checked)
            {
                textBox2Type.Enabled = true;
            }
            else if (radioButton4Genre.Checked)
            {
                textBox3Genre.Enabled = true;
            }
        }

        private void gridViewBooks_DoubleClick(object sender, System.EventArgs e)
        {
            BookDataSource item = ((DataGridView)sender).Rows[(int)((DataGridView)sender).CurrentCell.RowIndex].DataBoundItem as BookDataSource;

            ReserveBookForm form = new ReserveBookForm(item, mainForm);
            form.ShowDialog();

            try
            {
                OperationResultSetOfBookUcBWdBTS books = mainForm.WebServiceProxy.GetAllBooks(mainForm.UserName, mainForm.Guid);
                gridViewBooks.DataSource = readBooks(books);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Some internal error occured during getting data for all books.");
            }
        }

        private List<BookDataSource> readBooks(OperationResultSetOfBookUcBWdBTS books)
        {
            if (books.Error.Equals(OperationResultErrorEnum.None))
            {
                List<BookDataSource> result = new List<BookDataSource>();
                foreach(Book book in books.ResultSet.ToList<Book>())
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

        private void button1Search_Click(object sender, EventArgs e)
        {
            if (radioButton1Author.Checked)
            {
                try
                {
                    LibraryExchangeClient.BookManagement.OperationResultSetOfBookUcBWdBTS search = mainForm.WebServiceProxy.GetAllBooksByAuthor(textBox1Author.Text, mainForm.UserName, mainForm.Guid);
                    gridViewBooks.DataSource = readBooks(search);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Some internal error occured during getting data for books by author.");
                }
            }
            else if (radioButton2Title.Checked)
            {
                try
                {
                    LibraryExchangeClient.BookManagement.OperationResultSetOfBookUcBWdBTS search = mainForm.WebServiceProxy.GetAllBooksByTitle(textBox1Title.Text, mainForm.UserName, mainForm.Guid);
                    gridViewBooks.DataSource = readBooks(search);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Some internal error occured during getting data for books by title.");
                }
            }
            else if (radioButton3Type.Checked)
            {
                try
                {
                    LibraryExchangeClient.BookManagement.OperationResultSetOfBookUcBWdBTS search = mainForm.WebServiceProxy.GetAllBooksByType(textBox2Type.Text, mainForm.UserName, mainForm.Guid);
                    gridViewBooks.DataSource = readBooks(search);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Some internal error occured during getting data for books by type.");
                }
            }
            else if (radioButton4Genre.Checked)
            {
                try
                {
                    LibraryExchangeClient.BookManagement.OperationResultSetOfBookUcBWdBTS search = mainForm.WebServiceProxy.GetAllBooksByGenre(textBox3Genre.Text, mainForm.UserName, mainForm.Guid);
                    gridViewBooks.DataSource = readBooks(search);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Some internal error occured during getting data for books by genre.");
                }
            }
            else if (radioButton5None.Checked)
            {
                try
                {
                    LibraryExchangeClient.BookManagement.OperationResultSetOfBookUcBWdBTS search = mainForm.WebServiceProxy.GetAllBooks(mainForm.UserName, mainForm.Guid);
                    gridViewBooks.DataSource = readBooks(search);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Some internal error occured during getting data for all books.");
                }
            }
        }

        private void radioButton_CheckedChanged(object sender, EventArgs e)
        {
            SetSearchBoxesState();
        }
    }
}