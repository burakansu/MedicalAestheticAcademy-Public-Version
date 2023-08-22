using System.ComponentModel.DataAnnotations;
using VeronaAkademi.Data.Entities.Base;

namespace VeronaAkademi.Data.Entities
{
    public class CustomerLessonRelation 
    {
        [Key]
        public int CustomerLessonRelationId { get; set; }
        public int LessonId { get; set; }
        public Lesson Lesson { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public int Completed { get; set; }
    }
}
