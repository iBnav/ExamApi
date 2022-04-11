using ExamApi.Domain.Entities;
using Newtonsoft.Json;

namespace ExamApi.Domain.Models
{
    public class CardModel
    {
        [JsonProperty("card_id")]
        public int CardId { get; set; }
        [JsonProperty("card_number")]
        public long CardNumber { get; set; }
        [JsonProperty("cvv")]
        public int Cvv { get; set; }

        public CardModel()
        {

        }

        public CardModel(CardEntity entity)
        {
            CardId = entity.CardId;
            CardNumber = entity.CardNumber;
            Cvv = entity.Cvv;
        }
    }
}
