using System.ComponentModel.DataAnnotations;
using VeronaAkademi.Data.Entities.Base;

namespace VeronaAkademi.Data.Entities
{
    public class Lesson : BaseEntity
    {
        [Key]
        public int LessonId { get; set; }
        public string Image { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public int CurrencyId { get; set; }
        public Currency Currency { get; set; }
        public int LecturerId { get; set; }
        public Lecturer Lecturer { get; set; }
        public string Source { get; set; }
        public int Duration { get; set; }
        public int CourseId { get; set; }
        public Course Course { get; set; }

        public virtual ICollection<Review> Reviews { get; set; }
        public virtual ICollection<Basket> Basket { get; set; }
    }
}
