using TestCase_RIT_CrudAPI.Model;

namespace TestCase_RIT_CrudAPI.Data.Interfaces
{
    public interface IDrillBlockPointRepository
    {
        Task<bool> DrillBlockPointExists(int Id);
        Task<ICollection<DrillBlockPoint>> GetDrillBlockPoints();
        Task<DrillBlockPoint> GetSpecificDrillBlockPoint(int Id);
        Task<bool> CreateDrillBlockPoint(DrillBlockPoint drillBlockPoint);
        Task<bool> DeleteDrillBlockPoint(DrillBlockPoint drillBlockPoint);
        Task<bool> UpdateDrillBlockPoint(DrillBlockPoint drillBlockPoint);
        Task<bool> Save();
    }
}
