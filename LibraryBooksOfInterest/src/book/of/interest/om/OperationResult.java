package book.of.interest.om;

import javax.xml.bind.annotation.XmlAccessType;
import javax.xml.bind.annotation.XmlAccessorType;
import javax.xml.bind.annotation.XmlRootElement;

@XmlRootElement
@XmlAccessorType(XmlAccessType.FIELD)
public class OperationResult {
	public enum ErrorEnum
    {
        None,
        InvalidInputData,
        InternalProblem,
        NotAuthenticated, 
        ResultNotInitialized
    }

    public ErrorEnum Error;
    public String ErrorString;

    public OperationResult(ErrorEnum error, String errorString)
    {
        this.Error = error;
        this.ErrorString = errorString;
    }

    public OperationResult()
    {
        this.Error = ErrorEnum.None;
        this.ErrorString = "";
    }
}
