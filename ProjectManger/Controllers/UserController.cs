using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using ProjectManger.Dtos;
using ProjectManger.Services;

namespace ProjectManger.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase            
    {
        private RegisterService _registerService;
        private LoginService _loginService;

        public UserController(IOptions<SecuritySettings> config)
        {
            _registerService = new RegisterService();
            _loginService = new LoginService(config);
        }

        [Route("register")]
        [HttpPost]
        public async Task Register(NewUserDto user)
        {
            await _registerService.Register(user);
        }

        [Route("exists")]
        [HttpGet]
        public UsernameDto Exists()
        {
            return _loginService.UserExists();
        }
        
        [Route("login")]
        [HttpPost]
        public LoggedInUser Login(LoginUserDto user)
        {
            return _loginService.Login(user);
        }

        
    }
}
