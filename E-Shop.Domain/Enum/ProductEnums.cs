using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Shop.Domain.Enum
{
    public enum ProductEnums
    {
        [Display(Name ="")]
        All,

        [Display(Name = "")]
        MostExpensive,

        [Display(Name = "")]
        MostRecent,
    }
    public enum SortOrder 
    {

    }
}
