using E_Shop.Application.Services.Interfaces;
using E_Shop.Application.Services.Security;
using E_Shop.Domain.Models;
using E_Shop.Domain.Repositories.Interfaces;
using E_Shop.Domain.ViewModels;
using static E_Shop.Domain.ViewModels.LoginVM;
using static E_Shop.Domain.ViewModels.RegisterVM;

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
            await _repository.RegisterUser(register);
            return RegisterResult.Success;
        }
    }
}
