using System.ComponentModel.DataAnnotations;
using VeronaAkademi.Data.Entities.Base;

namespace VeronaAkademi.Data.Entities
{
    public class TestEntity:BaseEntity
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

    }
}
