using System.ComponentModel.DataAnnotations;

namespace VeronaAkademi.Data.Entities.Base
{
    public partial class RestrictionUi
    {
        [Key]
        public int RestrictionUiId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Group { get; set; }

        public virtual ICollection<RestrictionPersonelUi> RestrictionPersonelUi { get; set; }
    }
}
