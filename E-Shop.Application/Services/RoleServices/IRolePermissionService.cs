using E_Shop.Application.ViewModels.RoleViewModels;

namespace E_Shop.Application.Services.RoleServices
{
    public interface IRolePermissionService
    {
        #region Role
        Task CreateRoleAsync(RoleVM roleVM, List<int> selectedPermissionIds);
        Task AssignPermissionsToRoleAsync(int roleId, List<int> permissionIds);
        Task<RoleVM> GetRoleByIdAsync(int roleId);
        Task<List<RoleVM>> GetAllRolesAsync();
        Task<List<RoleVM>> GetRolesByUserIdAsync(int userId);
        Task UpdateRoleAsync(RoleVM roleVM, List<int> permissionIds);
        Task DeleteRoleAsync(int roleId);
        #endregion

        #region Permission
        Task<List<PermissionVM>> GetAllParentPermissionsAsync();
        Task<List<PermissionVM>> GetAllSubPermissionsByParentIdAsync(int parentId);
        Task<RolePermissionVMForShow> GetRolePermissionForShow(RoleVM roleVM, List<int> selectedPermissions);
        Task<List<PermissionVM>> GetPermissionTreeForViewBag();
        Task<bool> CheckUserPermissionAsync(int userId, string permissionName);
        #endregion

        #region For Actions
        Task<RoleDetailsVM> GetDetailsForShow(int roleId);
        Task<RoleEditVM> GetRoleEditVM(int roleId);
        #endregion
    }
}
