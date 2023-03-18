using System.ComponentModel.DataAnnotations;
using TestCase_RIT_CrudAPI.Model;

namespace TestCase_RIT_CrudAPI.Data.DTO
{
    public class DrillBlockPointDTO
    {
        public int Id { get; set; }
        [Required]
        public int DrillBlockId { get; set; }
        [Required]
        public string Sequence { get; set; }
        [Required]
        public double X { get; set; }
        [Required]
        public double Y { get; set; }
        [Required]
        public double Z { get; set; }
    }
}
