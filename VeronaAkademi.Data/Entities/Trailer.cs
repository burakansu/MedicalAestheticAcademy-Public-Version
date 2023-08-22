using System.ComponentModel.DataAnnotations;
using VeronaAkademi.Data.Entities.Base;

namespace VeronaAkademi.Data.Entities
{
    public class Trailer : BaseEntity
    {
        [Key]
        public int TrailerId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int CourseId { get; set; }
        public Course Course { get; set; }
        public string Source { get; set; }
    }
}
