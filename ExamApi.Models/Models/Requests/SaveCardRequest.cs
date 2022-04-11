using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamApi.Domain.Models.Requests
{
    public class SaveCardRequest
    {
        [JsonProperty("customer_id")]
        public int CustomerId { get; set; }
        [JsonProperty("card_number")]
        public long CardNumber { get; set; }
        [JsonProperty("cvv")]
        public int Cvv { get; set; }
    }
}
