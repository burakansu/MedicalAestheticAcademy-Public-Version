using System.ComponentModel.DataAnnotations;
using VeronaAkademi.Data.Entities.Base;

namespace VeronaAkademi.Data.Entities
{
    public class CustomerPracticeLessonRelation 
    {
        [Key]
        public int CustomerPracticeLessonRelationId { get; set; }
        public int PracticeLessonId { get; set; }
        public PracticeLesson PracticeLesson { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
    }
}
