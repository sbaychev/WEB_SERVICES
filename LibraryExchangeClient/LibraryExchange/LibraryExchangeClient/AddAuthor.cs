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
        BookManagementClient bookclient = new BookManagementClient();
        public AddAuthor()
        {
            InitializeComponent();
        }

        private void button1AddAuthor_Click(object sender, EventArgs e)
        {
            Author author = new Author();
            author.FirstName = textBox1FirstName.Text;
            author.LastName = textBox2LastName.Text;
            DateTime birth = dateTimePicker1BirthYear.Value;
            DateTime death = dateTimePickerDeathYear.Value;
            author.BornDate = birth;
            author.DeathDate = death;

            bookclient.AddAuthor(author);
        }

        private void AddAuthor_Load(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1BirthYear_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePickerDeathYear_ValueChanged(object sender, EventArgs e)
        {

        }

        private void textBox1FirstName_TextChanged(object sender, EventArgs e)
        {

        }
    }
    //public string FirstName;
    //    public string LastName;
    //    public DateTime BornDate;
    //    public DateTime DeathDate;
}