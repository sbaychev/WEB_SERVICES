package book.of.interest.om;

import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlAccessType;
import javax.xml.bind.annotation.XmlAccessorType;
import javax.xml.bind.annotation.XmlSeeAlso;

@XmlRootElement
@XmlAccessorType(XmlAccessType.FIELD)
@XmlSeeAlso({OperationResultSet.class, OperationResultValue.class})
public class User {

    public String userName;
    public String firstName;
    public String lastName;
    public Location location;
    public String phone;
    public String email;
    
    public User()
    {
    }
    
	public User(String userName, String firstName, String lastName,
			Location location, String phone, String email) {
		setUserName(userName);
		setFirstName(firstName);
		setLastName(lastName);
		setLocation(location);
		setPhone(phone);
		setEmail(email);
	}
	
	public String getUserName() {
		return userName;
	}
	public void setUserName(String userName) {
		this.userName = userName;
	}
	public String getFirstName() {
		return firstName;
	}
	public void setFirstName(String firstName) {
		this.firstName = firstName;
	}
	public String getLastName() {
		return lastName;
	}
	public void setLastName(String lastName) {
		this.lastName = lastName;
	}
	public Location getLocation() {
		return location;
	}
	public void setLocation(Location location) {
		this.location = location;
	}
	public String getPhone() {
		return phone;
	}
	public void setPhone(String phone) {
		this.phone = phone;
	}
	public String getEmail() {
		return email;
	}
	public void setEmail(String email) {
		this.email = email;
	}
}
