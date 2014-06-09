using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AuthenticationSOAP
{
    public class OperationResultValue<T> : OperationResult
    {
        public T ResultValue;

        public OperationResultValue(T resultValue)
            : base()
        {
            this.ResultValue = resultValue;
        }
        public OperationResultValue()
            : base(ErrorEnum.ResultNotInitialized, "Result not initialized")
        {
        }
        public OperationResultValue(ErrorEnum error, string errorString)
            : base(error, errorString)
        {
        }
    }
}