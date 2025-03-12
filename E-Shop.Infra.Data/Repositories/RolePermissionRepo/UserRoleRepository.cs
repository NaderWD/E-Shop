using E_Shop.Domain.Contracts.RolePermissionCont;
using E_Shop.Domain.Models.RolePermissionModels;
using Microsoft.EntityFrameworkCore;

namespace E_Shop.Infra.Data.Repositories.RolePermissionRepo
{
    public class UserRoleRepository(ShopDbContext _context) : IUserRoleRepository
    {
        public async Task CreateUserRole(UserRole userRole)
            => await _context.UserRoles.AddAsync(userRole);

        public async Task<IEnumerable<UserRole>> GetAllUserRoles()
            => await _context.UserRoles.Include(x => x.User)
                                                        .Include(x => x.Role)
                                                        .Where(x => !x.IsDelete)
                                                        .ToListAsync();

        public async Task<List<Role>> GetAllRolesForUser()            
            => await _context.Roles.Where(x => !x.IsDelete).ToListAsync();

        public async Task<UserRole> GetUserRoleById(int userRoleId)
            => await _context.UserRoles.Include(x => x.User)
                                                        .Include(x => x.Role)
                                                        .FirstOrDefaultAsync(x => x.Id == userRoleId);

        public async Task<List<UserRole>> GetUserRolesByRoleId(int roleId)
            => await _context.UserRoles.Include(x => x.Role)
                                                        .Include(x => x.User)
                                                        .Where(x => x.RoleId == roleId && !x.IsDelete)
                                                        .ToListAsync();

        public async Task<List<UserRole>> GetUserRolesByUserId(int userId)
            => await _context.UserRoles.Include(x => x.Role)
                                                        .Include(x => x.User)
                                                        .Where(x => x.UserId == userId && !x.IsDelete)
                                                        .ToListAsync();

        public async Task<List<Role>> GetRolesByUserId(int userId)
            => await _context.UserRoles.Include(x => x.User)
                                                        .Include(x => x.Role)
                                                        .ThenInclude(x => x.RolePermissions!)
                                                        .ThenInclude(x => x.Permission)
                                                        .Select(x => x.Role)
                                                        .ToListAsync();

        public async Task UpdateUserRole(UserRole userRoleId)
            => _context.UserRoles.Update(userRoleId);

        public async Task DeleteUserRole(int userRoleId)
            => _context.UserRoles.Remove(await GetUserRoleById(userRoleId));
    }
}
