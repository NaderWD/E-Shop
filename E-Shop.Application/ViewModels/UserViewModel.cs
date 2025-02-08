using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Shop.Application.ViewModels
{
    public class UserViewModel
    {
        
        public int Id { get; set; }
        [MaxLength(255)]
        public string? FirstName { get; set; }

        [MaxLength(255)]
        public string? LastName { get; set; }

        [MaxLength(255)]
        [Required(ErrorMessage = "لطفا نام کاربری را وارد کنید")]
        public string UserName { get; set; }

        [MaxLength(255)]
        public string Password { get; set; }

        [MaxLength(500)]
        [Required(ErrorMessage = "لطفا ایمیل را وارد کنید")]
        [DataType(DataType.EmailAddress)]
        public string EmailAddress { get; set; }

        [MaxLength(500)]
        public string? Mobile { get; set; }

        public bool? IsAdmin { get; set; }
    }
    public enum ValidationErrorType
    {
        EmailIsDuplicated,
        Success
    }
}
