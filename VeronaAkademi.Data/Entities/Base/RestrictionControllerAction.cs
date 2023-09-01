using System.ComponentModel.DataAnnotations;

namespace VeronaAkademi.Data.Entities.Base
{
    public class RestrictionControllerAction
    {
        [Key]
        public int RestrictionControllerActionId { get; set; }
        public int RestrictionId { get; set; }
        public Restriction Restriction { get; set; }
        public string Controller { get; set; }
        public string Action { get; set; }
    }
}
