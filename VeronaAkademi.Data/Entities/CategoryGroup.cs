using System.ComponentModel.DataAnnotations;
using VeronaAkademi.Data.Entities.Base;

namespace VeronaAkademi.Data.Entities
{
    public class CategoryGroup : BaseEntity
    {
        [Key]
        public int CategoryGroupId { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Category> Category { get; set; }
    }
}