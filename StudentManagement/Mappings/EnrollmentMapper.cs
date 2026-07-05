using StudentManagement.Models;
using StudentManagement.ViewModels.Enrollment;

namespace StudentManagement.Mappings
{
    public static class EnrollmentMapper
    {
        public static EnrollmentViewModel ToViewModel(this Enrollment enrollment)
            {
                return new EnrollmentViewModel
                {
                    Id = enrollment.Id,
                    StudentName = $"{enrollment.Student.FirstName} {enrollment.Student.LastName}",
                    CourseName = enrollment.Course.CourseName,
                    EnrolledDate = enrollment.EnrolledDate,
                    FinalMark = enrollment.FinalMark,
                    Status = enrollment.Status
                };
            }

            public static EnrollmentDetailsViewModel ToDetailsViewModel(this Enrollment enrollment)
            {
                return new EnrollmentDetailsViewModel
                {
                    Id = enrollment.Id,
                    StudentName = $"{enrollment.Student.FirstName} {enrollment.Student.LastName}",
                    StudentNumber = enrollment.Student.StudentNumber,
                    CourseCode = enrollment.Course.CourseCode,
                    CourseName = enrollment.Course.CourseName,
                    EnrolledDate = enrollment.EnrolledDate,
                    FinalMark = enrollment.FinalMark,
                    Status = enrollment.Status
                };
            }

            public static EnrollmentFormViewModel ToFormViewModel(this Enrollment enrollment)
            {
                return new EnrollmentFormViewModel
                {
                    Id = enrollment.Id,
                    StudentId = enrollment.StudentId,
                    CourseId = enrollment.CourseId,
                    EnrolledDate = enrollment.EnrolledDate,
                    FinalMark = enrollment.FinalMark,
                    Status = enrollment.Status
                };
            }

            public static Enrollment ToEntity(this EnrollmentFormViewModel model)
            {
                return new Enrollment
                {
                    Id = model.Id,
                    StudentId = model.StudentId,
                    CourseId = model.CourseId,
                    EnrolledDate = model.EnrolledDate,
                    FinalMark = model.FinalMark,
                    Status = model.Status
                };
            }

            public static void UpdateEntity(this Enrollment enrollment, EnrollmentFormViewModel model)
            {
                enrollment.StudentId = model.StudentId;
                enrollment.CourseId = model.CourseId;
                enrollment.EnrolledDate = model.EnrolledDate;
                enrollment.FinalMark = model.FinalMark;
                enrollment.Status = model.Status;
            }
    }

}
