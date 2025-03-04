using E_Shop.Application.ViewModels.ColorViewModels;
using E_Shop.Domain.Contracts.ColorCont;
using E_Shop.Domain.Models.ColorModels;

namespace E_Shop.Application.Services.ProductServices
{
    public class ProductColorService(IProductColorRepository productColor) : IProductColorService
    {
        public bool AddMapping(AddColorToProductViewModel model)
        {
            var colors = productColor.GetDefaultColorForProduct(model.ProductId).Where(c => c.IsDelete == false);
            if (colors.Any())
            {
                if (model.IsDefault == true)
                {
                    foreach (var item in colors)
                    {
                        item.IsDefault = false;
                        productColor.Update(item);
                    }
                }
            }

            else
            {
                model.IsDefault = true;
            }

            ProductColorMapping mapping = new()
            {
                ProductId = model.ProductId,
                ColorId = model.ColorId,
                Price = model.Price,
                IsDefault = model.IsDefault
            };

            var result = productColor.AddMapping(mapping);
            return result;
        }

        public List<AddColorToProductViewModel> GetAllColorForProduct(int productId)
        {
            var colorList = productColor.GetAllColorForProduct(productId).Where(c => c.IsDelete == false);

            var model = new List<AddColorToProductViewModel>();

            foreach (var color in colorList)
            {
                model.Add(new AddColorToProductViewModel
                {
                    Id = color.Id,
                    Name = color.Color.Name,
                    ColorId = color.Color.Id,
                    Code = color.Color.Code,
                    Price = color.Price,
                    IsDefault = color.IsDefault,
                    ProductId = color.ProductId,
                });
            }
            return model;

        }

        public bool RemoveColor(int Id)
        {
            var mapping = productColor.GetById(Id);
            mapping.IsDelete = true;
            productColor.Update(mapping);

            return mapping.IsDelete;

        }
    }
}
