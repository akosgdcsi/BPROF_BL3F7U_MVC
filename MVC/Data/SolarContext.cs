using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Models;

namespace Data
{
    public class SolarContext : IdentityDbContext<IdentityUser>
    {
        public SolarContext(DbContextOptions<SolarContext> opt):base(opt)
        {

        }
        public SolarContext()
        {
            this.Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.
                    UseLazyLoadingProxies().
                    UseSqlServer(@"Server=tcp:androiddatabase.database.windows.net,1433;Initial Catalog=AndroidDB;Persist Security Info=False;User ID=akosgdcsi;Password=Akos1999;MultipleActiveResultSets=True;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;", x => x.MigrationsAssembly("WebApi"));
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<IdentityRole>().HasData(
                new { Id = "341743f0-asd2–42de-afbf-59kmkkmk72cf6", Name = "Admin", NormalizedName = "ADMIN" },
                new { Id = "341743f0-dee2–42de-bbbb-59kmkkmk72cf6", Name = "Customer", NormalizedName = "CUSTOMER" });

            var appUser = new IdentityUser
            {
                Id = "02174cf0–9412–4cfe-afbf-59f706d72cf6",
                Email = "akosgadacsi99@gmail.com",
                NormalizedEmail = "akosgadacsi99@gmail.com",
                EmailConfirmed = true,
                UserName = "akosgadacsi99@gmail.com",
                NormalizedUserName = "akosgadacsi99@gmail.com",
                SecurityStamp = string.Empty
            };

            var appUser2 = new IdentityUser
            {
                Id = "e2174cf0–9412–4cfe-afbf-59f706d72cf6",
                Email = "valaki11@gmail.com",
                NormalizedEmail = "valaki11@gmail.com",
                EmailConfirmed = true,
                UserName = "valaki11@gmail.com",
                NormalizedUserName = "valaki11@gmail.com",
                SecurityStamp = string.Empty
            };

            appUser.PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null, "Android123!");
            appUser2.PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null, "Android123!");


            modelBuilder.Entity<IdentityUser>().HasData(appUser);
            modelBuilder.Entity<IdentityUser>().HasData(appUser2);

            modelBuilder.Entity<Planet>(entitiy =>
            {
                entitiy.HasOne(planet => planet.Star).WithMany(star => star.Planets).HasForeignKey(planet => planet.StarID).OnDelete(DeleteBehavior.Cascade);
            });
            modelBuilder.Entity<Star>(entitiy =>
            {
                entitiy.HasOne(star => star.System).WithMany(system => system.Stars).HasForeignKey(star => star.SystemID).OnDelete(DeleteBehavior.Cascade);
            });
        }
        public DbSet<Planet> Planets { get; set; }
        public DbSet<Star> Stars { get; set; }
        public DbSet<Models.System> Systems { get; set; }
    }
}
