namespace E_Shop.Domain.Models.AddressModels
{
    public class City : BaseModel
    {                                                            
        public string CityName { get; set; }       
        public int StateId { get; set; }              
        public State? State { get; set; }                      
        public List<Address>? Address { get; set; }
    }
}
