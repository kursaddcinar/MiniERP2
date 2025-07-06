using MiniERP.API.Models;

namespace MiniERP.API.Repositories
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task<User?> GetByUsernameAsync(string username);
        Task<User?> GetByEmailAsync(string email);
        Task<User?> GetUserWithRolesAsync(int userId);
        Task<User?> AuthenticateAsync(string username, string password);
        Task<bool> IsUsernameUniqueAsync(string username, int? excludeUserId = null);
        Task<bool> IsEmailUniqueAsync(string email, int? excludeUserId = null);
        Task<IEnumerable<User>> GetUsersByRoleAsync(string roleName);
        Task<bool> UpdatePasswordAsync(int userId, string newPasswordHash);
        Task<bool> AssignRolesAsync(int userId, IEnumerable<int> roleIds);
        Task<IEnumerable<User>> GetActiveUsersAsync();
    }
} 