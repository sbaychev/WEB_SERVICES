using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using Library.Database;

namespace Library.Models
{
    public class BookOfInterest
    {
        [DataMember]
        public int BookId;

        [DataMember]
        public User User;

        public int UserId;

        [DataMember]
        public string Title;

        [DataMember]
        public string AuthorName;

        public bool Validate()
        {
            bool validUserName;
            using (UserData userData = new UserData())
            {
                validUserName = userData.GetUserByUserName(User.UserName) != null;
            }

            if (!validUserName ||
                String.IsNullOrEmpty(Title) || 
                String.IsNullOrEmpty(AuthorName))
            {
                return false;
            }
            return true;
        }
    }
}