using dmitry_efimov_kt_31_20.Data.Configurations;
using dmitry_efimov_kt_31_20.Models;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;

namespace dmitry_efimov_kt_31_20.Data
{
    public class Academic_performanceDbContext: DbContext
    {
        DbSet<Student> Students { get; set; }
        DbSet<Ratings> Ratings { get; set; }
        DbSet<Test> Tests { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new StudentConfiguration());
            modelBuilder.ApplyConfiguration(new TestConfiguration());
            modelBuilder.ApplyConfiguration(new RatingsConfiguration());
        }
        public Academic_performanceDbContext(DbContextOptions<Academic_performanceDbContext> options): base(options) 
        {        
        }
    }
}
