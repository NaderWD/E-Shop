using E_Shop.Application.Services.Implementations;
using E_Shop.Application.Services.Interfaces;
using E_Shop.Application.ViewModels;
using E_Shop.Domain.Models.Shared;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Plugins;
using System.Security.Claims;
using static E_Shop.Application.ViewModels.LoginVM;

namespace E_Shop.Web.Controllers
{
    public class AccountController(IUserService service, IEmailSender emailSender) : SiteBaseController
    {
        private readonly IUserService _service = service;
        private readonly IEmailSender _emailSender = emailSender;


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
                case LoginResults.Success:
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

                case LoginResults.Error:
                    TempData[ErrorMessage] = "خطایی رخ داده است";
                    return View(userLogin);

                case LoginResults.UserNotFound:
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

             await _service.Register(register);

            TempData["Message"] = "Registration successful! Please check your email to confirm your account.";
            ViewBag.MessageType = "success";

            return RedirectToAction("ConfirmEmail", "Account");

        }


        [HttpGet("/confirmEmail")]
        public IActionResult ConfirmEmail()
        {
            return View();
        }


        [HttpPost("/confirmEmail")]
        public async Task<IActionResult> ConfirmEmail(ConfirmEmailVM model)
        {
            var result = await _service.ConfirmEmailService(model);
            if (result)
            {

                TempData["Message"] = "Email confirmed successfully!";
                TempData["MessageType"] = "success";

                return RedirectToAction("Login", "Account");
            }

            TempData["Message"] = "Invalid email confirmation token.";
            TempData["MessageType"] = "error";

            return RedirectToAction("register", "Account");
        }


        [HttpGet("/ForgetPassword")]
        public IActionResult ForgetPassword()
        {
            return View();
        }


        [HttpPost("/ForgetPassword")]
        public async Task<IActionResult> ForgetPassword(ForgetPasswordVM forgetPassword)
        {
            if (ModelState.IsValid)
            {
                var user = await _service.GetByEmail(forgetPassword.EmailAddress);
                if (user == null)
                {
                    return RedirectToAction("ForgotPasswordConfirmation");
                }

                var token = new Guid();
                var callbackUrl = Url.Action("ResetPassword", "Account", new { token, email = forgetPassword.EmailAddress }, protocol: Request.Scheme);

                await _emailSender.SendEmailAsync(forgetPassword.EmailAddress, "Reset Password",
                    $"Please reset your password by clicking here: <a href='{callbackUrl}'>link</a>");

                return RedirectToAction("ForgotPasswordConfirmation");
            }

            return View(forgetPassword);
        }


        [HttpGet("/ResetPassword")]
        public IActionResult ResetPassword(string token)
        {
            return token == null ? View("Error") : View(new ResetPasswordVM { ActivationCode = token });
        }

        [HttpPost("/ResetPassword")]
        public async Task<IActionResult> ResetPassword(ResetPasswordVM resetPassword)
        {
            if (ModelState.IsValid)
            {
                var user = await _service.GetByEmail(resetPassword.EmailAddress);
                if (user == null)
                {
                    return RedirectToAction("ResetPasswordConfirmation");
                }

                var result = await _service.ResetPassword(resetPassword, resetPassword.ActivationCode, resetPassword.Password);
                switch (result)
                {
                    case ResetPasswordVM.UserResult.Success:
                        break;
                    case ResetPasswordVM.UserResult.Error:
                        break;
                }
            }
            return View(resetPassword);
        }

        [HttpGet]
        public IActionResult ForgotPasswordConfirmation()
        {
            return View();
        }

        [HttpGet]
        public IActionResult ResetPasswordConfirmation()
        {
            return View();
        }
    }
}



