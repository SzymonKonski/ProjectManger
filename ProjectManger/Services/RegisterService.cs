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

        public RegisterService()
        {
            _context = new PMContext();
            _encrypter = new Encrypter();
        }

        public async Task Register(NewUserDto user)
        {
            var salt = _encrypter.GetSalt(user.Password);
            var hash = _encrypter.GetHash(user.Password, salt);
            var entity = new User
            {
                Name = user.Name,
                Password = hash
            };
            _context.User.Add(entity);
            await _context.SaveChangesAsync();
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
