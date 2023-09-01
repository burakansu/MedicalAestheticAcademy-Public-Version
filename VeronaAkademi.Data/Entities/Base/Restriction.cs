using System.ComponentModel.DataAnnotations;

namespace VeronaAkademi.Data.Entities.Base
{
    public partial class Restriction
    {
        [Key]
        public int RestrictionId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Group { get; set; }
        public string Controller { get; set; }
        public string Action { get; set; }
        public string NameSpace { get; set; }
        public string TargetDivId { get; set; }

        public virtual ICollection<PersonelInterfaceRestrictionRelation> PersonelInterfaceRestrictionRelation { get; set; }
        public virtual ICollection<RestrictionControllerAction> RestrictionControllerAction { get; set; }
    }
}
