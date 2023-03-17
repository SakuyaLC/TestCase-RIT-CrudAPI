using TestCase_RIT_CrudAPI.Model;

namespace TestCase_RIT_CrudAPI.Data.Interfaces
{
    public interface IDrillBlockRepository
    {
        Task<bool> DrillBlockExists(int Id);
        Task<ICollection<DrillBlock>> GetDrillBlocks();
        Task<DrillBlock> GetSpecificDrillBlock(int Id);
        Task<bool> CreateDrillBlock(DrillBlock drillBlock);
        Task<bool> DeleteDrillBlock(DrillBlock drillBlock);
        Task<bool> UpdateDrillBlock(DrillBlock drillblock);
        Task<bool> Save();
    }
}
