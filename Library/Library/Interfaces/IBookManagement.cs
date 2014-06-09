using System;
using System.Collections.Generic;
using System.EnterpriseServices;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using Library.Models;

namespace Library.Interfaces
{
    [ServiceContract] 
    interface IBookManagement
    {
        [OperationContract]
        [WebInvoke(UriTemplate = "/AddAuthor?userName={userName}&guid={guid}")]
        OperationResult AddAuthor(Author author, string userName, string guid);

        [OperationContract]
        [WebGet(UriTemplate = "/GetAllAuthors?userName={userName}&guid={guid}")]
        OperationResultSet<Author> GetAllAuthors(string userName, string guid);

        /*[OperationContract]
        [WebGet(UriTemplate = "/GetAllUsers?userName={userName}&guid={guid}")]
        OperationResultSet<User> GetAllUsers(string userName, string guid);*/

        [OperationContract]
        [WebGet(UriTemplate = "/GetAllTypes?userName={userName}&guid={guid}")]
        OperationResultSet<string> GetAllTypes(string userName, string guid);

        [OperationContract]
        [WebGet(UriTemplate = "/GetAllGenres?userName={userName}&guid={guid}")]
        OperationResultSet<string> GetAllGenres(string userName, string guid);

        [OperationContract]
        [WebInvoke(UriTemplate = "/AddBook?userName={userName}&guid={guid}")]
        OperationResult AddBook(Book book, string userName, string guid);

        [OperationContract]
        [WebInvoke(UriTemplate = "/AddUser")]
        OperationResultValue<string> AddUser(User user);

        [OperationContract]
        [WebInvoke(UriTemplate = "/EditBook?userName={userName}&guid={guid}")]
        OperationResult EditBook(Book book, string userName, string guid);

        [OperationContract]
        [WebInvoke(UriTemplate = "/AddBookOfInterest?userName={userName}&guid={guid}")]
        OperationResult AddBookOfInterest(BookOfInterest book, string userName, string guid);

        [OperationContract]
        [WebGet(UriTemplate = "/CheckBookOfInterest?bookid={bookid}&userName={userName}&guid={guid}")]
        OperationResultSet<Book> CheckBookOfInterest(int bookid, string userName, string guid);

        [OperationContract]
        [WebGet(UriTemplate = "/GetAllBooksOfInterest?userName={userName}&guid={guid}")]
        OperationResultSet<BookOfInterest> GetAllBooksOfInterest(string userName, string guid);

        [OperationContract]
        [WebGet(UriTemplate = "/GetAllBooksOfInterestByUser?userName={userName}&guid={guid}")]
        OperationResultSet<BookOfInterest> GetAllBooksOfInterestByUser(string userName, string guid);

        [OperationContract]
        [WebGet(UriTemplate = "/GetAllBooks?userName={userName}&guid={guid}")]
        OperationResultSet<Book> GetAllBooks(string userName, string guid);

        [OperationContract]
        [WebGet(UriTemplate = "/GetAllBooksByYear?year={year}&userName={userName}&guid={guid}")]
        OperationResultSet<Book> GetAllBooksByYear(int year, string userName, string guid);

        [OperationContract]
        [WebGet(UriTemplate = "/GetAllBooksByTitle?title={title}&userName={userName}&guid={guid}")]
        OperationResultSet<Book> GetAllBooksByTitle(string title, string userName, string guid);

        [OperationContract]
        [WebGet(UriTemplate = "/GetAllBooksByUser?userName={userName}&guid={guid}")]
        OperationResultSet<Book> GetAllBooksByUser(string userName, string guid);

        [OperationContract]
        [WebGet(UriTemplate = "/GetAllBooksByAuthor?author={authorName}&userName={userName}&guid={guid}")]
        OperationResultSet<Book> GetAllBooksByAuthor(string authorName, string userName, string guid);

        [OperationContract]
        [WebGet(UriTemplate = "/GetAllBooksByGenre?genre={genre}&userName={userName}&guid={guid}")]
        OperationResultSet<Book> GetAllBooksByGenre(string genre, string userName, string guid);

        [OperationContract]
        [WebGet(UriTemplate = "/GetAllBooksByType?type={type}&userName={userName}&guid={guid}")]
        OperationResultSet<Book> GetAllBooksByType(string type, string userName, string guid);

        [OperationContract]
        [WebInvoke(UriTemplate = "/ReserveBook?userName={userName}&guid={guid}")]
        OperationResult ReserveBook(Book book, string userName, string guid);

        /*[OperationContract]
        [WebInvoke(UriTemplate = "/ReleaseBook?userName={userName}&guid={guid}")]
        OperationResult ReleaseBook(Book book, string userName, string guid);*/
    }
}
