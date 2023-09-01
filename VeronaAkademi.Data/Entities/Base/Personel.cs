using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace VeronaAkademi.Data.Entities.Base
{
    public partial class Personel : BaseEntity
    {
        [Key]
        public int PersonelId { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string Head { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }

        [NotMapped]
        public string? NewPassword { get; set; }
        public int PersonelTypeId { get; set; }
        public PersonelType? PersonelType { get; set; }
        public int DepartmentId { get; set; }
        public Department? Department { get; set; }
        public virtual ICollection<PersonelInterfaceRestriction>? PersonelInterfaceRestriction { get; set; }
        public virtual ICollection<PersonelInterfaceRestrictionRelation>? PersonelInterfaceRestrictionRelation { get; set; }
    }
}