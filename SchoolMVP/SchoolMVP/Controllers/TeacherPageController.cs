using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolMVP.Models;

namespace SchoolMVP.Controllers
{
    public class TeacherPageController : Controller
    {
        private readonly SchoolDbContext _context;
        public TeacherPageController(SchoolDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Displays a list of all teachers.
        /// </summary>
        public async Task<IActionResult> List()
        {
            var teachers = await _context.Teachers.ToListAsync();
            return View("List", teachers);
        }

        /// <summary>
        /// Displays a specific teacher based on their ID.
        /// </summary>
        public async Task<IActionResult> Show(int id)
        {
            var teacher = await _context.Teachers.FindAsync(id);
            if (teacher == null)
            {
                return NotFound();
            }

            return View("Show", teacher);
        }
    }
}
