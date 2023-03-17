using TestCase_RIT_CrudAPI.Model;

namespace TestCase_RIT_CrudAPI.Data.Interfaces
{
    public interface IHolePointRepository
    {
        Task<bool> HolePointExists(int Id);
        Task<ICollection<HolePoint>> GetHolePoints();
        Task<HolePoint> GetSpecificHolePoint(int Id);
        Task<bool> CreateHolePoint(HolePoint holePoint);
        Task<bool> DeleteHolePoint(HolePoint holePoint);
        Task<bool> UpdateHolePoint(HolePoint holePoint);
        Task<bool> Save();
    }
}
