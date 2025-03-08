using E_Shop.Domain.Contracts.RolePermissionCont;
using E_Shop.Domain.Models.RolePermissionModels;
using Microsoft.EntityFrameworkCore;

namespace E_Shop.Infra.Data.Repositories.RolePermissionRepo
{
    class RolePermissionRepository(ShopDbContext _context) : IRolePermissionRepository
    {
        public async Task CreateRolePermission(RolePermission rolePermission)
            => await _context.RolePermissions.AddAsync(rolePermission);

        public async Task<IEnumerable<RolePermission>> GetAllRolePermissions()
            => await _context.RolePermissions.Include(x => x.Role)
                                                                 .Include(x => x.Permission)
                                                                 .Where(x => !x.IsDelete)
                                                                 .ToListAsync();

        public async Task<RolePermission> GetRolePermissionById(int rolePermissionId)
            => await _context.RolePermissions.Include(x => x.Role)
                                                                 .Include(x => x.Permission)
                                                                 .FirstOrDefaultAsync(x => x.Id == rolePermissionId);

        public async Task UpdateRolePermission(RolePermission rolePermission)
            => _context.RolePermissions.Update(rolePermission);

        public async Task DeleteRolePermission(int rolePermissionId)
            => _context.Remove(await GetRolePermissionById(rolePermissionId));
    }
}
