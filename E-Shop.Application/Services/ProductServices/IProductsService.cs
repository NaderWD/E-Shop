using E_Shop.Application.ViewModels.ProductsViewModel;
using E_Shop.Domain.Models.ProductModels;

namespace E_Shop.Application.Services.ProductServices
{
    public interface IProductsService
    {
        FilterProductViewModel Filter(FilterProductViewModel filter);
        ProductArchiveViewModel ArchiveFilter(ProductArchiveViewModel filter);
        ProductViewModel GetById(int Id);
        ProductViewModel GetByIdForDetails(int Id, int colorId);

        List<ProductViewModel> GetByCategoryId(int Id);

        CreateProductViewModel GetProductCreateModel();
        UpdateProductViewModel GetProductUpdateModel(int Id);
        public List<SelectListitem> GetSelectItems();
        bool CreateProduct(CreateProductViewModel product);
        bool UpdateProduct(UpdateProductViewModel product);
        bool DeleteProduct(int Id);
        
    }
}
