using dmitry_efimov_kt_31_20.Data.Helpers;
using dmitry_efimov_kt_31_20.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace dmitry_efimov_kt_31_20.Data.Configurations
{
    public class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        private const string TableName = "ct_student";
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.HasKey(p => p.StudentId).HasName($"pk_{TableName}_student_id");
            builder.Property(p => p.StudentId).ValueGeneratedOnAdd();
            builder.Property(p => p.StudentId).HasColumnName("student_id").HasComment("Идентификатор записи студента");

            builder.Property(s => s.FirstName).IsRequired().HasColumnName("c_student_firstname")
                .HasColumnType(ColumnType.String).HasMaxLength(100).HasComment("Имя студента");

            builder.Property(s => s.LastName).IsRequired().HasColumnName("c_student_lastname")
                .HasColumnType(ColumnType.String).HasMaxLength(100).HasComment("Фамилия студента");

            builder.Property(s => s.MiddleName).IsRequired().HasColumnName("c_student_middlename")
                .HasColumnType(ColumnType.String).HasMaxLength(100).HasComment("Отчество студента");

            builder.Property(s => s.RatingsId).IsRequired().HasColumnName("c_student_ratings_id")
               .HasColumnType(ColumnType.Int).HasComment("Оценка");

            builder.HasOne(s => s.Ratings)
                   .WithMany()
                   .HasForeignKey(s => s.RatingsId).HasConstraintName("fk_f_ratings_id").OnDelete(DeleteBehavior.Cascade);
            builder.ToTable(TableName).HasIndex(p => p.RatingsId, $"idx_{TableName}fk_f_ratings_id");
            builder.Navigation(p => p.Ratings).AutoInclude();

            builder.Property(s => s.TestId).IsRequired().HasColumnName("c_student_test_id")
               .HasColumnType(ColumnType.Int).HasComment("Зачет");

            builder.HasOne(s => s.Test)
                   .WithMany()
                   .HasForeignKey(s => s.RatingsId).HasConstraintName("fk_f_test_id").OnDelete(DeleteBehavior.Cascade);
            builder.ToTable(TableName).HasIndex(p => p.TestId, $"idx_{TableName}_fk_f_test_id");
            builder.Navigation(p => p.Test).AutoInclude();
            builder.ToTable(TableName);
        }
    }
}
