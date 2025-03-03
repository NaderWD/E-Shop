using E_Shop.Domain.Models.ProductModels;

namespace E_Shop.Domain.Contracts.ProductCont
{
    public interface IProductsRepository
    {
        IQueryable<Product> Filter();
        IQueryable<Product> ArchiveFilter(int categoryId);
        Product GetById(int Id);
        Product GetByIdForDetails(int Id);
        IQueryable<Product> GetByCategoryId(int Id);
        bool CreateProduct(Product product);
        bool UpdateProduct(Product product);
        bool DeleteProduct(int Id);
        public void Save();
    }
}
