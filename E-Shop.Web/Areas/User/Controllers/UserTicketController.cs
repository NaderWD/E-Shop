using E_Shop.Application.Services.Interfaces;
using E_Shop.Application.ViewModels.TicketViewModels;
using Microsoft.AspNetCore.Mvc;

namespace E_Shop.Web.Areas.User.Controllers
{
    public class UserTicketController(ITicketService _service) : UserBaseController
    {
        #region User Tickets
        [Route("UserTickets")]
        public async Task<IActionResult> UserTickets(int ticketId, int userId)
        {
            await _service.GetTicketsByUserId(userId);
            return View();
        }
        #endregion



        #region Create Ticket
        [HttpGet("CreateTicket")]
        public IActionResult CreateTicket()
        {
            return View();
        }

        [HttpPost("CreateTicket")]
        public async Task<IActionResult> CreateTicket(TicketVM ticketVM)
        {
            await _service.CreateTicket(ticketVM);
            return RedirectToAction("UserTickets", new { ticketVM.Id, ticketVM.UserId });
        }
        #endregion



        #region Create Message
        [HttpGet("CreateMessage")]
        public IActionResult CreateMessage()
        {
            return View();
        }

        [HttpPost("CreateMessage")]
        public async Task<IActionResult> CreateMessage(MessageVM message)
        {
            await _service.CreateMessage(message);
            return RedirectToAction("UpdateTicket", new { message.Id, message.TicketId });
        }
        #endregion



        #region Update Ticket
        [HttpGet("UpdateTicket")]
        public async Task<IActionResult> UpdateTicket(int ticketId)
        {
            return View(new TicketVM { Id = ticketId });
        }

        [HttpPost("UpdateTicket")]
        public async Task<IActionResult> UpdateTicket(TicketVM ticket)
        {
            await _service.UpdateTicket(ticket);
            return RedirectToAction("UserTickets", new { ticket.Id, ticket.UserId });
        }
        #endregion



        #region Ticket Messages
        [HttpGet("TicketMessages")]
        public IActionResult TicketMessages(int ticketId)
        {
            return View(new TicketVM { Id = ticketId });
        }
        #endregion



        #region Number Of Messages
        [HttpGet("NumberOfMessages")]
        public async Task<IActionResult> NumberOfMessages(int ticketId)
        {
            var count = await _service.GetMessageCounts(ticketId);
            return RedirectToAction("UserTickets", new { ticketId, count });
        }
        #endregion



        #region Delete Ticket
        [HttpGet("DeleteTicket")]
        public async Task<IActionResult> DeleteTicket(int ticketId, int userId)
        {
            await _service.DeleteTicket(ticketId);
            return RedirectToAction("UserTickets", new { userId });
        }
        #endregion
    }
}
