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
        bool MarkAsRead(int Id);
        List<ContactUsMessageViewModel> GetAll();
        List<ContactUsMessageViewModel> GetAllUnRead();
        ContactUsMessageViewModel GetMessageById(int Id);
        bool SendAnswer(int Id, string answer);
        bool DeleteMessage(int Id);
    }
}
