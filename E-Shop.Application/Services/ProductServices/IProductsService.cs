using E_Shop.Application.ViewModels.ProductsViewModel;

namespace E_Shop.Application.Services.ProductServices
{
    public interface IProductsService
    {
        FilterProductViewModel Filter(FilterProductViewModel filter);
        ProductViewModel GetById(int Id);
        ProductArchiveViewModel GetByCategoryId(int Id);
        CreateProductViewModel GetProductCreateModel();
        UpdateProductViewModel GetProductUpdateModel(int Id);
        public List<SelectListitem> GetSelectItems();
        bool CreateProduct(CreateProductViewModel product);
        bool UpdateProduct(UpdateProductViewModel product);
        bool DeleteProduct(int Id);
        
    }
}
