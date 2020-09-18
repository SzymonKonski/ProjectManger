using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectManger.Dtos
{
    public class LoggedInUser
    {
        public string Login { get; }
        public string Token { get; }

        public LoggedInUser(string login, string token)
        {
            Login = login;
            Token = token;
        }
    }
}
