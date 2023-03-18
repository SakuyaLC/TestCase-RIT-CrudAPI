using Microsoft.EntityFrameworkCore;
using TestCase_RIT_CrudAPI.Data.Context;
using TestCase_RIT_CrudAPI.Data.Interfaces;
using TestCase_RIT_CrudAPI.Model;

namespace TestCase_RIT_CrudAPI.Data.Repositories
{
    public class DrillBlockRepository : IDrillBlockRepository
    {
        private readonly DataContext _context;

        public DrillBlockRepository(DataContext context)
        {
            _context = context;
        }

        async public Task<bool> DrillBlockExists(int Id)
        {
            return await _context.DrillBlocks.AnyAsync(db => db.Id == Id);
        }

        async public Task<ICollection<DrillBlock>> GetDrillBlocks()
        {
            return await _context.DrillBlocks.OrderBy(db => db.Id).ToListAsync();
        }

        async public Task<DrillBlock> GetSpecificDrillBlock(int Id)
        {
            return await _context.DrillBlocks.Where(db => db.Id == Id).SingleOrDefaultAsync();
        }

        async public Task<bool> CreateDrillBlock(DrillBlock drillBlock)
        {
            _context.Add(drillBlock);

            return await Save();
        }

        async public Task<bool> DeleteDrillBlock(DrillBlock drillBlock)
        {
            _context.Remove(drillBlock);

            return await Save();
        }

        async public Task<bool> UpdateDrillBlock(DrillBlock drillblock)
        {
            _context.Update(drillblock);

            return await Save();
        }

        async public Task<bool> Save()
        {
            var saved = await _context.SaveChangesAsync();
            return saved > 0 ? true : false;
        }
    }
}
