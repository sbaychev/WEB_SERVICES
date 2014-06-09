using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Library.Models;

namespace Library.Database
{
    internal class BookData : Data<Book>
    {
        internal BookData()
            : base(ConfigurationManager.AppSettings["db.connections.default"])
        {
        }

        public static Book ExtractBook(IDataReader reader)
        {
            Book book = new Book();
            book.BookId = reader.GetInt32(0);
            book.Title = reader.GetString(1);
            book.AuthorId = reader.GetInt32(2);
            book.Type = reader.GetString(3);
            book.Genre = reader.GetString(4);
            book.UserId = reader.GetInt32(5);
            book.Isbn = reader.GetString(6);
            book.Reserved = reader.GetInt32(7) == 1 ? true : false;
            book.Year = reader.IsDBNull(8) ? 0 : reader.GetInt32(8);
            return book;
        }

        internal Book[] GetAllBooks()
        {
            using (SqlConnection connection = connectionFactory.create_connection())
            {
                connection.Open();
                using (SqlTransaction transaction = connection.BeginTransaction(IsolationLevel.ReadCommitted))
                {
                    try
                    {
                        Book[] results;
                        using (SqlCommand command = new SqlCommand("get_all_books", connection, transaction) { CommandType = CommandType.StoredProcedure })
                        {
                            using (IDataReader reader = command.ExecuteReader())
                            {
                                results = base.generate_results(ExtractBook, reader);
                            }
                        }

                        foreach (Book result in results)
                        {
                            using (AuthorData authorData = new AuthorData())
                            {
                                authorData.FromTransaction = true;
                                authorData.Connection = connection;
                                authorData.Transaction = transaction;
                                result.Author = authorData.GetAuthorById(result.AuthorId);
                            }
                            using (UserData userData = new UserData())
                            {
                                userData.FromTransaction = true;
                                userData.Connection = connection;
                                userData.Transaction = transaction;
                                result.User = userData.GetUserById(result.UserId);
                            }
                        }

                        transaction.Commit();
                        return results;
                    }
                    catch (Exception ex)
                    {
                        System.Diagnostics.Debug.WriteLine("BookData : GetAllBooks : " + ex.StackTrace);
                        transaction.Rollback();
                        throw ex;
                    }
                }
            }
        }

        internal Book[] GetAllBooksByYear(int year)
        {
            using (SqlConnection connection = connectionFactory.create_connection())
            {
                connection.Open();
                using (SqlTransaction transaction = connection.BeginTransaction(IsolationLevel.ReadCommitted))
                {
                    try
                    {
                        Book[] results;
                        using (SqlCommand command = new SqlCommand("get_all_books_by_year", connection, transaction) { CommandType = CommandType.StoredProcedure })
                        {
                            command.Parameters.AddWithValue("@year", year);
                            using (IDataReader reader = command.ExecuteReader())
                            {
                                results = base.generate_results(ExtractBook, reader);
                            }
                        }
                        foreach (Book result in results)
                        {
                            using (AuthorData authorData = new AuthorData())
                            {
                                authorData.FromTransaction = true;
                                authorData.Connection = connection;
                                authorData.Transaction = transaction;
                                result.Author = authorData.GetAuthorById(result.AuthorId);
                            }
                            using (UserData userData = new UserData())
                            {
                                userData.FromTransaction = true;
                                userData.Connection = connection;
                                userData.Transaction = transaction;
                                result.User = userData.GetUserById(result.UserId);
                            }
                        }
                        transaction.Commit();
                        return results;
                    }
                    catch (Exception ex)
                    {
                        System.Diagnostics.Debug.WriteLine("BookData : GetAllBooksByYear : " + ex.StackTrace);
                        transaction.Rollback();
                        throw ex;
                    }
                }
            }
        }

