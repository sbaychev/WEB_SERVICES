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
    internal class UserData : Data<User>
    {
        public static int ACCESS_TIME_MINUTES = 5;

        internal UserData()
            : base(ConfigurationManager.AppSettings["db.connections.default"])
        {
        }

        public User ExtractUser(IDataReader reader)
        {
            User user = new User();
            user.UserName = reader.GetString(0);
            user.FirstName = reader.IsDBNull(1) ? "" : reader.GetString(1);
            user.LastName = reader.IsDBNull(2) ? "" : reader.GetString(2);
            user.LocationId = reader.GetInt32(3);
            user.Phone = reader.IsDBNull(4) ? "" : reader.GetString(4);
            user.Email = reader.IsDBNull(5) ? "" : reader.GetString(5);
            return user;
        }

        internal User GetUserByUserName(string userName)
        {
            using (SqlConnection connection = connectionFactory.create_connection())
            {
                connection.Open();
                using (SqlTransaction transaction = connection.BeginTransaction(IsolationLevel.ReadCommitted))
                {
                    try
                    {
                        User result;
                        using (SqlCommand command = new SqlCommand("get_user_by_user_name", connection, transaction) { CommandType = CommandType.StoredProcedure })
                        {
                            command.Parameters.AddWithValue("@user_name", userName);
                            
                            using (IDataReader reader = command.ExecuteReader())
                            {
                                result = base.generate_result(ExtractUser, reader);
                            }
                        }
                        
                        using (LocationData locationData = new LocationData())
                        {
                            locationData.FromTransaction = true;
                            locationData.Connection = connection;
                            locationData.Transaction = transaction;
                            result.Location = locationData.GetLocationById(result.LocationId);
                        }

                        transaction.Commit();
                        return result;
                    }
                    catch (Exception ex)
                    {
                        System.Diagnostics.Debug.WriteLine("UserData : GetUserByUserName : " + ex.StackTrace);
                        transaction.Rollback();
                        throw ex;
                    }
                }
            }
        }

        private User GetUserByIdInner(int userId, SqlConnection connection, SqlTransaction transaction)
        {
            using (SqlCommand command = new SqlCommand("get_user_by_id", connection, transaction) { CommandType = CommandType.StoredProcedure })
            {
                command.Parameters.AddWithValue("@user_id", userId);

                using (IDataReader reader = command.ExecuteReader())
                {
                    return base.generate_result(ExtractUser, reader);
                }
            }
        }

        internal User GetUserById(int userId)
        {
            if (FromTransaction)
            {
                User result = GetUserByIdInner(userId, Connection, Transaction);
                
                using (LocationData locationData = new LocationData())
                {
                    locationData.FromTransaction = true;
                    locationData.Connection = Connection;
                    locationData.Transaction = Transaction;
                    result.Location = locationData.GetLocationById(result.LocationId);
                }

                return result;
            }

            using (SqlConnection connection = connectionFactory.create_connection())
            {
                connection.Open();
                using (SqlTransaction transaction = connection.BeginTransaction(IsolationLevel.ReadCommitted))
                {
                    try
                    {
                        User result = GetUserByIdInner(userId, connection, transaction);

                        using (LocationData locationData = new LocationData())
                        {
                            locationData.FromTransaction = true;
                            locationData.Connection = connection;
                            locationData.Transaction = transaction;
                            result.Location = locationData.GetLocationById(result.LocationId);
                        }
                        transaction.Commit();
                        return result;
                    }
                    catch (Exception ex)
                    {
                        System.Diagnostics.Debug.WriteLine("UserData : GetUserById : " + ex.StackTrace);
                        transaction.Rollback();
                        throw ex;
                    }
                }
            }
        }

        internal bool CheckUserAuthenticated(string userName, string guid)
        {
            if (String.IsNullOrEmpty(userName) || String.IsNullOrEmpty(guid))
            {
                return false;
            }
            using (SqlConnection connection = connectionFactory.create_connection())
            {
                connection.Open();
                using (SqlTransaction transaction = connection.BeginTransaction(IsolationLevel.ReadCommitted))
                {
                    try
                    {
                        int result;
                        using (SqlCommand command = new SqlCommand("check_user_authenticated", connection, transaction) 
                            { CommandType = CommandType.StoredProcedure })
                        {
                            command.Parameters.AddWithValue("@user_name", userName);
                            command.Parameters.AddWithValue("@access_token", guid);
                            command.Parameters.AddWithValue("@check_time", DateTime.Now);
                            command.Parameters.AddWithValue("@time_interval", ACCESS_TIME_MINUTES);

                            using (IDataReader reader = command.ExecuteReader())
                            {
                                result = base.extract_scalar<int>(reader, 0);
                            }
                        }
                        transaction.Commit();
                        return result == 1;
                    }
                    catch (Exception ex)
                    {
                        System.Diagnostics.Debug.WriteLine("UserData : CheckUserAuthenticated : " + ex.StackTrace);
                        transaction.Rollback();
                        throw ex;
                    }
                }
            }
        }
    }
}