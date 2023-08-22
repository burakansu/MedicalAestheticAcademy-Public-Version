using System.ComponentModel.DataAnnotations;
using VeronaAkademi.Data.Entities.Base;

namespace VeronaAkademi.Data.Entities
{
    public class Lecturer:BaseEntity
    {
        [Key]
        public int LecturerId { get; set; }
        public string Image { get; set; }
        public string Name{ get; set; }
        public string Email { get; set; }
        public virtual ICollection<LecturerCourseRelation> LecturerCourseRelation { get; set; }

    }
}