using System.ComponentModel.DataAnnotations;
using VeronaAkademi.Data.Entities.Base;

namespace VeronaAkademi.Data.Entities
{
    public class Review : BaseEntity
    {
        [Key]
        public int ReviewId { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        public int LessonId { get; set; }
        public Lesson Lesson { get; set; }
        public int StarRate { get; set; }
        public string Description { get; set; }
        public bool Approved{ get; set; }

    }
}
