using E_Shop.Application.Services.Interfaces;
using E_Shop.Application.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
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
            if (ModelState.IsValid)
            {
                await _service.Register(register);
                var user = await _service.GetByEmail(register.EmailAddress);
                var callbackUrl = Url.Action("ConfirmEmail", "Account", new { code = user.ActivationCode }, protocol: Request.Scheme);

                await _emailSender.SendEmailAsync(register.EmailAddress, "Confirm your email",
                    $"Please confirm your account by clicking this link: <a href='{callbackUrl}'>link</a>");

                return RedirectToAction("Index", "Home");
            }
            return View(register);
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
            return token == null ? View("Error") : View(new ResetPasswordVM { Code = token });
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

                var result = await _service.ResetPassword(resetPassword, resetPassword.Code, resetPassword.Password);
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



