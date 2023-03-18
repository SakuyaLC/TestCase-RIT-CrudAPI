using System.ComponentModel.DataAnnotations;
using TestCase_RIT_CrudAPI.Model;

namespace TestCase_RIT_CrudAPI.Data.DTO
{
    public class DrillBlockDTO
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}
