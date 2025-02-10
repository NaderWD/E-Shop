using E_Shop.Application.Services.Interfaces;
using E_Shop.Application.Tools;
using E_Shop.Application.ViewModels;
using E_Shop.Domain;
using E_Shop.Domain.Models;
using E_Shop.Domain.Models.Shared;
using E_Shop.Domain.Repositories.Interfaces;
using static E_Shop.Application.ViewModels.LoginVM;
using static E_Shop.Application.ViewModels.ResetPasswordVM;

namespace E_Shop.Application.Services.Implementations
{
    public class UserService(IUserRepository _repository, IEmailSender _emailSender) : IUserService
    {
        public bool DeleteUser(int id)
        {
            _repository.DeleteUser(id);
            return true;
        }

        public async Task<IEnumerable<UserViewModel>> GetAllUsers()
        {
            IEnumerable<User> model = await _repository.GetAllUsers();
            List<UserViewModel> users = [];

            foreach (var item in model)
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
                });
            }
            return (users);
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

        public Task<User> GetUserById(int id)
        {
            return _repository.GetUserById(id);
        }

        public async Task<LoginResults> Login(LoginVM login)
        {
            var email = login.EmailAddress.Trim().ToLower();
            var user = await _repository.GetUserByEmail(email);
            var password = PasswordHasher.EncodePasswordMd5(login.Password);

            if (user == null) return LoginResults.UserNotFound;
            if (password != user.Password) return LoginResults.Error;
            return LoginResults.Success;
        }

        public async Task<bool> ActivateAccount(string code)
        {
            User user = await _repository.GetUserByActivationCode(code);
            if (user != null)
            {
                user.IsActive = true;
                _repository.UpdateUser(user);
                return true;
            }
            return false;
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
            await _emailSender.SendEmailAsync(userVM.EmailAddress, "کد تایید اکانت", $"کد تایید اکانت شما {activeCode} می باشد");

            return ErrorMessages.registerConfirmationSuccess;
        }

        public async Task<UserResult> ResetPassword(ResetPasswordVM resetPassword, string code, string password)
        {
            User user = await _repository.GetUserByEmail(resetPassword.EmailAddress);
            if (user.ActivationCode == code)
            {
                user.Password = PasswordHasher.EncodePasswordMd5(password);
                _repository.UpdateUser(user);
                return UserResult.Success;
            }
            return UserResult.Error;
        }

        public async Task<ValidationErrorType> UpdateUser(UserViewModel model)
        {
            if (_repository.EmailIsDuplicated(model.EmailAddress))
                return ValidationErrorType.EmailIsDuplicated;
            else
            {
                var user = new User
                {
                    EmailAddress = model.EmailAddress,
                    Mobile = model.Mobile,
                    IsAdmin = model.IsAdmin,
                    FirstName = model.FirstName,
                    LastName = model.LastName
                };

                _repository.UpdateUser(user);
                return ValidationErrorType.Success;
            }
        }

        async Task<ValidationErrorType> IUserService.CreateUser(UserViewModel model)
        {
            if (_repository.EmailIsDuplicated(model.EmailAddress))
                return ValidationErrorType.EmailIsDuplicated;
            else
            {
                var user = new User
                {
                    EmailAddress = model.EmailAddress,
                    Mobile = model.Mobile,
                    IsAdmin = model.IsAdmin,
                    FirstName = model.FirstName,
                    LastName = model.LastName
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
            return true;
        }
    }
}
