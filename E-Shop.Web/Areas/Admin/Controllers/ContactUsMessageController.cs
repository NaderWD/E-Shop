using E_Shop.Application.Services.Interfaces;
using E_Shop.Application.ViewModels;
using E_Shop.Domain.Models.Shared;
using Microsoft.AspNetCore.Mvc;

namespace E_Shop.Web.Areas.Admin.Controllers
{
    public class ContactUsMessageController(IContactUsService contactUsService, IEmailSender emailSender) : AdminBaseController
    {
        public IActionResult Index()
        {
            var content = contactUsService.GetAll();
            return View(content);
        }
        [HttpPost]
        public IActionResult MarkAsRead(int Id)
        {
            contactUsService.MarkAsRead(Id);
            return Ok();

        }
        
        [HttpPost]
        public IActionResult DeleteMessage(int Id)
        {
            var result = contactUsService.DeleteMessage(Id);
            
            if (result == true)
            {
                TempData[SuccessMessage] = ErrorMessages.UserDeleted;
                return RedirectToAction("Index");
            }
            else
            {
                TempData[ErrorMessage] = ErrorMessages.FailedMessage;
                return RedirectToAction("Index");
            }

        }
        
        
        public IActionResult SendAnswer(int Id)
        {
            var content = contactUsService.GetMessageById(Id);
            return View(content);
        }

        [HttpPost]
        public async Task<IActionResult> SendAnswer(ContactUsAnswerViewModel model)
        {
            var message = contactUsService.GetMessageById(model.Id);
            contactUsService.SendAnswer(model.Id, model.AdminAnswer);
            
            
            var result =await emailSender.SendEmailAsync(message.Email, "جواب پیام شما به سایت یکتا کالا", model.AdminAnswer);
            
            
            if (result == true)
            {
                TempData[SuccessMessage] = ErrorMessages.MessageSent;
                return RedirectToAction("Index");
            }
            else
            {
                TempData[ErrorMessage] = ErrorMessages.FailedMessage;
                return RedirectToAction("SendAnswer");
            }
            

        }


    }
}
