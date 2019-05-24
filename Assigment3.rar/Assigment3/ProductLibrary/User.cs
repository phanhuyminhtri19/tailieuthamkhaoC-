namespace ProductLibrary
{
    using System;


    public partial class User
    {

        public String Username { get; set; }
        public String Password { get; set; }
        public String Fullname { get; set; }
        public Boolean IsAdmin { get; set; }
        public User()
        {

        }

        public User(string username, string password, string fullname, bool admin)
        {
            Username = username;
            Password = password;
            Fullname = fullname;
            IsAdmin = admin;
        }
    }
}
