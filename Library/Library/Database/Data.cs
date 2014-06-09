using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Library.Database
{
    internal class Data<T> : IDisposable
    {
        protected ConnectionFactory connectionFactory;

        protected Data(string connectionName)
        {
            connectionFactory = ConnectionFactory.new_instance(connectionName);
        }

        public bool FromTransaction { get; set; }
        public SqlConnection Connection { get; set; }
        public SqlTransaction Transaction { get; set; }

        protected T generate_result(Func<IDataReader, T> extract_func, IDataReader reader)
        {
            using (reader)
            {
                if (!reader.Read())
                    return default(T);
                return extract_func(reader);
            }
        }

        protected T generate_result(Func<IDataReader, SqlConnection, SqlTransaction, T> extract_func, 
            IDataReader reader, SqlConnection sqlConnection, SqlTransaction sqlTransaction)
        {
            using (reader)
            {
                if (!reader.Read())
                    return default(T);
                return extract_func(reader, sqlConnection, sqlTransaction);
            }
        }

        protected T[] generate_results(Func<IDataReader, T> extract_func, IDataReader reader)
        {
            using (reader)
            {
                List<T> results = new List<T>();
                while (reader.Read())
                    results.Add(extract_func(reader));
                return results.ToArray();
            }
        }

        protected NT extract_scalar<NT>(IDataReader reader, NT defaultResult)
        {
            using (reader)
            {
                if (reader.Read())
                    return (NT)reader.GetValue(0);
                else
                    return defaultResult;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        ~Data() 
        {
            Dispose(false);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing) 
            {
                if (connectionFactory != null)
                {
                    connectionFactory.Dispose();
                    connectionFactory = null;
                }
            }
        }
    }
}