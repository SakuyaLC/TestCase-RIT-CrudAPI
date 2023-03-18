using Microsoft.EntityFrameworkCore;
using TestCase_RIT_CrudAPI.Data.Context;
using TestCase_RIT_CrudAPI.Data.Interfaces;
using TestCase_RIT_CrudAPI.Model;

namespace TestCase_RIT_CrudAPI.Data.Repositories
{
    public class HolePointRepository : IHolePointRepository
    {
        private readonly DataContext _context;

        public HolePointRepository(DataContext context)
        {
            _context = context;
        }

        async public Task<bool> HolePointExists(int Id)
        {
            return await _context.HolePoints.AnyAsync(hp => hp.Id == Id);
        }

        async public Task<ICollection<HolePoint>> GetHolePoints()
        {
            return await _context.HolePoints.OrderBy(hp => hp.Id).ToListAsync();
        }

        async public Task<HolePoint> GetSpecificHolePoint(int Id)
        {
            return await _context.HolePoints.Where(hp => hp.Id == Id).SingleOrDefaultAsync();
        }

        async public Task<bool> CreateHolePoint(HolePoint holePoint)
        {
            _context.Add(holePoint);

            return await Save();
        }

        async public Task<bool> DeleteHolePoint(HolePoint holePoint)
        {
            _context.Remove(holePoint);

            return await Save();
        }

        async public Task<bool> UpdateHolePoint(HolePoint holePoint)
        {
            _context.Update(holePoint);

            return await Save();
        }

        async public Task<bool> Save()
        {
            var saved = await _context.SaveChangesAsync();
            return saved > 0 ? true : false;
        }
    }
}
