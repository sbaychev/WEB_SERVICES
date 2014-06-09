using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Net;
using System.ServiceModel.Web;
using System.Windows.Forms;
using System.Xml;
using System.Linq;
using System.Text;
using System.Web;

namespace LibraryExchangeClient.BookOfInterest
{
    public class BookOfInterestServ
    {
        private static BookOfInterestServ instance;

        private BookOfInterestServ()
        {
        }

        public static BookOfInterestServ GetInstance()
        {
            if (instance == null)
            {
                instance = new BookOfInterestServ();
            }
            return instance;
        }

        public List<Book> GetAllBooksOfInterestByUser(string userName, string guid)
        {
            // Create the web request 
            string url = "http://localhost:8080/LibraryBooksOfInterest/rest/bookofinterest/byuser/?username=" + userName + "&guid=" + guid;
            HttpWebRequest request
                = WebRequest.Create(url) as HttpWebRequest;

            // Get response  
            using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
            {
                // Load data into a dataset  
                DataSet dsWeather = new DataSet();
                dsWeather.ReadXml(response.GetResponseStream());

                // Print dataset information  
                return ExtractAllBooks(dsWeather);
            }
        }

        public List<User> CheckBookOfInterest(string userName, string guid, int bookId)
        {
            // Create the web request 
            string url = "http://localhost:8080/LibraryBooksOfInterest/rest/bookofinterest/check?username=" + userName + "&guid=" + guid + "&bookid=" + bookId;
            HttpWebRequest request
                = WebRequest.Create(url) as HttpWebRequest;

            // Get response  
            using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
            {
                // Load data into a dataset  
                DataSet dsWeather = new DataSet();
                dsWeather.ReadXml(response.GetResponseStream());

                // Print dataset information  
                return ExtractAllUsers(dsWeather);
            }
        }

        public bool AddBookOfInterest(string userName, string guid, string title, string author)
        {
            var populatedEndPoint = CreateFormattedPostRequest(userName, guid, title, author);
            byte[] bytes = Encoding.UTF8.GetBytes(populatedEndPoint);

            string url = "http://localhost:8080/LibraryBooksOfInterest/rest/bookofinterest/add";
            HttpWebRequest request = CreateWebRequest(url, bytes.Length);

            using (var requestStream = request.GetRequestStream())
            {
                requestStream.Write(bytes, 0, bytes.Length);
            }

            using (var response = (HttpWebResponse)request.GetResponse())
            {
                if (response.StatusCode != HttpStatusCode.OK)
                {
                    string message = String.Format("POST failed. Received HTTP {0}", response.StatusCode);
                    throw new ApplicationException(message);
                    return false;
                }
                else
                {
                    DataSet dsWeather = new DataSet();
                    dsWeather.ReadXml(response.GetResponseStream());

                    // Print dataset information  
                    return ExtractAddResult(dsWeather);
                }
            }  
        }

        private HttpWebRequest CreateWebRequest(string endPoint, Int32 contentLength)
        {
            var request = (HttpWebRequest)WebRequest.Create(endPoint);

            request.Method = "POST";
            request.ContentLength = contentLength;
            request.ContentType = "application/x-www-form-urlencoded";

            return request;
        }  

        private string CreateFormattedPostRequest(string userName, string guid, string title, string authorName)  
        {  
            var paramterBuilder = new StringBuilder();  

            paramterBuilder.AppendFormat("{0}={1}", "username", HttpUtility.UrlEncode(userName));
            paramterBuilder.Append("&");
            paramterBuilder.AppendFormat("{0}={1}", "guid", HttpUtility.UrlEncode(guid));
            paramterBuilder.Append("&");
            paramterBuilder.AppendFormat("{0}={1}", "title", HttpUtility.UrlEncode(title));
            paramterBuilder.Append("&");
            paramterBuilder.AppendFormat("{0}={1}", "author", HttpUtility.UrlEncode(authorName));  
  
            return paramterBuilder.ToString();  
        }

