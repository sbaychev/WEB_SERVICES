using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Web;

namespace Library.Database
{
    internal class TypeData : Data<string>
    {
        internal TypeData()
            : base(ConfigurationManager.AppSettings["db.connections.default"])
        {
        }

        internal string[] GetAllTypes()
        {
            using (SqlConnection connection = connectionFactory.create_connection())
            {
                connection.Open();
                using (SqlTransaction transaction = connection.BeginTransaction(IsolationLevel.ReadCommitted))
                {
                    try
                    {
                        string[] result;
                        using (SqlCommand command = new SqlCommand("get_all_types", connection, transaction) 
                            { CommandType = CommandType.StoredProcedure })
                        {
                            using (IDataReader reader = command.ExecuteReader())
                            {
                                result = base.generate_results(ExtractType, reader);
                            }
                        }
                        transaction.Commit();
                        return result;
                    }
                    catch (Exception ex)
                    {
                        System.Diagnostics.Debug.WriteLine("TypeData : GetAllTypes : " + ex.StackTrace);
                        transaction.Rollback();
                        throw ex;
                    }
               }
            }
        }

        internal int GetTypeIdByName(string typeName)
        {
            using (SqlConnection connection = connectionFactory.create_connection())
            {
                connection.Open();
                using (SqlTransaction transaction = connection.BeginTransaction(IsolationLevel.ReadCommitted))
                {
                    try
                    {
                        int result;
                        using (SqlCommand command = new SqlCommand("get_type_id_by_name", connection, transaction) 
                            { CommandType = CommandType.StoredProcedure })
                        {
                            command.Parameters.AddWithValue("@type_name", typeName);
                            
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
                        System.Diagnostics.Debug.WriteLine("TypeData : GetTypeIdByName : " + ex.StackTrace);
                        transaction.Rollback();
                        throw ex;
                    }
                }
            }
        }

        private string ExtractType(IDataReader reader)
        {
            return reader.GetString(0);
        }
    }
}