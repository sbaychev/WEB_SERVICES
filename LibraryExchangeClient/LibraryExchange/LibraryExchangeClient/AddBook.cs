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
        BookManagement.BookManagementClient bookmanage = new BookManagementClient();
        public AddBook()
        {
            InitializeComponent();

            BookManagement.BookManagementClient proxy = new BookManagement.BookManagementClient();

            LibraryExchangeClient.BookManagement.OperationResultSetOfstring booktypes = new LibraryExchangeClient.BookManagement.OperationResultSetOfstring();
                
            booktypes = proxy.GetAllTypes();

            comboBox1Type.DataSource = booktypes.ResultSet;
            comboBox1Type.Refresh();

            LibraryExchangeClient.BookManagement.OperationResultSetOfstring bookgenres = proxy.GetAllGenres();

            comboBox2Genre.DataSource = bookgenres.ResultSet;
            comboBox2Genre.Refresh();

            LibraryExchangeClient.BookManagement.OperationResultSetOfAuthorUcBWdBTS bookauthors = proxy.GetAllAuthors();
               
            comboBox1Author.DataSource = bookauthors.ResultSet;         
            comboBox1Author.Refresh();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1Type_SelectedIndexChanged(object sender, EventArgs e)
        {
            //System.Diagnostics.Debug.WriteLine
            //MessageBox.Show(((LibraryExchangeClient.BookManagement.Type)comboBox1Type.SelectedItem).Name.ToString());
            //KeyValuePair<string, string> selectedPair = (KeyValuePair<string, string>)comboBox1Type.SelectedItem.Name.ToString();
            //MessageBox.Show(selectedPair.Key);
            //MessageBox.Show(selectedPair.Value);
        }

        private void comboBox2Genre_SelectedIndexChanged(object sender, EventArgs e)
        {
            //System.Diagnostics.Debug.WriteLine(((Genre)comboBox2Genre.SelectedItem).Name.ToString());
        }

        private void textBox1Title_TextChanged(object sender, EventArgs e)
        {
            string textBoxContents = textBox1Title.Text;
           
        }

        private void textBox2Author_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4Year_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5ISBN_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
           Book book = new Book();

           book.Title = textBox1Title.Text;
           book.Author = (Author)comboBox1Author.SelectedItem;
           book.Genre = comboBox2Genre.SelectedItem.ToString();
           book.Type = comboBox1Type.SelectedItem.ToString();
           book.Year = int.Parse(textBox4Year.Text);
           book.Isbn = textBox5ISBN.Text;
           book.Reserved = false;
           //user = new User();
           //user.UserName = username;
           //book.User = user;
           //978-3-16-148410-0
           ISBNService.ISBNService oService = new ISBNService.ISBNService();
           bool res = oService.IsValidISBN13(textBox5ISBN.Text);
           if (!res)
               MessageBox.Show("Invalid format of the 13 digit ISBN. Example: 978-3-16-148410-0, try again!!");
           else
           {
               //MessageBox.Show("Result:  ISBN");
               bookmanage.AddBook(book);
           }
        }

        private void comboBox1Author_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1Author_CheckedChanged(object sender, EventArgs e)
        {
           AddAuthor addAuthorForm = new AddAuthor();
           addAuthorForm.FormClosed += new FormClosedEventHandler(addAuthorForm_FormClosed);
           addAuthorForm.ShowDialog();
           //this.Hide();
        }
        private void addAuthorForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }
    }
}