        private List<User> ExtractAllUsers(DataSet ds)
        {
            try
            {
                OperationResult or = new OperationResult();
                DataTable table = ds.Tables["operationResultSet"];
                or.Error = (OperationResult.ErrorEnum)Enum.Parse(typeof(OperationResult.ErrorEnum), table.Rows[0].Field<string>(table.Columns["Error"]));
                or.ErrorString = table.Rows[0].Field<string>(table.Columns["ErrorString"]);
                if (!or.Error.Equals(OperationResult.ErrorEnum.None))
                {
                    MessageBox.Show(or.ErrorString);
                    return null;
                }

                Dictionary<int, User> users = new Dictionary<int, User>();
                table = ds.Tables["ResultSet"];
                if (!(table == null))
                {
                    foreach (DataRow row in table.Rows)
                    {
                        User user = new User();
                        user.UserName = row.Field<string>(table.Columns["userName"]);
                        user.FirstName = row.Field<string>(table.Columns["firstName"]);
                        user.LastName = row.Field<string>(table.Columns["lastName"]);
                        user.Phone = row.Field<string>(table.Columns["phone"]);
                        user.Email = row.Field<string>(table.Columns["email"]);
                        int userId = row.Field<int>(table.Columns["ResultSet_Id"]);
                        users.Add(userId, user);
                    }

                    table = ds.Tables["location"];
                    foreach (DataRow row in table.Rows)
                    {
                        Location location = new Location();
                        location.Country = row.Field<string>(table.Columns["country"]);
                        location.City = row.Field<string>(table.Columns["city"]);
                        location.PostCode = row.Field<string>(table.Columns["postCode"]);
                        location.Address = row.Field<string>(table.Columns["address"]);
                        users[row.Field<int>(table.Columns["ResultSet_Id"])].Location = location;
                    }
                }
                return users.Values.ToList<User>();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.StackTrace);
                MessageBox.Show("Some error occured while reading users.");
                return null;
            }
        }

        private bool ExtractAddResult(DataSet ds)
        {
            try
            {
                OperationResult or = new OperationResult();
                DataTable table = ds.Tables["operationResultValue"];
                or.Error = (OperationResult.ErrorEnum)Enum.Parse(typeof(OperationResult.ErrorEnum), table.Rows[0].Field<string>(table.Columns["Error"]));
                or.ErrorString = table.Rows[0].Field<string>(table.Columns["ErrorString"]);
                if (!or.Error.Equals(OperationResult.ErrorEnum.None))
                {
                    MessageBox.Show(or.ErrorString);
                    return false;
                }

                string result = table.Rows[0].Field<string>(table.Columns["ResultValue"]);

                return result.Equals("1") ? true : false;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.StackTrace);
                MessageBox.Show("Some error occured while reading books of interest.");
                return false;
            }
        } 

        private List<Book> ExtractAllBooks(DataSet ds)
        {
            try
            {
                OperationResult or = new OperationResult();
                DataTable table = ds.Tables["operationResultSet"];
                or.Error = (OperationResult.ErrorEnum)Enum.Parse(typeof(OperationResult.ErrorEnum), table.Rows[0].Field<string>(table.Columns["Error"]));
                or.ErrorString = table.Rows[0].Field<string>(table.Columns["ErrorString"]);
                if (!or.Error.Equals(OperationResult.ErrorEnum.None))
                {
                    MessageBox.Show(or.ErrorString);
                    return null;
                }

                Dictionary<int, Book> books = new Dictionary<int, Book>();
                table = ds.Tables["ResultSet"];
                foreach (DataRow row in table.Rows)
                {
                    Book book = new Book();
                    book.BookId = int.Parse(row.Field<string>(table.Columns["bookId"]));
                    book.Title = row.Field<string>(table.Columns["title"]);
                    book.AuthorName = row.Field<string>(table.Columns["authorName"]);
                    int resultSetId = row.Field<int>(table.Columns["ResultSet_Id"]);
                    books.Add(resultSetId, book);
                }

                Dictionary<int, User> users = new Dictionary<int, User>();
                table = ds.Tables["user"];
                foreach (DataRow row in table.Rows)
                {
                    User user = new User();
                    user.UserId = row.Field<int>(table.Columns["user_Id"]);
                    user.UserName = row.Field<string>(table.Columns["userName"]);
                    user.FirstName = row.Field<string>(table.Columns["firstName"]);
                    user.LastName = row.Field<string>(table.Columns["lastName"]);
                    user.Phone = row.Field<string>(table.Columns["phone"]);
                    user.Email = row.Field<string>(table.Columns["email"]);
                    books[row.Field<int>(table.Columns["ResultSet_Id"])].User = user;
                    users.Add(user.UserId, user);
                }

                table = ds.Tables["location"];
                foreach (DataRow row in table.Rows)
                {
                    Location location = new Location();
                    location.Country = row.Field<string>(table.Columns["country"]);
                    location.City = row.Field<string>(table.Columns["city"]);
                    location.PostCode = row.Field<string>(table.Columns["postCode"]);
                    location.Address = row.Field<string>(table.Columns["address"]);
                    users[row.Field<int>(table.Columns["user_Id"])].Location = location;
                }
                return books.Values.ToList<Book>();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.StackTrace);
                MessageBox.Show("Some error occured while reading books of interest.");
                return null;
            }
        } 
    }
}
