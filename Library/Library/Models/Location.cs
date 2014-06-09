using System.Runtime.Serialization;

namespace Library.Models
{
    [DataContract(Namespace = "http://localhost/Library.Models")]
    public class Location
    {
        [DataMember]
        public string Country;

        [DataMember]
        public string City;

        [DataMember]
        public string PostCode;

        [DataMember]
        public string Address;
    }
}