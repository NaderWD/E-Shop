using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Shop.Application.ViewModels.ProductsViewModel
{
    public class ProductGalleryViewModel
    {
        public int Id { get; set; }
        public string ImageName { get; set; }
        public int ProductId { get; set; }

    }
    public class AddProductGalleryViewModel
    {
        public List<IFormFile> Images { get; set; }
        public string ImageName { get; set; }
        public int ProductId { get; set; }

    }
}
