using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryExchangeClient.BookOfInterest
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
    }
}
