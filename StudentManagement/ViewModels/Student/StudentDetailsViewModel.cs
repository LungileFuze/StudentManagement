using StudentManagement.Enums;

namespace StudentManagement.ViewModels.Student
{
    public class StudentDetailsViewModel
    {
        public int Id { get; set; }

        public string StudentNumber { get; set; } = string.Empty;

        public string FullName { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public Gender Gender { get; set; }

        public IEnumerable<string> Courses { get; set; } = new List<string>();
    }
}
