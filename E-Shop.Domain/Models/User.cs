using E_Shop.Domain.Models.Common;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace E_Shop.Domain.Models
{
    public class User : BaseModel
    {
        public string? FirstName { get; set; }
       
        public string? LastName { get; set; }

        public string Password { get; set; }

        public string EmailAddress { get; set; }

        public string? Mobile { get; set; }

        public string? ActivationCode { get; set; }

        public bool? IsAdmin { get; set; }

        public bool? IsActive { get; set; }
    }
    
}
