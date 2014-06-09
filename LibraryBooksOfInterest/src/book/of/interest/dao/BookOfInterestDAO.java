package book.of.interest.dao;

import java.sql.CallableStatement;
import java.sql.Connection;
import java.sql.Date;
import java.sql.DriverManager;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.util.ArrayList;
import java.util.Calendar;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

import book.of.interest.om.BookOfInterest;
import book.of.interest.om.Location;
import book.of.interest.om.User;

public enum BookOfInterestDAO {
	instance;
	
	private static final int ACCESS_TIME_MINUTES = 5;
	private static final String DB_DRIVER = "net.sourceforge.jtds.jdbc.Driver";
	private static final String DB_CONNECTION = "jdbc:jtds:sqlserver://127.0.0.1:1433/SOA";
	private static final String DB_USER = "sa";
	private static final String DB_PASSWORD = "tgbyhn";
	
	private Map<Integer, BookOfInterest> bookOfInterestProvider = new HashMap<Integer, BookOfInterest>();
	private Map<Integer, User> userProvider = new HashMap<Integer, User>();
	private Map<Integer, Location> locationProvider = new HashMap<Integer, Location>();

    private BookOfInterestDAO() {
    	Location location1 = new Location("Bulgaria", "Sofia", "1230", "1 str.");
    	locationProvider.put(1, location1);
    	Location location2 = new Location("Bulgaria", "Haskovo", "6300", "2 str.");
    	locationProvider.put(2, location2);
    	Location location3 = new Location("Bulgaria", "Plovdiv", "2349", "3 str.");
    	locationProvider.put(3, location3);
    	User user1 = new User("alex", "Alexandra", "Salikiryaki",
    			location2, "+35932414343", "aius@abv.bg");
    	userProvider.put(1, user1);
    	User user2 = new User("stefan", "Stefan", "Baychev",
    			location1, "+35932324456", "baychev@abv.bg");
    	userProvider.put(2, user2);
    	BookOfInterest book1 = new BookOfInterest(1, user1, "Malkiqt princ", "Djani Rodari");
    	bookOfInterestProvider.put(1, book1);
    	BookOfInterest book2 = new BookOfInterest(2, user1, "Malkata princesa", "Silvia Andjlari");
    	bookOfInterestProvider.put(2, book2);
    	BookOfInterest book3 = new BookOfInterest(3, user2, "Zelenata Svetulka", "Maria Kapon");
    	bookOfInterestProvider.put(3, book3);
    }
   
    public Map<Integer, BookOfInterest> getAllBooksOfInterestByUser(String userName){
    	Map<Integer, BookOfInterest> result = new HashMap<Integer, BookOfInterest>();
    	for(BookOfInterest book : bookOfInterestProvider.values())
    	{
    		if (book.getUser().getUserName().equals(userName))
    		{
    			result.put(result.size(), book);
    		}
    	}
        return result;
    }

    public boolean addBookOfInterest(String userName, BookOfInterest book){
    	try
    	{
    		User user = null;
    		for (User thisUser : userProvider.values())
    		{
    			if (thisUser.getUserName().equals(userName))
    			{
    				user = thisUser;
    				break;
    			}
    		}
    		if (user == null)
    		{
    			return false;
    		}
    		book.setBookId(bookOfInterestProvider.size() + 1);
    		book.setUser(user);
    		bookOfInterestProvider.put(bookOfInterestProvider.size() + 1, book);
    		return true;
    	}
    	catch(Exception ex)
    	{
    		return false;
    	}
    }
    
    public List<User> checkBookOfInterest(String userName, int book){
    	try
    	{
    		return new ArrayList<User>(userProvider.values());
    	}
    	catch(Exception ex)
    	{
    		return null;
    	}
    }
    
    private static java.sql.Timestamp getCurrentDateTime() {
		return new java.sql.Timestamp(System.currentTimeMillis());
	}
    
