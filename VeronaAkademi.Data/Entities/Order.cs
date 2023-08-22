using System.ComponentModel.DataAnnotations;
using VeronaAkademi.Data.Entities.Base;

namespace VeronaAkademi.Data.Entities
{
    public class Order : BaseEntity
    {
        [Key]
        public int OrderId { get; set; }
        public DateTime FinishDate { get; set; }
        public bool IsDeleted { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }

        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
    }
}