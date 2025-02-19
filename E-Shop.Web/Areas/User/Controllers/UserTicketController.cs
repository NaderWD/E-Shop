using E_Shop.Application.Services.Interfaces;
using E_Shop.Application.Tools;
using E_Shop.Application.ViewModels.TicketViewModels;
using Microsoft.AspNetCore.Mvc;

namespace E_Shop.Web.Areas.User.Controllers
{
    public class UserTicketController(ITicketService _service, ITicketMessageService _messageService) : UserBaseController
    {

        #region User Index
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var userId = User.GetUserId();
            var tickets = await _service.GetTicketsByUserId(userId);
            return View(tickets);
        }
        #endregion



        #region Details
        [HttpGet("Details/{id}")]
        public async Task<IActionResult> Details(int id)
        {
            var userId = User.GetUserId();
            var ticket = await _service.GetTicketById(id);
            if (ticket == null || ticket.UserId != userId) return NotFound();
            return View(ticket);
        }
        #endregion 



        #region Create
        [HttpGet("Create")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create(TicketVM ticketVM)
        {
            if (!ModelState.IsValid) return View(ticketVM);
            ticketVM.UserId = User.GetUserId();
            await _service.CreateTicket(ticketVM);
            return RedirectToAction(nameof(Index));
        }
        #endregion



        #region Delete Ticket
        [HttpGet("DeleteTicket")]
        public async Task<IActionResult> DeleteTicket(int id)
        {
            var ticket = await _service.GetTicketById(id);
            if (ticket == null || ticket.UserId == User.GetUserId()) return NotFound();
            await _service.SoftDeleteTicket(id);
            return RedirectToAction(nameof(Index));
        }
        #endregion



        #region Reply To Ticket
        [HttpPost("ReplyToTicket")]
        public async Task<IActionResult> ReplyToTicket(int ticketId, string message, IFormFile attachment)
        {
            var ticket = await _service.GetTicketById(ticketId);
            if (ticket == null || ticket.Id != User.GetUserId()) return NotFound();
            var ticketMessage = new MessageVM
            {
                TicketId = ticketId,
                Text = message,
                IsAdminReply = false,
            };
            await _messageService.AddMessageToTicket(ticketMessage);
            return RedirectToAction(nameof(Details), new { id = ticketId });
        }
        #endregion
    }
}
