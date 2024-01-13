using dmitry_efimov_kt_31_20.Database;
using dmitry_efimov_kt_31_20.Interfaces.StudentsInterfaces;
using dmitry_efimov_kt_31_20.Models;
using Microsoft.EntityFrameworkCore;
using NLog.Filters;
using System.Text.RegularExpressions;
using Group = dmitry_efimov_kt_31_20.Models.Group;

namespace dmitry_edimov_kt_31_20.Tests
{
    public class StudentIntegrationTests
    {
        public readonly DbContextOptions<StudentDbContext> _dbContextOptions;

        public StudentIntegrationTests()
        {
            _dbContextOptions = new DbContextOptionsBuilder<StudentDbContext>()
            .UseInMemoryDatabase(databaseName: "student_db")
            .Options;
        }

        [Fact]
        public async Task GetStudentsByGroupAsync_KT3120_TwoObjects()
        {
            // Arrange
            var ctx = new StudentDbContext(_dbContextOptions);
            var studentService = new StudentService(ctx);
            var groups = new List<Group>
            {
                new Group
                {
                    GroupName = "KT-31-20"
                },
                new Group
                {
                    GroupName = "KT-40-21"
                }
            };
            await ctx.Set<Group>().AddRangeAsync(groups);

            var students = new List<Student>
            {
                new Student
                {
                    FirstName = "Dmitry",
                    LastName = "Efimov",
                    MiddleName = "Andreevich",
                    GroupId = 1,
                },
                new Student
                {
                    FirstName = "qwerty2",
                    LastName = "asdf2",
                    MiddleName = "zxc2",
                    GroupId = 2,
                },
                new Student
                {
                    FirstName = "qwerty3",
                    LastName = "asdf3",
                    MiddleName = "zxc3",
                    GroupId = 1,
                }
            };
            await ctx.Set<Student>().AddRangeAsync(students);

            await ctx.SaveChangesAsync();

            // Act
            var filter = new dmitry_efimov_kt_31_20.Filters.StudentFilters.StudentGroupFilter
            {
                GroupName = "KT-31-20"
            };
            var studentsResult = await studentService.GetStudentsByGroupAsync(filter, CancellationToken.None);

            // Assert
            Assert.Equal(2, studentsResult.Length);
        }

        [Fact]
        public async Task GetStudentsByGroupAsync_KT3120()
        {
            // Arrange
            var ctx = new StudentDbContext(_dbContextOptions);
            var studentService = new StudentService(ctx);
            var groups = new List<Group>
            {
                new Group
                {
                    GroupName = "KT-31-20"
                },
                new Group
                {
                    GroupName = "KT-40-21"
                }
            };
            await ctx.Set<Group>().AddRangeAsync(groups);

            var students = new List<Student>
            {
                new Student
                {
                    FirstName = "Dmitry",
                    LastName = "Efimov",
                    MiddleName = "Andreevich",
                    GroupId = 1,
                },
                new Student
                {
                    FirstName = "qwerty2",
                    LastName = "asdf2",
                    MiddleName = "zxc2",
                    GroupId = 2,
                },
                new Student
                {
                    FirstName = "qwerty3",
                    LastName = "asdf3",
                    MiddleName = "zxc3",
                    GroupId = 1,
                }
            };
            await ctx.Set<Student>().AddRangeAsync(students);

            await ctx.SaveChangesAsync();

            // Act
            var filter = new dmitry_efimov_kt_31_20.Filters.StudentFilters.StudentGroupFilter
            {
                GroupName = "KT-31-20"
            };
            var studentsResult = await studentService.GetStudentsByGroupAsync(filter, CancellationToken.None);

            // Assert
            Assert.Equal(2, studentsResult.Length);
        }

        [Fact]
        public async Task GetStudentsByGroupAsync_KT3120_Two()
        {
            // Arrange
            var ctx = new StudentDbContext(_dbContextOptions);
            var studentService = new StudentService(ctx);
            var groups = new List<Student>
            {
                new Student
                {
                    FirstName = "Ivan",
                    LastName = "Ivanov",
                    MiddleName = "Ivanovich",
                    GroupId = 1,
                },
                new Student
                {
                    FirstName = "Dima",
                     LastName = "asdf3",
                    MiddleName = "zxc3",
                    GroupId = 1,
                }
            };
            await ctx.Set<Student>().AddRangeAsync(groups);

            var students = new List<Student>
            {
                new Student
                {
                    FirstName = "Ivan",
                    LastName = "Ivanov",
                    MiddleName = "Ivanovich",
                    GroupId = 1,
                },
                new Student
                {
                    FirstName = "Ivan",
                    LastName = "Ivanov",
                    MiddleName = "Ivanovich",
                    GroupId = 2,
                },
                new Student
                {
                    FirstName = "Dima",
                    LastName = "asdf3",
                    MiddleName = "zxc3",
                    GroupId = 1,
                }
            };
            await ctx.Set<Student>().AddRangeAsync(students);

            await ctx.SaveChangesAsync();

            // Act
            var filter = new dmitry_efimov_kt_31_20.Filters.StudentFilters.StudentNameFilter
            {
                FirstName = "Ivan"
            };
            var studentsResult = await studentService.GetStudentsByNameAsync(filter, CancellationToken.None);

            // Assert
            Assert.Equal(2, studentsResult.Length);
        }
    }
}
