using E_Shop.Application.Services.Interfaces;
using E_Shop.Application.ViewModels.UserViewModels;
using E_Shop.Application.ViewModels.AccountViewModels;
using E_Shop.Domain.Models.Shared;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace E_Shop.Web.Areas.User.Controllers
{
    public class AccountController(IUserService _service) : UserBaseController
    {

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

            return RedirectToAction("ConfirmEmail", "Account", new { email = register.EmailAddress });

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
                        new(ClaimTypes.Name, user.FirstName+" "+user.LastName),
                        new(ClaimTypes.NameIdentifier, user.Id.ToString()),
                        new(ClaimTypes.Email, user.EmailAddress),
                        new("IsAdmin", user.IsAdmin.ToString()),
                    };
            if (user.IsAdmin) claims.Add(new Claim(ClaimTypes.Role, "Admin"));

            var identify = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var principal = new ClaimsPrincipal(identify);
            var properties = new AuthenticationProperties { IsPersistent = true };
            await HttpContext.SignInAsync(principal, properties);
            TempData[SuccessMessage] = "خوش آمدید";
            return Redirect("/");
        }
        #endregion



        #region Logout
        [HttpGet("/logout")]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return Redirect("/");
        }
        #endregion



        #region Confirm Email
        [HttpGet("/confirmEmail")]
        public IActionResult ConfirmEmail(string email)
        {
            return View(new ConfirmEmailVM { EmailAddress = email });
        }


        [HttpPost("/confirmEmail")]
        public async Task<IActionResult> ConfirmEmail(ConfirmEmailVM model)
        {
            var result = await _service.ConfirmEmailService(model);
            if (!result) return RedirectToAction("confirmEmail");
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



        #region ReSendForReset
        [HttpGet("ReSendForReset")]
        public async Task<IActionResult> ReSendForReset(string email)
        {
            await _service.ReSendCode(email);
            return RedirectToAction("ResetPassword", new { email });
        }
        #endregion



        #region ReSendForConfirm
        [HttpGet("ReSendForConfirm")]
        public async Task<IActionResult> ReSendForConfirm(string email)
        {
            await _service.ReSendCode(email);
            return RedirectToAction("ConfirmEmail", new { email });
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







