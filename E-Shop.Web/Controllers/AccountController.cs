using E_Shop.Application.Services.Interfaces;
using E_Shop.Application.ViewModels;
using E_Shop.Domain.Models.Shared;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace E_Shop.Web.Controllers
{
    public class AccountController(IUserService service, IEmailSender emailSender) : SiteBaseController
    {
        private readonly IUserService _service = service;
        private readonly IEmailSender _emailSender = emailSender;


        #region Register
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
        #endregion



        #region Login
        [HttpGet("/login")]
        public IActionResult Login()
        {
            return View();
        }


        [HttpPost("/login")]
        public async Task<IActionResult> Login(LoginVM userLogin)
        {
            var result = await _service.Login(userLogin);
            if (result != ErrorMessages.LoginSuccess) return View(userLogin);

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
            return RedirectToAction("Index", "Home", new { user.EmailAddress });

        }
        #endregion



        #region Logout
        [HttpGet("/logout")]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Index");
        }
        #endregion



        #region Confirm Email
        [HttpGet("/confirmEmail")]
        public IActionResult ConfirmEmail()
        {
            return View();
        }


        [HttpPost("/confirmEmail")]
        public async Task<IActionResult> ConfirmEmail(ConfirmEmailVM model)
        {
            var result = await _service.ConfirmEmailService(model);
            if (!result) return RedirectToAction("register", "Account");
            return RedirectToAction("Login", "Account");
        }
        #endregion



        #region Forget Password
        [HttpGet("/ForgetPassword")]
        public IActionResult ForgetPassword(string email)
        {
            return View(new ForgetPasswordVM { EmailAddress = email });
        }


        [HttpPost("/ForgetPassword")]
        public async Task<IActionResult> ForgetPassword(ForgetPasswordVM forgetPassword)
        {
            if (!ModelState.IsValid) return View(forgetPassword);
            await _service.ForgetPasswordCode(forgetPassword);
            return RedirectToAction("ResetPassword", new { email = forgetPassword.EmailAddress });
        }
        #endregion



        #region Reset Password
        [HttpGet("/ResetPassword")]
        public IActionResult ResetPassword(string email)
        {
            return View(new ResetPasswordVM { EmailAddress = email });
        }

        [HttpPost("/ResetPassword")]
        public async Task<IActionResult> ResetPassword(ResetPasswordVM userVM)
        {
            if (!ModelState.IsValid) return View(userVM);

            await _service.ResetPassword(userVM, userVM.ActivationCode, userVM.Password);
            return RedirectToAction("Login", "Account");
        }
        #endregion



        #region ReSend
        [HttpGet("ReSend")]
        public async Task<IActionResult> ReSend(string email)
        {
            await _service.ReSendCode(email);
            return RedirectToAction("ResetPassword", new { email });
        }
        #endregion



        #region User Profile
        [HttpGet("/UserProfile")]
        public async Task<IActionResult> UserProfile(string email)
        {
            await _service.GetByEmail(email);
            return View(new UserDetailsVM { EmailAddress = email });
        }
        #endregion
    }

}







