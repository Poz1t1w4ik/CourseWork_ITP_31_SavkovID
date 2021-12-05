using Microsoft.EntityFrameworkCore;
using StreetLighting.Models.Entities;

namespace StreetLighting.Models.Db
{
    public class Context : DbContext
    {
        public DbSet<Street> Streets { get; set; }
        public DbSet<StreetPart> StreetParts { get; set; }
        public DbSet<Lamp> Lamps { get; set; }
        public DbSet<Luminare> Luminares { get; set; }
        public DbSet<SiteLighting> SiteLightings { get; set; }

        public Context(DbContextOptions<Context> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
