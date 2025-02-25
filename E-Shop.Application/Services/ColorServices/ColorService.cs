using E_Shop.Application.ViewModels.ColorViewModels;
using E_Shop.Domain.Contracts.ColorCont;
using E_Shop.Domain.Models.ColorModels;

namespace E_Shop.Application.Services.ColorServices
{
    public class ColorService(IColorRepository colorRepository) : IColorService
    {
        public bool Create(ColorViewModel color)
        {
            ColorModel model = new()
            {
                CreateDate = DateTime.Now,
                Code = color.Code,
                Name = color.Name
            };


            return colorRepository.Create(model);
        }

        public bool Delete(int Id)
        {
            var color = colorRepository.GetById(Id);
            color.IsDelete = true;
            return colorRepository.Update(color);
        }

        public List<ColorViewModel> GetAll()
        {
            var colors = colorRepository.GetAll();

            List<ColorViewModel> model = [];

            foreach (var color in colors)
            {
                model.Add(new ColorViewModel 
                {
                    Id = color.Id,
                    Name = color.Name,
                    Code = color.Code
                });
            }
            return model;
        }

      

        public ColorViewModel GetById(int Id)
        {
            var color = colorRepository.GetById(Id);
            ColorViewModel model = new()
            {
                Id = color.Id,
                Name = color.Name,
                Code = color.Code
            };

            return model;
        }

        public bool Update(ColorViewModel color)
        {
            var model = colorRepository.GetById(color.Id);
            
            model.Id = color.Id;
            model.Name = color.Name;
            model.Code = color.Code;

           
            return  colorRepository.Update(model);
        }
    }
}
