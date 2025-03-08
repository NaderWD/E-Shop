using E_Shop.Domain.Models.RolePermissionModels;

namespace E_Shop.Domain.Contracts.RolePermissionCont
{
    public interface IRoleRepository
    {
        Task CreateRole(Role role);
        Task<Role> GetRoleById(int roleId);
        Task<IEnumerable<Role>> GetAllRoles();
        Task UpdateRole(Role role);
        Task DeleteRole(int roleId);
    }
}
