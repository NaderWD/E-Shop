using E_Shop.Domain.Models.ProductModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Shop.Domain.Contracts.ProductCont
{
    public interface IProductGalleryRepository
    {

        IEnumerable<ProductGallery> GetAllGalleries();
        List<ProductGallery> GetGalleryByProductId(int productid);
        ProductGallery GetGalleryById(int id);
        bool CreateGallery(ProductGallery productGallery);
        bool UpdateGallery(ProductGallery productGallery);
        bool DeleteGallery(int id);
        void SaveChange();

    }
}
