using E_Shop.Domain.Contracts.ProductCont;
using E_Shop.Domain.Models.ProductModels;
using Microsoft.EntityFrameworkCore;

namespace E_Shop.Infra.Data.Repositories.ProductRepo
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

        public IQueryable<Product> Filter()
        {
            return dbContext.Products.Include(p => p.Category);
        }

        public Product GetById(int Id)
        {
            return dbContext.Products.Find(Id);
        }

        public IQueryable<Product> GetByCategoryId(int Id)
        {
            return dbContext.Products.Where(p => p.CategoryId == Id)
                .Include(p => p.Category)
                .Include(p => p.Color)
                .ThenInclude(p => p.Color)
                .Include(p => p.ProductSpecification);
        }

        public IQueryable<Product> ArchiveFilter(int categoryId)
        {
            return dbContext.Products.Where(p => p.CategoryId == categoryId)
                .Include(p => p.Category)
                .Include(p => p.Color)
                .ThenInclude(p => p.Color)
                .Include(p => p.ProductSpecification); 
        }

        public Product GetByIdForDetails(int Id)
        {
            return dbContext.Products.Where(p => p.Id == Id)
                .Include(p => p.Color)
                .ThenInclude(p=> p.Color).FirstOrDefault();
        }
    }
}
