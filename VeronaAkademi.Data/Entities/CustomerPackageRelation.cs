using System.ComponentModel.DataAnnotations;
using VeronaAkademi.Data.Entities.Base;

namespace VeronaAkademi.Data.Entities
{
    public class CustomerPackageRelation 
    {
        [Key]
        public int CustomerPackageRelationId { get; set; }
        public int PackageId { get; set; }
        public Package Package { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
    }
}
