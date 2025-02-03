using System.ComponentModel.DataAnnotations;

namespace E_Shop.Domain.Models.Common
{
    public abstract class BaseModel
    {
        [Key]
        public int Id { get; set; }

        public DateTime LastModifiedDate { get; set; }
    }
}
