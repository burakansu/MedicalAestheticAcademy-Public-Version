using System.ComponentModel.DataAnnotations;
using VeronaAkademi.Data.Entities.Base;

namespace VeronaAkademi.Data.Entities
{
    public class PracticeLessonGallery : BaseEntity
    {
        [Key]
        public int PracticeLessonGalleryId { get; set; }
        public string Image { get; set; }
        public int PracticeLessonId { get; set; }
        public PracticeLesson PracticeLesson { get; set; }
    }
}
