using E_Shop.Application.Services.Interfaces;
using E_Shop.Application.Tools;
using E_Shop.Application.ViewModels.TicketViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;
using static E_Shop.Domain.Enum.TicketsEnums;

namespace E_Shop.Web.Areas.Admin.Controllers
{
    public class AdminTicketController(ITicketService _ticketService, ITicketMessageService _messageService, IUserService _userService) : AdminBaseController
    {

        #region View All Tickets
        [HttpGet]
        public async Task<IActionResult> AllTickets()
        {
            var tickets = await _ticketService.GetAllTickets();
            return View(tickets);
        }
        #endregion



        #region Create New Ticket
        [HttpGet]
        public async Task<IActionResult> CreateNewTicket()
        {
            var users = await _userService.GetAllUsers();
            return View(users);
        }
        #endregion



        #region Send Ticket To User
        [HttpGet]
        public async Task<IActionResult> SendTicket(int userId)
        {
            var senderId = User.GetUserId();
            var user = await _userService.GetUserById(userId);
            ViewBag.Name = user.FirstName + " " + user.LastName;
            return View(new TicketVM { OwnerId = userId, SenderId = senderId });
        }

        [HttpPost]
        public async Task<IActionResult> SendTicket(TicketVM ticketVM, IFormFile? attachment)
        {
            if (!ModelState.IsValid) return View(ticketVM);
            var userId = User.GetUserId();
            await _ticketService.CreateTicket(ticketVM, attachment, userId);
            return RedirectToAction(nameof(AllTickets));
        }
        #endregion



        #region Send Message
        [HttpGet]
        public async Task<IActionResult> SendMessage(int ticketId, int userId)
        {
            var tikets = await _messageService.GetMessagesByTicketId(ticketId);
            var user = await _userService.GetUserById(userId);
            ViewBag.Name = user.FirstName + " " + user.LastName;
            return View(tikets);
        }                                     

        [HttpPost]
        public async Task<IActionResult> SendMessage(MessageVM messageVM, IFormFile? attachment, Status status)
        {
            var ownerId = _ticketService.GetUserIdByTicketId(messageVM.TicketId);
            if (!ModelState.IsValid) return RedirectToAction(nameof(SendMessage), new { ticketId = messageVM.TicketId, userId = ownerId });
            var userId = User.GetUserId();
            await _messageService.AddMessageToTicket(messageVM, attachment, userId);
            await _ticketService.UpdateTicketStatus(messageVM.TicketId, status);
            return RedirectToAction(nameof(SendMessage), new { ticketId = messageVM.TicketId, userId = ownerId });
        }
        #endregion



        #region Delete Ticket
        [HttpPost]
        public async Task<IActionResult> DeleteTicket(int ticketId)
        {
            var ticket = await _ticketService.GetTicketById(ticketId);
            if (ticket == null) return NotFound();
            await _ticketService.SoftDeleteTicket(ticketId);
            return RedirectToAction(nameof(AllTickets));
        }
        #endregion

        [HttpPost]
        public async Task<IActionResult> SaveMessage(MessageVM messageVM, IFormFile? attachment)
        {
            if (!ModelState.IsValid) return View("_SendMessage", messageVM);
            var userId = User.GetUserId();
            await _messageService.AddMessageToTicket(messageVM, attachment, userId);
            return RedirectToAction(nameof(Details), new { messageVM.TicketId });
        }
    }
}
