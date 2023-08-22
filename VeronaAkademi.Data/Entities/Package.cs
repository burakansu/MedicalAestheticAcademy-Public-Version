using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using VeronaAkademi.Data.Entities.Base;

namespace VeronaAkademi.Data.Entities
{
    public class Package : BaseEntity
    {
        [Key]
        public int PackageId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public int CurrencyId { get; set; }
        public Currency Currency { get; set; }
        public virtual ICollection<PackageAdvisorRelation> PackageAdvisorRelation { get; set; }
        public virtual ICollection<PackageCourseRelation> PackageCourseRelation { get; set; }
        public virtual ICollection<PackagePracticeLessonRelation> PackagePracticeLessonRelation { get; set; }
    }
}
