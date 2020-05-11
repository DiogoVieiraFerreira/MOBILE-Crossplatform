using System;
using System.Collections.Generic;
using System.Text;

namespace mobile.Models
{
    class User
    {
        public string FirstName { get; protected set; }
        public string LastName { get; protected set; }
        public string PhoneNumber{ get; protected set; }
        public string Token { get; protected set; }

        public User(string firstname, string lastname, string phonenumber)
        {
            this.FirstName = firstname;
            this.LastName = lastname;
            this.PhoneNumber = phonenumber;
        }

        public User(string token)
        {
            this.Token = token;
        }
    }
}
