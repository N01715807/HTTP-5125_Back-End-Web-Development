namespace SchoolMVPmark2.Models
{
    public class Teacher
    {
        public int TeacherId { get; set; }
        public required string TeacherFname { get; set; }
        public required string TeacherLname { get; set; }
        public required string Employeenumber { get; set; }
        public DateTime Hiredate { get; set; }
        public decimal Salary { get; set; }
        public List<Course> CoursesTaught { get; set; } = new List<Course>();
    }
}
