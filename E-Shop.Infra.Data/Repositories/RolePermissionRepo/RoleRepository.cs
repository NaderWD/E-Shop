using E_Shop.Domain.Contracts.RolePermissionCont;
using E_Shop.Domain.Models.RolePermissionModels;
using Microsoft.EntityFrameworkCore;

namespace E_Shop.Infra.Data.Repositories.RolePermissionRepo
{
    class RoleRepository(ShopDbContext _context) : IRoleRepository
    {
        public async Task CreateRole(Role role)
            => await _context.Roles.AddAsync(role);

        public async Task<IEnumerable<Role>> GetAllRoles()
            => await _context.Roles.Include(x => x.RolePermissions)
                                                 .Where(x => !x.IsDelete).ToListAsync();

        public async Task<Role> GetRoleById(int roleId)
            => await _context.Roles.FirstOrDefaultAsync(x => x.Id == roleId && !x.IsDelete);

        public async Task UpdateRole(Role role)
            => _context.Roles.Update(role);

        public async Task DeleteRole(int roleId)
            => _context.Remove(await GetRoleById(roleId));
    }
}
