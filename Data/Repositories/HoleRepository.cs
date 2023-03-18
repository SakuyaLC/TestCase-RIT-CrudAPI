using Microsoft.EntityFrameworkCore;
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
            return await _context.Holes.AnyAsync(h => h.Id == Id);
        }

        async public Task<ICollection<Hole>> GetHoles()
        {
            return await _context.Holes.OrderBy(h => h.Id).ToListAsync();
        }

        async public Task<Hole> GetSpecificHole(int Id)
        {
            return await _context.Holes.Where(h => h.Id == Id).SingleOrDefaultAsync();
        }

        async public Task<bool> CreateHole(Hole hole)
        {
            _context.Add(hole);

            return await Save();
        }

        async public Task<bool> DeleteHole(Hole hole)
        {
            _context.Remove(hole);

            return await Save();
        }

        async public Task<bool> UpdateHole(Hole hole)
        {
            _context.Update(hole);

            return await Save();
        }

        async public Task<bool> Save()
        {
            var saved = await _context.SaveChangesAsync();
            return saved > 0 ? true : false;
        }
    }
}
