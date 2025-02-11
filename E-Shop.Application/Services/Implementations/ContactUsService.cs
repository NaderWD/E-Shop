using E_Shop.Application.Services.Interfaces;
using E_Shop.Domain.Models;
using E_Shop.Domain.Repositories.Interfaces;
using E_Shop.Domain.ViewModels;
using E_Shop.Infra.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Shop.Application.Services.Implementations
{
    public class ContactUsService(IContactUsRepository contactUsRepository) : IContactUsService
    {
        
        public bool SendMessage(ContactUsMessageViewModel message)
        {
            var model = new ContactUsMessage
            {
                Title = message.Title,
                FullName = message.FullName,
                CreatDate = DateTime.Now,
                Email = message.Email,
                Mobile = message.Mobile,
                Message = message.Message,
                LastModifiedDate = DateTime.Now,
                
            };
            return contactUsRepository.SendMessage(model);
        }
    }
}
