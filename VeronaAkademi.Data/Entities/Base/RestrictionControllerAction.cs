using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VeronaAkademi.Data.Entities.Base
{
    public class RestrictionControllerAction
    {
        [Key]
        public int KisitlamaControllerActionId { get; set; }
        public int KisitlamaId { get; set; }
        public Restriction Kisitlama { get; set; }
        public string Controller { get; set; }
        public string Action { get; set; }
    }
}
