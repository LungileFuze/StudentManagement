using Microsoft.AspNetCore.Mvc.Rendering;
using StudentManagement.Enums;

namespace StudentManagement.ViewModels.Enrollment
{
    public class EnrollmentFormViewModel
    {
        public int Id { get; set; }

        public int StudentId { get; set; }

        public int CourseId { get; set; }

        public DateTime EnrolledDate { get; set; } = DateTime.Today;

        public decimal? FinalMark { get; set; }

        public EnrollmentStatus Status { get; set; } = EnrollmentStatus.Active;

        //public IEnumerable<SelectListItem> Students { get; set; } = new List<SelectListItem>();
        // Dropdown data
        public IEnumerable<SelectListItem> Students { get; set; }  = Enumerable.Empty<SelectListItem>();

        public IEnumerable<SelectListItem> Courses { get; set; } = Enumerable.Empty<SelectListItem>();

        //public IEnumerable<SelectListItem> Courses { get; set; } = new List<SelectListItem>();
    }
}
