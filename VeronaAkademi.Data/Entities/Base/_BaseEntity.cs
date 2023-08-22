using System.ComponentModel.DataAnnotations.Schema;

namespace VeronaAkademi.Data.Entities.Base
{
    public class BaseEntity
    {
        public DateTime? EklemeTarihi { get; set; }
        public DateTime? GuncellemeTarihi { get; set; }
        public bool Aktif { get; set; }
        public bool Silindi { get; set; }

        public int? Sira { get; set; }

        [NotMapped]
        public List<string> Include { get; set; }
        [NotMapped]
        public List<string> Relations { get; set; }

        [NotMapped]
        public int tempId { get; set; }

    }
}
