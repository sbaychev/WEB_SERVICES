using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Library.Models
{
    [DataContract(Namespace = "http://localhost/Library.Models")]
    public class OperationResult
    {
        public enum ErrorEnum
        {
            None,
            InvalidInputData,
            InternalProblem,
            NotAuthenticated, 
            ResultNotInitialized
        }

        [DataMember]
        public ErrorEnum Error;

        [DataMember]
        public string ErrorString;

        public OperationResult(ErrorEnum error, string errorString)
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
}