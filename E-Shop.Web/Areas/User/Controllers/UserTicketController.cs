using E_Shop.Application.Services.Interfaces;
using E_Shop.Application.ViewModels.TicketViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace E_Shop.Web.Areas.User.Controllers
{
    public class UserTicketController(ITicketService _service) : UserBaseController
    {
        [Route("UserTickets")]
        public async Task<IActionResult> Index()
        {
            await _service.GetAllTickets();
            return View();
        }

        [HttpGet("CreateTicket")]
        public IActionResult CreateTicket()
        {
            return View();
        }

        [HttpPost("CreateTicket")]
        public async Task<IActionResult> CreateTicket(CreateTicketVM ticketVM)
        {
            await _service.CreateTicket(ticketVM);
            return View();
        }

        [HttpGet("TicketMessages")]
        public IActionResult TicketMessages()
        {
            return View();
        }

        [HttpPost("TicketMessages")]
        public IActionResult TicketMessages(int ticketId)
        {

            return View();
        }
    }
}
