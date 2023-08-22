using System.ComponentModel.DataAnnotations;

namespace VeronaAkademi.Data.Entities.Base
{
    public partial class Department
    {
        [Key]
        public int DepartmentId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Personel> Personel { get; set; }
    }
}
