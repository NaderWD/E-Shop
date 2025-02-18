using E_Shop.Application.Services.Interfaces;
using E_Shop.Application.Tools;
using E_Shop.Application.ViewModels.TicketViewModels;
using Microsoft.AspNetCore.Mvc;

namespace E_Shop.Web.Areas.User.Controllers
{
    public class UserTicketController(ITicketService _service, ITicketMessageService _messageService) : UserBaseController
    {
        private static List<MessageVM> _messages = [];
        [HttpPost]
        public async Task<IActionResult> SendMessage(MessageVM message)
        {
            message.CreateDate = DateTime.Now;
            _messages.Add(message);
            return RedirectToAction("Index");
        }

        public IActionResult Index()
        {
            return View(_messages);
        }




        #region User Tickets
        [Route("UserTickets")]
        public async Task<IActionResult> UserTickets()
        {
            var userId = User.GetUserId();
            var model = await _service.GetTicketsByUserId(userId);
            return View(model);
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
            ticketVM.UserId = User.GetUserId();
            if (!ModelState.IsValid) return View(ticketVM);
            await _service.CreateTicket(ticketVM);
            return RedirectToAction("UserTickets", new { userId = ticketVM.UserId });
        }
        #endregion



        #region Create Message
        [HttpPost("CreateMessage")]
        public async Task<IActionResult> CreateMessage(int ticketId)
        {
            var message = new MessageVM { TicketId = ticketId };
            if (!ModelState.IsValid) return View(message);
            await _messageService.CreateMessage(message);
            await _messageService.UpdateMessage(message);
            var ticket = await _service.GetTicketById(ticketId);
            await _service.UpdateTicket(ticket);
            return RedirectToAction("TicketMessages", new { ticketId = message.TicketId });
        }
        #endregion



        #region Ticket Messages
        [HttpGet("TicketMessages")]
        public async Task<IActionResult> TicketMessages(int ticketId)
        {
            var model = await _messageService.GetMessagesByTicketId(ticketId);
            return View(model);
        }
        #endregion



        #region Number Of Messages
        [HttpGet("NumberOfMessages")]
        public async Task<IActionResult> NumberOfMessages(int ticketId)
        {
            var count = await _messageService.GetMessageCounts(ticketId);
            return RedirectToAction("UserTickets", new { ticketId, count });
        }
        #endregion



        #region Delete Ticket
        [HttpGet("DeleteTicket")]
        public async Task<IActionResult> DeleteTicket(int ticketId)
        {
            if (ticketId == 0) return BadRequest("Invalid ticket ID.");
            await _service.DeleteTicket(ticketId);
            return RedirectToAction("UserTickets", new { userId = User.GetUserId() });
        }
        #endregion
    }
}
