using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Library.Models
{
    [DataContract(Namespace = "http://localhost/Library.Models")]
    public class OperationResultValue<T> : OperationResult
    {
        [DataMember]
        public T ResultValue;

        public OperationResultValue()
            : base(ErrorEnum.ResultNotInitialized, "Result not initialized")
        {
        }

        public OperationResultValue(T resultValue)
            : base()
        {
            this.ResultValue = resultValue;
        }

        public OperationResultValue(ErrorEnum error, string errorString)
            : base(error, errorString)
        {
        }
    }
}