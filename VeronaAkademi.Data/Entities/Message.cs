using System.ComponentModel.DataAnnotations;
using VeronaAkademi.Data.Entities.Base;

namespace VeronaAkademi.Data.Entities
{
    public class Message : BaseEntity
    {
        [Key]
        public int MessageId { get; set; }
        public string Contents { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public int AdvisorId { get; set; }
        public Advisor Advisor { get; set; }
        public int Type { get; set; }
    }
}
