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
        private Encrypter _encrypter;

        public LoginService()
        {
            _context = new PMContext();
            _encrypter = new Encrypter();
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
            var salt = _encrypter.GetSalt(user.Password);
            var hash = _encrypter.GetHash(user.Password, salt);
            return _context.User.Any(x => x.Password == hash);
        }
    }
}
