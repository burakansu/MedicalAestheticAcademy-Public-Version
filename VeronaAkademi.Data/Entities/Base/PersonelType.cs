using System.ComponentModel.DataAnnotations;

namespace VeronaAkademi.Data.Entities.Base
{
    public partial class PersonelType
    {
        [Key]
        public int PersonelTypeId { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Personel> Personel { get; set; }
    }
}
