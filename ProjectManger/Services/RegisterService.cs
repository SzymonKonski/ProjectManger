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

        public RegisterService()
        {
            _context = new PMContext();
        }

        public async Task Register(NewUserDto user)
        {
            var entity = new User
            {
                Name = user.Name,
                Password = HashPassword(user.Password)
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
