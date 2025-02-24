using E_Shop.Application.Services.Interfaces;
using E_Shop.Application.ViewModels.Color;
using E_Shop.Domain.Models;
using E_Shop.Domain.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;

namespace E_Shop.Application.Services.Implementations
{
    public class ColorService(IColorRepository colorRepository) : IColorService
    {
        public bool Create(ColorViewModel color)
        {
            ColorModel model = new ColorModel();

            model.CreateDate= DateTime.Now;
            model.Code = color.Code;
            model.Name = color.Name;    
            
            
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

            List<ColorViewModel> model = new List<ColorViewModel>();

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
            ColorViewModel  model = new ColorViewModel();
            model.Id = color.Id;
            model.Name = color.Name;
            model.Code = color.Code;

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
