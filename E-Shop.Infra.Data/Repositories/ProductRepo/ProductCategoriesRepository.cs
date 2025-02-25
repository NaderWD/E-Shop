using E_Shop.Domain.Contracts.ProductCont;
using E_Shop.Domain.Models.ProductModels;
using Microsoft.EntityFrameworkCore;

namespace E_Shop.Infra.Data.Repositories.ProductRepo
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



        public async Task<bool> Exist(int categoryId)
            => await dbContext.ProductCategories.AnyAsync(x => x.Id == categoryId);

        public async Task<List<ProductCategories>> GetAllSubCategories()
            => await dbContext.ProductCategories.Where(x => x.ParentId != null)
                                                .Include(x => x.Parent)
                                                .OrderBy(x => x.Name)
                                                .ToListAsync();
    }
}
