using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamApi.Domain.Entities
{
    [Table("Test.CustomerCard")]
    public class CustomerCardEntity
    {
        [Column("CustomerId")]
        public int CustomerId { get; set; }
        [Column("CardId")]
        public long CardId { get; set; }
    }
}
