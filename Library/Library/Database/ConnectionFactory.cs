using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Library.Database
{
    public class ConnectionFactory
    {
        private string m_connection_string;

        private ConnectionFactory(string connection_string)
        {
            m_connection_string = connection_string;
            return;
        }

        internal static ConnectionFactory new_instance()
        {
            try
            {
                return new ConnectionFactory(ConfigurationManager.ConnectionStrings["default"].ConnectionString);
            }
            catch (Exception)
            {
                throw;
            }
        }

        internal static ConnectionFactory new_instance(string connection_string_name)
        {
            try
            {
                return new ConnectionFactory(ConfigurationManager.ConnectionStrings[connection_string_name].ConnectionString);
            }
            catch (Exception)
            {
                throw;
            }
        }

        internal SqlConnection create_connection()
        {
            try
            {
                return new SqlConnection(m_connection_string);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        ~ConnectionFactory() 
        {
            Dispose(false);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing) 
            {
                if (m_connection_string != null)
                {
                    m_connection_string = null;
                }
            }
        }
    }
}