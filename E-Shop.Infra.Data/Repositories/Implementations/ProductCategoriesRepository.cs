using E_Shop.Domain.Models;
using E_Shop.Domain.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Shop.Infra.Data.Repositories.Implementations
{
    public class ProductCategoriesRepository(ShopDbContext dbContext) : IProductCategoriesRepository
    {
        public bool CreateProductCategory(ProductCategories model)
        {
            dbContext.ProductCategories.Add(model);
            dbContext.SaveChanges();
            return true;
        }

        public List<ProductCategories> GetAll()
        {
           return dbContext.ProductCategories.Include(c => c.Parent).Where(c => c.IsDelete == false).ToList();
        }
    }
}
