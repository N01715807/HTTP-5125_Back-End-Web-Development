/// <summary>
/// This class represents a Teacher from the database.
/// </summary>
namespace SchoolMVP.Models
{
    public class Teacher
    {
        /// <summary>
        /// A unique number that represents a teacher;It is the primary key in the database;
        /// </summary>
        public int TeacherId { get; set; }
        /// <summary>
        /// The first name of the teacher.
        ///  </summary>
        public string? FirstName { get; set; }
        /// <summary>
        /// The last name of the teacher.
        ///  </summary>
        public string? LastName { get; set; }
        /// <summary>
        /// The The employee company number of the teacher.
        ///  </summary>
        public string? EmployeeNumber { get; set; }
        /// <summary>
        /// The hire date of the teacher.
        ///  </summary>
        public DateTime HireDate { get; set; }
        /// <summary>
        /// The salary of the teacher.
        ///  </summary>
        public decimal Salary { get; set; }
    }
}
