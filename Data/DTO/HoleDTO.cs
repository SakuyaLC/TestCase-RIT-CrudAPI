using System.ComponentModel.DataAnnotations;
using TestCase_RIT_CrudAPI.Model;

namespace TestCase_RIT_CrudAPI.Data.DTO
{
    public class HoleDTO
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public int DrillBlockId { get; set; }
        [Required]
        public double Depth { get; set; }
    }
}
