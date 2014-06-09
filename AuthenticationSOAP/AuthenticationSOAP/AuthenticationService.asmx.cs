using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Windows.Forms;

namespace AuthenticationSOAP
{
    /// <summary>
    /// Summary description for AuthenticateService
    /// </summary>
    [WebService]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class AuthenticationService : System.Web.Services.WebService
    {
        [WebMethod]
        public OperationResult AddUser(string Country, string City, string PostCode, string Address, 
                                       string UserName, string Password, string Email, string FirstName, 
                                       string LastName, string Phone)
        {
            SqlConnection connection = null;
            try
            {
                connection = new SqlConnection(ConfigurationManager.ConnectionStrings[ConfigurationManager.AppSettings["db.connections.default"]].ConnectionString);

                connection.Open();
                SqlCommand cmd = new SqlCommand("add_user", connection);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@country", Country);
                cmd.Parameters.AddWithValue("@city", City);
                cmd.Parameters.AddWithValue("@postcode", PostCode);
                cmd.Parameters.AddWithValue("@address", Address);

                cmd.Parameters.AddWithValue("@user_name", UserName);
                cmd.Parameters.AddWithValue("@password", Password);
                cmd.Parameters.AddWithValue("@email", Email);
                cmd.Parameters.AddWithValue("@first_name", FirstName);
                cmd.Parameters.AddWithValue("@last_name", LastName);
                cmd.Parameters.AddWithValue("@phone", Phone);
                cmd.ExecuteNonQuery();

                return new OperationResult();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("AuthenticatationService : AddUser : " + ex.StackTrace);
                return new OperationResult(
                    OperationResult.ErrorEnum.InternalProblem, 
                    "Some internal problem has occured");
            }
            finally
            {
                if (connection != null)
                {
                    connection.Close();
                }
            }
        }

        [WebMethod]
        public OperationResultValue<string> IsUserValid(string userName, string password)
        {
            string token = String.Empty;
            try
            {
                using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings[ConfigurationManager.AppSettings["db.connections.default"]].ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("select * from users where user_name=@user_name and password=@password", connection))
                    {
                        command.Parameters.AddWithValue("@user_name", userName);
                        command.Parameters.AddWithValue("@password", password);
                        DataTable dt = new DataTable();
                        SqlDataAdapter da = new SqlDataAdapter(command);
                        connection.Open();
                        da.Fill(dt);
                        if (dt.Rows.Count == 0)
                        {
                            dt.Dispose();
                        }
                        else
                        {
                            token = Guid.NewGuid().ToString();
                        }
                    }
                    if (!String.IsNullOrEmpty(token))
                    {
                        using (SqlCommand comm = new SqlCommand("UPDATE users SET access_token = @access_token, last_access_time = @last_access_time WHERE user_name = @user_name", connection))
                        {
                            comm.Parameters.AddWithValue("@user_name", userName);
                            comm.Parameters.AddWithValue("@access_token", token);
                            comm.Parameters.AddWithValue("@last_access_time", DateTime.Now);
                            comm.ExecuteNonQuery();
                        }
                    }
                }
                return new OperationResultValue<string>(token);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("AuthenticatationService : IsUserValid : " + ex.StackTrace);
                return new OperationResultValue<string>(
                    OperationResult.ErrorEnum.InternalProblem,
                    "Some internal problem has occured");
            }
        }
    }
}