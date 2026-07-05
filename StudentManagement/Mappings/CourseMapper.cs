using StudentManagement.Models;
using StudentManagement.ViewModels.Course;

namespace StudentManagement.Mappings
{
    public static class CourseMapper
    {
        public static CourseViewModel ToViewModel(this Course course)
        {
            return new CourseViewModel
            {
                Id = course.Id,
                CourseCode = course.CourseCode,
                CourseName = course.CourseName,
                Credits = course.Credits,
                TotalStudents = course.Enrollments.Count
            };
        }

        public static CourseDetailsViewModel ToDetailsViewModel(this Course course)
        {
            return new CourseDetailsViewModel
            {
                Id = course.Id,
                CourseCode = course.CourseCode,
                CourseName = course.CourseName,
                Credits = course.Credits,
                Students = course.Enrollments
                    .Select(e => $"{e.Student.FirstName} {e.Student.LastName}")
                    .ToList()
            };
        }

        public static CourseFormViewModel ToFormViewModel(this Course course)
        {
            return new CourseFormViewModel
            {
                Id = course.Id,
                CourseCode = course.CourseCode,
                CourseName = course.CourseName,
                Credits = course.Credits
            };
        }

        public static Course ToEntity(this CourseFormViewModel model)
        {
            return new Course
            {
                Id = model.Id,
                CourseCode = model.CourseCode,
                CourseName = model.CourseName,
                Credits = model.Credits
            };
        }

        public static void UpdateEntity(this Course course, CourseFormViewModel model)
        {
            course.CourseCode = model.CourseCode;
            course.CourseName = model.CourseName;
            course.Credits = model.Credits;
        }
    }

}
