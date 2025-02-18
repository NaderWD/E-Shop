using E_Shop.Application.Services.Interfaces;
using E_Shop.Application.ViewModels.TicketViewModels;
using Microsoft.AspNetCore.Mvc;

namespace E_Shop.Web.Areas.Admin.Controllers
{
    public class AdminTicketController(ITicketService _service) : AdminBaseController
    {

        #region View All Tickets
        [Route("Admin/Tickets")]
        public async Task<IActionResult> Index()
        {
            var tickets = await _service.GetAllTickets();
            return View(tickets);
        }
        #endregion



        #region Update Ticket
        [HttpGet("Admin/Tickets/Edit/{id}")]
        public async Task<IActionResult> Edit(int id)
        {
            var ticket = await _service.GetTicketById(id);
            if (ticket == null) return NotFound();
            return View(ticket);
        }

        [HttpPost("Admin/Tickets/Edit/{id}")]
        public async Task<IActionResult> Edit(int id, TicketVM ticketVM)
        {
            if (id != ticketVM.Id) return BadRequest();
            if (!ModelState.IsValid) return View(ticketVM);
            await _service.UpdateTicket(ticketVM);
            return RedirectToAction("Index");
        }
        #endregion



        #region Delete Ticket
        [HttpGet("Admin/Tickets/Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var ticket = await _service.GetTicketById(id);
            if (ticket == null) return NotFound();
            return View(ticket);
        }

        [HttpPost("Admin/Tickets/Delete/{id}"), ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _service.DeleteTicket(id);
            return RedirectToAction("Index");
        }
        #endregion


    }
}
