using TestCase_RIT_CrudAPI.Model;

namespace TestCase_RIT_CrudAPI.Data.Interfaces
{
    public interface IHoleRepository
    {
        Task<bool> HoleExists(int Id);
        Task<ICollection<Hole>> GetHoles();
        Task<Hole> GetSpecificHole(int Id);
        Task<bool> CreateHole(Hole hole);
        Task<bool> DeleteHole(Hole hole);
        Task<bool> UpdateHole(Hole hole);
        Task<bool> Save();
    }
}
