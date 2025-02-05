namespace E_Shop.Domain.ServicesModels
{
    public class Email
    {
        public string? To { get; set; }
        public string? Subject { get; set; }
        public string? Body { get; set; }
        public string? ActivationCode { get; set; }
    }
}
