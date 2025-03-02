using E_Shop.Application.ViewModels.ColorViewModels;

namespace E_Shop.Application.Services.ProductServices
{
    public interface IProductColorService
    {
        public List<AddColorToProductViewModel> GetAllColorForProduct(int productId);
        bool AddMapping(AddColorToProductViewModel model);
        bool RemoveColor(int Id);
        
    }
}
