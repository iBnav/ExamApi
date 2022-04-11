using ExamApi.Domain.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamApi.Domain.Models
{
    public class CustomerCardModel
    {
        [JsonProperty("costumer_id")]
        public int CustomerId { get; set; }
        [JsonProperty("card_id")]
        public long CardId { get; set; }

        public CustomerCardModel()
        {

        }

        public CustomerCardModel(CustomerCardEntity entity)
        {
            CustomerId = entity.CustomerId;
            CardId = entity.CardId;
        }
    }
}
