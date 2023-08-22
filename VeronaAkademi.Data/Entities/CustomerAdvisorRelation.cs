using System.ComponentModel.DataAnnotations;

namespace VeronaAkademi.Data.Entities
{
    public class CustomerAdvisorRelation 
    {
        [Key]
        public int CustomerAdvisorRelationId { get; set; }
        public int AdvisorId { get; set; }
        public Advisor Advisor { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
    }
}
