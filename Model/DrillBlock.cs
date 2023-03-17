using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestCase_RIT_CrudAPI.Model
{
    [Table("DrillBlocks")]
    public class DrillBlock
    {
        [Key]
        [Required]
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime UpdateDate { get; set; }
        public ICollection<DrillBlockPoint> DrillBlockPoints { get; set; }
        public ICollection<Hole> Holes { get; set; }
    }
}
