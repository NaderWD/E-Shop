namespace E_Shop.Application.ViewModels.AddressViewModels
{
    public class AddressVM
    {
        public int AddressId { get; set; }
        public int CityId { get; set; }
        public int StateId { get; set; }
        public string FullAddress { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public CityVM? City { get; set; }
        public StateVM? State { get; set; }
        public List<UserAddressVM>? UserAddresses { get; set; }
    }

    public class CityVM
    {
        public int CityId { get; set; }
        public string CityName { get; set; }             
        public int StateId { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public StateVM? State { get; set; }
        public List<AddressVM>? Addresses { get; set; }
    }

    public class StateVM
    {
        public int StateId { get; set; }
        public string StateName { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public List<CityVM>? Cities { get; set; }
    }

    public class UserAddressVM
    {
        public int UserAddressId { get; set; }
        public int UserId { get; set; }
        public int AddressId { get; set; }
        public AddressVM? Address { get; set; }
    }
}
