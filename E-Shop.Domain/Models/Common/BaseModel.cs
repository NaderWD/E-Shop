using System.ComponentModel.DataAnnotations;

namespace E_Shop.Domain.Models.Common
{
    public class BaseModel
    {
        [Key]
        public int Id { get; set; }

        public DateTime LastModifiedDate { get; set; }

        public bool IsDelete { get; set; }
    }
}
