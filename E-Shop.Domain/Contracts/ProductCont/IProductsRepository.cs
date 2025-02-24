using E_Shop.Domain.Models.ProductModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Shop.Domain.Contracts.ProductCont
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
