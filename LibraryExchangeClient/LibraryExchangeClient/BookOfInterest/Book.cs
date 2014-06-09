using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryExchangeClient.BookOfInterest
{
    public class Book
    {
        public int bookId;
        public string title;
        public string authorName;

        public User User;

        public int BookId
        {
            get { return bookId; }
            set
            {
                bookId = value;
            }
        }

        public string Title
        {
            get { return title; }
            set
            {
                title = value;
            }
        }

        public string AuthorName
        {
            get { return authorName; }
            set
            {
                authorName = value;
            }
        }
    }
}
