using E_Shop.Application.ViewModels.UserViewModels;
using E_Shop.Domain.Enum;

namespace E_Shop.Application.Services.UserServices
{
    public interface IUserService
    {
        Task<ValidationErrorType> CreateUser(UserViewModel userVM, List<int> selectedRoleIds);
        Task<List<UserViewModel>> GetAllUsers();
        Task<UserViewModel> GetUserById(int id);
        Task<ValidationErrorType> UpdateUser(UserViewModel userVM, bool EmailCheck, List<int> selectedRoleIds);
        Task<bool> DeleteUser(int id);
    }
}
