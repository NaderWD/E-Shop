using E_Shop.Application.Services.Interfaces;
using E_Shop.Application.ViewModels;
using E_Shop.Domain.Models.Shared;
using Microsoft.AspNetCore.Mvc;
namespace E_Shop.Web.Areas.Admin.Controllers
{
    public class UserController(IUserService _userService) : AdminBaseController
    {
        public async Task<IActionResult> Index()
        {
            var model = await _userService.GetAllUsers(); 
            return View(model);
        }
        public IActionResult CreateUser()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateUser(UserViewModel model)
        {
            if (!ModelState.IsValid) { return View(model); }
            else
            {
                var result = await _userService.CreateUser(model);
                switch (result)
                {
                    case Domain.Enum.ValidationErrorType.EmailIsDuplicated:
                        TempData[ErrorMessage] = ErrorMessages.EmailIsDuplicated;
                        break;
                    case Domain.Enum.ValidationErrorType.Success:
                        TempData[SuccessMessage] = ErrorMessages.UserAdded;
                        return RedirectToAction("Index");
                }
                return RedirectToAction("Index");
            }
        }

        public async Task<IActionResult> UpdateUser(int UserId)
        {
            var content = await _userService.GetUserById(UserId);
            return View(content);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateUser(UserViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            else
            {
                var emailcheck = await _userService.GetUserById(model.Id);
                if (emailcheck.EmailAddress != model.EmailAddress)
                {

                    var result = await _userService.UpdateUser(model,true);
                    switch (result)
                    {
                        case Domain.Enum.ValidationErrorType.EmailIsDuplicated:
                            TempData[ErrorMessage] = ErrorMessages.EmailIsDuplicated;
                            break;
                        case Domain.Enum.ValidationErrorType.Success:
                            TempData[SuccessMessage] = ErrorMessages.UserUpdate;
                            return RedirectToAction("Index");
                    }
                    return RedirectToAction("Index");

                }
                else
                {

                    await _userService.UpdateUser(model, false);
                    TempData[SuccessMessage] = ErrorMessages.UserUpdate;
                    return RedirectToAction("Index");

                }
            }

        }

        public async Task<IActionResult> DeleteUser(int UserId)
        {
            var result = _userService.DeleteUser(UserId);

            if (result == null)
            {
                TempData[SuccessMessage] = ErrorMessages.UserDeleted;
                return RedirectToAction("Index");
            }
            else
            {
                TempData[ErrorMessage] = ErrorMessages.FailedMessage;
                return RedirectToAction("Index");
            }
        }
    }
}