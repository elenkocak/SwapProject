using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SwapProject.Business.Abstract;
using SwapProject.Entity.DTO.UserDto;

namespace SwapProject.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private IAuthService _authService;
       public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public IActionResult Login(UserLoginDto dto)
        {
            var result=_authService.Login(dto);
            return Ok(result);
        }
        [HttpPost("register")]
        public IActionResult Register(UserRegisterDto dto)
        {
            var result = _authService.Register(dto);
            return Ok(result);
        }
        [HttpPost("changeuserpassword")]
        public IActionResult ChangeUserPassword(UserPasswordChangeDto dto)
        {
            var result = _authService.ChangeUserPassword(dto);
            return Ok(result);
        }
    }
}
