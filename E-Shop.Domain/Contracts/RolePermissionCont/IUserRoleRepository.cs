using E_Shop.Domain.Models.RolePermissionModels;

namespace E_Shop.Domain.Contracts.RolePermissionCont
{
    public interface IUserRoleRepository
    {
        Task CreateUserRole(UserRole userRole);
        Task<IEnumerable<UserRole>> GetAllUserRoles();
        Task<List<Role>> GetAllRolesForUser();
        Task<UserRole> GetUserRoleById(int userRoleId);
        Task<List<UserRole>> GetUserRolesByRoleId(int roleId);
        Task<List<UserRole>> GetUserRolesByUserId(int userId);
        Task<List<Role>> GetRolesByUserId(int userId);
        Task UpdateUserRole(UserRole userRoleId);
        Task DeleteUserRole(int userRoleId);
    }
}