        internal Book[] GetAllBooksByTitle(string title)
        {
            using (SqlConnection connection = connectionFactory.create_connection())
            {
                connection.Open();
                using (SqlTransaction transaction = connection.BeginTransaction(IsolationLevel.ReadCommitted))
                {
                    try
                    {
                        Book[] results;
                        using (SqlCommand command = new SqlCommand("get_all_books_by_title", connection, transaction) { CommandType = CommandType.StoredProcedure })
                        {
                            command.Parameters.AddWithValue("@title", title);
                            using (IDataReader reader = command.ExecuteReader())
                            {
                                results = base.generate_results(ExtractBook, reader);
                            }
                        }
                        foreach (Book result in results)
                        {
                            using (AuthorData authorData = new AuthorData())
                            {
                                authorData.FromTransaction = true;
                                authorData.Connection = connection;
                                authorData.Transaction = transaction;
                                result.Author = authorData.GetAuthorById(result.AuthorId);
                            }
                            using (UserData userData = new UserData())
                            {
                                userData.FromTransaction = true;
                                userData.Connection = connection;
                                userData.Transaction = transaction;
                                result.User = userData.GetUserById(result.UserId);
                            }
                        }
                        transaction.Commit();
                        return results;
                    }
                    catch (Exception ex)
                    {
                        System.Diagnostics.Debug.WriteLine("BookData : GetAllBooksByTitle : " + ex.StackTrace);
                        transaction.Rollback();
                        throw ex;
                    }
                }
            }
        }

        internal Book[] GetAllBooksByAuthor(string name)
        {
            using (SqlConnection connection = connectionFactory.create_connection())
            {
                connection.Open();
                using (SqlTransaction transaction = connection.BeginTransaction(IsolationLevel.ReadCommitted))
                {
                    try
                    {
                        Book[] results;
                        using (SqlCommand command = new SqlCommand("get_all_books_by_author", connection, transaction) { CommandType = CommandType.StoredProcedure })
                        {
                            command.Parameters.AddWithValue("@name", name);
                            using (IDataReader reader = command.ExecuteReader())
                            {
                                results = base.generate_results(ExtractBook, reader);
                            }
                        }
                        foreach (Book result in results)
                        {
                            using (AuthorData authorData = new AuthorData())
                            {
                                authorData.FromTransaction = true;
                                authorData.Connection = connection;
                                authorData.Transaction = transaction;
                                result.Author = authorData.GetAuthorById(result.AuthorId);
                            }
                            using (UserData userData = new UserData())
                            {
                                userData.FromTransaction = true;
                                userData.Connection = connection;
                                userData.Transaction = transaction;
                                result.User = userData.GetUserById(result.UserId);
                            }
                        }
                        transaction.Commit();
                        return results;
                    }
                    catch (Exception ex)
                    {
                        System.Diagnostics.Debug.WriteLine("BookData : GetAllBooksByAuthor : " + ex.StackTrace);
                        transaction.Rollback();
                        throw ex;
                    }
                }
            }
        }

        internal Book[] GetAllBooksByUser(string userName)
        {
            using (SqlConnection connection = connectionFactory.create_connection())
            {
                connection.Open();
                using (SqlTransaction transaction = connection.BeginTransaction(IsolationLevel.ReadCommitted))
                {
                    try
                    {
                        Book[] results;
                        using (SqlCommand command = new SqlCommand("get_all_books_by_user", connection, transaction) { CommandType = CommandType.StoredProcedure })
                        {
                            command.Parameters.AddWithValue("@user_name", userName);
                            using (IDataReader reader = command.ExecuteReader())
                            {
                                results = base.generate_results(ExtractBook, reader);
                            }
                        }
                        foreach (Book result in results)
                        {
                            using (AuthorData authorData = new AuthorData())
                            {
                                authorData.FromTransaction = true;
                                authorData.Connection = connection;
                                authorData.Transaction = transaction;
                                result.Author = authorData.GetAuthorById(result.AuthorId);
                            }
                            using (UserData userData = new UserData())
                            {
                                userData.FromTransaction = true;
                                userData.Connection = connection;
                                userData.Transaction = transaction;
                                result.User = userData.GetUserById(result.UserId);
                            }
                        }
                        transaction.Commit();
                        return results;
                    }
                    catch (Exception ex)
                    {
                        System.Diagnostics.Debug.WriteLine("BookData : GetAllBooksByUser : " + ex.StackTrace);
                        transaction.Rollback();
                        throw ex;
                    }
                }
            }
        }

