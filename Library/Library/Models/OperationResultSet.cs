using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Library.Models
{
    [DataContract(Namespace = "http://localhost/Library.Models")]
    public class OperationResultSet<T> : OperationResult
    {
        [DataMember]
        public List<T> ResultSet;

        public OperationResultSet(List<T> resultSet) : base()
        {
            this.ResultSet = resultSet;
        }

        public OperationResultSet(ErrorEnum error, string errorString)
            : base(error, errorString)
        {
            this.ResultSet = null;
        }
    }
}