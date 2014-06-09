using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using Library.Models;

namespace Library.Database
{
    internal class LocationData : Data<Location>
    {
        internal LocationData()
            : base(ConfigurationManager.AppSettings["db.connections.default"])
        {
        }

        private Location GetLocationByIdInner(int id, SqlConnection connection, SqlTransaction transaction)
        {
            using (SqlCommand command = new SqlCommand("get_location_by_id", connection, transaction) 
                { CommandType = CommandType.StoredProcedure })
            {
                command.Parameters.AddWithValue("@location_id", id);

                using (IDataReader reader = command.ExecuteReader())
                {
                    return base.generate_result(ExtractLocation, reader);
                }
            }
        }

        internal Location GetLocationById(int id)
        {
            if (FromTransaction)
            {
                return GetLocationByIdInner(id, Connection, Transaction);
            }

            using (SqlConnection connection = connectionFactory.create_connection())
            {
                connection.Open();
                using (SqlTransaction transaction = connection.BeginTransaction(IsolationLevel.ReadCommitted))
                {
                    try
                    {
                        Location result = GetLocationByIdInner(id, Connection, transaction);
                        transaction.Commit();
                        return result;
                    }
                    catch (Exception ex)
                    {
                        System.Diagnostics.Debug.WriteLine("LocationData : GetLocationById : " + ex.StackTrace);
                        transaction.Rollback();
                        throw ex;
                    }
                }
            }
        }



        private Location ExtractLocation(IDataReader reader)
        {
            Location location = new Location();
            location.Country = reader.GetString(0);
            location.City = reader.GetString(1);
            location.PostCode = reader.GetString(2);
            location.Address = reader.IsDBNull(3) ? "" : reader.GetString(3);
            return location;
        }
    }
}