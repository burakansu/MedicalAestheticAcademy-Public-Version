using System.ComponentModel.DataAnnotations;

namespace VeronaAkademi.Data.Entities
{
    public class Basket
    {
        [Key]
        public int BasketId { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
