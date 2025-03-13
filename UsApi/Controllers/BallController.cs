using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UsApi.Models;
using UsApi.UDbContext;

namespace UsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BallController : Controller
    {
        private readonly UserDbContext _context;

        public BallController(UserDbContext context)
        {
            _context = context;
        }

        

        [HttpGet("{id}")]
        public async Task<Ball> GetUserById(int id)
        {
            return await _context.Ball.FindAsync(id);
        }
        [HttpGet]
        public async Task<List<Ball>> GetAllUsers()
        {
            return await _context.Ball.ToListAsync();
        }
        //[HttpPost]
        //public async Task<IActionResult> CreateUser(User user)
        //{
        //    var result = await _userService.CreateUserAsync(user);
        //    if (!result)
        //        return BadRequest("Email already exists");

        //    return Ok();
        //}

        //[HttpPut("{id}")]
        //public async Task<IActionResult> UpdateUser(int id, User user)
        //{
        //    if (id != user.Id)
        //        return BadRequest();

        //    var result = await _userService.UpdateUserAsync(user);
        //    if (!result)
        //        return NotFound();

        //    return Ok();
        //}

        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteUser(int id)
        //{
        //    var result = await _userService.DeleteUserAsync(id);
        //    if (!result)
        //        return NotFound();

        //    return Ok();
        //}
    }
}
