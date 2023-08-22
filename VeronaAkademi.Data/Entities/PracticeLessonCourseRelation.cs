using System.ComponentModel.DataAnnotations;
using VeronaAkademi.Data.Entities.Base;

namespace VeronaAkademi.Data.Entities
{
    public class PracticeLessonCourseRelation : BaseEntity
    {
        [Key]
        public int PracticeLessonCourseRelationId { get; set; }
        public int CourseId { get; set; }
        public Course Course { get; set; }
        public int PracticeLessonId { get; set; }
        public PracticeLesson PracticeLesson { get; set; }
    }
}
