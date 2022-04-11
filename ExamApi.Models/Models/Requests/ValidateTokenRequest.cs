using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamApi.Domain.Models.Requests
{
    public class ValidateTokenRequest
    {
        [JsonProperty("customer_id")]
        public int CustomerId { get; set; }
        [JsonProperty("card_id")]
        public int CardId { get; set; }
        [JsonProperty("token")]
        public long Token { get; set; }
        [JsonProperty("cvv")]
        public int Cvv { get; set; }
    }
}
