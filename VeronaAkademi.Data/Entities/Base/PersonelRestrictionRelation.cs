using System.ComponentModel.DataAnnotations;

namespace VeronaAkademi.Data.Entities.Base
{
    public partial class PersonelRestrictionRelation
    {
        [Key]
        public int PersonelKisitlamaRelationId { get; set; }
        public int PersonelId { get; set; }
        public Personel Personel { get; set; }
        public int KisitlamaId { get; set; }
        public Restriction Kisitlama { get; set; }

    }
}
