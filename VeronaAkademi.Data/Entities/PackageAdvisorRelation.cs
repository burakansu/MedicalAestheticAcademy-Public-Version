using System.ComponentModel.DataAnnotations;
using VeronaAkademi.Data.Entities.Base;

namespace VeronaAkademi.Data.Entities
{
    public class PackageAdvisorRelation : BaseEntity
    {
        [Key]
        public int PackageAdvisorRelationId { get; set; }
        public int AdvisorId { get; set; }
        public Advisor Advisor { get; set; }
        public int PackageId { get; set; }
        public Package Package { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime FinishDate { get; set; }
    }
}
