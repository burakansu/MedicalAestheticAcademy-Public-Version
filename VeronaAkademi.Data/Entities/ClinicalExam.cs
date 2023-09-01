using System.ComponentModel.DataAnnotations;
using VeronaAkademi.Data.Entities.Base;

namespace VeronaAkademi.Data.Entities
{
    public class ClinicalExam : BaseEntity
    {
        [Key]
        public int ClinicalExamId { get; set; }

        // Attributes
        public DateTime? ExamDate { get; set; } 
        public string? ExamType { get; set; }  // (Physical, Blood Test, XRay..)
        public string? Results { get; set; }   // Exam Reports
        public int? Temperature { get; set; } // Body Temperature

        // Relation
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public int AdvisorId { get; set; }
        public Advisor Advisor { get; set; }
    }
}