using E_Shop.Application.ViewModels.UserViewModels;
using E_Shop.Domain.Enum;

namespace E_Shop.Application.Services.Interfaces
{
    public interface IUserService
    {
        Task<ValidationErrorType> CreateUser(UserViewModel userVM);
        Task<ValidationErrorType> UpdateUser(UserViewModel userVM, bool EmailCheck);
        Task<bool> DeleteUser(int id);
        Task<UserViewModel> GetUserById(int id);
        Task<List<UserViewModel>> GetAllUsers();
        Task<List<UserDetailsVM>> GetAllUsersForShow();
    }
}
