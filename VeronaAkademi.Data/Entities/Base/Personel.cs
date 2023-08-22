using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace VeronaAkademi.Data.Entities.Base
{
    public partial class Personel : BaseEntity
    {
        [Key]
        public int PersonelId { get; set; }
        public string Adi { get; set; }
        public string Kod { get; set; }
        public string Unvan { get; set; }
        public string Eposta { get; set; }
        public string Telefon { get; set; }
        public string Parola { get; set; }

        [NotMapped]
        public string? YeniParola { get; set; }
        public int PersonelTipId { get; set; }
        public PersonelType? PersonelTip { get; set; }
        public int DepartmanId { get; set; }
        public Department? Departman { get; set; }
        public virtual ICollection<RestrictionPersonelUi>? PersonelArayuzKisitlama { get; set; }
        public virtual ICollection<PersonelRestrictionRelation>? PersonelKisitlamaRelation { get; set; }
    }
}
