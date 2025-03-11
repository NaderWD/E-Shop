using E_Shop.Domain.Contracts.RolePermissionCont;
using E_Shop.Domain.Models.RolePermissionModels;
using Microsoft.EntityFrameworkCore;

namespace E_Shop.Infra.Data.Repositories.RolePermissionRepo
{
    public class RoleRepository(ShopDbContext _context) : IRoleRepository
    {
        public async Task CreateRole(Role role)
            => await _context.Roles.AddAsync(role);

        public async Task<IEnumerable<Role>> GetAllRoles()
            => await _context.Roles.Include(x => x.RolePermissions!)
                                                 .ThenInclude(x => x.Permission)
                                                 .Where(x => !x.IsDelete).ToListAsync();

        public async Task<Role> GetRoleById(int roleId)
            => await _context.Roles.Include(x => x.RolePermissions!)
                                                 .ThenInclude(x => x.Permission)
                                                 .FirstOrDefaultAsync(x => x.Id == roleId && !x.IsDelete);

        public async Task<List<Role>> GetRolesByUserId(int userId)
            => await _context.UserRoles.Where(x => x.UserId == userId && !x.IsDelete)
                                                        .Include(x => x.Role)
                                                        .Select(x => x.Role)
                                                        .ToListAsync();

        public async Task UpdateRole(Role role)
                    => _context.Roles.Update(role);

        public async Task DeleteRole(int roleId)
            => _context.Remove(await GetRoleById(roleId));

        public async Task Save() => await _context.SaveChangesAsync();
    }
}