        internal Book[] GetAllBooksByGenre(string genre)
        {
            using (SqlConnection connection = connectionFactory.create_connection())
            {
                connection.Open();
                using (SqlTransaction transaction = connection.BeginTransaction(IsolationLevel.ReadCommitted))
                {
                    try
                    {
                        Book[] results;
                        using (SqlCommand command = new SqlCommand("get_all_books_by_genre", connection, transaction) { CommandType = CommandType.StoredProcedure })
                        {
                            command.Parameters.AddWithValue("@genre", genre);
                            using (IDataReader reader = command.ExecuteReader())
                            {
                                results = base.generate_results(ExtractBook, reader);
                            }
                        }
                        foreach (Book result in results)
                        {
                            using (AuthorData authorData = new AuthorData())
                            {
                                authorData.FromTransaction = true;
                                authorData.Connection = connection;
                                authorData.Transaction = transaction;
                                result.Author = authorData.GetAuthorById(result.AuthorId);
                            }
                            using (UserData userData = new UserData())
                            {
                                userData.FromTransaction = true;
                                userData.Connection = connection;
                                userData.Transaction = transaction;
                                result.User = userData.GetUserById(result.UserId);
                            }
                        }
                        transaction.Commit();
                        return results;
                    }
                    catch (Exception ex)
                    {
                        System.Diagnostics.Debug.WriteLine("BookData : GetAllBooksByGenre : " + ex.StackTrace);
                        transaction.Rollback();
                        throw ex;
                    }
                }
            }
        }

        internal Book[] GetAllBooksByType(string type)
        {
            using (SqlConnection connection = connectionFactory.create_connection())
            {
                connection.Open();
                using (SqlTransaction transaction = connection.BeginTransaction(IsolationLevel.ReadCommitted))
                {
                    try
                    {
                        Book[] results;
                        using (SqlCommand command = new SqlCommand("get_all_books_by_type", connection, transaction) { CommandType = CommandType.StoredProcedure })
                        {
                            command.Parameters.AddWithValue("@type", type);
                            using (IDataReader reader = command.ExecuteReader())
                            {
                                results = base.generate_results(ExtractBook, reader);
                            }
                        }
                        foreach (Book result in results)
                        {
                            using (AuthorData authorData = new AuthorData())
                            {
                                authorData.FromTransaction = true;
                                authorData.Connection = connection;
                                authorData.Transaction = transaction;
                                result.Author = authorData.GetAuthorById(result.AuthorId);
                            }
                            using (UserData userData = new UserData())
                            {
                                userData.FromTransaction = true;
                                userData.Connection = connection;
                                userData.Transaction = transaction;
                                result.User = userData.GetUserById(result.UserId);
                            }
                        }
                        transaction.Commit();
                        return results;
                    }
                    catch (Exception ex)
                    {
                        System.Diagnostics.Debug.WriteLine("BookData : GetAllBooksByType : " + ex.StackTrace);
                        transaction.Rollback();
                        throw ex;
                    }
                }
            }
        }

        internal bool AddBook(Book book)
        {
            using (SqlConnection connection = connectionFactory.create_connection())
            {
                connection.Open();
                using (SqlTransaction transaction = connection.BeginTransaction(IsolationLevel.ReadCommitted))
                {
                    try
                    {
                        using (SqlCommand command = new SqlCommand("add_book", connection, transaction)
                            { CommandType = CommandType.StoredProcedure })
                        {
                            command.Parameters.AddWithValue("@title", book.Title);
                            command.Parameters.AddWithValue("@author_id", book.Author.AuthorId);
                            command.Parameters.AddWithValue("@type", book.Type);
                            command.Parameters.AddWithValue("@genre", book.Genre);
                            command.Parameters.AddWithValue("@user_name", book.User.UserName);
                            command.Parameters.AddWithValue("@isbn", book.Isbn);
                            command.Parameters.AddWithValue("@reserved", 0);

                            if (book.Year <= 0)
                            {
                                command.Parameters.AddWithValue("@year", DBNull.Value);
                            }
                            else
                            {
                                command.Parameters.AddWithValue("@year", book.Year);
                            }

                            command.ExecuteNonQuery();
                        }
                        transaction.Commit();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        System.Diagnostics.Debug.WriteLine("BookData : AddBook : " + ex.StackTrace);
                        transaction.Rollback();
                        throw ex;
                    }
                }
            }
        }

        internal bool EditBook(Book book)
        {
            using (SqlConnection connection = connectionFactory.create_connection())
            {
                connection.Open();
                using (SqlTransaction transaction = connection.BeginTransaction(IsolationLevel.ReadCommitted))
                {
                    try
                    {
                        using (SqlCommand command = new SqlCommand("edit_book", connection, transaction) 
                            { CommandType = CommandType.StoredProcedure })
                        {
                            command.Parameters.AddWithValue("@book_id", book.BookId);
                            command.Parameters.AddWithValue("@title", book.Title);
                            command.Parameters.AddWithValue("@author_id", book.Author.AuthorId);
                            command.Parameters.AddWithValue("@type", book.Type);
                            command.Parameters.AddWithValue("@genre", book.Genre);
                            command.Parameters.AddWithValue("@isbn", book.Isbn);
                            command.Parameters.AddWithValue("@reserved", book.Reserved);

                            if (book.Year <= 0)
                            {
                                command.Parameters.AddWithValue("@year", DBNull.Value);
                            }
                            else
                            {
                                command.Parameters.AddWithValue("@year", book.Year);
                            }

                            command.ExecuteNonQuery();
                        }
                        transaction.Commit();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        System.Diagnostics.Debug.WriteLine("BookData : EditBook : " + ex.StackTrace);
                        transaction.Rollback();
                        throw ex;
                    }
                }
            }
        }

