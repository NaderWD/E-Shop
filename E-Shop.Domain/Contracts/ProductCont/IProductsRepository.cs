using E_Shop.Domain.Models.ProductModels;

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


        Task<Product> GetProductById(int productId);
        Task<bool> IsCategoryExist(int categoryId);
    }
}
