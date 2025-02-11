using E_Shop.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Shop.Application.Services.Interfaces
{
    public interface IContactUsService
    {
        bool SendMessage(ContactUsMessageViewModel message);
    }
}
