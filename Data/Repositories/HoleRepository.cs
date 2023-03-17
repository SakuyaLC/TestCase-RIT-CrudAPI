using TestCase_RIT_CrudAPI.Data.Context;
using TestCase_RIT_CrudAPI.Data.Interfaces;
using TestCase_RIT_CrudAPI.Model;

namespace TestCase_RIT_CrudAPI.Data.Repositories
{
    public class HoleRepository : IHoleRepository
    {
        private readonly DataContext _context;

        public HoleRepository(DataContext context)
        {
            _context = context;
        }

        async public Task<bool> HoleExists(int Id)
        {
            bool result = false;

            await Task.Run(
            () =>
            {
                result = _context.Holes.Any(h => h.Id == Id);
            });

            return result;
        }

        async public Task<ICollection<Hole>> GetHoles()
        {
            ICollection<Hole> result = null;

            await Task.Run(
            () =>
            {
                result = _context.Holes.OrderBy(h => h.Id).ToList();
            });

            return result;
        }

        async public Task<Hole> GetSpecificHole(int Id)
        {
            Hole result = null;

            await Task.Run(
            () =>
            {
                result = _context.Holes.Where(h => h.Id == Id).SingleOrDefault();
            });

            return result;
        }

        async public Task<bool> CreateHole(Hole hole)
        {
            bool result = false;

            await Task.Run(
            async () =>
            {
                _context.Add(hole);
                result = await Save();
            });

            return result;
        }

        async public Task<bool> DeleteHole(Hole hole)
        {
            bool result = false;

            await Task.Run(
            async () =>
            {
                _context.Remove(hole);
                result = await Save();
            });

            return result;
        }

        async public Task<bool> UpdateHole(Hole hole)
        {
            bool result = false;

            await Task.Run(
            async () =>
            {
                _context.Update(hole);
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
