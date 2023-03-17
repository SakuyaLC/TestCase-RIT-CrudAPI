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
            bool result = false;

            await Task.Run(
            () =>
            {
                result = _context.DrillBlockPoints.Any(dbp => dbp.Id == Id);
            });

            return result;
        }

        async public Task<ICollection<DrillBlockPoint>> GetDrillBlockPoints()
        {
            ICollection<DrillBlockPoint> result = null;

            await Task.Run(
            () =>
            {
                result = _context.DrillBlockPoints.OrderBy(dbp => dbp.Id).ToList();
            });

            return result;
        }

        async public Task<DrillBlockPoint> GetSpecificDrillBlockPoint(int Id)
        {
            DrillBlockPoint result = null;

            await Task.Run(
            () =>
            {
                result = _context.DrillBlockPoints.Where(dbp => dbp.Id == Id).SingleOrDefault();
            });

            return result;
        }

        async public Task<bool> CreateDrillBlockPoint(DrillBlockPoint drillBlockPoint)
        {
            bool result = false;

            await Task.Run(
            async () =>
            {
                _context.Add(drillBlockPoint);
                result = await Save();
            });

            return result;
        }

        async public Task<bool> DeleteDrillBlockPoint(DrillBlockPoint drillBlockPoint)
        {
            bool result = false;

            await Task.Run(
            async () =>
            {
                _context.Remove(drillBlockPoint);
                result = await Save();
            });

            return result;
        }

        async public Task<bool> UpdateDrillBlockPoint(DrillBlockPoint drillBlockPoint)
        {
            bool result = false;

            await Task.Run(
            async () =>
            {
                _context.Update(drillBlockPoint);
                result = await Save();
            });

            return result;
        }

        async public Task<bool> Save()
        {
            var saved = await _context.SaveChangesAsync();
            return saved > 0 ? true : false;
        }
    }
}
