using E_Shop.Application.Services.Interfaces;
using E_Shop.Application.ViewModels.TicketViewModels;
using Microsoft.AspNetCore.Mvc;

namespace E_Shop.Web.Areas.Admin.Controllers
{
    public class AdminTicketController(ITicketService _service) : AdminBaseController
    {

        #region View All Tickets
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var tickets = await _service.GetAllTickets();
            return View(tickets);
        }
        #endregion



        #region Details
        [HttpGet("Details/{id}")]
        public async Task<IActionResult> Details(int id)
        {
            var ticket = await _service.GetTicketById(id);
            if (ticket == null) return NotFound();
            return View(ticket);
        }
        #endregion



        #region Create Ticket
        [HttpGet("Create")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create(TicketVM ticketVM)
        {
            if (!ModelState.IsValid) return View(ticketVM);
            await _service.CreateTicket(ticketVM);
            return RedirectToAction(nameof(Index));
        }
        #endregion



        #region Update Ticket
        [HttpGet("Edit/{id}")]
        public async Task<IActionResult> Edit(int id)
        {
            var ticket = await _service.GetTicketById(id);
            if (ticket == null) return NotFound();
            return View(ticket);
        }

        [HttpPost("Edit/{id}")]
        public async Task<IActionResult> Edit(int id, TicketVM ticketVM)
        {
            if (id != ticketVM.Id) return BadRequest();
            if (!ModelState.IsValid) return View(ticketVM);
            await _service.UpdateTicket(ticketVM);
            return RedirectToAction(nameof(Index));
        }
        #endregion



        #region Delete Ticket
        [HttpGet("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var ticket = await _service.GetTicketById(id);
            if (ticket == null) return NotFound();
            return View(ticket);
        }

        [HttpPost("Delete/{id}"), ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _service.DeleteTicket(id);
            return RedirectToAction("Index");
        }
        #endregion


    }
}
