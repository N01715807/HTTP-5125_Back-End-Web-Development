using System;

namespace SchoolMVPmark2.Models
{
    public class Course
    {
        public int CourseId { get; set; }

        // Required: course code like "ENG100"
        public string CourseCode { get; set; } = string.Empty;

        // Start and finish dates as DateTime
        public DateTime StartDate { get; set; } = DateTime.Now;
        public DateTime FinishDate { get; set; } = DateTime.Now;

        // Name of the course
        public string CourseName { get; set; } = string.Empty;
    }
}
