using E_Shop.Application.ViewModels.RoleViewModels;
using E_Shop.Domain.Contracts.RolePermissionCont;
using E_Shop.Domain.Contracts.UserCont;

namespace E_Shop.Application.Services.RoleServices
{
    public class UserRoleService(IUserRoleRepository _userRoleRepository) : IUserRoleService
    {
        public async Task<List<UserRoleVM>> GetUserRolesByUserId(int userId)
        {
            var userRoles = await _userRoleRepository.GetUserRolesByUserId(userId);
            return userRoles.Select(r => new UserRoleVM
            {
                UserRoleId = r.Id,
                 RoleId = r.RoleId,
                UserId = userId,
//SelectedRoles =,
//RolesName =,
            }).ToList();
        }
    }
}
