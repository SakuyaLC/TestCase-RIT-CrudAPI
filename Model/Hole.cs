using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestCase_RIT_CrudAPI.Model
{
    [Table("Holes")]
    public class Hole
    {
        [Key]
        [Required]
        public int Id { get; set; }
        public string Name { get; set; }
        public int DrillBlockId { get; set; }
        public DrillBlock DrillBlock { get; set; }
        public double Depth { get; set; }
        public ICollection<HolePoint> HolePoints { get; set; }
    }
}
