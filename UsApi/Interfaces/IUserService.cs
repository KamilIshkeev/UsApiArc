using UsApi.Models;

namespace UsApi.Interfaces
{
    public interface IUserService
    {
        Task<List<User>> GetAllUsersAsync();
        Task<User> GetUserByIdAsync(int id);
        Task<bool> CreateUserAsync(User user);
        
        Task<bool> DeleteUserAsync(int id);
        Task<User> AuthenticateAsync(string email, string password);
    }
}
