using System.ComponentModel.DataAnnotations;
using VeronaAkademi.Data.Entities.Base;

namespace VeronaAkademi.Data.Entities
{
    public class ProfessionCourseRelation : BaseEntity
    {
        [Key]
        public int ProfessionCourseRelationId { get; set; }
        public int ProfessionId { get; set; }
        public Profession Profession { get; set; }
        public int CourseId { get; set; }
        public Course Course { get; set; }
    }
}
