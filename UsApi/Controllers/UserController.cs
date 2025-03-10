using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UsApi.Interfaces;
using UsApi.Models;

namespace UsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _userService.GetAllUsersAsync();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            var user = await _userService.GetUserByIdAsync(id);
            if (user == null)
                return NotFound();

            return Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(User user)
        {
            var result = await _userService.CreateUserAsync(user);
            if (!result)
                return BadRequest("Email already exists");

            return Ok();
        }

        

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var result = await _userService.DeleteUserAsync(id);
            if (!result)
                return NotFound();

            return Ok();
        }

        [HttpPost("authentication")]
        public async Task<IActionResult> Authenticate(string login, string password)
        {
            
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //var authenticatedUser = await _userService.AuthenticateAsync(loginRequest., loginRequest.Password);
            var user1 = await _userService.AuthenticateAsync(login, password);
            if (user1 == null)
            {
                return Unauthorized();
            }

            return Ok(user1);
        }
    }
}
