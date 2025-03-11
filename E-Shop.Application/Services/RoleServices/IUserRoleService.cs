using E_Shop.Application.ViewModels.RoleViewModels;
using E_Shop.Domain.Models.RolePermissionModels;

namespace E_Shop.Application.Services.RoleServices
{
    public interface IUserRoleService
    {
       Task<List<UserRoleVM>> GetUserRolesByUserId(int userId);

    }
}
