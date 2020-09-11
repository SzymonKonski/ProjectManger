using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectManger.Dtos;
using ProjectManger.Services;

namespace ProjectManger.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private RegisterService _registerService = new RegisterService();
        private LoginService _loginService = new LoginService();
        [Route("register")]
        [HttpPost]
        public async Task Register(NewUserDto user)
        {
            await _registerService.Register(user);
        }

        [Route("exists")]
        [HttpGet]
        public LoggedInUser Exists()
        {
            return _loginService.UserExists();
        }
        
        [Route("login")]
        [HttpPost]
        public bool Login(LoginUserDto user)
        {
            return _loginService.Login(user);
        }

        
    }
}
