using dmitry_efimov_kt_31_20.Data.Configurations;
using dmitry_efimov_kt_31_20.Database.Configurations;
using dmitry_efimov_kt_31_20.Models;
using Microsoft.EntityFrameworkCore;

namespace dmitry_efimov_kt_31_20.Database
{
    public class StudentDbContext : DbContext
    {
        //Добавляем таблицы
        DbSet<Student> Students { get; set; }
        DbSet<Group> Groups { get; set; }
        DbSet<Test> Tests { get; set; }
        DbSet<Ratings> Ratings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Добавляем конфигурации к таблицам
            modelBuilder.ApplyConfiguration(new StudentConfiguration());
            modelBuilder.ApplyConfiguration(new GroupConfiguration());
            modelBuilder.ApplyConfiguration(new TestConfiguration());
            modelBuilder.ApplyConfiguration(new RatingsConfiguration());
        }

        public StudentDbContext(DbContextOptions<StudentDbContext> options) : base(options)
        {
        }
    }
}
