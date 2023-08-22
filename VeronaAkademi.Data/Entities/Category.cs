using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using VeronaAkademi.Data.Entities.Base;

namespace VeronaAkademi.Data.Entities
{
    public class Category : BaseEntity
    {
        [Key]
        public int CategoryId { get; set; }
        public string Name { get; set; }

        [DefaultValue(0)]
        public int? ParentId { get; set; }
        public Category? Parent { get; set; }
        public int CategoryGroupId { get; set; }
        public CategoryGroup CategoryGroup { get; set; }
        public ICollection<Category> SubCategory { get; } = new List<Category>();


    }
}
