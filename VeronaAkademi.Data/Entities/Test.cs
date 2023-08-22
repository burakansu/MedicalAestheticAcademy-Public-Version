using System.ComponentModel.DataAnnotations;
using VeronaAkademi.Data.Entities.Base;

namespace VeronaAkademi.Data.Entities
{
    public class Test
    {
        [Key]
        public int TestId { get; set; }
        public string Name { get; set; }


    }
}
