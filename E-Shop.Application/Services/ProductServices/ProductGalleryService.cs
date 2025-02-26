using E_Shop.Application.ViewModels.ProductsViewModel;
using E_Shop.Domain.Contracts.ProductCont;
using E_Shop.Domain.Models.ProductModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Shop.Application.Services.ProductServices
{
    public class ProductGalleryService(IProductGalleryRepository productGalleryRepository) : IProductGalleryService
    {
        public bool CreateGallery(AddProductGalleryViewModel productGallery)
        {
            var model = new ProductGallery();
            
            foreach (var item in productGallery.Images)
            {
                if (item != null && item.Length > 0)
                {

                    var fileName = Path.GetFileNameWithoutExtension(item.FileName);
                    var extension = Path.GetExtension(item.FileName);
                    var uniqueFileName = $"{fileName}_{DateTime.Now.ToString("yyyyMMddHHmmss")}{extension}";


                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/theme-assets/images/products", uniqueFileName);


                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        item.CopyTo(stream);
                    }
                    
                    model.ImageName = uniqueFileName;
                    model.ProductId = productGallery.ProductId;
                    model.CreateDate = DateTime.Now;
                    productGalleryRepository.CreateGallery(model);
                }
            }

            return true;


        }

        public bool DeleteGallery(int id)
        {
            var model = productGalleryRepository.GetGalleryByProductId(id);
            
            foreach (var item in model)
            {
                var oldFilePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/theme-assets/images/products", item.ImageName);
                if (System.IO.File.Exists(oldFilePath))
                {
                    System.IO.File.Delete(oldFilePath);
                }
                item.IsDelete = true;
                productGalleryRepository.UpdateGallery(item);
                productGalleryRepository.SaveChange();
            }
            
            return true;
        }

        public List<ProductGalleryViewModel> GetAllGalleries()
        {
            var Gallery = productGalleryRepository.GetAllGalleries();

            List<ProductGalleryViewModel> model = new List<ProductGalleryViewModel>();

            foreach (var item in Gallery)
            {
                model.Add(new ProductGalleryViewModel 
                {
                    ProductId = item.ProductId,
                    ImageName = item.ImageName,
                    Id = item.Id,
                    
                });
            }

            return model;
        }

        public ProductGalleryViewModel GetGalleryById(int Id)
        {
            var Gallery = productGalleryRepository.GetGalleryById(Id);

            ProductGalleryViewModel model = new ProductGalleryViewModel();
            model.Id = Gallery.Id;
            model.ProductId = Gallery.ProductId;
            model.ImageName = Gallery.ImageName;

            return model;
        }

        public List<ProductGalleryViewModel> GetGalleryByProductId(int productId)
        {
            var Gallery = productGalleryRepository.GetGalleryByProductId(productId);

            List<ProductGalleryViewModel> model = new List<ProductGalleryViewModel>();
            foreach (var item in Gallery)
            {
                model.Add(new ProductGalleryViewModel 
                {
                    Id = item.Id,
                    ProductId = item.ProductId,
                    ImageName = item.ImageName,
                });
            }
            return model;
        }

        public bool UpdateGallery(ProductGalleryViewModel productGallery)
        {
            var model = productGalleryRepository.GetGalleryById(productGallery.Id);
            model.ImageName = productGallery.ImageName;
            model.ProductId = productGallery.ProductId;
            
            productGalleryRepository.UpdateGallery(model);
            productGalleryRepository.SaveChange();
            return true;
        }
    }
}
