using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Shop.Domain.ViewModels
{
    public class ValidationResultViewModel
    {
        public bool IsValidUsername { get; set; } = true;
        public string UsernameErrorMessage { get; set; }

        public bool IsValidPassword { get; set; } = true;
        public string PasswordErrorMessage { get; set; }
    }
}
