namespace E_Shop.Domain.Models.ProductModels
{
    public class ProductRating : BaseModel
    {
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public double OverallRating { get; set; }
        public double BuildQuality { get; set; }
        public double ValueForMoney { get; set; }
        public double Innovation { get; set; }
        public double Features { get; set; }
        public double EaseOfUse { get; set; }
        public double Design { get; set; }
    }
}
