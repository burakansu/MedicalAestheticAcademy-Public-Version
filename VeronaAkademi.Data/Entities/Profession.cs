using System.ComponentModel.DataAnnotations;
using VeronaAkademi.Data.Entities.Base;

namespace VeronaAkademi.Data.Entities
{
    public class Profession : BaseEntity
    {
        [Key]
        public int ProfessionId { get; set; }
        public string Image { get; set; }
        public string Name{ get; set; }
        public virtual ICollection<ProfessionCourseRelation> ProfessionCourseRelation { get; set; }
    }
}