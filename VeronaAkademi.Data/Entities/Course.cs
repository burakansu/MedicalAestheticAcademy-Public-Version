using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using VeronaAkademi.Data.Entities.Base;

namespace VeronaAkademi.Data.Entities
{
    [Table("Course")]
    public class Course : BaseEntity
    {
        [Key]
        public int CourseId { get; set; }
        public string Image { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public int CurrencyId { get; set; }
        public Currency Currency { get; set; }
        public string Source { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        [NotMapped]
        public List<int> LecturerIdList{ get; set; }
        public virtual ICollection<Lesson> Lesson{ get; set; }
        public virtual ICollection<Trailer> Trailer{ get; set; }
        public virtual ICollection<SkillCourseRelation> SkillCourseRelation{ get; set; }
        public virtual ICollection<ProfessionCourseRelation> ProfessionCourseRelation { get; set; }
        public virtual ICollection<LecturerCourseRelation> LecturerCourseRelation { get; set; }
        public virtual ICollection<PackageCourseRelation> PackageCourseRelation { get; set; }
        public virtual ICollection<AdvisorCourseRelation> AdvisorCourseRelation { get; set; }
        public virtual ICollection<PracticeLessonCourseRelation> PracticeLessonCourseRelation { get; set; }
    }
}
