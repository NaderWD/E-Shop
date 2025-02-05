using E_Shop.Domain.Models.Common;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace E_Shop.Domain.Models
{
    public class User : BaseModel
    {

        [MaxLength(255, ErrorMessage = "Username cannot be longer than 50 characters")]
        [Required(ErrorMessage = "Username is required")]
        public string? FirstName { get; set; }
       
        [MaxLength(255, ErrorMessage = "Username cannot be longer than 50 characters")]

        public string? LastName { get; set; }
        
        [MaxLength(255, ErrorMessage = "Username cannot be longer than 50 characters")]
        [Required(ErrorMessage = "Username is required")]

        public string? UserName { get; set; }

        [MaxLength(255, ErrorMessage = "Username cannot be longer than 50 characters")]
        [Required(ErrorMessage = "Username is required")]

        public string Password { get; set; }

        [MaxLength(500, ErrorMessage = "Username cannot be longer than 50 characters")]
        [Required(ErrorMessage = "Username is required")]

        public string EmailAddress { get; set; }

        [MaxLength(500, ErrorMessage = "Username cannot be longer than 50 characters")]

        public string? Mobile { get; set; }

        public bool IsAdmin { get; set; } = false;
    }
    
}
