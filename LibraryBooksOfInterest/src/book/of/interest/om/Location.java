package book.of.interest.om;

import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlAccessorType;
import javax.xml.bind.annotation.XmlAccessType;
import javax.xml.bind.annotation.XmlSeeAlso;

@XmlRootElement
@XmlAccessorType(XmlAccessType.FIELD)
@XmlSeeAlso({OperationResultSet.class, OperationResultValue.class})
public class Location {
	
	public String country;
    public String city;
    public String postCode;
    public String address;
	
    public Location()
    {
    
    }
    
    public Location(String country, String city, String postCode, String address) {
		setCountry(country);
		setCity(city);
		setPostCode(postCode);
		setAddress(address);
	}
    
	public String getCountry() {
		return country;
	}
	public void setCountry(String country) {
		this.country = country;
	}
	public String getCity() {
		return city;
	}
	public void setCity(String city) {
		this.city = city;
	}
	public String getPostCode() {
		return postCode;
	}
	public void setPostCode(String postCode) {
		this.postCode = postCode;
	}
	public String getAddress() {
		return address;
	}
	public void setAddress(String address) {
		this.address = address;
	}
}
