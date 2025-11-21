namespace FinalProject_2258.Models
{
    public class Course
    {
        public int CourseId { get; set; }       // Primary Key

        public string CourseName { get; set; }
        public int Credits { get; set; }

        public int StudentId { get; set; }
        public string Semester { get; set; }    // e.g., "Fall 2024"

        public string Instructor { get; set; }  // Extra column
    }
}
