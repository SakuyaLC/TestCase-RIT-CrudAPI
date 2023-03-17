using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestCase_RIT_CrudAPI.Model
{
    [Table("HolePoints")]
    public class HolePoint
    {
        [Key]
        [Required]
        public int Id { get; set; }
        public int HoleId { get; set; }
        public Hole Hole { get; set; }
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }
    }
}
