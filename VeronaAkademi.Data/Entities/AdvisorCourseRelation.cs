using System.ComponentModel.DataAnnotations;
using VeronaAkademi.Data.Entities.Base;

namespace VeronaAkademi.Data.Entities
{
    public class AdvisorCourseRelation : BaseEntity
    {
        [Key]
        public int AdvisorCourseRelationId { get; set; }
        public int CourseId { get; set; }
        public Course Course { get; set; }
        public int AdvisorId { get; set; }
        public Advisor Advisor { get; set; }
    }
}
