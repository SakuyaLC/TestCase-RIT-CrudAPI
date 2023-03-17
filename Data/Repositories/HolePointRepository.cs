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
            bool result = false;

            await Task.Run(
            () =>
            {
                result = _context.HolePoints.Any(hp => hp.Id == Id);
            });

            return result;
        }

        async public Task<ICollection<HolePoint>> GetHolePoints()
        {
            ICollection<HolePoint> result = null;

            await Task.Run(
            () =>
            {
                result = _context.HolePoints.OrderBy(hp => hp.Id).ToList();
            });

            return result;
        }

        async public Task<HolePoint> GetSpecificHolePoint(int Id)
        {
            HolePoint result = null;

            await Task.Run(
            () =>
            {
                result = _context.HolePoints.Where(hp => hp.Id == Id).SingleOrDefault();
            });

            return result;
        }

        async public Task<bool> CreateHolePoint(HolePoint holePoint)
        {
            bool result = false;

            await Task.Run(
            async () =>
            {
                _context.Add(holePoint);
                result = await Save();
            });

            return result;
        }

        async public Task<bool> DeleteHolePoint(HolePoint holePoint)
        {
            bool result = false;

            await Task.Run(
            async () =>
            {
                _context.Remove(holePoint);
                result = await Save();
            });

            return result;
        }

        async public Task<bool> UpdateHolePoint(HolePoint holePoint)
        {
            bool result = false;

            await Task.Run(
            async () =>
            {
                _context.Update(holePoint);
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
