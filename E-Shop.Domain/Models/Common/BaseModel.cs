using System.ComponentModel.DataAnnotations;

namespace E_Shop.Domain.Models.Common
{
    public abstract class BaseModel
    {
        [Key]
        [Required]
        public int Id { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime LastModifiedDate { get; set; }
    }
}
