﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using dmitry_efimov_kt_31_20.Data;

#nullable disable

namespace dmitryefimovkt3120.Migrations
{
    [DbContext(typeof(Academic_performanceDbContext))]
    partial class AcademicperformanceDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("dmitry_efimov_kt_31_20.Models.Ratings", b =>
                {
                    b.Property<int>("RaingsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ratings_id")
                        .HasComment("Идентификатор экзамена");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RaingsId"));

                    b.Property<int>("GradeRatings")
                        .HasMaxLength(100)
                        .HasColumnType("int")
                        .HasColumnName("c_ratings_ratingsgrade")
                        .HasComment("Оценка за экзамен");

                    b.Property<string>("RaingsName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar")
                        .HasColumnName("c_ratings_ratingsname")
                        .HasComment("Название предмета по которому экзамен");

                    b.HasKey("RaingsId")
                        .HasName("pk_ct_ratings_ratings_id");

                    b.ToTable("ct_ratings", (string)null);
                });

            modelBuilder.Entity("dmitry_efimov_kt_31_20.Models.Student", b =>
                {
                    b.Property<int>("StudentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("student_id")
                        .HasComment("Идентификатор записи студента");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("StudentId"));

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar")
                        .HasColumnName("c_student_firstname")
                        .HasComment("Имя студента");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar")
                        .HasColumnName("c_student_lastname")
                        .HasComment("Фамилия студента");

                    b.Property<string>("MiddleName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar")
                        .HasColumnName("c_student_middlename")
                        .HasComment("Отчество студента");

                    b.Property<int>("RatingsId")
                        .HasColumnType("int")
                        .HasColumnName("c_student_ratings_id")
                        .HasComment("Оценка");

                    b.Property<int>("TestId")
                        .HasColumnType("int")
                        .HasColumnName("c_student_test_id")
                        .HasComment("Зачет");

                    b.HasKey("StudentId")
                        .HasName("pk_ct_student_student_id");

                    b.HasIndex(new[] { "TestId" }, "idx_ct_student_fk_f_test_id");

                    b.HasIndex(new[] { "RatingsId" }, "idx_ct_studentfk_f_ratings_id");

                    b.ToTable("ct_student", (string)null);
                });

            modelBuilder.Entity("dmitry_efimov_kt_31_20.Models.Test", b =>
                {
                    b.Property<int>("TestId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("test_id")
                        .HasComment("Идентификатор зачета");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TestId"));

                    b.Property<int>("IsTheTest")
                        .HasMaxLength(100)
                        .HasColumnType("int")
                        .HasColumnName("c_test_isthetest")
                        .HasComment("Есть зачет или нет");

                    b.Property<string>("TestName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar")
                        .HasColumnName("c_test_testname")
                        .HasComment("Название предмета по которому зачет");

                    b.HasKey("TestId")
                        .HasName("pk_ct_test_test_id");

                    b.ToTable("ct_test", (string)null);
                });

            modelBuilder.Entity("dmitry_efimov_kt_31_20.Models.Student", b =>
                {
                    b.HasOne("dmitry_efimov_kt_31_20.Models.Ratings", "Ratings")
                        .WithMany()
                        .HasForeignKey("RatingsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_f_ratings_id");

                    b.HasOne("dmitry_efimov_kt_31_20.Models.Test", "Test")
                        .WithMany()
                        .HasForeignKey("RatingsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_f_test_id");

                    b.Navigation("Ratings");

                    b.Navigation("Test");
                });
#pragma warning restore 612, 618
        }
    }
}