using E_Shop.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace E_Shop.Web.Areas.Admin.Controllers
{
    public class AdminTicketController(ITicketService _service) : AdminBaseController
    {
        #region Get All
        [HttpGet]
        [Route("AdminTickets")]
        public async Task<IActionResult> AllTickets()
        {
            await _service.GetAllTickets();
            return View();
        }
        #endregion




    }
}
