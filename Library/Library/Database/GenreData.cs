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
    internal class GenreData : Data<string>
    {
        internal GenreData()
            : base(ConfigurationManager.AppSettings["db.connections.default"])
        {
        }

        internal string[] GetAllGenres()
        {
            using (SqlConnection connection = connectionFactory.create_connection())
            {
                connection.Open();
                using (SqlTransaction transaction = connection.BeginTransaction(IsolationLevel.ReadCommitted))
                {
                    try
                    {
                        string[] result;
                        using (SqlCommand command = new SqlCommand("get_all_genres", connection, transaction) 
                            { CommandType = CommandType.StoredProcedure })
                        {
                            using (IDataReader reader = command.ExecuteReader())
                            {
                                result = base.generate_results(ExtractGenre, reader);
                            }
                            
                        }
                        transaction.Commit();
                        return result;
                    }
                    catch (Exception ex)
                    {
                        System.Diagnostics.Debug.WriteLine("GenreData : GetAllGenres : " + ex.StackTrace);
                        transaction.Rollback();
                        throw ex;
                    }
                }
            }
        }

        internal int GetGenreIdByName(string genreName)
        {
            using (SqlConnection connection = connectionFactory.create_connection())
            {
                connection.Open();
                using (SqlTransaction transaction = connection.BeginTransaction(IsolationLevel.ReadCommitted))
                {
                    try
                    {
                        int result;
                        using (SqlCommand command = new SqlCommand("get_genre_id_by_name", connection, transaction) { CommandType = CommandType.StoredProcedure })
                        {
                            command.Parameters.AddWithValue("@genre_name", genreName);
                            
                            using (IDataReader reader = command.ExecuteReader())
                            {
                                result = base.extract_scalar<int>(reader, -1);
                            }
                        }
                        transaction.Commit();
                        return result;
                    }
                    catch (Exception ex)
                    {
                        System.Diagnostics.Debug.WriteLine("GenreData : GetGenreIdByName : " + ex.StackTrace);
                        transaction.Rollback();
                        throw ex;
                    }
                }
            }
        }

        private string ExtractGenre(IDataReader reader)
        {
            return reader.GetString(0);
        }
    }
}