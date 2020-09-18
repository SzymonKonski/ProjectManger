using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using ProjectManger.Controllers;
using ProjectManger.Data;
using ProjectManger.Dtos;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManger.Services
{
    public class LoginService
    {
        private PMContext _context;
        private Encrypter _encrypter;
        private IOptions<SecuritySettings> _config;

        public LoginService(IOptions<SecuritySettings> config, PMContext context, Encrypter encrypter)
        {
            _context = context;
            _encrypter = encrypter;
            _config = config;
        }
        public UsernameDto UserExists()
        {
            if (!_context.User.Any())
            {
                return null;
            }

            var login = _context.User.Single().Name;
            return new UsernameDto(login);
        }

        public LoggedInUser Login(LoginUserDto user)
        {
            if(!IsPasswordCorrect(user.Password))
            {
                return null;
            }

            string name = _context.User.First().Name;
            var token = GenerateToken(name);
            var loggedInUser = new LoggedInUser(name, token);
            return loggedInUser;
        }

        private bool IsPasswordCorrect(string password)
        {
            var salt = _encrypter.GetSalt(password);
            var hash = _encrypter.GetHash(password, salt);
            return _context.User.Any(x => x.Password == hash);
        }

        private string GenerateToken(string username)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(_config.Value.Key);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new System.Security.Claims.ClaimsIdentity(new Claim[]
                {
                        new Claim(ClaimTypes.Name, username)
                }),
                Expires = DateTime.Now.AddDays(_config.Value.ExpireDays),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}
