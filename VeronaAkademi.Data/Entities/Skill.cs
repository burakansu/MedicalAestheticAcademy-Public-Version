using System.ComponentModel.DataAnnotations;
using VeronaAkademi.Data.Entities.Base;

namespace VeronaAkademi.Data.Entities
{
    public class Skill : BaseEntity
    {
        [Key]
        public int SkillId { get; set; }
        public string Name { get; set; }
        public int SkillGroupId { get; set; }
        public SkillGroup SkillGroup { get; set; }
        public virtual ICollection<SkillCourseRelation> SkillCourseRelation { get; set; }
    }
}
