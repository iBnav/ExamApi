using ExamApi.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamApi.Domain.Entities
{
    [Table("Test.Card")]
    public class CardEntity
    {
        [Column("CardId")]
        public int CardId { get; set; }
        [Column("CardNumber")]
        public long CardNumber { get; set; }
        [Column("Cvv")]
        public int Cvv { get; set; }

        public CardEntity(CardModel model)
        {
            CardId = model.CardId;
            CardNumber = model.CardNumber;
            Cvv = model.Cvv;
        }

        public CardEntity()
        {

        }
    }
}
