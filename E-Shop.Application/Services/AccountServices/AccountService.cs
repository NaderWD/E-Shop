using E_Shop.Application.Services.EmailServices;
using E_Shop.Application.Tools;
using E_Shop.Application.ViewModels.AccountViewModels;
using E_Shop.Domain.Contracts.UserCont;
using E_Shop.Domain.Models.UserModels;
using E_Shop.Domain.Models.ValidationModels;

namespace E_Shop.Application.Services.AccountServices
{
    public class AccountService(IUserRepository _repository, IEmailSender _emailSender, IUserRepository _userRepository) : IAccountService
    {

        public async Task<string> Login(LoginVM login)
        {
            var user = await GetByEmail(login.EmailAddress);
            var password = login.Password.EncodePasswordMd5();

            if (user == null) return ErrorMessages.UserNotExistError;
            if (password != user.Password) return ErrorMessages.WrongPassword;

            return ErrorMessages.LoginSuccess;
        }

        public async Task<string> Register(RegisterVM userVM)
        {
            var check = await EmailExist(userVM.EmailAddress);
            if (check) return ErrorMessages.EmailExistError;

            var activeCode = CodeGenerator.GenerateCode();
            User user = new()
            {
                FirstName = userVM.FirstName,
                LastName = userVM.LastName,
                EmailAddress = userVM.EmailAddress.Trim().ToLower(),
                Mobile = userVM.Mobile,
                Password = userVM.Password.EncodePasswordMd5(),
                ActivationCode = activeCode,
                IsActive = false,
            };
            await _repository.CreateUser(user);
            await _repository.Save();
            await _emailSender.SendEmailAsync(userVM.EmailAddress, "کد فعال سازی", $"کد تایید اکانت شما {activeCode} می باشد");

            return ErrorMessages.registerConfirmationSuccess;
        }

        public async Task<string> ForgetPasswordCode(ForgetPasswordVM userVM)
        {
            var email = userVM.EmailAddress.Trim().ToLower();
            var user = await _repository.GetUserByEmail(email);
            var activeCode = CodeGenerator.GenerateCode();

            user.ActivationCode = activeCode;
            await _repository.UpdateUser(user);
            await _repository.Save();

            await _emailSender.SendEmailAsync(userVM.EmailAddress, "کد فعال سازی", $"کد تایید اکانت شما {activeCode} می باشد");
            return ErrorMessages.ResetPasswordEmailSent;
        }

        public async Task<string> ResetPassword(ResetPasswordVM resetPassword, string code, string password)
        {
            User user = await _repository.GetUserByEmail(resetPassword.EmailAddress);
            if (user.ActivationCode != code) return ErrorMessages.ResetPasswordCodeError;

            user.Password = password.EncodePasswordMd5();
            user.ActivationCode = CodeGenerator.GenerateCode();
            await _repository.UpdateUser(user);
            await _repository.Save();

            await _emailSender.SendEmailAsync(user.EmailAddress, "تغییر رمز عبور", $"کاربر گرامی رمز عبور شما در سایت بزرگ فروشگاهی یکتا فلان فلان با موفقیت تغییر کرد");

            return ErrorMessages.ResetPasswordSuccess;
        }

        public async Task<User> GetByEmail(string email)
        {
            var myEmail = email.Trim().ToLower();
            return await _repository.GetUserByEmail(myEmail);
        }

        public async Task<bool> EmailExist(string email)
        {
            var check = await _repository.EmailIsDuplicated(email);
            if (check) return true;
            return false;
        }

        public async Task<bool> ConfirmEmailService(ConfirmEmailVM model)
        {
            var user = await _repository.GetUserByActivationCode(model.ActivationCode);
            if (user == null) return false;

            user.IsActive = true;
            user.ActivationCode = CodeGenerator.GenerateCode();
            await _repository.UpdateUser(user);
            await _repository.Save();

            await _emailSender.SendEmailAsync(user.EmailAddress, "آفرین بر تو", $"کاربر گرامی ثبت نام شما در سایت بزرگ فروشگاهی یکتا فلان فلان با موفقیت انجام شد");

            return true;
        }

        public async Task<string> ReSendCode(string email)
        {
            var email2 = email.Trim().ToLower();
            var user = await _repository.GetUserByEmail(email2);
            var activeCode = CodeGenerator.GenerateCode();

            user.ActivationCode = activeCode;
            await _repository.UpdateUser(user);
            await _repository.Save();

            await _emailSender.SendEmailAsync(user.EmailAddress, "کد فعال سازی", $"کد تایید اکانت شما {activeCode} می باشد");
            return ErrorMessages.ResetPasswordEmailSent;
        }

        public async Task<bool> AdminCheck(int userId)
        {
            return await _userRepository.ChekAdmin(userId);
        }
    }
}
