using dmitry_efimov_kt_31_20.Data.Helpers;
using dmitry_efimov_kt_31_20.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace dmitry_efimov_kt_31_20.Data.Configurations
{
    public class RatingsConfiguration : IEntityTypeConfiguration<Ratings>
    {

        private const string TableName = "ct_ratings";
        public void Configure(EntityTypeBuilder<Ratings> builder)
        {
            builder.HasKey(p => p.RaingsId).HasName($"pk_{TableName}_ratings_id");
            builder.Property(p => p.RaingsId).ValueGeneratedOnAdd();
            builder.Property(p => p.RaingsId).HasColumnName("ratings_id").HasComment("Идентификатор экзамена");

            builder.Property(s => s.RaingsName).IsRequired().HasColumnName("c_ratings_ratingsname")
               .HasColumnType(ColumnType.String).HasMaxLength(100).HasComment("Название предмета по которому экзамен");

            builder.Property(s => s.GradeRatings).IsRequired().HasColumnName("c_ratings_ratingsgrade")
               .HasColumnType(ColumnType.Int).HasMaxLength(100).HasComment("Оценка за экзамен");

            builder.ToTable(TableName);
        }
    }
}
