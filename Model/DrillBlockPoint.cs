using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestCase_RIT_CrudAPI.Model
{
    [Table("DrillBlockPoints")]
    public class DrillBlockPoint
    {
        [Key]
        [Required]
        public int Id { get; set; }
        public int DrillBlockId { get; set; }
        public DrillBlock DrillBlock { get; set; }
        public string Sequence { get; set; }
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }
    }
}
