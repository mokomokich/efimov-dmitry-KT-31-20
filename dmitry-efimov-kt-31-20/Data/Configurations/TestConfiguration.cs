using dmitry_efimov_kt_31_20.Data.Helpers;
using dmitry_efimov_kt_31_20.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Text.RegularExpressions;

namespace dmitry_efimov_kt_31_20.Data.Configurations
{
    public class TestConfiguration : IEntityTypeConfiguration<Test>
    {
        private const string TableName = "ct_test";
        public void Configure(EntityTypeBuilder<Test> builder)
        {
            builder.HasKey(p => p.TestId).HasName($"pk_{TableName}_test_id");
            builder.Property(p => p.TestId).ValueGeneratedOnAdd();
            builder.Property(p => p.TestId).HasColumnName("test_id").HasComment("Идентификатор зачета");

            builder.Property(s => s.TestName).IsRequired().HasColumnName("c_test_testname")
               .HasColumnType(ColumnType.String).HasMaxLength(100).HasComment("Название предмета по которому зачет");

            builder.Property(s => s.IsTheTest).IsRequired().HasColumnName("c_test_isthetest")
               .HasColumnType(ColumnType.Int).HasMaxLength(100).HasComment("Есть зачет или нет");

            builder.ToTable(TableName);
        }
    }
}
