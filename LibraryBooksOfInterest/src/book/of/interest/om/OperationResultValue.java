package book.of.interest.om;

import javax.xml.bind.annotation.XmlAccessType;
import javax.xml.bind.annotation.XmlAccessorType;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlSeeAlso;

@XmlRootElement
@XmlAccessorType(XmlAccessType.FIELD)
@XmlSeeAlso({BookOfInterest.class, Location.class, User.class, OperationResult.class})
public class OperationResultValue<T> extends OperationResult{

    public T ResultValue;

    public OperationResultValue()
    {
    	super(ErrorEnum.ResultNotInitialized, "Result not initialized");
    }

    public OperationResultValue(T resultValue)
    {
        this.ResultValue = resultValue;
    }

    public OperationResultValue(ErrorEnum error, String errorString)
    {
    	super(error, errorString);
    }
}
