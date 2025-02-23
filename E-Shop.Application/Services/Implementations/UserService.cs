using E_Shop.Application.Services.Interfaces;
using E_Shop.Application.ViewModels.UserViewModels;
using E_Shop.Domain.Enum;
using E_Shop.Domain.Models;
using E_Shop.Domain.Repositories.Interfaces;


namespace E_Shop.Application.Services.Implementations
{
    public class UserService(IUserRepository _repository, IAccountService _accountService) : IUserService
    {

        public async Task<bool> DeleteUser(int id)
        {
            var user = await _repository.GetUserById(id);
            user.IsDelete = true;
            await _repository.UpdateUser(user);
            await _repository.Save();
            return true;
        }

        public async Task<List<UserDetailsVM>> GetAllUsersForShow()
        {
            List<User> model = await _repository.GetAllUsers();   
            List<UserDetailsVM> users = [];

            foreach (var item in model.Where(u => u.IsDelete == false))
            {
                users.Add(new UserDetailsVM
                {
                    FirstName = item.FirstName,
                    LastName = item.LastName,
                    EmailAddress = item.EmailAddress,
                    Mobile = item.Mobile,
                });
            }
            return users;
        }

        public async Task<List<UserViewModel>> GetAllUsers()
        {
            List<User> model = await _repository.GetAllUsers();
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

        public async Task<ValidationErrorType> UpdateUser(UserViewModel model, bool EmailCheck)
        {
            if (EmailCheck)
            {
                if (await _accountService.EmailExist(model.EmailAddress))
                    return ValidationErrorType.EmailIsDuplicated;

                var user = await _repository.GetUserById(model.Id);


                user.EmailAddress = model.EmailAddress;
                user.Mobile = model.Mobile;
                user.IsAdmin = model.IsAdmin;
                user.FirstName = model.FirstName;
                user.LastName = model.LastName;


                await _repository.UpdateUser(user);
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


                await _repository.UpdateUser(user);
                return ValidationErrorType.Success;
            }

        }

        public async Task<ValidationErrorType> CreateUser(UserViewModel model)
        {
            if (await _accountService.EmailExist(model.EmailAddress))
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

                await _repository.CreateUser(user);
                return ValidationErrorType.Success;
            }
        }

    }
}
