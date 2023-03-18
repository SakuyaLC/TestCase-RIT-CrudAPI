using Microsoft.EntityFrameworkCore;
using TestCase_RIT_CrudAPI.Data.Context;
using TestCase_RIT_CrudAPI.Data.Interfaces;
using TestCase_RIT_CrudAPI.Model;

namespace TestCase_RIT_CrudAPI.Data.Repositories
{
    public class DrillBlockPointRepository : IDrillBlockPointRepository
    {
        private readonly DataContext _context;

        public DrillBlockPointRepository(DataContext context)
        {
            _context = context;
        }

        async public Task<bool> DrillBlockPointExists(int Id)
        {
            return await _context.DrillBlockPoints.AnyAsync(dbp => dbp.Id == Id);
        }

        async public Task<ICollection<DrillBlockPoint>> GetDrillBlockPoints()
        {
            return await _context.DrillBlockPoints.OrderBy(dbp => dbp.Id).ToListAsync();
        }

        async public Task<DrillBlockPoint> GetSpecificDrillBlockPoint(int Id)
        {
            return await _context.DrillBlockPoints.Where(dbp => dbp.Id == Id).SingleOrDefaultAsync();
        }

        async public Task<bool> CreateDrillBlockPoint(DrillBlockPoint drillBlockPoint)
        {
            _context.Add(drillBlockPoint);

            return await Save();
        }

        async public Task<bool> DeleteDrillBlockPoint(DrillBlockPoint drillBlockPoint)
        {
            _context.Remove(drillBlockPoint);

            return await Save();
        }

        async public Task<bool> UpdateDrillBlockPoint(DrillBlockPoint drillBlockPoint)
        {
            _context.Update(drillBlockPoint);

            return await Save();
        }

        async public Task<bool> Save()
        {
            var saved = await _context.SaveChangesAsync();
            return saved > 0 ? true : false;
        }
    }
}
