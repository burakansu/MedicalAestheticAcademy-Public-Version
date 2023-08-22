using System.ComponentModel.DataAnnotations;
using VeronaAkademi.Data.Entities.Base;

namespace VeronaAkademi.Data.Entities
{
    public class SkillGroup : BaseEntity
    {
        [Key]
        public int SkillGroupId { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Skill> Skills { get; set; }
    }
}
