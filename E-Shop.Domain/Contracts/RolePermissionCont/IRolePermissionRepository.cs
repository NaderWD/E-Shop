using E_Shop.Domain.Models.RolePermissionModels;

namespace E_Shop.Domain.Contracts.RolePermissionCont
{
    public interface IRolePermissionRepository
    {                                                                                                
        Task CreateRolePermission(RolePermission rolePermission);
        Task<RolePermission> GetRolePermissionById(int rolePermissionId);             
        Task<IEnumerable<RolePermission>> GetAllRolePermissions();
        Task UpdateRolePermission(RolePermission rolePermission);
        Task DeleteRolePermission(int rolePermissionId);
    }
}
