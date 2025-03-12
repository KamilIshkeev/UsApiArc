using Microsoft.EntityFrameworkCore;
using UsApi.Interfaces;
using UsApi.Models;
using UsApi.UDbContext;

namespace UsApi.Services
{
    public class UserService : IUserService
    {
        private readonly UserDbContext _context;
        public UserService(UserDbContext context)
        {
            _context = context;
        }
        public async Task<List<User>> GetAllUsersAsync()
        {
            return await _context.User.ToListAsync();
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            return await _context.User.FindAsync(id);
        }

        public async Task<bool> CreateUserAsync(User user)
        {
            // Проверяем только уникальность логина
            if (await _context.User.AnyAsync(u => u.Login == user.Login))
                return false;

            _context.User.Add(user);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateUserAsync(User user)
        {
            var existingUser = await _context.User.FindAsync(user.Id);
            if (existingUser == null)
                return false;

            existingUser.Login = user.Login;
            existingUser.Password = user.Login;
            existingUser.Money = user.Money;
            existingUser.Ball_id = user.Ball_id;

            await _context.SaveChangesAsync();
            return true;
        }


        public async Task<bool> DeleteUserAsync(int id)
        {
            var user = await _context.User.FindAsync(id);
            if (user == null)
                return false;

            _context.User.Remove(user);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<User> AuthenticateAsync(string Login, string Password)
        {
            var user = await _context.User.FirstOrDefaultAsync(u => u.Login == Login && u.Password == Password);
            return user;
        }


    }
}
