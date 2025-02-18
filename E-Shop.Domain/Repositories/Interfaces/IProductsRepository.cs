using E_Shop.Domain.Models.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Shop.Domain.Repositories.Interfaces
{
    public interface IProductsRepository
    {
        List<Product> GetAll();
        Product GetById(int Id);
        bool CreateProduct(Product product);
        bool UpdateProduct(Product product);
        bool DeleteProduct(int Id);
        public void Save();

    }
}
