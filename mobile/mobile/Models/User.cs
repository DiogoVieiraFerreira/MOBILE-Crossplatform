namespace mobile.Models
{
    class User
    {
        public int ID { get; set; }
        public string Firstname { get; protected set; }
        public string Lastname { get; protected set; }
        public string PhoneNumber{ get; set; }
        public string Token { get; set; }
        public User(string token)
        {
            this.Token = token;
        }

        public User(string firstname, string lastname)
        {
            this.Firstname = firstname;
            this.Lastname = lastname;
        }

        public static bool CheckInformations(string firstname, string lastname, string phoneNumber)
        {
            if (string.IsNullOrEmpty(firstname) || string.IsNullOrEmpty(lastname) || string.IsNullOrEmpty(phoneNumber))
                return false;

            return true;
        }

    }
}
