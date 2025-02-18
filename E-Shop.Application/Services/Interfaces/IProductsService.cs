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
        bool CreateProduct(Product product);
        bool UpdateProduct(Product product);
        bool DeleteProduct(int Id);
    }
}
