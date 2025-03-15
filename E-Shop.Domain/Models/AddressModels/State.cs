namespace E_Shop.Domain.Models.AddressModels
{
    public class State : BaseModel           
    {
        public string StateName { get; set; }       
        public List<City>? Cities { get; set; }                
        public List<Address>? Addresses { get; set; }
    }
}
