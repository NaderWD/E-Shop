using E_Shop.Application.ViewModels.RoleViewModels;
using E_Shop.Domain.Contracts.RolePermissionCont;
using E_Shop.Domain.Contracts.UserCont;
using E_Shop.Domain.Models.RolePermissionModels;
using System.Data;

namespace E_Shop.Application.Services.RoleServices
{
    public class UserRoleService(IUserRoleRepository _userRoleRepository, IUserRepository _userRepository) : IUserRoleService
    {
        public async Task<List<RoleVMForUser>> GetAllRolesForShow()
        {
            var roles = await _userRoleRepository.GetAllRolesForUser();
            return [.. roles.Select(r => new RoleVMForUser
            {
                RoleId = r.Id,
                RoleName = r.RoleName
            })];
        }

        public async Task<List<RoleVMForUser>> GetUsersCurrentRoles(int userId)
        {
            var currentRoles = await _userRoleRepository.GetRolesByUserId(userId);
            return [.. currentRoles.Select(r => new RoleVMForUser
            {
                RoleId = r.Id,
                RoleName = r.RoleName
            })];
        }

        public async Task UpdateUserRole(int userId, List<int>? selectedRoleIds)
        {
            var roles = await _userRoleRepository.GetRolesByUserId(userId);
            var userRoles = await _userRoleRepository.GetUserRolesByUserId(userId);
            foreach (var userRole in userRoles)
                if (!selectedRoleIds.Any(id => id == userRole.Id)) await DeleteUserRole(userRole.Id);
            foreach (var roleId in selectedRoleIds)
            {
                UserRole newUserRole = new()
                {
                    RoleId = roleId,
                    UserId = userId,
                    CreateDate = DateTime.Now,
                    LastModifiedDate = DateTime.Now
                };
                await _userRoleRepository.CreateUserRole(newUserRole);
                await Save();
            }
            await Save();
        }

        public async Task DeleteUserRole(int userRoleId) => await _userRoleRepository.DeleteUserRole(userRoleId);

        public async Task Save() => await _userRepository.Save();
    }
}
