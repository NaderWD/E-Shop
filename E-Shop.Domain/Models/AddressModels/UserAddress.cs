using E_Shop.Domain.Models.UserModels;

namespace E_Shop.Domain.Models.AddressModels
{
    public class UserAddress :BaseModel
    {
        public int UserId { get; set; }
        public int AddressId { get; set; }
                                                                 
        public User? User { get; set; }
        public Address? Address { get; set; }
    }
}
