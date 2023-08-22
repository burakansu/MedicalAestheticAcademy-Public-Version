using VeronaAkademi.Data.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VeronaAkademi.Data.Entities.Base
{
    public partial class RestrictionPersonelUi
    {
        [Key]
        public int PersonelArayuzKisitlamaId { get; set; }
        public int PersonelId { get; set; }
        public Personel Personel { get; set; }
        public int ArayuzKisitlamaId { get; set; }

        public virtual RestrictionUi ArayuzKisitlama { get; set; }
    }
}
