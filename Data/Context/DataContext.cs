using Microsoft.EntityFrameworkCore;
using TestCase_RIT_CrudAPI.Model;

namespace TestCase_RIT_CrudAPI.Data.Context
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<DrillBlock> DrillBlocks { get; set; }
        public DbSet<DrillBlockPoint> DrillBlockPoints { get; set; }
        public DbSet<Hole> Holes { get; set; }
        public DbSet<HolePoint> HolePoints { get; set; }

        public void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DrillBlockPoint>()
                .HasOne(db => db.DrillBlock)
                .WithMany(dbp => dbp.DrillBlockPoints)
                .HasForeignKey(dbi => dbi.DrillBlockId);

            modelBuilder.Entity<Hole>()
                .HasOne(db => db.DrillBlock)
                .WithMany(h => h.Holes)
                .HasForeignKey(hpi => hpi.DrillBlockId);

            modelBuilder.Entity<HolePoint>()
                .HasOne(h => h.Hole)
                .WithMany(hp => hp.HolePoints)
                .HasForeignKey(hpi => hpi.HoleId);

        }

    }
}
