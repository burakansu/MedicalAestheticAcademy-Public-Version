using System.ComponentModel.DataAnnotations;
using VeronaAkademi.Data.Entities.Base;

namespace VeronaAkademi.Data.Entities
{
    public class PackageCourseRelation : BaseEntity
    {
        [Key]
        public int PackageCourseRelationId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime FinishDate { get; set; }
        public int CourseId { get; set; }
        public Course Course { get; set; }
        public int PackageId { get; set; }
        public Package Package { get; set; }
    }
}