    public boolean checkUserAuthenticatedSql(String userName, String guid){
    	int result = 0;
    	Connection dbConnection = null;
    	CallableStatement checkUserAuthenticatedStmt = null;
 
		try {
			dbConnection = getDBConnection();
 
			dbConnection.setAutoCommit(false);
			
			final String checkUserAuthenticatedSql = "{call check_user_authenticated(?,?,?,?)}";
			checkUserAuthenticatedStmt = dbConnection.prepareCall(checkUserAuthenticatedSql);
			checkUserAuthenticatedStmt.setString(1, userName);
			checkUserAuthenticatedStmt.setString(2, guid);
			checkUserAuthenticatedStmt.setTimestamp(3, getCurrentDateTime());
			checkUserAuthenticatedStmt.setInt(4, ACCESS_TIME_MINUTES);
			ResultSet rs = checkUserAuthenticatedStmt.executeQuery();
			while (rs.next())
            {
                result = rs.getInt("result");
            }

			dbConnection.commit();
			
			return result == 1;  
		} catch (SQLException e) {
 
			System.out.println(e.getMessage());
			try {
				dbConnection.rollback();
			} catch (SQLException e1) {
				e1.printStackTrace();
			}
			return false;
		} finally {
 
			if (checkUserAuthenticatedStmt != null) {
				try {
					checkUserAuthenticatedStmt.close();
				} catch (SQLException e) {
					e.printStackTrace();
				}
			}
 
			if (dbConnection != null) {
				try {
					dbConnection.close();
				} catch (SQLException e) {
					e.printStackTrace();
				}
			}
		}
    }
    
    public boolean addBookOfInterestSql(String userName, BookOfInterest book){
    	Connection dbConnection = null;
    	CallableStatement addBookOfInterestStmt = null;
 
		try {
			dbConnection = getDBConnection();
 
			dbConnection.setAutoCommit(false);
			
			final String addBookOfInterestSql = "{call add_book_of_interest(?,?,?)}";
			addBookOfInterestStmt = dbConnection.prepareCall(addBookOfInterestSql);
			addBookOfInterestStmt.setString(1, book.getTitle());
			addBookOfInterestStmt.setString(2, book.getAuthorName());
			addBookOfInterestStmt.setString(3, userName);
			addBookOfInterestStmt.executeQuery();
 
			dbConnection.commit();
			
			return true;  
		} catch (SQLException e) {
 
			System.out.println(e.getMessage());
			try {
				dbConnection.rollback();
			} catch (SQLException e1) {
				e1.printStackTrace();
			}
			return false;
		} finally {
 
			if (addBookOfInterestStmt != null) {
				try {
					addBookOfInterestStmt.close();
				} catch (SQLException e) {
					e.printStackTrace();
				}
			}
 
			if (dbConnection != null) {
				try {
					dbConnection.close();
				} catch (SQLException e) {
					e.printStackTrace();
				}
			}
		}
    }
    
    public List<User> checkBookOfInterestSql(String userName, int book){
    	List<User> result = new ArrayList<User>();
    	Connection dbConnection = null;
    	CallableStatement getUserOwningBookOfInterestStmt = null;
 
		try {
			dbConnection = getDBConnection();
 
			dbConnection.setAutoCommit(false);
			
			final String getUserOwningBookOfInterestSql = "{call check_book_of_interest(?)}";
			getUserOwningBookOfInterestStmt = dbConnection.prepareCall(getUserOwningBookOfInterestSql);
			getUserOwningBookOfInterestStmt.setInt(1, book);
			ResultSet rs = getUserOwningBookOfInterestStmt.executeQuery();
			while (rs.next())
            {
                String userUserName = rs.getString("user_name");
                String firstName = rs.getString("first_name");
                String lastName = rs.getString("last_name");
                String phone = rs.getString("phone");
                String email = rs.getString("email");
                String country = rs.getString("country");
                String city = rs.getString("city");
                String postcode = rs.getString("postcode");
                String address = rs.getString("address");
                
                Location location = new Location();
                location.setCountry(country);
                location.setCity(city);
                location.setPostCode(postcode);
                location.setAddress(address == null ? "" : address);
                User user = new User();
                user.setEmail(email);
                user.setFirstName(firstName == null ? "" : firstName);
                user.setLastName(lastName == null ? "" : lastName);
                user.setLocation(location);
                user.setPhone(phone == null ? "" : phone);
                user.setUserName(userUserName);
                
                result.add(user);
            }
 
			dbConnection.commit();
			
			return result;  
		} catch (SQLException e) {
 
			System.out.println(e.getMessage());
			try {
				dbConnection.rollback();
			} catch (SQLException e1) {
				e1.printStackTrace();
			}
			return null;
		} finally {
 
			if (getUserOwningBookOfInterestStmt != null) {
				try {
					getUserOwningBookOfInterestStmt.close();
				} catch (SQLException e) {
					e.printStackTrace();
				}
			}
 
			if (dbConnection != null) {
				try {
					dbConnection.close();
				} catch (SQLException e) {
					e.printStackTrace();
				}
			}
		}
    }
    
