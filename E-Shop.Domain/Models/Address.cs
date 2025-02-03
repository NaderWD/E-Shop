using E_Shop.Domain.Models.Common;
using System.ComponentModel.DataAnnotations;

namespace E_Shop.Domain.Models
{
    public class Address : BaseModel
    {
        [MaxLength(500)]
        public string? Country { get; set; }

        [MaxLength(500)]
        public string? City { get; set; }

        [MaxLength(500)]
        [DataType(DataType.Text)]
        public string? PhysicalAddress { get; set; }

        [MaxLength(500)]
        [DataType(DataType.PostalCode)]
        public string? PostalCode { get; set; }
    }
}
