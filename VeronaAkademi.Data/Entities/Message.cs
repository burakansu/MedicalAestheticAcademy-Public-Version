using System.ComponentModel.DataAnnotations;
using VeronaAkademi.Data.Entities.Base;

namespace VeronaAkademi.Data.Entities
{
    public class Message : BaseEntity
    {
        [Key]
        public int MessageId { get; set; }

        // Message Body
        public string Contents { get; set; }

        // 1: Advisor
        // 2: Student
        public int Type { get; set; }

        // Relations
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public int AdvisorId { get; set; }
        public Advisor Advisor { get; set; }
    }
}
