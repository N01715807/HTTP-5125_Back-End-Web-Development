using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolMVP.Models;
using Microsoft.EntityFrameworkCore;

namespace SchoolMVP.Controllers
{
    [Route("api/teacher")]
    [ApiController]
    public class TeacherAPIController : ControllerBase
    {
        /// <summary>
        /// This API controller handles HTTP requests related to Teacher data.
        /// It provides endpoints to retrieve teacher information from the database.
        /// </summary>
        /// /// <summary>
        /// Initializes a new instance of the <see cref="TeacherAPIController"/> class with the specified database context.
        /// </summary>
        /// <param name="context">The database context used to access teacher data.</param>
        /// <summary>
        /// Retrieves a list of all teachers from the database.
        /// </summary>
        /// <returns>A list of <see cref="Teacher"/> objects in JSON format.</returns>
        private readonly SchoolDbContext _context;
        public TeacherAPIController(SchoolDbContext context)
        {
            _context = context;
        }
        [HttpGet("GetAllTeachers")]
        public async Task<IEnumerable<Teacher>> GetAllTeachers()
        {
            return await _context.Teachers.ToListAsync();
        }
    }
}
