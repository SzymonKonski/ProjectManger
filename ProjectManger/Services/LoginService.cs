using ProjectManger.Data;
using ProjectManger.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManger.Services
{
    public class LoginService
    {
        private PMContext _context;

        public LoginService()
        {
            _context = new PMContext();
        }
        public LoggedInUser UserExists()
        {
            if (_context.User.Any())
            {
                return new LoggedInUser
                {
                    Name = _context.User.FirstOrDefault().Name
                }; 
            }

            return null;
        }

        public bool Login(LoginUserDto user)
        {
            return _context.User.Any(x => x.Password == HashPassword(user.Password));
        }

        private string HashPassword(string password)
        {
            var alg = SHA256.Create();
            StringBuilder sb = new StringBuilder();
            foreach (var by in alg.ComputeHash(Encoding.UTF8.GetBytes(password)))
            {
                sb.Append(by.ToString("X2"));
            }
            return sb.ToString();
        }
    }
}
