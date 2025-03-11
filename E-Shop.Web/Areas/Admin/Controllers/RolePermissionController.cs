using E_Shop.Application.Services.RoleServices;
using E_Shop.Application.ViewModels.RoleViewModels;
using Microsoft.AspNetCore.Mvc;

namespace E_Shop.Web.Areas.Admin.Controllers
{
    public class RolePermissionController(IRolePermissionService _roleService) : AdminBaseController
    {
        #region All Roles
        [HttpGet]
        public async Task<IActionResult> AllRoles()
        {
            return View(await _roleService.GetAllRolesAsync());
        }
        #endregion

        #region Create Role
        [HttpGet]
        public async Task<IActionResult> CreateRole()
        {
            ViewBag.PermissionTree = await _roleService.GetPermissionTreeForViewBag();
            return View(new RoleVM { });
        }

        [HttpPost]
        public async Task<IActionResult> CreateRole(RoleVM roleVM, List<int> selectedPermissions)
        {
            if (!ModelState.IsValid) return RedirectToAction(nameof(CreateRole));
            await _roleService.CreateRoleAsync(roleVM, selectedPermissions);
            return RedirectToAction(nameof(AllRoles));
        }
        #endregion

        #region Details
        [HttpGet]
        public async Task<IActionResult> RoleDetails(int roleId)
        {
            return View(await _roleService.GetDetailsForShow(roleId));
        }
        #endregion

        #region Edit
        [HttpGet]
        public async Task<IActionResult> EditRole(int roleId)
        {
            ViewBag.PermissionTree = await _roleService.GetPermissionTreeForViewBag();
            return View(await _roleService.GetRoleEditVM(roleId));
        }

        [HttpPost]
        public async Task<IActionResult> EditRole(RoleVM roleVM, List<int> SelectedPermissions)
        {
            await _roleService.UpdateRoleAsync(roleVM, SelectedPermissions);
            return RedirectToAction(nameof(AllRoles));
        }
        #endregion

        #region Delete
        [HttpPost]
        public async Task<IActionResult> DeleteRole(int roleId)
        {
            await _roleService.DeleteRoleAsync(roleId);
            return RedirectToAction(nameof(AllRoles));
        }
        #endregion

    }
}
