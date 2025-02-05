using E_Shop.Application.Services.Interfaces;
using E_Shop.Application.Services.Tools;
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

        public async Task<LoginResult> Login(LoginVM login)
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
    }
}
