using E_Shop.Application.Services.Interfaces;
using E_Shop.Application.Tools;
using E_Shop.Domain.Models;
using E_Shop.Domain.Repositories.Interfaces;
using E_Shop.Domain.ViewModels;
using static E_Shop.Domain.ViewModels.LoginVM;
using static E_Shop.Domain.ViewModels.RegisterVM;
using static E_Shop.Domain.ViewModels.ResetPasswordVM;

namespace E_Shop.Application.Services.Implementations
{
    public class UserService(IUserRepository repository) : IUserService
    {
        private readonly IUserRepository _repository = repository;

       

        public async Task<User> GetByEmail(string email)
        {
            var myEmail = email.Trim().ToLower();
            return await _repository.GetUserByEmail(myEmail);
        }

        public async Task<bool> EmailExist(string email)
        {
            var check = await _repository.CheckEmailExist(email);
            if (check == true) return false;
            return true;
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

        public async Task<bool> ActivateAccount(ForgetPasswordVM userVM, string code)
        {
            User user = await _repository.GetUserByEmail(userVM.EmailAddress);
            if (user.ActivationCode == code)
            {
                user.IsActive = true;
                _repository.Update(user);
                return true;
            }
            return false;
        }

        public async Task<RegisterResults> Register(RegisterVM userVM)
        {
            var activeCode = Guid.NewGuid().ToString();
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
            var check = await EmailExist(userVM.EmailAddress);
            if (check == true) return RegisterResults.EmailExists;
            await _repository.CreateUser(user);
            return RegisterResults.Success;
        }

        public async Task<UserResult> ResetPassword(ResetPasswordVM resetPassword, string code, string password)
        {
            var user = await _repository.GetUserByEmail(resetPassword.EmailAddress);
            user.Password = password;
            _repository.UpdateUser(user);
            _repository.Save();
            if (code != null) { }
            return UserResult.Success;
        }


    }
}
