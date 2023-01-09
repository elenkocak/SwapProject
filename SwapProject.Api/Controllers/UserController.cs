using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SwapProject.Business.Abstract;
using SwapProject.Core.Entities.Concrete;
using SwapProject.Entity.DTO.UserDto;

namespace SwapProject.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class UserController : ControllerBase
    {
        private IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpGet("getlist")]
        public IActionResult GetAll()
        {
            var result = _userService.GetList();
            return Ok(result);
        }
        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _userService.GetById(id);  
            return Ok(result);
        }
        [HttpPost("create")]
        public IActionResult Create(User user)
        {
            var result=_userService.Create(user);
            return Ok(result);
        }
        [HttpPost("update")]
        public IActionResult Update(UserUpdateDto userUpdateDto)
        {
            var result = _userService.Update(userUpdateDto);
            return Ok(result);
        }
        [HttpPost("delete")]
        public IActionResult Delete(int id)
        {
            var result = _userService.Delete(id);
            return Ok(result);
        }
    }
}
