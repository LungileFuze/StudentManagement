namespace StudentManagement.ViewModels.Course
{
    public class CourseViewModel
    {
        public int Id { get; set; }

        public string CourseCode { get; set; } = string.Empty;

        public string CourseName { get; set; } = string.Empty;

        public int Credits { get; set; }

        public int TotalStudents { get; set; }
    }
}
