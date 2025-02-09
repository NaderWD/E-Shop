using E_Shop.Domain.Models.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Shop.Domain.Models
{
    public class ContactUsMessage : BaseModel
    {
        
        public string Title { get; set; }
        
        public string FullName { get; set; }
        
        public string Email { get; set; }
       
        public string Mobile { get; set; }
        
        public string Message { get; set; }

    }
}
