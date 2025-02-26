using E_Shop.Application.ViewModels.ProductsViewModel;
using E_Shop.Domain.Models.ProductModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Shop.Application.Services.ProductServices
{
    public interface IProductGalleryService
    {
        List<ProductGalleryViewModel> GetAllGalleries();
        List<ProductGalleryViewModel> GetGalleryByProductId(int productId);
        ProductGalleryViewModel GetGalleryById(int Id);
        bool CreateGallery(AddProductGalleryViewModel productGallery);
        bool UpdateGallery(ProductGalleryViewModel productGallery);
        bool DeleteGallery(int id);
    }
}
