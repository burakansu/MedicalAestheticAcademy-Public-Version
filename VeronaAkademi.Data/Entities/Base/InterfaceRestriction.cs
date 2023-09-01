using System.ComponentModel.DataAnnotations;

namespace VeronaAkademi.Data.Entities.Base
{
    public partial class InterfaceRestriction
    {
        [Key]
        public int InterfaceRestrictionId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Group { get; set; }

        public virtual ICollection<PersonelInterfaceRestriction> PersonelInterfaceRestriction { get; set; }
    }
}
