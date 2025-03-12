using E_Shop.Application.Services.AccountServices;
using E_Shop.Application.Services.RoleServices;
using E_Shop.Application.ViewModels.UserViewModels;
using E_Shop.Domain.Contracts.RolePermissionCont;
using E_Shop.Domain.Contracts.UserCont;
using E_Shop.Domain.Enum;
using E_Shop.Domain.Models.UserModels;


namespace E_Shop.Application.Services.UserServices
{
    public class UserService(IUserRepository _repository, 
                                           IAccountService _accountService, 
                                           IUserRoleRepository _userRoleRepository, 
                                           IUserRoleService _userRoleService) : IUserService
    {
        public async Task<ValidationErrorType> CreateUser(UserViewModel model, List<int> selectedRoleIds)
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
                await _repository.Save();
                await _userRoleService.UpdateUserRole(user.Id, selectedRoleIds);
                await _repository.Save();
                return ValidationErrorType.Success;
            }
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
                    RoleNames = [.. (await _userRoleRepository.GetUserRolesByUserId(item.Id)).Select(r => r.Role.RoleName)]
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
                RoleNames = [.. (await _userRoleRepository.GetUserRolesByUserId(user.Id)).Select(r => r.Role.RoleName)]
            };
            return model;
        }

        public async Task<ValidationErrorType> UpdateUser(UserViewModel model, bool EmailCheck, List<int> selectedRoleIds)
        {
            if (await _accountService.EmailExist(model.EmailAddress))
                return ValidationErrorType.EmailIsDuplicated;

            var user = await _repository.GetUserById(model.Id);
            user.Mobile = model.Mobile;
            user.IsAdmin = model.IsAdmin;
            user.FirstName = model.FirstName;
            user.LastName = model.LastName;

            await _userRoleService.UpdateUserRole(model.Id, selectedRoleIds);
            await _repository.Save();
            await _repository.UpdateUser(user);
            return ValidationErrorType.Success;
        }

        public async Task<bool> DeleteUser(int userId)
        {
            var userRoles = await _userRoleRepository.GetUserRolesByUserId(userId);
            foreach (var userRole in userRoles) await _userRoleRepository.DeleteUserRole(userRole.Id);
            var user = await _repository.GetUserById(userId);
            user.IsDelete = true;
            await _repository.UpdateUser(user);
            await _repository.Save();
            return true;
        }
    }
}
