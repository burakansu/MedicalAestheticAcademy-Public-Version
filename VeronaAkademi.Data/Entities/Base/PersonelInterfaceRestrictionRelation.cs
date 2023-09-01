using System.ComponentModel.DataAnnotations;

namespace VeronaAkademi.Data.Entities.Base
{
    public partial class PersonelInterfaceRestrictionRelation
    {
        [Key]
        public int PersonelInterfaceRestrictionRelationId { get; set; }
        public int PersonelId { get; set; }
        public Personel Personel { get; set; }
        public int RestrictionId { get; set; }
        public Restriction Restriction { get; set; }
    }
}
