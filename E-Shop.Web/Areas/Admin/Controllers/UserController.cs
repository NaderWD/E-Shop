using E_Shop.Application.Services.RoleServices;
using E_Shop.Application.Services.UserServices;
using E_Shop.Application.ViewModels.UserViewModels;
using E_Shop.Domain.Models.ValidationModels;
using Microsoft.AspNetCore.Mvc;


namespace E_Shop.Web.Areas.Admin.Controllers
{
    public class UserController(IUserService _userService, IUserRoleService _userRoleService) : AdminBaseController
    {
        #region Index
        public async Task<IActionResult> Index()
        {
            var model = await _userService.GetAllUsers();
            return View(model);
        }
        #endregion

        #region Create
        [HttpPost]
        public async Task<IActionResult> CreateUser(UserViewModel model, List<int> selectedRoleIds)
        {
            ViewBag.Roles = await _userRoleService.GetAllRolesForShow();
            if (!ModelState.IsValid)
            {
                return PartialView("_AddUser", model);
            }
            else
            {
                var result = await _userService.CreateUser(model, selectedRoleIds);
                switch (result)
                {
                    case Domain.Enum.ValidationErrorType.EmailIsDuplicated:
                        TempData[ErrorMessage] = ErrorMessages.EmailIsDuplicated;
                        break;
                    case Domain.Enum.ValidationErrorType.Success:
                        TempData[SuccessMessage] = ErrorMessages.UserAdded;
                        return RedirectToAction("Index");
                }
                return RedirectToAction(nameof(Index));
            }
        }
        #endregion

        #region Update
        public async Task<IActionResult> UpdateUser(int UserId)
        {
            ViewBag.Roles = await _userRoleService.GetAllRolesForShow();
            var content = await _userService.GetUserById(UserId);
            return PartialView("_UpdateUser", content);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateUser(UserViewModel model, List<int> selectedRoleIds)
        {
            if (!ModelState.IsValid)
            {
                return PartialView("_UpdateUser", model);
            }
            else
            {
                var emailcheck = await _userService.GetUserById(model.Id);
                if (emailcheck.EmailAddress != model.EmailAddress)
                {

                    var result = await _userService.UpdateUser(model, true, selectedRoleIds);
                    switch (result)
                    {
                        case Domain.Enum.ValidationErrorType.EmailIsDuplicated:
                            TempData[ErrorMessage] = ErrorMessages.EmailIsDuplicated;
                            break;
                        case Domain.Enum.ValidationErrorType.Success:
                            TempData[SuccessMessage] = ErrorMessages.UserUpdate;
                            return RedirectToAction(nameof(Index));
                    }
                    return RedirectToAction(nameof(Index));

                }
                else
                {

                    await _userService.UpdateUser(model, false, selectedRoleIds);
                    TempData[SuccessMessage] = ErrorMessages.UserUpdate;
                    return RedirectToAction(nameof(Index));

                }
            }

        }
        #endregion

        #region Delete
        public async Task<IActionResult> DeleteUser(int UserId)
        {
            var result = await _userService.DeleteUser(UserId);

            if (result == true)
            {
                TempData[SuccessMessage] = ErrorMessages.UserDeleted;
                return RedirectToAction(nameof(Index));
            }
            else
            {
                TempData[ErrorMessage] = ErrorMessages.FailedMessage;
                return RedirectToAction(nameof(Index));
            }
        }
        #endregion
    }
}