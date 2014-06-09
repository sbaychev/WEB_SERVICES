using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Xml;
using Test.LibraryService;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Press any key to continue");
            Console.ReadLine();

            BookManagement proxy = new BookManagement();

            /*OperationResultSetOfUserUcBWdBTS result = proxy.GetAllUsers();
            foreach (User user in result.ResultSet)
            {
                Console.WriteLine(user.UserName.ToString());
            }

            OperationResultSetOfstring types = proxy.GetAllTypes();
            if (types.Error == OperationResultErrorEnum.None)
            {
                if (types.ResultSet.Count() > 0)
                {
                    foreach (string type in types.ResultSet)
                    {
                        Console.WriteLine(type);
                    }
                }
            }

            OperationResultSetOfstring genres = proxy.GetAllGenres();
            if (genres.Error == OperationResultErrorEnum.None)
            {
                if (genres.ResultSet.Count() > 0)
                {
                    foreach (string genre in genres.ResultSet)
                    {
                        Console.WriteLine(genre);
                    }
                }
            }
            Author author1 = new Author();
            author1.FirstName = "Maria";
            author1.LastName = "Kapon";
            author1.BornDate = new DateTime(1945, 02, 03, 02, 30, 20).ToString();
            author1.DeathDate = new DateTime(2013, 02, 03, 02, 30, 20).ToString();
            OperationResult or = proxy.AddAuthor(author1);
            Console.WriteLine("Adding Maria Kapon error" + or.Error.ToString());
            Author author2 = new Author();
            author2.FirstName = "Esra";
            author2.LastName = "Dimitrova";
            author2.BornDate = new DateTime(1937, 04, 03, 02, 30, 20).ToString();
            author2.DeathDate = new DateTime(2012, 05, 03, 02, 30, 20).ToString();
            or = proxy.AddAuthor(author2);
            Console.WriteLine("Adding Esra Dimitrova error" + or.Error.ToString());
            Author author3 = new Author();
            author3.FirstName = "Petur";
            author3.LastName = "Marinov";
            author3.BornDate = new DateTime(1925, 04, 03, 02, 30, 20).ToString();
            or = proxy.AddAuthor(author3);
            Console.WriteLine("Adding Petur Marinov error" + or.Error.ToString());

            OperationResultSetOfAuthorUcBWdBTS authors = proxy.GetAllAuthors();
            foreach (Author author in authors.ResultSet)
            {
                Console.WriteLine(author.AuthorInfo);
            }

            /*Book book = new Book();
            book.Author = authors.ResultSet[0];
            book.Genre = "nqma takuv";
            book.Isbn = "1233444";
            book.Title = "One two three";
            book.Type = "nqma takuv";
            User user = new User();
            user.UserName = "alex";
            book.User = user;
            book.Year = 1988;
            OperationResult or1 = proxy.AddBook(book);
            Console.WriteLine("Book added " + or1.Error.ToString());*/

            User user = new User();
            user.UserName = "maria";

            /*BookOfInterest book = new BookOfInterest();
            book.Title = "D e j";
            book.AuthorName = "Petur Petrov";
            book.User = user;
            OperationResult result = proxy.AddBookOfInterest(book);
            if (result.Error.Equals(OperationResultErrorEnum.None))
            {
                Console.WriteLine("Book successfully added");
            }
            else
            {
                Console.WriteLine(result.ErrorString);
            }*/

            /*OperationResultSetOfBookOfInterest6WXd3OUP booksOfInterest = proxy.GetAllBooksOfInterestByUser("maria");
            if (booksOfInterest.Error.Equals(OperationResultErrorEnum.None))
            {
                foreach (BookOfInterest bookr in booksOfInterest.ResultSet)
                {
                    Console.WriteLine(bookr.Title + " " + bookr.AuthorName + " " + bookr.User.UserName);
                }
            }*/

            OperationResultSetOfBookUcBWdBTS bookcheck = proxy.CheckBookOfInterest(1, true);
            if (bookcheck.Error.Equals(OperationResultErrorEnum.None))
            {
                foreach (Book bookr in bookcheck.ResultSet)
                {
                    Console.WriteLine(bookr.Title + " " + bookr.Author.AuthorInfo + " " + bookr.User.UserName);
                }
            }

            Console.WriteLine("Press any key to continue");
            Console.Read();
        }
    }
}
