using E_Shop.Application.Services.Interfaces;
using E_Shop.Application.ViewModels.TicketViewModels;
using Microsoft.AspNetCore.Mvc;

namespace E_Shop.Web.Areas.Admin.Components
{
    public class ChatContactsViewComponent(ITicketService _service) : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(TicketVM ticketVM)
        {
            //var user = await 
            //var model = await _service.GetAllTickets();
            //return View("ChatContacts", model);
            return View();
        }
    }
}
