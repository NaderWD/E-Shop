using System.ComponentModel.DataAnnotations;

namespace E_Shop.Application.ViewModels.UserViewModels
{
    public class UserDetailsVM
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string? EmailAddress { get; set; }

        public string? Mobile { get; set; }
    }
}
