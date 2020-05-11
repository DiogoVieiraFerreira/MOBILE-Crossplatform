using System;
using System.Collections.Generic;
using System.Text;

namespace mobile.Models
{
    class User
    {
        public string Firstname { get; protected set; }
        public string Lastname { get; protected set; }
        public string PhoneNumber{ get; protected set; }
        public string Token { get; protected set; }

        public User(string firstname, string lastname, string phoneNumber)
        {
            this.Firstname = firstname;
            this.Lastname = lastname;
            this.PhoneNumber = phoneNumber;
        }

        public static bool CheckInformations(string firstname, string lastname, string phoneNumber)
        {
            if (string.IsNullOrEmpty(firstname) || string.IsNullOrEmpty(lastname) || string.IsNullOrEmpty(phoneNumber))
                return false;

            return true;
        }

        public User(string token)
        {
            this.Token = token;
        }
    }
}
