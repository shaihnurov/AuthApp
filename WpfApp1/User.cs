using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthApp
{
    class User
    {
        public int id { get; set; }
        private string name, email, pass;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public string Email
        {
            get { return email; }
            set { email = value; }
        }
        public string Pass
        {
            get { return pass; }
            set{ pass = value; }
        }

        public User() { }

        public User(string name, string email, string pass)
        {
            Name = name;
            Email = email;
            Pass = pass;
        }
    }
}
