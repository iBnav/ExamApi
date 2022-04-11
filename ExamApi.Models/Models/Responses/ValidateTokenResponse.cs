using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamApi.Domain.Models.Responses
{
    public class ValidateTokenResponse
    {
        [JsonProperty("validated")]
        public bool Validated { get; set; }
    }
}
