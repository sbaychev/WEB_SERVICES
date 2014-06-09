using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Library.Models
{
    [DataContract(Namespace = "http://localhost/Library.Models")]
    public class User
    {
        [DataMember]
        public string UserName;

        [DataMember]
        public string FirstName;

        [DataMember]
        public string LastName;

        [DataMember]
        public Location Location;

        public int LocationId;

        [DataMember]
        public string Phone;

        [DataMember]
        public string Email;
    }
}