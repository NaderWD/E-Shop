using System.ComponentModel.DataAnnotations;

namespace E_Shop.Domain.ViewModels
{
    public class ResetPasswordVM
    {
        public string Code { get; set; }

        [DataType(DataType.Password)]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Compare("NewPassword")]
        public string RePassword { get; set; }
    }
}
