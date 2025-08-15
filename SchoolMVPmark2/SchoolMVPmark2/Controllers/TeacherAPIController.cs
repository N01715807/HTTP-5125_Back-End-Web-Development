using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using SchoolMVPmark2.Models;
using System.Collections.Generic;

namespace SchoolMVPmark2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherAPIController : ControllerBase
    {
        private readonly string connectionString = "server=localhost;user=root;password=;database=school;";
        private readonly SchoolDbContext _context = new SchoolDbContext();

        /// <summary>
        /// Returns a list of all teachers from the database.
        /// </summary>
        /// <remarks>
        /// Example: GET /api/teacherapi/GetAllTeachers
        /// </remarks>
        /// <returns>A JSON object with teacher records.</returns>
        [HttpGet("GetAllTeachers")]
        public ActionResult<object> GetAllTeachers()
        {
            var teachers = _context.GetAllTeachers();

            return Ok(new
            {
                Response = "Success",
                Teachers = teachers
            });
        }

        /// <summary>
        /// Retrieves a single teacher by ID.
        /// </summary>
        /// <param name="id">The ID of the teacher to find.</param>
        /// <remarks>
        /// Example: GET /api/teacherapi/FindTeacher/5
        /// </remarks>
        /// <returns>
        /// A teacher object if found; otherwise, an error message.
        /// </returns>
        [HttpGet("FindTeacher/{id}")]
        public ActionResult<object> FindTeacher(int id)
        {
            if (id <= 0)
            {
                return BadRequest(new
                {
                    Response = "Error",
                    Message = "Invalid teacher ID."
                });
            }

            var teacher = _context.FindTeacher(id);

            if (teacher == null)
            {
                return NotFound(new
                {
                    Response = "Error",
                    Message = $"No teacher found with ID {id}."
                });
            }

            return Ok(new
            {
                Response = "Success",
                Teacher = teacher
            });
        }

        /// <summary>
        /// Adds a new teacher to the database.
        /// </summary>
        /// <param name="teacher">The teacher object sent in the request body.</param>
        /// <remarks>
        /// Example JSON:
        /// {
        ///   "TeacherFname": "Jane",
        ///   "TeacherLname": "Smith",
        ///   "Employeenumber": "T101",
        ///   "Hiredate": "2024-05-10T00:00:00",
        ///   "Salary": 64000
        /// }
        /// POST /api/teacherapi/add
        /// </remarks>
        /// <returns>
        /// A result message indicating success or failure.
        /// </returns>
        [HttpPost("add")]
        public IActionResult AddTeacher([FromBody] Teacher teacher)
        {
            using var conn = new MySqlConnection(connectionString);
            conn.Open();

            string query = @"
                INSERT INTO teachers 
                (teacherfname, teacherlname, employeenumber, hiredate, salary)
                VALUES 
                (@fname, @lname, @enum, @hire, @salary)";

            var cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@fname", teacher.TeacherFname);
            cmd.Parameters.AddWithValue("@lname", teacher.TeacherLname);
            cmd.Parameters.AddWithValue("@enum", teacher.Employeenumber);
            cmd.Parameters.AddWithValue("@hire", teacher.Hiredate);
            cmd.Parameters.AddWithValue("@salary", teacher.Salary);

            int rowsAffected = cmd.ExecuteNonQuery();

            return Ok(new
            {
                Result = rowsAffected > 0 ? "Success" : "Failed"
            });
        }

        /// <summary>
        /// Deletes a teacher based on their ID.
        /// </summary>
        /// <param name="id">The ID of the teacher to delete.</param>
        /// <remarks>
        /// Example: DELETE /api/teacherapi/delete/4
        /// </remarks>
        /// <returns>
        /// A result message: "Deleted" if successful, "Not Found" otherwise.
        /// </returns>
        [HttpDelete("delete/{id}")]
        public IActionResult DeleteTeacher(int id)
        {
            using var conn = new MySqlConnection(connectionString);
            conn.Open();

            string query = "DELETE FROM teachers WHERE teacherid = @id";

            var cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@id", id);

            int deleted = cmd.ExecuteNonQuery();

            return Ok(new
            {
                Result = deleted > 0 ? "Deleted" : "Not Found"
            });
        }
        /// <summary>
        /// Updates a teacher's information by ID.
        /// </summary>
        /// <param name="id">Teacher ID to update. Must be positive.</param>
        /// <param name="teacher">Teacher object with updated details.</param>
        /// <remarks>
        /// Validates that:
        /// - ID is valid and teacher exists
        /// - Names are not empty
        /// - Hire date is not in the future
        /// - Salary is non-negative
        /// </remarks>
        /// <returns>
        /// 200 OK if updated, 400 Bad Request for invalid data,
        /// 404 Not Found if teacher doesn't exist,
        /// 500 Internal Server Error if update fails.
        /// </returns>
        [HttpPut("update/{id}")]
        public IActionResult UpdateTeacher(int id, [FromBody] Teacher teacher)
        {
            if (id <= 0 || teacher == null)
                return BadRequest(new { Response = "Error", Message = "Invalid id or payload." });
            if (string.IsNullOrWhiteSpace(teacher.TeacherFname) ||
                string.IsNullOrWhiteSpace(teacher.TeacherLname))
                return BadRequest(new { Response = "Error", Message = "Name cannot be empty." });
            if (teacher.Hiredate > DateTime.Now)
                return BadRequest(new { Response = "Error", Message = "Hire date cannot be in the future." });
            if (teacher.Salary < 0)
                return BadRequest(new { Response = "Error", Message = "Salary cannot be negative." });

            using var conn = new MySqlConnection(connectionString);
            conn.Open();

            using (var check = new MySqlCommand("SELECT COUNT(*) FROM teachers WHERE teacherid=@id", conn))
            {
                check.Parameters.AddWithValue("@id", id);
                if (Convert.ToInt32(check.ExecuteScalar()) == 0)
                    return NotFound(new { Response = "Error", Message = $"Teacher {id} not found." });
            }

            string sql = @"UPDATE teachers SET teacherfname=@f, teacherlname=@l, employeenumber=@e, hiredate=@h, salary=@s WHERE teacherid=@id";
            using var cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@f", teacher.TeacherFname);
            cmd.Parameters.AddWithValue("@l", teacher.TeacherLname);
            cmd.Parameters.AddWithValue("@e", teacher.Employeenumber);
            cmd.Parameters.AddWithValue("@h", teacher.Hiredate);
            cmd.Parameters.AddWithValue("@s", teacher.Salary);
            cmd.Parameters.AddWithValue("@id", id);

            int rows = cmd.ExecuteNonQuery();
            return rows == 1
                ? Ok(new { Response = "Success", Message = $"Teacher {id} updated." })
                : StatusCode(500, new { Response = "Error", Message = "Update failed." });
        }
    }
}
