using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;
using VeronaAkademi.Data.Entities.Base;

namespace VeronaAkademi.Data.Entities
{
    public class Customer:BaseEntity
    {
        [Key]
        public int CustomerId { get; set; }
        public string Image { get; set; }
        public string NameSurname { get; set; }
        public string Email{ get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        public int CurrencyId { get; set; }
        public Currency Currency { get; set; }
        public ICollection<Review> Review{ get; set; }

    }
}