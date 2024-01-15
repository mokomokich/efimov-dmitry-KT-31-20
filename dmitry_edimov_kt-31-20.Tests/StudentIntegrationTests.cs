using dmitry_efimov_kt_31_20.Database;
using dmitry_efimov_kt_31_20.Interfaces.StudentsInterfaces;
using dmitry_efimov_kt_31_20.Models;
using Microsoft.EntityFrameworkCore;
using System.Runtime.ExceptionServices;
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
        public async Task GetStudentsByGroupAsync_Test1()
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

            var ratings = new List<Ratings>
            {
                new Ratings
                {
                    RatingsName = "Матем",
                    GradeRatings = 5,
                },
                new Ratings
                {
                    RatingsName = "Физик",
                    GradeRatings = 5,
                }
            };
            await ctx.Set<Ratings>().AddRangeAsync(ratings);

            var tests = new List<Test>
            {
                new Test
                {
                    TestName = "ППО",
                    IsTheTest = 1,
                },
                new Test
                {
                    TestName = "СКПО",
                    IsTheTest = 1,
                }
            };
            await ctx.Set<Test>().AddRangeAsync(tests);



            var students = new List<Student>
            {
                new Student
                {
                    FirstName = "Dmitry",
                    LastName = "Efimov",
                    MiddleName = "Andreevich",
                    GroupId = 1,
                    TestId = 1,
                    RatingsId =1,
                },
                new Student
                {
                    FirstName = "Ivan",
                    LastName = "asdf2",
                    MiddleName = "zxc2",
                    GroupId = 2,
                    TestId = 1,
                    RatingsId =1,
                },
                new Student
                {
                    FirstName = "Lolosh",
                    LastName = "asdf3",
                    MiddleName = "zxc3",
                    GroupId = 1,
                    TestId = 1,
                    RatingsId =1,
                }
            };
            await ctx.Set<Student>().AddRangeAsync(students);

            await ctx.SaveChangesAsync();

            // Act
            var filter = new dmitry_efimov_kt_31_20.Filters.StudentFilters.StudentGroupFilter
            {
                GroupName = "KT-31-20",
            };
            var studentsResult = await studentService.GetStudentsByGroupAsync(filter, CancellationToken.None);

            // Assert
            Assert.Equal(2, studentsResult.Length);
        }
        [Fact]
        public async Task GetStudentsByGroupAsync_Test2()
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

            var ratings = new List<Ratings>
            {
                new Ratings
                {
                    RatingsName = "Матем",
                    GradeRatings = 5,
                },
                new Ratings
                {
                    RatingsName = "Физик",
                    GradeRatings = 5,
                }
            };
            await ctx.Set<Ratings>().AddRangeAsync(ratings);

            var tests = new List<Test>
            {
                new Test
                {
                    TestName = "ППО",
                    IsTheTest = 1,
                },
                new Test
                {
                    TestName = "СКПО",
                    IsTheTest = 1,
                }
            };
            await ctx.Set<Test>().AddRangeAsync(tests);



            var students = new List<Student>
            {
                new Student
                {
                    FirstName = "Dmitry",
                    LastName = "Efimov",
                    MiddleName = "Andreevich",
                    GroupId = 1,
                    TestId = 1,
                    RatingsId =1,
                },
                new Student
                {
                    FirstName = "Ivan",
                    LastName = "asdf2",
                    MiddleName = "zxc2",
                    GroupId = 2,
                    TestId = 1,
                    RatingsId =1,
                },
                new Student
                {
                    FirstName = "Lolosh",
                    LastName = "asdf3",
                    MiddleName = "zxc3",
                    GroupId = 1,
                    TestId = 1,
                    RatingsId =1,
                }
            };
            await ctx.Set<Student>().AddRangeAsync(students);

            await ctx.SaveChangesAsync();

            // Act
            var filter = new dmitry_efimov_kt_31_20.Filters.StudentFilters.StudentGroupId
            {
                GroupId = 1 ,
            };
            var studentsResult = await studentService.GetStudentsByGroupIdAsync(filter, CancellationToken.None);

            // Assert
            Assert.Equal(2, studentsResult.Length);

        }

        [Fact]
        public async Task GetStudentsByGroupAsync_Test3()
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

            var ratings = new List<Ratings>
            {
                new Ratings
                {
                    RatingsName = "Матем",
                    GradeRatings = 5,
                },
                new Ratings
                {
                    RatingsName = "Физик",
                    GradeRatings = 5,
                }
            };
            await ctx.Set<Ratings>().AddRangeAsync(ratings);

            var tests = new List<Test>
            {
                new Test
                {
                    TestName = "ППО",
                    IsTheTest = 1,
                },
                new Test
                {
                    TestName = "СКПО",
                    IsTheTest = 1,
                }
            };
            await ctx.Set<Test>().AddRangeAsync(tests);



            var students = new List<Student>
            {
                new Student
                {
                    FirstName = "Ivan",
                    LastName = "Efimov",
                    MiddleName = "Andreevich",
                    GroupId = 1,
                    TestId = 1,
                    RatingsId =1,
                },
                new Student
                {
                    FirstName = "Ivan",
                    LastName = "asdf2",
                    MiddleName = "zxc2",
                    GroupId = 1,
                    TestId = 1,
                    RatingsId =1,
                },
                new Student
                {
                    FirstName = "Ivan",
                    LastName = "asdf3",
                    MiddleName = "zxc3",
                    GroupId = 1,
                    TestId = 1,
                    RatingsId =1,
                }
            };
            await ctx.Set<Student>().AddRangeAsync(students);

            await ctx.SaveChangesAsync();

            // Act
            var filter = new dmitry_efimov_kt_31_20.Filters.StudentFilters.StudName
            {
                FirstName = "Ivan",
                GroupId = 1,
            };
            var studentsResult = await studentService.GetStudNameee(filter, CancellationToken.None);

            // Assert
            Assert.Equal(3, studentsResult.Length);
        }

    }
}
