using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PasswordHasher.DTOs;
using PasswordHasher.Services;

namespace PasswordHasher.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        // Method is used to Add New User and Main Purpose is to hash the Plain Text Password
        [HttpPost]
        public IActionResult AddUser(UserDto userDto)
        {
            var user = _userService.AddUser(userDto);
            return Ok(user);
        }

        [HttpPost("/Login")]
        public IActionResult Login(UserDto userDto)
        {
            var user = _userService.Login(userDto);
            return Ok(user);
        }
    }
}
