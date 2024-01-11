using dmitry_efimov_kt_31_20.Filters.StudentFilters;
using dmitry_efimov_kt_31_20.StudentInterfaces;
using Microsoft.AspNetCore.Mvc;

namespace dmitry_efimov_kt_31_20.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class StudentsController : ControllerBase
    {
        private readonly ILogger<StudentsController> _logger;

        private readonly IStudentService _studentFilter;

        public StudentsController(ILogger<StudentsController> logger, IStudentService studentFilter)
        {
            _logger = logger;
            _studentFilter = studentFilter;
        }

        [HttpPost(Name = "GetStudentByGroup")]
        public async Task<IActionResult> GetStudentsByGroupAsync(ChangeInGrades filter, CancellationToken cancellationToken = default)
        {
            var students = await _studentFilter.GetStudentsByGroupAsync(filter, cancellationToken);

            return Ok(students);
        }
    }
}
