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
        private readonly SchoolDbContext _context;
        /// <summary>
        /// Initializes a new instance of the <see cref="TeacherAPIController"/> class with the specified database context.
        /// </summary>
        public TeacherAPIController(SchoolDbContext context)
        {
            _context = context;
        }
        /// <summary>
        /// Retrieves a list of all teachers from the database.
        /// </summary>
        /// <returns>A list of Teacher objects.</returns>
        [HttpGet("GetAllTeachers")]
        public async Task<IEnumerable<Teacher>> GetAllTeachers()
        {
            return await _context.Teachers.ToListAsync();
        }

        [HttpGet("FindTeacher/{id}")]
        public async Task<ActionResult<Teacher>> FindTeacher(int id)
        {
            var teacher = await _context.Teachers.FindAsync(id);
            if (teacher == null)
            {
                return NotFound();
            }
            return Ok(teacher);
        }
    }
}
