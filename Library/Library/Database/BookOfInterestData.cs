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
    internal class BookOfInterestData : Data<BookOfInterest>
    {
        internal BookOfInterestData()
            : base(ConfigurationManager.AppSettings["db.connections.default"])
        {
        }

        internal static BookOfInterest ExtractBookOfInterest(IDataReader reader)
        {
            BookOfInterest book = new BookOfInterest();
            book.BookId = reader.GetInt32(0);
            book.Title = reader.GetString(1);
            book.AuthorName = reader.GetString(2);
            book.UserId = reader.GetInt32(3);
            return book;
        }

        internal BookOfInterest[] GetAllBooksOfInterest()
        {
            using (SqlConnection connection = connectionFactory.create_connection())
            {
                connection.Open();
                using (SqlTransaction transaction = connection.BeginTransaction(IsolationLevel.ReadCommitted))
                {
                    try
                    {
                        BookOfInterest[] results;
                        using (SqlCommand command = new SqlCommand("get_all_books_of_interest", connection, transaction) { CommandType = CommandType.StoredProcedure })
                        {
                            using (IDataReader reader = command.ExecuteReader())
                            {
                                results = base.generate_results(ExtractBookOfInterest, reader);
                            }

                            foreach (BookOfInterest result in results)
                            {
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
                        System.Diagnostics.Debug.WriteLine("BookOfInterest : GetAllBooksOfInterest : " + ex.StackTrace);
                        transaction.Rollback();
                        throw ex;
                    }
                }
            }
        }

        internal BookOfInterest[] GetAllBooksOfInterestByUser(string userName)
        {
            using (SqlConnection connection = connectionFactory.create_connection())
            {
                connection.Open();
                using (SqlTransaction transaction = connection.BeginTransaction(IsolationLevel.ReadCommitted))
                {
                    try
                    {
                        BookOfInterest[] results;
                        using (SqlCommand command = new SqlCommand("get_all_books_of_interest_by_user", connection, transaction) 
                            { CommandType = CommandType.StoredProcedure })
                        {
                            command.Parameters.AddWithValue("@user_name", userName);

                            using (IDataReader reader = command.ExecuteReader())
                            {
                                results = base.generate_results(ExtractBookOfInterest, reader);
                            }

                            foreach (BookOfInterest result in results)
                            {
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
                        System.Diagnostics.Debug.WriteLine("BookOfInterest : GetAllBooksOfInterestByUser : " + ex.StackTrace);
                        transaction.Rollback();
                        throw ex;
                    }
                }
            }
        }

        internal bool AddBookOfInterest(BookOfInterest book)
        {
            using (SqlConnection connection = connectionFactory.create_connection())
            {
                connection.Open();
                using (SqlTransaction transaction = connection.BeginTransaction(IsolationLevel.ReadCommitted))
                {
                    try
                    {
                        using (SqlCommand command = new SqlCommand("add_book_of_interest", connection, transaction) { CommandType = CommandType.StoredProcedure })
                        {
                            command.Parameters.AddWithValue("@title", book.Title);
                            command.Parameters.AddWithValue("@author_name", book.AuthorName);
                            command.Parameters.AddWithValue("@user_name", book.User.UserName);

                            command.ExecuteNonQuery();
                        }
                        transaction.Commit();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        System.Diagnostics.Debug.WriteLine("BookOfInterest : AddBookOfInterest : " + ex.StackTrace);
                        transaction.Rollback();
                        throw ex;
                    }
                }
            }
        }
    }
}