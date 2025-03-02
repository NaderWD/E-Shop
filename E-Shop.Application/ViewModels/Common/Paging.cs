using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Shop.Application.ViewModels.Common
{
    public class Paging<T>()
    {
        public int Take { get; set; } = 1;
        public int Count { get; set; }
        public int Page { get; set; } = 1;
        public int Skip { get; set; }
        public int StartPage { get; set; }
        public int EndPage { get; set; }
        public int HowManyShowPageBeforeAndAfter { get; set; } = 3;

        public List<T> Entities { get; set; }

        public PagingViewModel GetCurrentPaging() 
        {
            return new PagingViewModel
            {
                EndPage = this.EndPage,
                Page = this.Page,
                StartPage = this.StartPage,
            };
        }

        public void ToPaged(IQueryable<T> queryable) 
        {
            Skip = (Page -1)* Take;
            var allEntitiesCount = queryable.Count();
            Count = Convert.ToInt32(Math.Ceiling((double)allEntitiesCount / Take));
            Entities = queryable.Skip(Skip).Take(Take).ToList();
            StartPage = Page - HowManyShowPageBeforeAndAfter <= 0 ? 1 : Page - HowManyShowPageBeforeAndAfter;
            EndPage = Page + HowManyShowPageBeforeAndAfter > Count ? Count : Page + HowManyShowPageBeforeAndAfter;
        }

        public class PagingViewModel 
        {
            public int Page { get; set; }
            public int StartPage { get; set; }
            public int EndPage { get; set; }
        }
    }
}
