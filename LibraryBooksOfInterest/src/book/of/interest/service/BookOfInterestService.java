package book.of.interest.service;

import java.util.ArrayList;
import java.util.List;

import javax.ws.rs.Consumes;
import javax.ws.rs.FormParam;
import javax.ws.rs.GET;
import javax.ws.rs.POST;
import javax.ws.rs.Path;
import javax.ws.rs.Produces;
import javax.ws.rs.QueryParam;
import javax.ws.rs.core.Context;
import javax.ws.rs.core.MediaType;
import javax.ws.rs.core.Request;
import javax.ws.rs.core.UriInfo;

import book.of.interest.dao.BookOfInterestDAO;
import book.of.interest.om.BookOfInterest;
import book.of.interest.om.OperationResult;
import book.of.interest.om.OperationResult.ErrorEnum;
import book.of.interest.om.OperationResultSet;
import book.of.interest.om.OperationResultValue;
import book.of.interest.om.User;

@Path("/bookofinterest")
public class BookOfInterestService {

	@Context
	UriInfo uriInfo;
	@Context
	Request request;

	@GET
	@Produces({MediaType.APPLICATION_XML, MediaType.APPLICATION_JSON})
	@Path("/byuser")
	public OperationResultSet<BookOfInterest> getBooksOfInterestByUser(
			@QueryParam("username") String userName,
			@QueryParam("guid") String guid) {
		try
		{
			if (userName == null || userName.equals("") || userName == null || userName.equals(""))
			{
				return new OperationResultSet<BookOfInterest>(
						ErrorEnum.NotAuthenticated,
						"Please authenticate first");
			}
			
			if (!BookOfInterestDAO.instance.checkUserAuthenticatedSql(userName, guid))
			{
				return new OperationResultSet<BookOfInterest>(
						ErrorEnum.NotAuthenticated,
						"Please authenticate first");
			}
			
			List<BookOfInterest> booksOfInterest = new ArrayList<BookOfInterest>();
			booksOfInterest.addAll(BookOfInterestDAO.instance.getBooksOfInterestByUserSql(userName));
			return new OperationResultSet(booksOfInterest);
		}
		catch(Exception ex)
		{
			ex.printStackTrace();
			return new OperationResultSet<BookOfInterest>(
					ErrorEnum.InternalProblem,
					"Some internal problem has occured");
		}
	}
	
	@POST
	@Consumes({MediaType.APPLICATION_FORM_URLENCODED})
	@Path("/add")
	public OperationResultValue<Integer> addBookOfInterest(
			@FormParam("username") String userName, 
			@FormParam("guid") String guid,
			@FormParam("title") String title,
			@FormParam("author") String author) {
		try
		{
			if (userName == null || userName.equals("") || userName == null || userName.equals(""))
			{
				return new OperationResultValue<Integer>(
						ErrorEnum.NotAuthenticated,
						"Please authenticate first");
			}
			
			if (!BookOfInterestDAO.instance.checkUserAuthenticatedSql(userName, guid))
			{
				return new OperationResultValue<Integer>(
						ErrorEnum.NotAuthenticated,
						"Please authenticate first");
			}
			
			if (title == null || title.equals("") || author == null || author.equals(""))
			{
				return new OperationResultValue<Integer>(
						ErrorEnum.InvalidInputData,
						"Please fill in correctly all fields");
			}
			
			BookOfInterest book = new BookOfInterest();
			book.setAuthorName(author);
			book.setTitle(title);
			
			if (BookOfInterestDAO.instance.addBookOfInterestSql(userName, book))
			{
				return new OperationResultValue<Integer>(1);
			}
			else
			{
				return new OperationResultValue<Integer>(0);
			}
		}
		catch(Exception ex)
		{
			ex.printStackTrace();
			return new OperationResultValue<Integer>(
					ErrorEnum.InternalProblem,
					"Some internal problem has occured");
		}
	}
	
	@GET
	@Produces({MediaType.APPLICATION_XML, MediaType.APPLICATION_JSON})
	@Path("/check")
	public OperationResultSet<User> checkBookOfInterest(
			@QueryParam("username") String userName, 
			@QueryParam("guid") String guid,
			@QueryParam("bookid") int bookId) {
		try
		{
			if (userName == null || userName.equals("") || userName == null || userName.equals(""))
			{
				return new OperationResultSet<User>(
						ErrorEnum.NotAuthenticated,
						"Please authenticate first");
			}
	
			if (!BookOfInterestDAO.instance.checkUserAuthenticatedSql(userName, guid))
			{
				return new OperationResultSet<User>(
						ErrorEnum.NotAuthenticated,
						"Please authenticate first");
			}
			List<User> users = BookOfInterestDAO.instance.checkBookOfInterestSql(userName, bookId);
			return new OperationResultSet(users);
		}
		catch(Exception ex)
		{
			ex.printStackTrace();
			return new OperationResultSet<User>(
					ErrorEnum.InternalProblem,
					"Some internal problem has occured");
		}
	}
}
