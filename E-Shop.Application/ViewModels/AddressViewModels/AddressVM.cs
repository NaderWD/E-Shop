namespace E_Shop.Application.ViewModels.AddressViewModels
{
    public class AddressVM
    {
        public int AddressId { get; set; }
        public int CityId { get; set; }
        public string FullAddress { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? LastModifiedDate { get; set; }
    }

    public class CreateAddressVM
    {
        public int CityId { get; set; }
        public string FullAddress { get; set; }
    }

    public class AddressForShowVM
    {
        public int AddressId { get; set; }
        public string FullAddress { get; set; }
        public string CityName { get; set; }
        public string StateName { get; set; }
    }

    public class CityVM
    {
        public int CityId { get; set; }
        public string CityName { get; set; }
        public int StateId { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? LastModifiedDate { get; set; }
    }

    public class StateVM
    {
        public int StateId { get; set; }
        public string StateName { get; set; }
    }

}
