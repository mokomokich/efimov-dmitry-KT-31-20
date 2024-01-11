using dmitry_efimov_kt_31_20.Data;
using dmitry_efimov_kt_31_20.Filters.StudentFilters;
using dmitry_efimov_kt_31_20.Models;
using Microsoft.EntityFrameworkCore;
using NLog.Filters;

namespace dmitry_efimov_kt_31_20.StudentInterfaces
{
    public interface IStudentService
    {
        public Task<Student[]> GetStudentsByGroupAsync(ChangeInGrades filter, CancellationToken cancellationToken);
    }

    public class StudentFilterService : IStudentService
    {
        private readonly Academic_performanceDbContext _dbContext;

        public StudentFilterService(Academic_performanceDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<Student[]> GetStudentsByGroupAsync(ChangeInGrades filter, CancellationToken cancellationToken = default)
        {
            var students = _dbContext.Set<Student>().Where(w => w.Ratings.RaingsName == filter.RaingsName).ToArrayAsync(cancellationToken);
            return students;

        }
    }
}
