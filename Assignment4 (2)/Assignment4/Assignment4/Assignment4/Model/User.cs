using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment4.Model
{
    public class User
    {
        public String Username { get; set; }
        public String Password { get; set; }
        public Boolean IsAdmin { get; set; }
        public User()
        {

        }
        public User(string username, string password, bool isAdmin)
        {
            Username = username;
            Password = password;
            IsAdmin = isAdmin;
        }
    }
}