    public List<BookOfInterest> getBooksOfInterestByUserSql(String userName)
    {
    	List<BookOfInterest> result = new ArrayList<BookOfInterest>();
    	Connection dbConnection = null;
    	CallableStatement getBookOfInterestByUserByUserStmt = null;
 
		try {
			dbConnection = getDBConnection();
 
			dbConnection.setAutoCommit(false);
			
			final String getBookOfInterestByUserByUserSql = "{call get_all_books_of_interest_by_user(?)}";
			getBookOfInterestByUserByUserStmt = dbConnection.prepareCall(getBookOfInterestByUserByUserSql);
			getBookOfInterestByUserByUserStmt.setString(1, userName);
			ResultSet rs = getBookOfInterestByUserByUserStmt.executeQuery();
			while (rs.next())
            {
                Integer bookOfInterestId = rs.getInt("book_of_interest_id");
                String title = rs.getString("title");
                String authorName = rs.getString("author_name");
                String userUserName = rs.getString("user_name");
                String firstName = rs.getString("first_name");
                String lastName = rs.getString("last_name");
                String phone = rs.getString("phone");
                String email = rs.getString("email");
                String country = rs.getString("country");
                String city = rs.getString("city");
                String postcode = rs.getString("postcode");
                String address = rs.getString("address");
                
                Location location = new Location();
                location.setCountry(country);
                location.setCity(city);
                location.setPostCode(postcode);
                location.setAddress(address == null ? "" : address);
                User user = new User();
                user.setEmail(email);
                user.setFirstName(firstName == null ? "" : firstName);
                user.setLastName(lastName == null ? "" : lastName);
                user.setLocation(location);
                user.setPhone(phone == null ? "" : phone);
                user.setUserName(userUserName);
                BookOfInterest book = new BookOfInterest();
                book.setAuthorName(authorName);
                book.setBookId(bookOfInterestId);
                book.setTitle(title);
                book.setUser(user);
                
                result.add(book);
            }
 
			dbConnection.commit();
			
			return result;  
		} catch (SQLException e) {
 
			System.out.println(e.getMessage());
			try {
				dbConnection.rollback();
			} catch (SQLException e1) {
				e1.printStackTrace();
			}
			return null;
		} finally {
 
			if (getBookOfInterestByUserByUserStmt != null) {
				try {
					getBookOfInterestByUserByUserStmt.close();
				} catch (SQLException e) {
					e.printStackTrace();
				}
			}
 
			if (dbConnection != null) {
				try {
					dbConnection.close();
				} catch (SQLException e) {
					e.printStackTrace();
				}
			}
		}
    }
    
    private Connection getDBConnection() {
    	 
		Connection dbConnection = null;
 
		try {
 
			Class.forName(DB_DRIVER).newInstance();
 
		} catch (ClassNotFoundException | InstantiationException | IllegalAccessException e) {
 
			System.out.println(e.getMessage());
		}
 
		try {
 
			dbConnection = DriverManager.getConnection(DB_CONNECTION, DB_USER,
					DB_PASSWORD);
			return dbConnection;
 
		} catch (SQLException e) {
 
			System.out.println(e.getMessage());
		}
 
		return dbConnection;
	}
}
