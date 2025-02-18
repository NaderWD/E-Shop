using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Shop.Application.ViewModels.ContactUsViewModels
{
    public class ContactUsAnswerViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "لطفا جواب را وارد کنید.")]
        public string? AdminAnswer { get; set; }
    }
}
