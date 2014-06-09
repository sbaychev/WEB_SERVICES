package book.of.interest.om;

import javax.xml.bind.annotation.XmlAccessorType;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlAccessType;
import javax.xml.bind.annotation.XmlSeeAlso;

@XmlRootElement
@XmlAccessorType(XmlAccessType.FIELD)
@XmlSeeAlso({OperationResultSet.class, OperationResultValue.class})
public class BookOfInterest {
	
    public int bookId;
    public User user;
    public String title;
    public String authorName;

    public BookOfInterest()
    {
    
    }
    
    public BookOfInterest(int bookId, User user, String title, String authorName) {
		setBookId(bookId);
		setUser(user);
		setTitle(title);
		setAuthorName(authorName);
	}
    
    public int getBookId() {
		return bookId;
	}

	public void setBookId(int bookId) {
		this.bookId = bookId;
	}

	public User getUser() {
		return user;
	}

	public void setUser(User user) {
		this.user = user;
	}

	public String getTitle() {
		return title;
	}

	public void setTitle(String title) {
		this.title = title;
	}

	public String getAuthorName() {
		return authorName;
	}

	public void setAuthorName(String authorName) {
		this.authorName = authorName;
	}

	public boolean Validate()
    {
        /*boolean validUserName;
        using (UserData userData = new UserData())
        {
            validUserName = userData.GetUserByUserName(User.UserName) != null;
        }

        if (!validUserName ||
            String.IsNullOrEmpty(Title) || 
            String.IsNullOrEmpty(AuthorName))
        {
            return false;
        }*/
        return true;
    }
}
