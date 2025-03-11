using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Shop.Application.DTOs.Novino
{
    public class NovinoGetPaymentUrlResponseDto
    {
        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("data")]
        public NovinoGetPaymentUrlRequestData Data { get; set; }

        [JsonProperty("errors")]
        public object Errors { get; set; }

    }
    public class NovinoGetPaymentUrlRequestData 
    {
        [JsonProperty("wage")]
        public string Wage { get; set; }

        [JsonProperty("wage_payer")]
        public string Wage_Payer { get; set; }

        [JsonProperty("Authority")]
        public string Authority { get; set; }

        [JsonProperty("trans_id")]
        public string Trans_Id { get; set; }

        [JsonProperty("payment_url")]
        public string Payment_Url { get; set; }
        
    }
}
