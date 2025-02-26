using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Shop.Application.ViewModels.Common
{
    public class Paging<T>()
    {
        public int Take { get; set; }
        public int Count { get; set; }
        public int Page { get; set; }
        public int Skip { get; set; }
        public List<T> Entities { get; set; }


        public void ToPaged(IQueryable<T> queryable) 
        {
            Skip = (Page -1)* Take;
            var allEntitiesCount = queryable.Count();
            Count = Convert.ToInt32(Math.Ceiling((double)allEntitiesCount / Take));
            Entities = queryable.Skip(Skip).Take(Take).ToList();
        }
    }
}
