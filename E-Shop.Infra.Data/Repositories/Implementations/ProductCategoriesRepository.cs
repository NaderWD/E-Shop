using E_Shop.Domain.Models;
using E_Shop.Domain.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Shop.Infra.Data.Repositories.Implementations
{
    public class ProductCategoriesRepository(ShopDbContext dbContext) : IProductCategoriesRepository
    {
        public List<ProductCategories> GetAll()
        {
           return dbContext.ProductCategories.ToList();
        }
    }
}
