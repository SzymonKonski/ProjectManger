using ProjectManger.Data;
using ProjectManger.Data.Models;
using ProjectManger.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManger.Services
{
    public class RegisterService
    {
        private PMContext _context;
        private Encrypter _encrypter;

        public RegisterService(PMContext context, Encrypter encrypter)
        { 
            _context = context;
            _encrypter = encrypter;
        }

        public async Task Register(NewUserDto user)
        {

            if (_context.User.Any())
                throw new ArgumentException("Already exists");

            var salt = _encrypter.GetSalt(user.Password);
            var hash = _encrypter.GetHash(user.Password, salt);
            var entity = new User(user.Name, hash);
            _context.User.Add(entity);
            await _context.SaveChangesAsync();
        }
    }
}
