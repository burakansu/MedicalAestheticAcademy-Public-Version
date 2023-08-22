using System.ComponentModel.DataAnnotations;
using VeronaAkademi.Data.Entities.Base;

namespace VeronaAkademi.Data.Entities
{
    public class CustomerCourseRelation 
    {
        [Key]
        public int CustomerCourseRelationId { get; set; }
        public int CourseId { get; set; }
        public Course Course { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public int Completed { get; set; }
    }
}
