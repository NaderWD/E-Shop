using E_Shop.Domain.Contracts.RolePermissionCont;
using E_Shop.Domain.Models.RolePermissionModels;
using Microsoft.EntityFrameworkCore;

namespace E_Shop.Infra.Data.Repositories.RolePermissionRepo
{
    public class RolePermissionRepository(ShopDbContext _context) : IRolePermissionRepository
    {
        public async Task CreateRolePermission(RolePermission rolePermission)
            => await _context.RolePermissions.AddAsync(rolePermission);

        public async Task CreateRangeRolePermissions(IEnumerable<RolePermission> rolePermissions)
            => await _context.RolePermissions.AddRangeAsync(rolePermissions);

        public async Task<IEnumerable<RolePermission>> GetAllRolePermissions()
                    => await _context.RolePermissions.Include(x => x.Role)
                                                                         .Include(x => x.Permission)
                                                                         .Where(x => !x.IsDelete)
                                                                         .ToListAsync();

        public async Task<IEnumerable<Permission>> GetAllPermissions()
            => await _context.Permissions.Include(x => x.Parent)
                                                           .Include(x => x.RolePermissions!)
                                                           .ThenInclude(x => x.Role)
                                                           .Where(x => !x.IsDelete)
                                                           .ToListAsync();

        public async Task<IEnumerable<Permission>> GetAllParentPermissions()
            => await _context.Permissions.Include(x => x.Parent)
                                                           .Include(x => x.RolePermissions!)
                                                           .ThenInclude(x => x.Role)
                                                           .Where(x => x.ParentId == null && !x.IsDelete)
                                                           .ToListAsync();


        public async Task<IEnumerable<Permission>> GetAllSubPermissionsByParentId(int parentId)
            => await _context.Permissions.Include(x => x.Parent)
                                                           .Include(x => x.RolePermissions!)
                                                           .ThenInclude(x => x.Role)
                                                           .Where(x => x.ParentId == parentId && !x.IsDelete)
                                                           .ToListAsync();

        public async Task<RolePermission> GetRolePermissionById(int rolePermissionId)
            => await _context.RolePermissions.Include(x => x.Role)
                                                                 .Include(x => x.Permission)
                                                                 .FirstOrDefaultAsync(x => x.Id == rolePermissionId);

        public async Task<IEnumerable<Permission>> GetPermissionsByRoleId(int roleId)
           => await _context.RolePermissions.Where(x => x.RoleId == roleId && !x.IsDelete)
                                                                .Include(x => x.Permission)
                                                                .Select(x => x.Permission)
                                                                .ToListAsync();

        public async Task<IEnumerable<RolePermission>> GetRolePermissionsByRoleId(int roleId)
            => await _context.RolePermissions.Include(x => x.Role)
                                                                 .Include(x => x.Permission)
                                                                 .Where(x => x.RoleId == roleId)
                                                                 .ToListAsync();

        public async Task UpdateRolePermission(RolePermission rolePermission)
            => _context.RolePermissions.Update(rolePermission);

        public async Task DeleteRolePermission(int rolePermissionId)
            => _context.Remove(await GetRolePermissionById(rolePermissionId));

        public async Task DeleteRangeRolePermissions(IEnumerable<RolePermission> rolePermissions)
            => _context.RemoveRange(rolePermissions);
    }
}
