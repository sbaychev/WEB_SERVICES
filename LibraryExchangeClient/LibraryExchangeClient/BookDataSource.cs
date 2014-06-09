using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryExchangeClient.BookManagement;

namespace LibraryExchangeClient
{
    public class BookDataSource
    {
        private Book book;

        public BookDataSource(Book book)
        {
            this.book = book;
        }

        public Book Book
        {
            get { return book; }
        }

        public string Title 
        {
            get { return book.Title; }
        }

        public string Author
        {
            get { return book.Author.AuthorInfo; }
        }

        public string Genre
        {
            get { return book.Genre; }
        }

        public string Type
        {
            get { return book.Type; }
        }

        public string Year
        {
            get { return book.Year.ToString(); }
        }

        public string Isbn
        {
            get { return book.Isbn; }
        }

        public bool Reserved
        {
            get { return book.Reserved; }
        }
    }
}
