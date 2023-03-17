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
            bool result = false;

            await Task.Run(
            () =>
            {
                result = _context.DrillBlocks.Any(db => db.Id == Id);
            });

            return result;
        }

        async public Task<ICollection<DrillBlock>> GetDrillBlocks()
        {
            ICollection<DrillBlock> result = null;

            await Task.Run(
            () =>
            {
                result = _context.DrillBlocks.OrderBy(db => db.Id).ToList();
            });

            return result;

        }

        async public Task<DrillBlock> GetSpecificDrillBlock(int Id)
        {
            DrillBlock result = null;

            await Task.Run(
            () =>
            {
                result = _context.DrillBlocks.Where(db => db.Id == Id).SingleOrDefault();
            });

            return result;
        }

        async public Task<bool> CreateDrillBlock(DrillBlock drillBlock)
        {

            bool result = false;

            await Task.Run(
            async () =>
            {
                _context.Add(drillBlock);

                result = await Save();
            });

            return result;
        }

        async public Task<bool> DeleteDrillBlock(DrillBlock drillBlock)
        {
            bool result = false;

            await Task.Run(
            async () =>
            {
                _context.Remove(drillBlock);

                result = await Save();
            });

            return result;
        }

        async public Task<bool> UpdateDrillBlock(DrillBlock drillblock)
        {
            bool result = false;

            await Task.Run(
            async () =>
            {
                _context.Update(drillblock);

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
