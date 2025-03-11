using E_Shop.Domain.Models.RolePermissionModels;

namespace E_Shop.Domain.Contracts.RolePermissionCont
{
    public interface IRolePermissionRepository
    {                                                                                                
        Task CreateRolePermission(RolePermission rolePermission);
        Task CreateRangeRolePermissions(IEnumerable<RolePermission> rolePermissions);
        Task<RolePermission> GetRolePermissionById(int rolePermissionId);                
        Task<IEnumerable<RolePermission>> GetAllRolePermissions();
        Task<IEnumerable<Permission>> GetAllPermissions();
        Task<IEnumerable<Permission>> GetAllParentPermissions();                            
        Task<IEnumerable<Permission>> GetAllSubPermissionsByParentId(int parentId);
        Task<IEnumerable<Permission>> GetPermissionsByRoleId(int roleId);
        Task<IEnumerable<RolePermission>> GetRolePermissionsByRoleId(int roleId);
        Task UpdateRolePermission(RolePermission rolePermission);
        Task DeleteRolePermission(int rolePermissionId);
        Task DeleteRangeRolePermissions( IEnumerable<RolePermission> rolePermissions);
    }
}
