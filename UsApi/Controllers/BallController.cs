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
        [HttpGet("Hist/{id}")]
        public async Task<List<HistoryBall>> GetAllHistory(int id)
        {
            
            return await _context.HistoryBall.Where(u=> u.User_id == id).ToListAsync();
        }

        [HttpPost("Hist")]
        public async Task<IActionResult> CreateUser(HistoryBall historyBall)
        {
            if (await _context.HistoryBall.AnyAsync(u => u.Id == historyBall.Id))
            { 
                return BadRequest();
            }
            else 
            { 
            _context.HistoryBall.Add(historyBall);
            await _context.SaveChangesAsync();
            return Ok();
            }
        }

        [HttpGet("Hist")]
        public async Task<IActionResult> GetAllHist()
        {
            var historyBalls = await _context.HistoryBall.ToListAsync();
            return Ok(new { items = historyBalls });
        }

        //[HttpGet("Hist")]
        //public async Task<List<HistoryBall>> GetAllHist()
        //{
        //    return await _context.HistoryBall.ToListAsync();
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
