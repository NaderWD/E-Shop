using E_Shop.Application.Services.Interfaces;
using E_Shop.Application.Services.Tools;

using E_Shop.Application.ViewModels;
using E_Shop.Domain.Models;
using E_Shop.Domain.Repositories.Interfaces;
using E_Shop.Domain.ViewModels;
using System.Collections.Generic;
using System.Numerics;
using static E_Shop.Domain.ViewModels.LoginVM;
using static E_Shop.Domain.ViewModels.RegisterVM;
using static E_Shop.Domain.ViewModels.ResetPasswordVM;

namespace E_Shop.Application.Services.Implementations
{
    public class UserService(IUserRepository repository) : IUserService
    {
        private readonly IUserRepository _repository = repository;

        public bool DeleteUser(int id)
        {
          _repository.DeleteUser(id);
            return true;
        }

        public async Task<IEnumerable<UserViewModel>> GetAllUsers()
        {
            List<UserViewModel> users = new List<UserViewModel>();
            IEnumerable<User> model = await _repository.GetAllUsers();

            foreach (var item in model)
            {
                users.Add(new UserViewModel
                {
                    Id = item.Id,
                    FirstName = item.FirstName,
                    LastName = item.LastName,
                    EmailAddress = item.EmailAddress,
                    Mobile = item.Mobile,
                    UserName = item.UserName,
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

       
        public Task<User> GetUserById(int id)
        {
            return _repository.GetUserById(id);
        }

        public async Task<LoginVM.LoginResult> Login(LoginVM login)
        {
            var email = login.EmailAddress.Trim().ToLower();
            var user = await _repository.GetUserByEmail(email);

            if (user == null) return LoginResult.UserNotFound;

            string hashPassword = login.Password.Trim().EncodePasswordMd5();

            if (login.Password != hashPassword) return LoginResult.Error;

            return LoginResult.Success;
        }

        public async Task<RegisterResult> Register(RegisterVM register)
        {
            var code = new Guid();
            var user = new User()
            {
                FirstName = register.FirstName,
                LastName = register.LastName,
                EmailAddress = register.EmailAddress,
                Mobile = register.Mobile,
                Password = PasswordHasher.EncodePasswordMd5(register.Password),
                ActivationCode = code,
            };
            _repository.CreateUser(user);
            _repository.Save();
            return RegisterResult.Success;
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

        public async Task<ValidationErrorType> UpdateUser(UserViewModel model)
        {
            if (_repository.EmailIsDuplicated(model.EmailAddress))
                return ValidationErrorType.EmailIsDuplicated;
            else
            {
                var user = new User
                {
                    UserName = model.UserName,
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
                    UserName = model.UserName,
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
    }
}
