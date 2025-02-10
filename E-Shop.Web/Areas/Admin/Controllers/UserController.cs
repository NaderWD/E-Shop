using E_Shop.Application.Services.Interfaces;
using E_Shop.Application.ViewModels;
using E_Shop.Domain;
using E_Shop.Domain.Models.Shared;
using Microsoft.AspNetCore.Mvc;
namespace E_Shop.Web.Areas.Admin.Controllers
{
    public class UserController : AdminBaseController
    {
        private readonly IUserService _userService;


        public IActionResult Index()
        {
            var model = _userService.GetAllUsers();
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
                    case ValidationErrorType.EmailIsDuplicated:
                        TempData[SuccessMessage] = ErrorMessages.EmailExistError;
                        break;
                    case ValidationErrorType.Success:
                        TempData[SuccessMessage] = ErrorMessages.UserAdded;
                        return RedirectToAction("Index");

                }

                return RedirectToAction("Index");
            }

        }

        public IActionResult UpdateUser(int Id)
        {
            var content = _userService.GetUserById(Id);
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

                var result = await _userService.UpdateUser(model);
                switch (result)
                {
                    case ValidationErrorType.EmailIsDuplicated:
                        TempData[SuccessMessage] = ErrorMessages.EmailExistError;
                        break;
                    case ValidationErrorType.Success:
                        TempData[SuccessMessage] = ErrorMessages.UserAdded;
                        return RedirectToAction("Index");

                }

                return RedirectToAction("Index", "User", new { area = "Admin" });
            }
        }

        public IActionResult DeleteUser(int Id)
        {
            _userService.DeleteUser(Id);
            return View("Index");
        }


    }
}
