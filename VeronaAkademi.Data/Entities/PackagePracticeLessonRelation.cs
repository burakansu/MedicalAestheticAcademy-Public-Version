using System.ComponentModel.DataAnnotations;
using VeronaAkademi.Data.Entities.Base;

namespace VeronaAkademi.Data.Entities
{
    public class PackagePracticeLessonRelation : BaseEntity
    {
        [Key]
        public int PackagePracticeLessonRelationId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime FinishDate { get; set; }
        public int PracticeLessonId { get; set; }
        public PracticeLesson PracticeLesson { get; set; }
        public int PackageId { get; set; }
        public Package Package { get; set; }
    }
}
