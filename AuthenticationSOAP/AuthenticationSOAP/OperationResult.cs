using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AuthenticationSOAP
{
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

        public ErrorEnum Error;

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