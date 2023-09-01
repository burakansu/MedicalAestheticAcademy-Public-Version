using System.ComponentModel.DataAnnotations;

namespace VeronaAkademi.Data.Entities.Base
{
    public partial class PersonelInterfaceRestriction
    {
        [Key]
        public int PersonelInterfaceRestrictionId { get; set; }
        public int PersonelId { get; set; }
        public Personel Personel { get; set; }
        public int InterfaceRestrictionId { get; set; }

        public virtual InterfaceRestriction InterfaceRestriction { get; set; }
    }
}
