using ExamApi.Domain.Models.CustomException;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamApi.Domain.Models.Responses
{
    public class SaveCardResponse
    {
        [JsonProperty("registration_date")]
        public DateTime RegistrationDate { get; set; }
        [JsonProperty("token")]
        public long Token { get; set; }
        [JsonProperty("card_id")]
        public int CardId { get; set; }
        [JsonProperty("error")]
        public AppException? Error { get; set; }
    }
}
