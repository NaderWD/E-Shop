using E_Shop.Application.Services.Interfaces;
using E_Shop.Application.Tools;
using E_Shop.Application.ViewModels.TicketViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace E_Shop.Web.Areas.User.Controllers
{


    [Authorize]
    public class UserTicketController(ITicketService _service, ITicketMessageService _messageService) : UserBaseController
    {

        #region User Index
        [HttpGet("/UserTickets")]
        public async Task<IActionResult> UserTickets()
        {
            var userId = User.GetUserId();
            var tickets = await _service.GetTicketsByUserId(userId);
            return View(tickets);
        }
        #endregion



        #region Details & Chat Screen
        [HttpGet("/Ticket/Details")]
        public async Task<IActionResult> Details(int tiketId)
        {
            var userId = User.GetUserId();
            var ticket = await _service.GetTicketById(tiketId);
            if (ticket == null || ticket.OwnerId != userId) return NotFound();
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
        [HttpGet("/Ticket/Create")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost("/Ticket/Create")]
        public async Task<IActionResult> Create(TicketVM ticketVM, IFormFile? attachment)
        {
            if (!ModelState.IsValid) return View(ticketVM);
            var userId = User.GetUserId();
            await _service.CreateTicket(ticketVM, attachment, userId);
            return RedirectToAction(nameof(UserTickets));
        }
        #endregion



        #region Delete Ticket
        [HttpGet("/Ticket/DeleteTicket")]
        public async Task<IActionResult> DeleteTicket(int ticketId)
        {
            var ticket = await _service.GetTicketById(ticketId);
            if (ticket == null || ticket.OwnerId != User.GetUserId()) return NotFound();
            await _service.SoftDeleteTicket(ticketId);
            return RedirectToAction(nameof(UserTickets));
        }
        #endregion

    }
}
