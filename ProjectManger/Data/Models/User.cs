using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectManger.Data.Models
{
    public class User
    {
        public User(string name, string hash)
        {
            Name = name;
            Password = hash;
        }

        public long Id { get; set; }
        public string  Name { get; set; }
        public string Password { get; set; }
    }
}
