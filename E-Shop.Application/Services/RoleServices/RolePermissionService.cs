using E_Shop.Application.ViewModels.RoleViewModels;
using E_Shop.Domain.Contracts.RolePermissionCont;
using E_Shop.Domain.Models.RolePermissionModels;
using System.Data;

namespace E_Shop.Application.Services.RoleServices
{
    public class RolePermissionService(IRoleRepository _roleRepository,
                                                           IRolePermissionRepository _rolePermissionRepository,
                                                           IUserRoleRepository _userRoleRepository) : IRolePermissionService
    {
        #region Role
        public async Task CreateRoleAsync(RoleVM roleVM, List<int> selectedPermissionIds)
        {
            Role role = new()
            {
                RoleName = roleVM.RoleName,
                CreateDate = DateTime.Now,
                LastModifiedDate = DateTime.Now,
            };
            await _roleRepository.CreateRole(role);
            await Save();
            foreach (var permissionId in selectedPermissionIds)
            {
                RolePermission newRolePermission = new()
                {
                    RoleId = role.Id,
                    PermissionId = permissionId,
                    CreateDate = DateTime.Now,
                    LastModifiedDate = DateTime.Now
                };
                await _rolePermissionRepository.CreateRolePermission(newRolePermission);
                await Save();
            }
            await Save();
        }

        public async Task AssignPermissionsToRoleAsync(int roleId, List<int> selectedPermissionIds)
        {
            var rolePermissions = await _rolePermissionRepository.GetRolePermissionsByRoleId(roleId);
            foreach (var rolePermission in rolePermissions)
                if (!selectedPermissionIds.Any( id=> id == rolePermission.PermissionId)) await _rolePermissionRepository.DeleteRolePermission(rolePermission.Id);
            foreach (var PermissionId in selectedPermissionIds)
            {
                RolePermission rolePermission = new()
                {
                    RoleId = roleId,
                    PermissionId = PermissionId,
                    CreateDate = DateTime.Now,
                    LastModifiedDate = DateTime.Now,
                };
                await _rolePermissionRepository.CreateRolePermission(rolePermission);
                await Save();
            }
            await Save();
        }

        public async Task<List<RoleVM>> GetAllRolesAsync()
        {
            var roles = await _roleRepository.GetAllRoles();
            var roleVMs = roles.Select(x => new RoleVM
            {
                RoleId = x.Id,
                RoleName = x.RoleName,
            }).ToList();
            foreach (var roleVm in roleVMs)
                roleVm.PermissionNames = [.. (await _rolePermissionRepository.GetPermissionsByRoleId(roleVm.RoleId)).Select(n => n.DisplayName)];
            return roleVMs;
        }

        public async Task<RoleVM> GetRoleByIdAsync(int roleId)
        {
            var role = await _roleRepository.GetRoleById(roleId);
            return new RoleVM
            {
                RoleId = role.Id,
                RoleName = role.RoleName,
                PermissionNames = [.. (await _rolePermissionRepository.GetPermissionsByRoleId(roleId)).Select(n => n.DisplayName)]
            };
        }

        public async Task<List<RoleVM>> GetRolesByUserIdAsync(int userId)
        {
            var roles = await _roleRepository.GetRolesByUserId(userId);
            List<RoleVM> roleVMs = [.. roles.Select(x => new RoleVM
            {
                RoleId = x.Id,
                RoleName = x.RoleName,
            })];
            foreach (var roleVM in roleVMs)
            {
                roleVM.PermissionNames = [.. (await _rolePermissionRepository.GetPermissionsByRoleId(roleVM.RoleId)).Select(n => n.DisplayName)];
            }
            return roleVMs;
        }

        public async Task UpdateRoleAsync(RoleVM roleVM, List<int> permissionIds)
        {
            var role = await _roleRepository.GetRoleById(roleVM.RoleId);
            role.RoleName = roleVM.RoleName;
            role.LastModifiedDate = DateTime.UtcNow;
            await AssignPermissionsToRoleAsync(roleVM.RoleId, permissionIds);
            await _roleRepository.UpdateRole(role);
            await Save();
        }

        public async Task DeleteRoleAsync(int roleId)
        {
            var userRoles = await _userRoleRepository.GetUserRolesByRoleId(roleId);
            foreach (var userRole in userRoles) await _userRoleRepository.DeleteUserRole(userRole.Id);

            var rolePermissions = await _rolePermissionRepository.GetRolePermissionsByRoleId(roleId);
            foreach (var rolePermission in rolePermissions) await _rolePermissionRepository.DeleteRolePermission(rolePermission.Id);

            await _roleRepository.DeleteRole(roleId);
            await Save();
        }

        public async Task Save() => await _roleRepository.Save();
        #endregion

        #region Permission
        public async Task<List<PermissionVM>> GetAllParentPermissionsAsync()
        {
            var parents = await _rolePermissionRepository.GetAllParentPermissions();
            return [.. parents.Select(x => new PermissionVM
            {
                PermissionId = x.Id,
                ParentId = x.ParentId,
                DisplayName = x.DisplayName,
                UniqName = x.UniqName
            })];
        }

        public async Task<List<PermissionVM>> GetAllSubPermissionsByParentIdAsync(int parentId)
        {
            var parents = await _rolePermissionRepository.GetAllSubPermissionsByParentId(parentId);
            return [.. parents.Select(x => new PermissionVM
            {
                PermissionId = x.Id,
                ParentId = x.ParentId,
                DisplayName = x.DisplayName,
                UniqName = x.UniqName
            })];
        }

        public async Task<RolePermissionVMForShow> GetRolePermissionForShow(RoleVM roleVM, List<int> selectedPermissions)
        {
            return new RolePermissionVMForShow
            {
                RoleName = roleVM.RoleName,
                SelectedPermissions = selectedPermissions
            };
        }

        public async Task<List<PermissionVM>> GetPermissionTreeForViewBag()
        {
            var parents = await _rolePermissionRepository.GetAllParentPermissions();
            List<PermissionVM> permissionTree = [];
            foreach (var parent in parents)
            {
                PermissionVM parentNode = new()
                {
                    PermissionId = parent.Id,
                    DisplayName = parent.DisplayName,
                    UniqName = parent.UniqName,
                    ParentId = parent.ParentId,
                    IsSelected = false,
                };
                var subPermissions = await _rolePermissionRepository.GetAllSubPermissionsByParentId(parent.Id);
                parentNode.Children = [.. subPermissions.Select(x => new PermissionVM
                {
                    PermissionId = x.Id,
                    DisplayName = x.UniqName,
                    UniqName = x.UniqName,
                    ParentId = x.ParentId,
                    IsSelected = false
                })];
                permissionTree.Add(parentNode);
            }
            return permissionTree;
        }

        public async Task<bool> CheckUserPermissionAsync(int userId, string permissionName)
        {
            var roleIds = (await _userRoleRepository.GetUserRolesByUserId(userId)).Select(r => r.RoleId).ToList();
            foreach (var roleId in roleIds)
            {
                var rolePermissionNames = (await _rolePermissionRepository.GetRolePermissionsByRoleId(roleId)).Select(n => n.Permission.UniqName).ToList();
                if (rolePermissionNames.Contains(permissionName)) return true;
            }
            return false;
        }
        #endregion

        #region For Actions
        public async Task<RoleDetailsVM> GetDetailsForShow(int roleId)
        {
            var role = await GetRoleByIdAsync(roleId);
            var allPermissions = await GetPermissionTreeForViewBag();
            var chosenPermissions = await _rolePermissionRepository.GetPermissionsByRoleId(roleId);

            List<PermissionForDetailVM> FilterSelectedPermissions(List<PermissionVM> permissions)
            {
                return [.. permissions
             .Where(p => chosenPermissions.Any(rp => rp.Id == p.PermissionId))
             .Select(p => new PermissionForDetailVM
             {
                 PermissionId = p.PermissionId,
                 DisplayName = p.DisplayName,
                 Children = FilterSelectedPermissions(p.Children ?? [])
             })];
            }

            var filteredPermissions = FilterSelectedPermissions(allPermissions);
            return new RoleDetailsVM
            {
                RoleName = role.RoleName,
                Permissions = filteredPermissions
            };
        }

        public async Task<RoleEditVM> GetRoleEditVM(int roleId)
        {
            var role = await GetRoleByIdAsync(roleId);
            var selectedPermissionIds = (await _rolePermissionRepository.GetPermissionsByRoleId(roleId)).Select(i => i.Id).ToList();
            return new RoleEditVM
            {
                RoleId = role.RoleId,
                RoleName = role.RoleName,
                SelectedPermissions = selectedPermissionIds
            };
        }
        #endregion
    }
}
