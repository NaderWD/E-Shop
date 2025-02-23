using E_Shop.Domain.Contracts.Products;
using E_Shop.Domain.Models.Products;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
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

        public ProductCategories GetProductCategoryById(int Id)
        {
            return dbContext.ProductCategories.Where(c => c.Id == Id).Include(c => c.Parent).FirstOrDefault();
        }

        public bool Save()
        {
            dbContext.SaveChanges();
            return true;
        }

        public bool UpdateProductCategory(ProductCategories model)
        {
            dbContext.ProductCategories.Update(model);
            
            return true;
        }
    }
}
