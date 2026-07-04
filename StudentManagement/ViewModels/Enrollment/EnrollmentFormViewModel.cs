using Microsoft.AspNetCore.Mvc.Rendering;
using StudentManagement.Enums;

namespace StudentManagement.ViewModels.Enrollment
{
    public class EnrollmentFormViewModel
    {
        public int Id { get; set; }

        public int StudentId { get; set; }

        public int CourseId { get; set; }

        public DateTime EnrolledDate { get; set; }

        public decimal? FinalMark { get; set; }

        public EnrollmentStatus Status { get; set; }

        public IEnumerable<SelectListItem> Students { get; set; } = new List<SelectListItem>();

        public IEnumerable<SelectListItem> Courses { get; set; } = new List<SelectListItem>();
    }
}
