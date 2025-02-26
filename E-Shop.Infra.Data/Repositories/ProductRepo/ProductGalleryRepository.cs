using E_Shop.Domain.Contracts.ProductCont;
using E_Shop.Domain.Models.ProductModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Shop.Infra.Data.Repositories.ProductRepo
{
    public class ProductGalleryRepository(ShopDbContext dbContext) : IProductGalleryRepository
    {
        public IEnumerable<ProductGallery> GetAllGalleries()
        {
            return dbContext.ProductGallery.ToList();
        }

        public List<ProductGallery> GetGalleryByProductId(int id)
        {
            return dbContext.ProductGallery.Where(p => p.ProductId == id && p.IsDelete == false).ToList();
        }

        public bool CreateGallery(ProductGallery productGallery)
        {
            dbContext.ProductGallery.Add(productGallery);
            dbContext.SaveChanges();
            return true;
        }

        public bool UpdateGallery(ProductGallery productGallery)
        {
            dbContext.ProductGallery.Update(productGallery);
            dbContext.SaveChanges();
            return true;
        }

        public bool DeleteGallery(int id)
        {
            var productGallery = dbContext.ProductGallery.Find(id);
            if (productGallery != null)
            {
                dbContext.ProductGallery.Remove(productGallery);
                dbContext.SaveChanges();
                return true;
            }
            return false;
        }

        public ProductGallery GetGalleryById(int id)
        {
           return dbContext.ProductGallery.Find(id);
        }

        public void SaveChange()
        {
            dbContext.SaveChanges();
        }
    }
}
