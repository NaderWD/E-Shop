namespace E_Shop.Domain.Models.AddressModels
{
    public class Address : BaseModel
    {
        public string FullAddress { get; set; }            
        public int CityId { get; set; }
        public int StateId { get; set; }           
        public bool IsDefault { get; set; }
        public City? City { get; set; }
        public State? State { get; set; }
        public List<UserAddress>? UserAddresses { get; set; }
    }
}
