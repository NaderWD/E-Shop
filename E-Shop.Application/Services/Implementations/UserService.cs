using E_Shop.Application.Services.Interfaces;
using E_Shop.Application.Tools;
using E_Shop.Application.ViewModels;
using E_Shop.Domain.Enum;
using E_Shop.Domain.Models;
using E_Shop.Domain.Models.Shared;
using E_Shop.Domain.Repositories.Interfaces;


namespace E_Shop.Application.Services.Implementations
{
    public class UserService(IUserRepository _repository, IEmailSender _emailSender) : IUserService
    {

        public async Task<bool> DeleteUser(int id)
        {
            var user = await _repository.GetUserById(id);
            user.IsDelete = true;
            _repository.UpdateUser(user);
            _repository.Save();
            return true;
        }


        public async Task<IEnumerable<UserViewModel>> GetAllUsers()
        {
            IEnumerable<User> model = await _repository.GetAllUsers();
            List<UserViewModel> users = [];

            foreach (var item in model.Where(u => u.IsDelete == false))
            {
                users.Add(new UserViewModel
                {
                    Id = item.Id,
                    FirstName = item.FirstName,
                    LastName = item.LastName,
                    EmailAddress = item.EmailAddress,
                    Mobile = item.Mobile,
                    IsAdmin = item.IsAdmin,
                    Password = item.Password,
                    IsActive = item.IsActive,
                });
            }
            return users;
        }

        public async Task<User> GetByEmail(string email)
        {
            var myEmail = email.Trim().ToLower();
            return await _repository.GetUserByEmail(myEmail);
        }

        public async Task<bool> EmailExist(string email)
        {
            var check = _repository.EmailIsDuplicated(email);
            if (check) return true;
            return false;
        }

        public async Task<UserViewModel> GetUserById(int id)
        {
            var user = await _repository.GetUserById(id);

            var model = new UserViewModel
            {
                Id = user.Id,
                EmailAddress = user.EmailAddress,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Mobile = user.Mobile,
                IsAdmin = user.IsAdmin,
                Password = user.Password,
            };
            return model;
        }

        public async Task<string> Login(LoginVM login)
        {
            var user = await GetByEmail(login.EmailAddress);
            var password = PasswordHasher.EncodePasswordMd5(login.Password);

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
                Password = PasswordHasher.EncodePasswordMd5(userVM.Password),
                ActivationCode = activeCode,
                IsActive = false,
            };
            _repository.CreateUser(user);
            _repository.Save();
            await _emailSender.SendEmailAsync(userVM.EmailAddress, "کد فعال سازی", $"کد تایید اکانت شما {activeCode} می باشد");

            return ErrorMessages.registerConfirmationSuccess;
        }

        public async Task<string> ForgetPasswordCode(ForgetPasswordVM userVM)
        {
            var email = userVM.EmailAddress.Trim().ToLower();
            var user = await _repository.GetUserByEmail(email);
            var activeCode = CodeGenerator.GenerateCode();

            user.ActivationCode = activeCode;
            _repository.UpdateUser(user);
            _repository.Save();

            await _emailSender.SendEmailAsync(userVM.EmailAddress, "کد فعال سازی", $"کد تایید اکانت شما {activeCode} می باشد");
            return ErrorMessages.ResetPasswordEmailSent;
        }

        public async Task<string> ResetPassword(ResetPasswordVM resetPassword, string code, string password)
        {
            User user = await _repository.GetUserByEmail(resetPassword.EmailAddress);
            if (user.ActivationCode != code) return ErrorMessages.ResetPasswordCodeError;

            user.Password = PasswordHasher.EncodePasswordMd5(password);
            user.ActivationCode = CodeGenerator.GenerateCode();
            _repository.UpdateUser(user);
            _repository.Save();
            return ErrorMessages.ResetPasswordSuccess;
        }

        public async Task<ValidationErrorType> UpdateUser(UserViewModel model, bool EmailCheck)
        {
            if (EmailCheck)
            {
                if (await EmailExist(model.EmailAddress))
                    return ValidationErrorType.EmailIsDuplicated;

                var user = await _repository.GetUserById(model.Id);


                user.EmailAddress = model.EmailAddress;
                user.Mobile = model.Mobile;
                user.IsAdmin = model.IsAdmin;
                user.FirstName = model.FirstName;
                user.LastName = model.LastName;


                _repository.UpdateUser(user);
                return ValidationErrorType.Success;
            }
            else
            {
                var user = await _repository.GetUserById(model.Id);


                user.EmailAddress = model.EmailAddress;
                user.Mobile = model.Mobile;
                user.IsAdmin = model.IsAdmin;
                user.FirstName = model.FirstName;
                user.LastName = model.LastName;


                _repository.UpdateUser(user);
                return ValidationErrorType.Success;
            }

        }

        public async Task<ValidationErrorType> CreateUser(UserViewModel model)
        {
            if (await EmailExist(model.EmailAddress))
                return ValidationErrorType.EmailIsDuplicated;

            else
            {
                var user = new User
                {
                    EmailAddress = model.EmailAddress,
                    Mobile = model.Mobile,
                    IsAdmin = model.IsAdmin,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Password = model.Password,
                };

                _repository.CreateUser(user);
                return ValidationErrorType.Success;
            }
        }

        public async Task<bool> ConfirmEmailService(ConfirmEmailVM model)
        {
            var user = await _repository.GetUserByActivationCode(model.ActivationCode);
            if (user == null) return false;

            user.IsActive = true;
            user.ActivationCode = CodeGenerator.GenerateCode();
            _repository.UpdateUser(user);
            _repository.Save();

            await _emailSender.SendEmailAsync(user.EmailAddress, "آفرین بر تو", $"کاربر گرامی ثبت نام شما در سایت بزرگ فروشگاهی یکتا فلان فلان با موفقیت انجام شد");

            return true;
        }

        public async Task<string> ReSendCode(string email)
        {
            var email2 = email.Trim().ToLower();
            var user = await _repository.GetUserByEmail(email2);
            var activeCode = CodeGenerator.GenerateCode();

            user.ActivationCode = activeCode;
            _repository.UpdateUser(user);
            _repository.Save();

            await _emailSender.SendEmailAsync(user.EmailAddress, "کد فعال سازی", $"کد تایید اکانت شما {activeCode} می باشد");
            return ErrorMessages.ResetPasswordEmailSent;
        }
    }
}
