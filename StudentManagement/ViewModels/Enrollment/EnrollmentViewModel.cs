using StudentManagement.Enums;

namespace StudentManagement.ViewModels.Enrollment
{
    public class EnrollmentViewModel
    {
        public int Id { get; set; }

        public string StudentName { get; set; } = string.Empty;

        public string CourseName { get; set; } = string.Empty;

        public DateTime EnrolledDate { get; set; }

        public decimal? FinalMark { get; set; }

        public EnrollmentStatus Status { get; set; }
    }
}
