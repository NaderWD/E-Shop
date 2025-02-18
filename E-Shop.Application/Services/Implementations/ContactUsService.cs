using E_Shop.Application.Services.Interfaces;
using E_Shop.Application.ViewModels.ContactUsViewModels;
using E_Shop.Domain.Models;
using E_Shop.Domain.Repositories.Interfaces;
using E_Shop.Infra.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Shop.Application.Services.Implementations
{
    public class ContactUsService(IContactUsRepository contactUsRepository) : IContactUsService
    {
        public bool DeleteMessage(int Id)
        {
            var user = contactUsRepository.GetMessageById(Id);
            user.IsDelete = true;
            contactUsRepository.UpdateMessage(user);
            return true;
        }

        public List<ContactUsMessageViewModel> GetAll()
        {
            var messages = contactUsRepository.GetAll().Where(m => m.IsDelete == false);
            List<ContactUsMessageViewModel> models = new List<ContactUsMessageViewModel>();
            
            foreach (var message in messages)
            {
                models.Add(new ContactUsMessageViewModel
                {
                    Id = message.Id,
                    FullName = message.FullName,
                    Message = message.Message,
                    Mobile = message.Mobile,
                    Title = message.Title,
                    Email = message.Email,
                    IsRead = message.IsRead,
                    IsClosed = message.IsClosed,
                    
                });

            }
            return models;
        }

        public List<ContactUsMessageViewModel> GetAllUnRead()
        {
           return GetAll().Where(m => m.IsRead == false && m.IsDeleted == false).ToList();
        }

        public ContactUsMessageViewModel GetMessageById(int Id)
        {
            var message =  contactUsRepository.GetMessageById(Id);

            var model = new ContactUsMessageViewModel
            {
                 Title =message.Title,
                 Email = message.Email,
                 IsRead = message.IsRead,
                 Mobile = message.Mobile,
                 Id = Id,
                 IsClosed = message.IsClosed,
                 FullName=message.FullName,
                 Message=message.Message,
                 AdminAnswer=message.AdminAnswer,

            };
           return model;
               
            
        }

        public bool MarkAsRead(int Id)
        {
            var message = contactUsRepository.GetMessageById(Id);
            message.IsRead = true;
            contactUsRepository.UpdateMessage(message);
            return true;
        }

        public bool SendAnswer(int Id, string answer)
        {
            var message = contactUsRepository.GetMessageById(Id);
            message.AdminAnswer = answer;
            message.IsClosed = true;
            contactUsRepository.UpdateMessage(message);
            return true;
        }

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
