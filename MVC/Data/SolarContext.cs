using System;
using Microsoft.EntityFrameworkCore;
using Models;

namespace Data
{
    public class SolarContext : DbContext
    {
        public SolarContext(DbContextOptions<SolarContext> opt):base(opt)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.
                    UseLazyLoadingProxies().
                    UseSqlServer(@"data source=(LocalDB)\MSSQLLocalDB;attachdbfilename=|DataDirectory|\Solar.mdf;integrated security=True;MultipleActiveResultSets=True");
            }
        }
        public DbSet<Planet> Planets { get; set; }
        public DbSet<Star> Stars { get; set; }
        public DbSet<Models.System> Systems { get; set; }
    }
}
