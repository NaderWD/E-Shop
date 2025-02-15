using System.ComponentModel.DataAnnotations;

namespace E_Shop.Application.ViewModels
{
    public class UserDetailsVM
    {
       public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string? EmailAddress { get; set; }

        public string? Mobile { get; set; }
    }
}
