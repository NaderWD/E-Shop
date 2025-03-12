using E_Shop.Application.ViewModels.RoleViewModels;

namespace E_Shop.Application.Services.RoleServices
{
    public interface IUserRoleService
    {                                                           
        Task<List<RoleVMForUser>> GetAllRolesForShow();    
        Task UpdateUserRole(int userId, List<int>? selectedNewRoles);
        Task DeleteUserRole(int userRoleId);
        Task Save();
    }
}
