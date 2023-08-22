using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using VeronaAkademi.Data.Entities.Base;

namespace VeronaAkademi.Data.Entities
{
    public class PracticeLesson : BaseEntity
    {
        [Key]
        public int PracticeLessonId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }

        public virtual ICollection<PracticeLessonGallery> PracticeLessonGallery { get; set; }
        public virtual ICollection<PracticeLessonCourseRelation> PracticeLessonCourseRelation { get; set; }
        public virtual ICollection<PackagePracticeLessonRelation> PackagePracticeLessonRelation { get; set; }
    }
}
