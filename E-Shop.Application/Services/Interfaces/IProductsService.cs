using E_Shop.Application.ViewModels;
using E_Shop.Application.ViewModels.ProductsViewModel;
using E_Shop.Domain.Models.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Shop.Application.Services.Interfaces
{
    public interface IProductsService
    {
        List<ProductViewModel>GetAll();
        ProductViewModel GetById(int Id);
        CreateProductViewModel GetProductCreateModel();
        UpdateProductViewModel GetProductUpdateModel(int Id);
        public List<SelectListitem> GetSelectItems();
        bool CreateProduct(CreateProductViewModel product);
        bool UpdateProduct(UpdateProductViewModel product);
        bool DeleteProduct(int Id);
    }
}
