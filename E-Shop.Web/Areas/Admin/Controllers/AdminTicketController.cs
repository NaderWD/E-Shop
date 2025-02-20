using E_Shop.Application.Services.Interfaces;
using E_Shop.Application.Tools;
using E_Shop.Application.ViewModels.TicketViewModels;
using E_Shop.Application.ViewModels.UserViewModels;
using Microsoft.AspNetCore.Mvc;
using static E_Shop.Domain.Enum.TicketsEnums;

namespace E_Shop.Web.Areas.Admin.Controllers
{
    public class AdminTicketController(ITicketService _ticketService, ITicketMessageService _messageService, IUserService _userService) : AdminBaseController
    {

        #region View All Tickets
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var tickets = await _ticketService.GetAllTickets();
            return View(tickets);
        }
        #endregion



        #region Create New Ticket
        [HttpGet]
        public async Task<IActionResult> CreateNewTicket()
        {
            IEnumerable<UserViewModel> users = await _userService.GetAllUsers();
            return View(users);
        }
        #endregion



        #region Send Ticket To User
        [HttpGet]
        public async Task<IActionResult> SendMessage(int userId)
        {
            var adminId = User.GetUserId();
            var user = await _userService.GetUserById(userId);
            ViewBag.Name = user.FirstName + " " + user.LastName;
            return View(new TicketVM { OwnerId = userId, SenderId = adminId });
        }

        [HttpPost]
        public async Task<IActionResult> SendMessage(TicketVM ticketVM, IFormFile? attachment)
        {
            if (!ModelState.IsValid) return View(ticketVM);
            await _ticketService.CreateTicket(ticketVM, attachment, User.GetUserId());
            return View();
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



        #region Update Ticket
        [HttpGet]
        public async Task<IActionResult> EditTicket(int ticketId, int userId)
        {
            var user = await _userService.GetUserById(userId);
            ViewBag.Name = user.FirstName + " " + user.LastName;
            var ticket = await _ticketService.GetTicketById(ticketId);
            if (ticket == null) return NotFound();
            return View(ticket);
        }

        [HttpPost]
        public async Task<IActionResult> EditTicket(TicketVM ticketVM)
        {
            if (!ModelState.IsValid) return View(ticketVM);
            await _ticketService.UpdateTicket(ticketVM);
            return RedirectToAction(nameof(Index));
        }
        #endregion



        #region Delete Ticket
        [HttpGet]
        public async Task<IActionResult> Delete(int ticketId)
        {
            var ticket = await _ticketService.GetTicketById(ticketId);
            if (ticket == null) return NotFound();
            return View(ticket);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int ticketId)
        {
            await _ticketService.DeleteTicket(ticketId);
            return RedirectToAction("Index");
        }
        #endregion

    }
}
