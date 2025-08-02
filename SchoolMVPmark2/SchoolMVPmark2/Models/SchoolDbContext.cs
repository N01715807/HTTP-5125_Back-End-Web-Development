using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace SchoolMVPmark2.Models
{
    /// <summary>
    /// Provides methods to interact with the MySQL School database for Teacher-related operations.
    /// </summary>
    public class SchoolDbContext
    {
        // MySQL connection string
        private readonly string connectionString = "server=localhost;user=root;password=;database=school;";

        /// <summary>
        /// Retrieves all teachers from the database.
        /// </summary>
        /// <returns>A list of Teacher objects</returns>
        public List<Teacher> GetAllTeachers()
        {
            var teachers = new List<Teacher>();

            using var conn = new MySqlConnection(connectionString);
            try
            {
                conn.Open();
                var query = "SELECT * FROM teachers";
                using var cmd = new MySqlCommand(query, conn);
                using var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    teachers.Add(new Teacher
                    {
                        TeacherId = reader.GetInt32("teacherid"),
                        TeacherFname = reader.GetString("teacherfname"),
                        TeacherLname = reader.GetString("teacherlname"),
                        Employeenumber = reader.GetString("employeenumber"),
                        Hiredate = reader.GetDateTime("hiredate"),
                        Salary = reader.GetDecimal("salary")
                    });
                }
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine("Error loading teachers: " + ex.Message);
            }

            return teachers;
        }

        /// <summary>
        /// Finds a specific teacher by ID, including their assigned courses.
        /// </summary>
        /// <param name="id">Teacher ID</param>
        /// <returns>A Teacher object or null if not found</returns>
        public Teacher? FindTeacher(int id)
        {
            Teacher? teacher = null;

            using var conn = new MySqlConnection(connectionString);
            try
            {
                conn.Open();
                var query = @"SELECT * FROM teachers 
                            LEFT JOIN courses ON teachers.teacherid = courses.teacherid
                            WHERE teachers.teacherid = @id";

                using var cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", id);
                using var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    if (teacher == null)
                    {
                        teacher = new Teacher
                        {
                            TeacherId = reader.GetInt32("teacherid"),
                            TeacherFname = reader.GetString("teacherfname"),
                            TeacherLname = reader.GetString("teacherlname"),
                            Employeenumber = reader.GetString("employeenumber"),
                            Hiredate = reader.GetDateTime("hiredate"),
                            Salary = reader.GetDecimal("salary"),
                            CoursesTaught = new List<Course>()
                        };
                    }

                    if (!reader.IsDBNull(reader.GetOrdinal("classid")))
                    {
                        teacher.CoursesTaught.Add(new Course
                        {
                            CourseId = reader.GetInt32("courseid"),
                            CourseCode = reader.GetString("coursecode"),
                            CourseName = reader.GetString("coursename"),
                            StartDate = reader.GetDateTime("startdate"),
                            FinishDate = reader.GetDateTime("finishdate")
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine("Error finding teacher: " + ex.Message);
            }

            return teacher;
        }

        /// <summary>
        /// Retrieves teachers hired between two specific dates.
        /// </summary>
        /// <param name="minDate">Start of the date range</param>
        /// <param name="maxDate">End of the date range</param>
        /// <returns>List of teachers within the specified hire date range</returns>
        public List<Teacher> GetTeachersByHireDate(DateTime minDate, DateTime maxDate)
        {
            var teachers = new List<Teacher>();

            using var conn = new MySqlConnection(connectionString);
            try
            {
                conn.Open();
                var query = "SELECT * FROM teachers WHERE hiredate BETWEEN @min AND @max";
                using var cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@min", minDate);
                cmd.Parameters.AddWithValue("@max", maxDate);

                using var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    teachers.Add(new Teacher
                    {
                        TeacherId = reader.GetInt32("teacherid"),
                        TeacherFname = reader.GetString("teacherfname"),
                        TeacherLname = reader.GetString("teacherlname"),
                        Employeenumber = reader.GetString("employeenumber"),
                        Hiredate = reader.GetDateTime("hiredate"),
                        Salary = reader.GetDecimal("salary")
                    });
                }
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine("Error loading teachers by hire date: " + ex.Message);
            }

            return teachers;
        }
    }
}
