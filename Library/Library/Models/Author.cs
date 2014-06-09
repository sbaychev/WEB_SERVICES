using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using Library.Database;

namespace Library.Models
{
    [DataContract(Namespace = "http://localhost/Library.Models")]
    public class Author
    {
        [DataMember]
        public int AuthorId;

        [DataMember]
        public string FirstName;

        [DataMember]
        public string LastName;

        public DateTime BornDateInner;

        [DataMember]
        public String BornDate
        {
            get { return BornDateInner.ToShortDateString(); }
            set {
                DateTime result = new DateTime();
                DateTime.TryParse(value, out result);
                BornDateInner = result; }
        }

        public DateTime DeathDateInner;

        [DataMember]
        public String DeathDate
        {
            get { return DeathDateInner.ToShortDateString(); }
            set {
                DateTime result = new DateTime();
                DateTime.TryParse(value, out result);
                DeathDateInner = result;
            }
        }

        [DataMember]
        public string AuthorInfo;

        public bool Validate()
        {
            if (FirstName == null || LastName == null)
            {
                return false;
            }
            return true;
        }
    }
}