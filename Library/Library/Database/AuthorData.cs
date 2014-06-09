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
    internal class AuthorData : Data<Author>
    {
        internal AuthorData()
            : base(ConfigurationManager.AppSettings["db.connections.default"])
        {
        }

        public static Author ExtractAuthor(IDataReader reader)
        {
            Author author = new Author();
            author.AuthorId = reader.GetInt32(0);
            author.FirstName = reader.GetString(1);
            author.LastName = reader.GetString(2);
            DateTime birthDate = reader.IsDBNull(3) ? new DateTime() : reader.GetDateTime(3);
            DateTime deathDate = reader.IsDBNull(4) ? new DateTime() : reader.GetDateTime(4);
            author.BornDate = birthDate.ToShortDateString();
            author.DeathDate = deathDate.ToShortDateString();
            author.AuthorInfo = author.FirstName + " " + author.LastName + " (" +
                (birthDate.Equals(new DateTime()) ? "-" : birthDate.ToShortDateString()) + ", " +
                (deathDate.Equals(new DateTime()) ? "-" : deathDate.ToShortDateString()) + ")";
            return author;
        }

        internal Author[] GetAllAuthors()
        {
            using (SqlConnection connection = connectionFactory.create_connection())
            {
                connection.Open();
                using (SqlTransaction transaction = connection.BeginTransaction(IsolationLevel.ReadCommitted))
                {
                    try
                    {
                        Author[] result;
                        using (SqlCommand command = new SqlCommand("get_all_authors", connection, transaction) 
                            { CommandType = CommandType.StoredProcedure })
                        {
                            using (IDataReader reader = command.ExecuteReader())
                            {
                                result = base.generate_results(ExtractAuthor, reader);
                            }
                        }
                        transaction.Commit();
                        return result;
                    }
                    catch (Exception ex)
                    {
                        System.Diagnostics.Debug.WriteLine("AuthorData : GetAllAuthors : " + ex.StackTrace);
                        transaction.Rollback();
                        throw ex;
                    }
                }
            }
        }

        internal bool AddAuthor(Author author)
        {
            using (SqlConnection connection = connectionFactory.create_connection())
            {
                connection.Open();
                using (SqlTransaction transaction = connection.BeginTransaction(IsolationLevel.ReadCommitted))
                {
                    try
                    {
                        using (SqlCommand command = new SqlCommand("add_author", connection, transaction) { CommandType = CommandType.StoredProcedure })
                        { 
                            command.Parameters.AddWithValue("@first_name", author.FirstName);
                            command.Parameters.AddWithValue("@last_name", author.LastName);
                            if (author.BornDateInner == null || author.BornDateInner.Equals(new DateTime()))
                                command.Parameters.AddWithValue("@born_date", DBNull.Value);
                            else
                                command.Parameters.AddWithValue("@born_date", author.BornDateInner.Date); 
                            if (author.DeathDateInner == null || author.DeathDateInner.Equals(new DateTime()))
                                command.Parameters.AddWithValue("@death_date", DBNull.Value);
                            else
                                command.Parameters.AddWithValue("@death_date", author.DeathDateInner.Date);
                            command.ExecuteNonQuery();
                        }
                        transaction.Commit();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        System.Diagnostics.Debug.WriteLine("AuthorData : AddAuthor : " + ex.StackTrace);
                        transaction.Rollback();
                        throw ex;
                    }
                }
            }
        }

        private Author GetAuthorByIdInner(int authorId, SqlConnection connection, SqlTransaction transaction)
        {
            using (SqlCommand command = new SqlCommand("get_author_by_id", connection, transaction) { CommandType = CommandType.StoredProcedure })
            {
                command.Parameters.AddWithValue("@author_id", authorId);

                using (IDataReader reader = command.ExecuteReader())
                {
                    return base.generate_result(ExtractAuthor, reader);
                }
            }
        }

        internal Author GetAuthorById(int authorId)
        {
            if (FromTransaction)
            {
                return GetAuthorByIdInner(authorId, Connection, Transaction);
            }
            using (SqlConnection connection = connectionFactory.create_connection())
            {
                connection.Open();
                using (SqlTransaction transaction = connection.BeginTransaction(IsolationLevel.ReadCommitted))
                {
                    try
                    {
                        Author result = GetAuthorByIdInner(authorId, connection, transaction);
                        
                        transaction.Commit();
                        return result;
                    }
                    catch (Exception ex)
                    {
                        System.Diagnostics.Debug.WriteLine("AuthorData : GetAuthorById : " + ex.StackTrace);
                        transaction.Rollback();
                        throw ex;
                    }
                }
            }
        }
    }
}