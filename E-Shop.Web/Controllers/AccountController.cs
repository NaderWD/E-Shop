using E_Shop.Application.Services.Interfaces;
using E_Shop.Domain.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace E_Shop.Web.Controllers
{
    public class AccountController(IUserService service) : SiteBaseController
    {
        private readonly IUserService _service = service;



        [HttpGet("/login")]
        public IActionResult Login()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpPost("/login")]
        public async Task<IActionResult> Login(LoginVM userLogin)
        {
            if (!ModelState.IsValid) return View(userLogin);

            var result = await _service.Login(userLogin);

            switch (result)
            {
                case LoginVM.LoginResult.Success:
                    var user = await _service.GetByEmail(userLogin.EmailAddress);
                    var claims = new List<Claim>()
                    {
                        new(ClaimTypes.NameIdentifier, user.Id.ToString()),
                        new(ClaimTypes.Email, user.EmailAddress),
                    };
                    var identify = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var principal = new ClaimsPrincipal(identify);
                    var properties = new AuthenticationProperties { IsPersistent = true };
                    await HttpContext.SignInAsync(principal, properties);
                    TempData[SuccessMessage] = "خوش آمدید";
                    return RedirectToAction("Index");

                case LoginVM.LoginResult.Error:
                    TempData[ErrorMessage] = "خطایی رخ داده است";
                    return View(userLogin);

                case LoginVM.LoginResult.UserNotFound:
                    TempData[ErrorMessage] = "کاربری یافت نشد";
                    return View(userLogin);
            }

            return View(userLogin);
        }

        [HttpGet("/logout")]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Index");
        }


        [HttpGet("/register")]
        public IActionResult Register()
        {
            return View();
        }


        [HttpPost("/register")]
        public async Task<IActionResult> Register(RegisterVM register)
        {
            if (!ModelState.IsValid) return View(register);

            var result = await _service.Register(register);

            switch (result)
            {
                case RegisterVM.RegisterResult.Success:
                    return RedirectToAction("Index");

                case RegisterVM.RegisterResult.Error:
                    TempData[ErrorMessage] = "خطایی رخ داده است";
                    return View(register);
            }
            return View(register);
        }

    }
}
