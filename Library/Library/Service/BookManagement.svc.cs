using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Text;
using System.Threading;
using Library.Database;
using Library.Models;
using System.Data.SqlClient;
using System.Data;

namespace Library.Service
{
    [AspNetCompatibilityRequirements(RequirementsMode=AspNetCompatibilityRequirementsMode.Required)]
    public class BookManagement : Library.Interfaces.IBookManagement
    {
        public BookManagement()
        {
        }

        private bool CheckAuthenticated(string userName, string guid)
        {
            try
            {
                using (UserData userData = new UserData())
                {
                    if (userData.CheckUserAuthenticated(userName, guid))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        [OperationBehavior(TransactionScopeRequired = true)]
        public OperationResult AddAuthor(Author author, string userName, string guid)
        {
            if (!CheckAuthenticated(userName, guid))
            {
                return new OperationResult(Library.Models.OperationResult.ErrorEnum.NotAuthenticated,
                    "Please authenticate first!");
            }
            if (author == null || !author.Validate())
            {
                return new OperationResult(Library.Models.OperationResult.ErrorEnum.InvalidInputData, "Invalid first name or last name");
            }
            try
            {
                using (AuthorData authorData = new AuthorData())
                {
                    authorData.AddAuthor(author);
                    return new OperationResult();
                }
            }
            catch (Exception ex)
            {
                return new OperationResult(Library.Models.OperationResult.ErrorEnum.InternalProblem, "Some internal problem has occured");
            }
        }

        [OperationBehavior(TransactionScopeRequired = true)]
        public OperationResult AddBook(Book book, string userName, string guid)
        {
            if (!CheckAuthenticated(userName, guid))
            {
                return new OperationResult(Library.Models.OperationResult.ErrorEnum.NotAuthenticated,
                    "Please authenticate first!");
            }
            if (book == null || !book.Validate())
            {
                return new OperationResult(Library.Models.OperationResult.ErrorEnum.InvalidInputData, "Invalid or missing book data");
            }
            try
            {
                using (BookData bookData = new BookData())
                {
                    bookData.AddBook(book);
                    return new OperationResult();
                }
            }
            catch (Exception ex)
            {
                return new OperationResult(Library.Models.OperationResult.ErrorEnum.InternalProblem, "Some internal problem has occured");
            }
        }

        [OperationBehavior(TransactionScopeRequired = true)]
        public OperationResult EditBook(Book book, string userName, string guid)
        {
            if (!CheckAuthenticated(userName, guid))
            {
                return new OperationResult(Library.Models.OperationResult.ErrorEnum.NotAuthenticated,
                    "Please authenticate first!");
            }
            if (book == null || !book.ValidateEdit())
            {
                return new OperationResult(Library.Models.OperationResult.ErrorEnum.InvalidInputData, "Invalid or missing book data");
            }
            try
            {
                using (BookData bookData = new BookData())
                {
                    bookData.EditBook(book);
                    return new OperationResult();
                }
            }
            catch (Exception ex)
            {
                return new OperationResult(Library.Models.OperationResult.ErrorEnum.InternalProblem, "Some internal problem has occured");
            }
        }

        [OperationBehavior(TransactionScopeRequired = true)]
        public OperationResult AddBookOfInterest(BookOfInterest book, string userName, string guid)
        {
            if (!CheckAuthenticated(userName, guid))
            {
                return new OperationResult(Library.Models.OperationResult.ErrorEnum.NotAuthenticated,
                    "Please authenticate first!");
            }
            if (book == null || !book.Validate())
            {
                return new OperationResult(Library.Models.OperationResult.ErrorEnum.InvalidInputData, "Invalid or missing book data");
            }
            try
            {
                using (BookOfInterestData bookData = new BookOfInterestData())
                {
                    bookData.AddBookOfInterest(book);
                    return new OperationResult();
                }
            }
            catch (Exception ex)
            {
                return new OperationResult(Library.Models.OperationResult.ErrorEnum.InternalProblem, "Some internal problem has occured");
            }
        }

        [OperationBehavior(TransactionScopeRequired = true)]
        public OperationResultSet<Book> CheckBookOfInterest(int bookid, string userName, string guid)
        {
            if (!CheckAuthenticated(userName, guid))
            {
                return new OperationResultSet<Book>(Library.Models.OperationResult.ErrorEnum.NotAuthenticated,
                    "Please authenticate first!");
            }
            using (BookData dataProvider = new BookData())
            {
                try
                {
                    Book[] result = dataProvider.CheckBookOfInterest(bookid);
                    if (result == null)
                    {
                        return new OperationResultSet<Book>(new List<Book>());
                    }
                    return new OperationResultSet<Book>(new List<Book>(result));
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine("BookManagement : CheckBookOfInterest : " + ex.StackTrace);
                    return new OperationResultSet<Book>(Library.Models.OperationResult.ErrorEnum.InternalProblem, "Some internal problem has occured");
                }
            }
        }

        [OperationBehavior(TransactionScopeRequired = true)]
        public OperationResultSet<BookOfInterest> GetAllBooksOfInterest(string userName, string guid)
        {
            if (!CheckAuthenticated(userName, guid))
            {
                return new OperationResultSet<BookOfInterest>(Library.Models.OperationResult.ErrorEnum.NotAuthenticated,
                    "Please authenticate first!");
            }
            using (BookOfInterestData dataProvider = new BookOfInterestData())
            {
                try
                {
                    OperationResultSet<BookOfInterest> booksOfInterest = new OperationResultSet<BookOfInterest>(new List<BookOfInterest>(dataProvider.GetAllBooksOfInterest()));
                    return booksOfInterest;
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine("BookManagement : GetAllBooksOfInterest : " + ex.StackTrace);
                    return new OperationResultSet<BookOfInterest>(Library.Models.OperationResult.ErrorEnum.InternalProblem, "Some internal problem has occured");
                }
            }
        }

        [OperationBehavior(TransactionScopeRequired = true)]
        public OperationResultSet<BookOfInterest> GetAllBooksOfInterestByUser(string userName, string guid)
        {
            if (!CheckAuthenticated(userName, guid))
            {
                return new OperationResultSet<BookOfInterest>(Library.Models.OperationResult.ErrorEnum.NotAuthenticated,
                    "Please authenticate first!");
            }
            using (BookOfInterestData dataProvider = new BookOfInterestData())
            {
                try
                {
                    OperationResultSet<BookOfInterest> booksOfInterest = new OperationResultSet<BookOfInterest>(new List<BookOfInterest>(dataProvider.GetAllBooksOfInterestByUser(userName)));
                    return booksOfInterest;
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine("BookManagement : GetAllBooksOfInterest : " + ex.StackTrace);
                    return new OperationResultSet<BookOfInterest>(Library.Models.OperationResult.ErrorEnum.InternalProblem, "Some internal problem has occured");
                }
            }
        }

        [OperationBehavior(TransactionScopeRequired = true)]
        public OperationResult ReserveBook(Book book, string userName, string guid)
        {
            if (!CheckAuthenticated(userName, guid))
            {
                return new OperationResult(Library.Models.OperationResult.ErrorEnum.NotAuthenticated,
                    "Please authenticate first!");
            }
            string validationError = book.ValidateReservation();
            if (book == null || !validationError.Equals(""))
            {
                return new OperationResult(Library.Models.OperationResult.ErrorEnum.InvalidInputData, validationError);
            }
            try
            {
                using (BookData bookData = new BookData())
                {
                    bookData.SetBookReservedState(book.BookId, true);
                    return new OperationResult();
                }
            }
            catch (Exception ex)
            {
                return new OperationResult(Library.Models.OperationResult.ErrorEnum.InternalProblem, "Some internal problem has occured");
            }
        }

        /*[OperationBehavior(TransactionScopeRequired = true)]
        public OperationResult ReleaseBook(Book book, string userName, string guid)
        {
            if (!CheckAuthenticated(userName, guid))
            {
                return new OperationResult(Library.Models.OperationResult.ErrorEnum.NotAuthenticated,
                    "Please authenticate first!");
            }
            string validationError = book.ValidateRelease();
            if (!validationError.Equals(""))
            {
                return new OperationResult(Library.Models.OperationResult.ErrorEnum.InvalidInputData, validationError);
            }
            try
            {
                using (BookData bookData = new BookData())
                {
                    bookData.SetBookReservedState(book.BookId, false);
                    return new OperationResult();
                }
            }
            catch (Exception ex)
            {
                return new OperationResult(Library.Models.OperationResult.ErrorEnum.InternalProblem, "Some internal problem has occured");
            }
        }*/

        [OperationBehavior(TransactionScopeRequired = true)]
        public OperationResultSet<Author> GetAllAuthors(string userName, string guid)
        {
            if (!CheckAuthenticated(userName, guid))
            {
                return new OperationResultSet<Author>(Library.Models.OperationResult.ErrorEnum.NotAuthenticated,
                    "Please authenticate first!");
            }
            using (AuthorData dataProvider = new AuthorData())
            {
                try
                {
                    OperationResultSet<Author> authors = new OperationResultSet<Author>(new List<Author>(dataProvider.GetAllAuthors()));
                    return authors;
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine("BookManagement : GetAllAuthors : " + ex.StackTrace);
                    return new OperationResultSet<Author>(Library.Models.OperationResult.ErrorEnum.InternalProblem, "Some internal problem has occured");
                }
            }
        }

        /*[OperationBehavior(TransactionScopeRequired = true)]
        public OperationResultSet<User> GetAllUsers(string userName, string guid)
        {
            if (!CheckAuthenticated(userName, guid))
            {
                return new OperationResultSet<User>(Library.Models.OperationResult.ErrorEnum.NotAuthenticated,
                    "Please authenticate first!");
            }
            using (UserData dataProvider = new UserData())
            {
                try
                {
                    List<User> user = new List<User>();
                    user.Add(dataProvider.GetUserByUserName("alex"));
                    return new OperationResultSet<User>(user);
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine("BookManagement : GetAllAuthors : " + ex.StackTrace);
                    return new OperationResultSet<User>(Library.Models.OperationResult.ErrorEnum.InternalProblem, "Some internal problem has occured");
                }
            }
        }*/

        [OperationBehavior(TransactionScopeRequired = true)]
        public OperationResultSet<string> GetAllTypes(string userName, string guid)
        {
            if (!CheckAuthenticated(userName, guid))
            {
                return new OperationResultSet<string>(Library.Models.OperationResult.ErrorEnum.NotAuthenticated,
                    "Please authenticate first!");
            }
            using (TypeData dataProvider = new TypeData())
            {
                try
                {
                    string[] result = dataProvider.GetAllTypes();
                    if (result == null)
                    {
                        return new OperationResultSet<string>(new List<string>());
                    }
                    return new OperationResultSet<string>(new List<string>(result));
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine("BookManagement : GetAllTypes : " + ex.StackTrace);
                    return new OperationResultSet<string>(Library.Models.OperationResult.ErrorEnum.InternalProblem, "Some internal problem has occured");
                }
            }
        }

        [OperationBehavior(TransactionScopeRequired = true)]
        public OperationResultSet<string> GetAllGenres(string userName, string guid)
        {
            if (!CheckAuthenticated(userName, guid))
            {
                return new OperationResultSet<string>(Library.Models.OperationResult.ErrorEnum.NotAuthenticated,
                    "Please authenticate first!");
            }
            using (GenreData dataProvider = new GenreData())
            {
                try
                {
                    string[] result = dataProvider.GetAllGenres();
                    if (result == null)
                    {
                        return new OperationResultSet<string>(new List<string>());
                    }
                    return new OperationResultSet<string>(new List<string>(result));
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine("BookManagement : GetAllGenres : " + ex.StackTrace);
                    return new OperationResultSet<string>(Library.Models.OperationResult.ErrorEnum.InternalProblem, "Some internal problem has occured");
                }
            }
        }

        [OperationBehavior(TransactionScopeRequired = true)]
        public OperationResultSet<Book> GetAllBooks(string userName, string guid)
        {
            if (!CheckAuthenticated(userName, guid))
            {
                return new OperationResultSet<Book>(Library.Models.OperationResult.ErrorEnum.NotAuthenticated,
                    "Please authenticate first!");
            }
            using (BookData dataProvider = new BookData())
            {
                try
                {
                    Book[] result = dataProvider.GetAllBooks();
                    if (result == null)
                    {
                        return new OperationResultSet<Book>(new List<Book>());
                    }
                    return new OperationResultSet<Book>(new List<Book>(result));
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine("BookManagement : GetAllBooks : " + ex.StackTrace);
                    return new OperationResultSet<Book>(Library.Models.OperationResult.ErrorEnum.InternalProblem, "Some internal problem has occured");
                }
            }
        }

        [OperationBehavior(TransactionScopeRequired = true)]
        public OperationResultSet<Book> GetAllBooksByYear(int year, string userName, string guid)
        {
            if (!CheckAuthenticated(userName, guid))
            {
                return new OperationResultSet<Book>(Library.Models.OperationResult.ErrorEnum.NotAuthenticated,
                    "Please authenticate first!");
            }
            using (BookData dataProvider = new BookData())
            {
                try
                {
                    Book[] result = dataProvider.GetAllBooksByYear(year);
                    if (result == null)
                    {
                        return new OperationResultSet<Book>(new List<Book>());
                    }
                    return new OperationResultSet<Book>(new List<Book>(result));
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine("BookManagement : GetAllBooksByYear : " + ex.StackTrace);
                    return new OperationResultSet<Book>(Library.Models.OperationResult.ErrorEnum.InternalProblem, "Some internal problem has occured");
                }
            }
        }

        [OperationBehavior(TransactionScopeRequired = true)]
        public OperationResultSet<Book> GetAllBooksByTitle(string title, string userName, string guid)
        {
            if (!CheckAuthenticated(userName, guid))
            {
                return new OperationResultSet<Book>(Library.Models.OperationResult.ErrorEnum.NotAuthenticated,
                    "Please authenticate first!");
            }
            if (String.IsNullOrEmpty(title))
            {
                return new OperationResultSet<Book>(Library.Models.OperationResult.ErrorEnum.InvalidInputData, "Invalid or missing book title");
            }
            using (BookData dataProvider = new BookData())
            {
                try
                {
                    Book[] result = dataProvider.GetAllBooksByTitle(title);
                    if (result == null)
                    {
                        return new OperationResultSet<Book>(new List<Book>());
                    }
                    return new OperationResultSet<Book>(new List<Book>(result));
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine("BookManagement : GetAllBooksByTitle : " + ex.StackTrace);
                    return new OperationResultSet<Book>(Library.Models.OperationResult.ErrorEnum.InternalProblem, "Some internal problem has occured");
                }
            }
        }

        [OperationBehavior(TransactionScopeRequired = true)]
        public OperationResultSet<Book> GetAllBooksByAuthor(string authorName, string userName, string guid)
        {
            if (!CheckAuthenticated(userName, guid))
            {
                return new OperationResultSet<Book>(Library.Models.OperationResult.ErrorEnum.NotAuthenticated,
                    "Please authenticate first!");
            }
            if (String.IsNullOrEmpty(authorName))
            {
                return new OperationResultSet<Book>(Library.Models.OperationResult.ErrorEnum.InvalidInputData, "Invalid or missing book author name");
            }
            using (BookData dataProvider = new BookData())
            {
                try
                {
                    Book[] result = dataProvider.GetAllBooksByAuthor(authorName);
                    if (result == null)
                    {
                        return new OperationResultSet<Book>(new List<Book>());
                    }
                    return new OperationResultSet<Book>(new List<Book>(result));
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine("BookManagement : GetAllBooksByAuthor : " + ex.StackTrace);
                    return new OperationResultSet<Book>(Library.Models.OperationResult.ErrorEnum.InternalProblem, "Some internal problem has occured");
                }
            }
        }

        [OperationBehavior(TransactionScopeRequired = true)]
        public OperationResultSet<Book> GetAllBooksByUser(string userName, string guid)
        {
            if (!CheckAuthenticated(userName, guid))
            {
                return new OperationResultSet<Book>(Library.Models.OperationResult.ErrorEnum.NotAuthenticated,
                    "Please authenticate first!");
            }
            using (BookData dataProvider = new BookData())
            {
                try
                {
                    Book[] result = dataProvider.GetAllBooksByUser(userName);
                    if (result == null)
                    {
                        return new OperationResultSet<Book>(new List<Book>());
                    }
                    return new OperationResultSet<Book>(new List<Book>(result));
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine("BookManagement : GetAllBooksByUser : " + ex.StackTrace);
                    return new OperationResultSet<Book>(Library.Models.OperationResult.ErrorEnum.InternalProblem, "Some internal problem has occured");
                }
            }
        }

        [OperationBehavior(TransactionScopeRequired = true)]
        public OperationResultSet<Book> GetAllBooksByGenre(string genre, string userName, string guid)
        {
            if (!CheckAuthenticated(userName, guid))
            {
                return new OperationResultSet<Book>(Library.Models.OperationResult.ErrorEnum.NotAuthenticated,
                    "Please authenticate first!");
            }
            if (String.IsNullOrEmpty(genre))
            {
                return new OperationResultSet<Book>(Library.Models.OperationResult.ErrorEnum.InvalidInputData, "Invalid or missing book genre");
            }
            using (BookData dataProvider = new BookData())
            {
                try
                {
                    Book[] result = dataProvider.GetAllBooksByGenre(genre);
                    if (result == null)
                    {
                        return new OperationResultSet<Book>(new List<Book>());
                    }
                    return new OperationResultSet<Book>(new List<Book>(result));
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine("BookManagement : GetAllBooksByGenre : " + ex.StackTrace);
                    return new OperationResultSet<Book>(Library.Models.OperationResult.ErrorEnum.InternalProblem, "Some internal problem has occured");
                }
            }
        }
        [OperationBehavior(TransactionScopeRequired = true)]
        public OperationResultValue<string> AddUser(User user)
        {
            SqlConnection connection =
          new SqlConnection("Data Source=AJLEKC-PC;Initial Catalog=SOA;Persist Security Info=True;User ID=sa;Password=tgbyhn;Trusted_Connection=True;");

            connection.Open();
            SqlCommand cmd = new SqlCommand("add_user", connection);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@country", user.Location.Country);
            cmd.Parameters.AddWithValue("@city", user.Location.City);
            cmd.Parameters.AddWithValue("@postcode", user.Location.PostCode);
            cmd.Parameters.AddWithValue("@address", user.Location.Address);

            cmd.Parameters.AddWithValue("@user_name", user.UserName);
            cmd.Parameters.AddWithValue("@password", "1234567");
            cmd.Parameters.AddWithValue("@email", user.Email);
            cmd.Parameters.AddWithValue("@first_name", user.FirstName);
            cmd.Parameters.AddWithValue("@last_name", user.LastName);
            cmd.Parameters.AddWithValue("@last_access_time", DateTime.Now);
            cmd.Parameters.AddWithValue("@phone", user.Phone);
            cmd.Parameters.AddWithValue("@access_token", Guid.NewGuid());
            //cmd.Parameters.Add("@ERROR", SqlDbType.Char, 500);
            //cmd.Parameters["@ERROR"].Direction = ParameterDirection.Output;
            cmd.ExecuteNonQuery();
            connection.Close();

            return new OperationResultValue<string>(Guid.NewGuid().ToString());
        }

        [OperationBehavior(TransactionScopeRequired = true)]
        public OperationResultSet<Book> GetAllBooksByType(string type, string userName, string guid)
        {
            if (!CheckAuthenticated(userName, guid))
            {
                return new OperationResultSet<Book>(Library.Models.OperationResult.ErrorEnum.NotAuthenticated,
                    "Please authenticate first!");
            }
            if (String.IsNullOrEmpty(type))
            {
                return new OperationResultSet<Book>(Library.Models.OperationResult.ErrorEnum.InvalidInputData, "Invalid or missing book type");
            }
            using (BookData dataProvider = new BookData())
            {
                try
                {
                    Book[] result = dataProvider.GetAllBooksByType(type);
                    if (result == null)
                    {
                        return new OperationResultSet<Book>(new List<Book>());
                    }
                    return new OperationResultSet<Book>(new List<Book>(result));
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine("BookManagement : GetAllBooksByType : " + ex.StackTrace);
                    return new OperationResultSet<Book>(Library.Models.OperationResult.ErrorEnum.InternalProblem, "Some internal problem has occured");
                }
            }
        }
    }
}
