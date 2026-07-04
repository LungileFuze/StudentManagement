namespace StudentManagement.ViewModels.Course
{
    public class CourseDetailsViewModel
    {
        public int Id { get; set; }

        public string CourseCode { get; set; } = string.Empty;

        public string CourseName { get; set; } = string.Empty;

        public int Credits { get; set; }

        public IEnumerable<string> Students { get; set; } = new List<string>();
    }
}
