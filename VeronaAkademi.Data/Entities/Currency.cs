using System.ComponentModel.DataAnnotations;

namespace VeronaAkademi.Data.Entities
{
    public class Currency
    {
        [Key]
        public int CurrencyId { get; set; }
        public string Name{ get; set; }
        public virtual ICollection<Course> Course{ get; set; }

     }
}