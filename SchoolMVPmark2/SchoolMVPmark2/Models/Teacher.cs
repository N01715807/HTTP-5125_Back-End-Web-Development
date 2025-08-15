namespace SchoolMVPmark2.Models
{
    public class Teacher
    {
        /// <summary>Primary key for teacher.</summary>
        public int TeacherId { get; set; }
        /// <summary>First name (required).</summary>
        public required string TeacherFname { get; set; }
        /// <summary>Last name (required).</summary>
        public required string TeacherLname { get; set; }
        /// <summary>Employee number like T381.</summary>
        public required string Employeenumber { get; set; }
        /// <summary>Hire date (cannot be in the future).</summary>
        public DateTime Hiredate { get; set; }
        /// <summary>Salary in dollars (>= 0).</summary>
        public decimal Salary { get; set; }
        public List<Course> CoursesTaught { get; set; } = new List<Course>();
    }
}
