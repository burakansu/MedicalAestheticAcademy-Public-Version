using System.ComponentModel.DataAnnotations;
using VeronaAkademi.Data.Entities.Base;

namespace VeronaAkademi.Data.Entities
{
    public class Advisor : BaseEntity
    {
        [Key]
        public int AdvisorId { get; set; }
        public string Name { get; set; }
        public int Type { get; set; }
        public int Price { get; set; }
        public int CurrencyId { get; set; }
        public Currency Currency { get; set; }
        public int LecturerId { get; set; }
        public Lecturer Lecturer { get; set; }

        public virtual ICollection<AdvisorCourseRelation> AdvisorCourseRelation { get; set; }
        public virtual ICollection<PackageAdvisorRelation> PackageAdvisorRelation { get; set; }
        public virtual ICollection<CustomerAdvisorRelation> CustomerAdvisorRelation { get; set; }
    }
}
