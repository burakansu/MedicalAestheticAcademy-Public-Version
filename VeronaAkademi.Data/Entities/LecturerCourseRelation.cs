using System.ComponentModel.DataAnnotations;
using VeronaAkademi.Data.Entities.Base;

namespace VeronaAkademi.Data.Entities
{
    public class LecturerCourseRelation : BaseEntity
    {
        [Key]
        public int LecturerCourseRelationId { get; set; }
        public int CourseId { get; set; }
        public Course Course { get; set; }
        public int LecturerId { get; set; }
        public Lecturer Lecturer { get; set; }
    }
}
