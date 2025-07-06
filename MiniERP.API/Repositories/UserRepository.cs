using Microsoft.EntityFrameworkCore;
using MiniERP.API.Data;
using MiniERP.API.Models;

namespace MiniERP.API.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<User?> GetByUsernameAsync(string username)
        {
            return await _dbSet
                .Include(u => u.UserRoles)
                .ThenInclude(ur => ur.Role)
                .FirstOrDefaultAsync(u => u.Username == username);
        }

        public async Task<User?> GetByEmailAsync(string email)
        {
            return await _dbSet
                .Include(u => u.UserRoles)
                .ThenInclude(ur => ur.Role)
                .FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task<User?> GetUserWithRolesAsync(int userId)
        {
            return await _dbSet
                .Include(u => u.UserRoles)
                .ThenInclude(ur => ur.Role)
                .FirstOrDefaultAsync(u => u.UserID == userId);
        }

        public async Task<User?> AuthenticateAsync(string username, string password)
        {
            var user = await _dbSet
                .Include(u => u.UserRoles)
                .ThenInclude(ur => ur.Role)
                .FirstOrDefaultAsync(u => u.Username == username && u.IsActive);

            if (user != null && VerifyPassword(password, user.Password))
            {
                return user;
            }

            return null;
        }

        public async Task<bool> IsUsernameUniqueAsync(string username, int? excludeUserId = null)
        {
            return !await _dbSet.AnyAsync(u => u.Username == username && (!excludeUserId.HasValue || u.UserID != excludeUserId.Value));
        }

        public async Task<bool> IsEmailUniqueAsync(string email, int? excludeUserId = null)
        {
            return !await _dbSet.AnyAsync(u => u.Email == email && (!excludeUserId.HasValue || u.UserID != excludeUserId.Value));
        }

        public async Task<IEnumerable<User>> GetUsersByRoleAsync(string roleName)
        {
            return await _dbSet
                .Include(u => u.UserRoles)
                .ThenInclude(ur => ur.Role)
                .Where(u => u.UserRoles.Any(ur => ur.Role.RoleName == roleName) && u.IsActive)
                .ToListAsync();
        }

        public async Task<bool> UpdatePasswordAsync(int userId, string newPasswordHash)
        {
            var user = await _dbSet.FindAsync(userId);
            if (user != null)
            {
                user.Password = newPasswordHash;
                return await SaveChangesAsync();
            }
            return false;
        }

        public async Task<bool> AssignRolesAsync(int userId, IEnumerable<int> roleIds)
        {
            // Remove existing roles
            var existingRoles = await _context.UserRoles
                .Where(ur => ur.UserID == userId)
                .ToListAsync();

            _context.UserRoles.RemoveRange(existingRoles);

            // Add new roles
            var newUserRoles = roleIds.Select(roleId => new UserRole
            {
                UserID = userId,
                RoleID = roleId,
                CreatedDate = DateTime.Now
            });

            await _context.UserRoles.AddRangeAsync(newUserRoles);
            return await SaveChangesAsync();
        }

        public async Task<IEnumerable<User>> GetActiveUsersAsync()
        {
            return await _dbSet
                .Include(u => u.UserRoles)
                .ThenInclude(ur => ur.Role)
                .Where(u => u.IsActive)
                .ToListAsync();
        }

        private bool VerifyPassword(string password, string hash)
        {
            // In a real application, you would use a proper password hashing library like BCrypt
            // For now, we'll use a simple hash comparison
            return hash == password; // This is just for demo - use proper hashing in production!
        }
    }
} 