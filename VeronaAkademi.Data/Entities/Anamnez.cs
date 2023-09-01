using System.ComponentModel.DataAnnotations;
using VeronaAkademi.Data.Entities.Base;

namespace VeronaAkademi.Data.Entities
{
    public class Anamnez : BaseEntity
    {
        [Key]
        public int AnamnezId { get; set; }

        // Attributes
        public string? FullName { get; set; }  // Patient's full name
        public int? Age { get; set; }          // Patient's age
        public string? Diagnosis { get; set; } // Diagnosis information
        public string? Allergies { get; set; } // Allergy information

        // Relation
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public int AdvisorId { get; set; }
        public Advisor Advisor { get; set; }
    }
}
