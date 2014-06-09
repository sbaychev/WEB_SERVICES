using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using Library.Database;

namespace Library.Models
{
    [DataContract(Namespace = "http://localhost/Library.Models")]
    public class Book
    {
        [DataMember]
        public int BookId;

        [DataMember]
        public User User;

        public int UserId;

        [DataMember]
        public string Title;

        [DataMember]
        public Author Author;

        public int AuthorId;

        [DataMember]
        public string Type;

        [DataMember]
        public string Genre;

        [DataMember]
        public int Year;

        [DataMember]
        public string Isbn;

        [DataMember]
        public bool Reserved;

        public string ValidateReservation()
        {
            using (BookData bookData = new BookData())
            {
                Book book = bookData.GetBookById(BookId);
                if (book == null)
                {
                    return "Book with this id does not exist";
                }
                else if (book.Reserved)
                {
                    return "Book already reserved";
                }
                else
                {
                    return "";
                }
            }
        }

        public string ValidateRelease()
        {
            using (BookData bookData = new BookData())
            {
                Book book = bookData.GetBookById(BookId);
                if (book == null)
                {
                    return "Book with this id does not exist";
                }
                else if (!book.Reserved)
                {
                    return "Book not reserved";
                }
                else
                {
                    return "";
                }
            }
        }

        public bool Validate()
        {
            bool validGenre;
            using (GenreData genreData = new GenreData())
            {
                validGenre = genreData.GetGenreIdByName(Genre) >= 0;
            }

            bool validType;
            using (TypeData typeData = new TypeData())
            {
                validType = typeData.GetTypeIdByName(Type) >= 0;
            }

            bool validAuthorId;
            using (AuthorData authorData = new AuthorData())
            {
                validAuthorId = authorData.GetAuthorById(Author.AuthorId) != null;
            }

            bool validUserName;
            using (UserData userData = new UserData())
            {
                validUserName = userData.GetUserByUserName(User.UserName) != null;
            }

            if (!validGenre ||
                !validType ||
                !validAuthorId ||
                !validUserName ||
                String.IsNullOrEmpty(Title) ||
                Year < 0 ||
                String.IsNullOrEmpty(Isbn))
            {
                return false;
            }
            return true;
        }

        public bool ValidateEdit()
        {
            bool validBookId;
            using (BookData genreData = new BookData())
            {
                validBookId = genreData.GetBookById(BookId) != null;
            }

            bool validGenre;
            using (GenreData genreData = new GenreData())
            {
                validGenre = genreData.GetGenreIdByName(Genre) >= 0;
            }

            bool validType;
            using (TypeData typeData = new TypeData())
            {
                validType = typeData.GetTypeIdByName(Type) >= 0;
            }

            bool validAuthorId;
            using (AuthorData authorData = new AuthorData())
            {
                validAuthorId = authorData.GetAuthorById(Author.AuthorId) != null;
            }

            if (!validGenre ||
                !validType ||
                !validAuthorId ||
                !validBookId ||
                String.IsNullOrEmpty(Title) ||
                Year < 0 ||
                String.IsNullOrEmpty(Isbn))
            {
                return false;
            }
            return true;
        }
    }
}