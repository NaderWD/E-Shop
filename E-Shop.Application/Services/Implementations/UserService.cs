using E_Shop.Application.Services.Interfaces;
using E_Shop.Application.Tools;
using E_Shop.Application.ViewModels;
using E_Shop.Domain;
using E_Shop.Domain.Models;
using E_Shop.Domain.Repositories.Interfaces;
using static E_Shop.Application.ViewModels.LoginVM;
using static E_Shop.Application.ViewModels.RegisterVM;
using static E_Shop.Application.ViewModels.ResetPasswordVM;

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
            if (check == true) return false;
            return true;
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
            //var check = await EmailExist(userVM.EmailAddress);
            //if (check != true) return user;
            _repository.CreateUser(user);
            return RegisterResults.Success;
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
    }
}
