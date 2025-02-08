using E_Shop.Domain.Models;
using E_Shop.Domain.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using E_Shop.Application.ViewModels;
using System.Reflection;
using E_Shop.Application.Services.Interfaces;
using E_Shop.Domain;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using E_Shop.Domain.ViewModels;
namespace E_Shop.Web.Areas.Admin.Controllers
{
    public class UserController(IUserService userService) : AdminBaseController
    {

        private readonly IUserService _userService = userService;

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

            if (!ModelState.IsValid)
            {
                return View(model);

            }
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
            var emailcheck = await _userService.GetUserById(model.Id);
            if (emailcheck.EmailAddress != model.EmailAddress)
            {
                if (!ModelState.IsValid)
                {
                    return View(model);

                }
                else
                {

                    var result = await _userService.UpdateUser(model, true);
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
            }
            else
            {
                if (!ModelState.IsValid)
                {
                    return View(model);

                }
                else
                {
                    var result = await _userService.UpdateUser(model, false);
                    TempData[SuccessMessage] = ErrorMessages.UserUpdate;
                    return RedirectToAction("Index");
                }
            }

        }

     
       
        public async Task<IActionResult> DeleteUser(int UserId)
        {
            var result = await _userService.DeleteUser(UserId);
            if (result)
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