        internal Book GetBookById(int bookId)
        {
            using (SqlConnection connection = connectionFactory.create_connection())
            {
                connection.Open();
                using (SqlTransaction transaction = connection.BeginTransaction(IsolationLevel.ReadCommitted))
                {
                    try
                    {
                        Book result;
                        using (SqlCommand command = new SqlCommand("get_book_by_id", connection, transaction) { CommandType = CommandType.StoredProcedure })
                        {
                            command.Parameters.AddWithValue("@book_id", bookId);
                            
                            using (IDataReader reader = command.ExecuteReader())
                            {
                                result = base.generate_result(ExtractBook, reader);
                            }
                        }
                        using (AuthorData authorData = new AuthorData())
                        {
                            authorData.FromTransaction = true;
                            authorData.Connection = connection;
                            authorData.Transaction = transaction;
                            result.Author = authorData.GetAuthorById(result.AuthorId);
                        }
                        using (UserData userData = new UserData())
                        {
                            userData.FromTransaction = true;
                            userData.Connection = connection;
                            userData.Transaction = transaction;
                            result.User = userData.GetUserById(result.UserId);
                        }
                        transaction.Commit();
                        return result;
                    }
                    catch (Exception ex)
                    {
                        System.Diagnostics.Debug.WriteLine("BookData : GetBookById : " + ex.StackTrace);
                        transaction.Rollback();
                        throw ex;
                    }
                }
            }
        }

        internal bool SetBookReservedState(int bookId, bool reserved)
        {
            using (SqlConnection connection = connectionFactory.create_connection())
            {
                connection.Open();
                using (SqlTransaction transaction = connection.BeginTransaction(IsolationLevel.ReadCommitted))
                {
                    try
                    {
                        using (SqlCommand command = new SqlCommand("set_book_reserved_state", connection, transaction) 
                            { CommandType = CommandType.StoredProcedure })
                        {
                            command.Parameters.AddWithValue("@book_id", bookId);
                            command.Parameters.AddWithValue("@reserved", reserved ? 1 : 0);

                            command.ExecuteNonQuery();
                        }
                        transaction.Commit();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        System.Diagnostics.Debug.WriteLine("BookData : SetBookReservedState : " + ex.StackTrace);
                        transaction.Rollback();
                        throw ex;
                    }
                }
            }
        }

        internal Book[] CheckBookOfInterest(int bookId)
        {
            using (SqlConnection connection = connectionFactory.create_connection())
            {
                connection.Open();
                using (SqlTransaction transaction = connection.BeginTransaction(IsolationLevel.ReadCommitted))
                {
                    try
                    {
                        Book[] results;
                        using (SqlCommand command = new SqlCommand("check_book_of_interest", connection, transaction) { CommandType = CommandType.StoredProcedure })
                        {
                            command.Parameters.AddWithValue("@book_of_interest_id", bookId);

                            using (IDataReader reader = command.ExecuteReader())
                            {
                                results = base.generate_results(ExtractBook, reader);
                            }

                            foreach (Book result in results)
                            {
                                using (AuthorData authorData = new AuthorData())
                                {
                                    authorData.FromTransaction = true;
                                    authorData.Connection = connection;
                                    authorData.Transaction = transaction;
                                    result.Author = authorData.GetAuthorById(result.AuthorId);
                                }
                                using (UserData userData = new UserData())
                                {
                                    userData.FromTransaction = true;
                                    userData.Connection = connection;
                                    userData.Transaction = transaction;
                                    result.User = userData.GetUserById(result.UserId);
                                }
                            }
                        }
                        transaction.Commit();
                        return results;
                    }
                    catch (Exception ex)
                    {
                        System.Diagnostics.Debug.WriteLine("BookData : CheckBookOfInterest : " + ex.StackTrace);
                        transaction.Rollback();
                        throw ex;
                    }
                }
            }
        }
    }
}