using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace E_Shop.Domain.DTOs.Novino
{
    public class NovinoGetPaymentUrlRequestDto
    {
        [JsonProperty("merchant_id")]
        public string MerchantId { get; set; }

        [JsonProperty("amount")]
        public int Amount { get; set; }

        [JsonProperty("callback_url")]
        public string CallBack_Url { get; set; }

        [JsonProperty("callback_method")]
        public string CallBack_Method { get; set; }

        [JsonProperty("invoice_id")]
        public string Invoice_Id { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("mobile")]
        public string Mobile { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("card_pan")]
        public string Card_pan { get; set; }

    }
}
