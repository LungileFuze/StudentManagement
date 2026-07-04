using StudentManagement.Enums;

namespace StudentManagement.Models
{
    public class Enrollment
    {
        public int Id { get; set; }

        public int StudentId { get; set; }

        public Student Student { get; set; } = null!;

        public int CourseId { get; set; }

        public Course Course { get; set; } = null!;

        public DateTime EnrolledDate { get; set; }

        public decimal? FinalMark { get; set; }

        public EnrollmentStatus Status { get; set; } = EnrollmentStatus.Active;
    }
}
