using E_Shop.Application.Services.TicketServices;
using E_Shop.Application.Tools;
using E_Shop.Application.ViewModels.TicketViewModels;
using E_Shop.Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace E_Shop.Web.Areas.User.Controllers
{


    [Authorize]
    public class UserTicketController(ITicketService _ticketService, ITicketMessageService _messageService) : UserBaseController
    {

        #region User Tickets
        [HttpGet]
        public async Task<IActionResult> UserTickets()
        {
            var userId = User.GetUserId();
            var tickets = await _ticketService.GetTicketsByUserId(userId);
            return View(tickets);
        }
        #endregion



        #region Details & Save Message
        [HttpGet]
        public async Task<IActionResult> Details(int ticketId)
        {
            var ticket = await _ticketService.GetTicketById(ticketId);
            if (ticket == null) return NotFound();
            var messages = await _messageService.GetMessagesByTicketId(ticketId);
            return View(ticket);
        }

        public async Task<IActionResult> SaveMessage(MessageVM messageVM, IFormFile? attachment)
        {
            if (!ModelState.IsValid) return View("_SendMessage", messageVM);
            var userId = User.GetUserId();
            await _messageService.AddMessageToTicket(messageVM, attachment, userId);
            return RedirectToAction(nameof(Details), new { messageVM.TicketId });
        }
        #endregion



        #region Create 
        [HttpGet]
        public IActionResult Create()
        {
            var userId = User.GetUserId();
            return View(new TicketVM { OwnerId = userId });
        }

        [HttpPost]
        public async Task<IActionResult> Create(TicketVM ticketVM, IFormFile? attachment)
        {
            if (!ModelState.IsValid) return View(ticketVM);
            var userId = User.GetUserId();
            await _ticketService.CreateTicket(ticketVM, attachment, userId);
            return RedirectToAction(nameof(UserTickets));
        }
        #endregion



        #region Delete Ticket
        public async Task<IActionResult> DeleteTicket(int ticketId)
        {
            var ticket = await _ticketService.GetTicketById(ticketId);
            if (ticket == null || ticket.OwnerId != User.GetUserId()) return NotFound();
            await _ticketService.SoftDeleteTicket(ticketId);
            return RedirectToAction(nameof(UserTickets));
        }
        #endregion

    }
}
