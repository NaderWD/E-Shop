using E_Shop.Domain.Models.RolePermissionModels;

namespace E_Shop.Domain.Contracts.RolePermissionCont
{
    public interface IUserRoleRepository
    {
        Task CreateUserRole(UserRole userRole);
        Task<UserRole> GetUserRoleById(int userRoleId);
        Task<IEnumerable<UserRole>> GetAllUserRoles();
        Task UpdateUserRole(UserRole userRoleId);                                                                                             
        Task DeleteUserRole(int userRoleId);
    }
}
