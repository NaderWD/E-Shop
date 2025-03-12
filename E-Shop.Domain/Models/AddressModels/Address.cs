namespace E_Shop.Domain.Models.AddressModels
{
    public class Address
    {
        public int HouseNumber { get; set; }         
        public string StreetName { get; set; }            
        public string? NeighborHood { get; set; }
        public City? City { get; set; }
        public State? State { get; set; }
    }
}
