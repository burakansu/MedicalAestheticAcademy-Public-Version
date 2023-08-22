using System.ComponentModel.DataAnnotations;
using VeronaAkademi.Data.Entities.Base;

namespace VeronaAkademi.Data.Entities
{
    public class SkillCourseRelation : BaseEntity
    {
        [Key]
        public int SkillCourseRelationId { get; set; }
        public int SkillId { get; set; }
        public Skill Skill { get; set; }
        public int CourseId { get; set; }
        public Course Course { get; set; }
    }
}
