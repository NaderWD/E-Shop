using E_Shop.Domain.Models.Products;
using E_Shop.Domain.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Shop.Infra.Data.Repositories.Implementations
{
    public class ProductsRepository(ShopDbContext dbContext) : IProductsRepository
    {
        #region Product CRUD
        public bool CreateProduct(Product product)
        {
            dbContext.Products.Add(product);
            Save();
            return true;
        }

        public bool DeleteProduct(int Id)
        {
           throw new NotImplementedException();
        }

        public bool UpdateProduct(Product product)
        {
            dbContext.Products.Update(product);
            Save();
            return true;
        }
        #endregion Product CRUD

        public void Save() 
        {
            dbContext.SaveChanges();
        }
       
        public List<Product> GetAll()
        {
            return dbContext.Products.Include(p => p.Category).ToList();
        }

        public Product GetById(int Id)
        {
            return dbContext.Products.Find(Id);
        }
    }
}
