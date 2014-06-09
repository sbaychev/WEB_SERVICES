package book.of.interest.om;

import java.util.List;

import javax.xml.bind.annotation.XmlAccessType;
import javax.xml.bind.annotation.XmlAccessorType;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlSeeAlso;

@XmlRootElement
@XmlAccessorType(XmlAccessType.FIELD)
@XmlSeeAlso({BookOfInterest.class, Location.class, User.class, OperationResult.class})
public class OperationResultSet<T> extends OperationResult {

    public List<T> ResultSet;

    public OperationResultSet()
    {
    	super(ErrorEnum.ResultNotInitialized, "Result not initialized");
    }
    
    public OperationResultSet(List<T> resultSet)
    {
        this.ResultSet = resultSet;
    }

    public OperationResultSet(ErrorEnum error, String errorString)
    {
    	super(error, errorString);
        this.ResultSet = null;
    }
}
