using E_Shop.Application.ViewModels.TicketViewModels;
using Microsoft.AspNetCore.Mvc;


namespace E_Shop.Web.Areas.User.Components
{

    public class ChatBoxViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(IEnumerable<MessageVM> messages)
        {
            return View(messages);
        }
    }

}
