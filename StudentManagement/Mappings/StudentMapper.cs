using StudentManagement.Models;
using StudentManagement.ViewModels.Student;

namespace StudentManagement.Mappings
{
    public static class StudentMapper
    {
        public static StudentViewModel ToViewModel(this Student student)
        {
            return new StudentViewModel
            {
                Id = student.Id,
                StudentNumber = student.StudentNumber,
                FullName = $"{student.FirstName} {student.LastName}",
                Email = student.Email,
                Gender = student.Gender
            };
        }

        public static StudentDetailsViewModel ToDetailsViewModel(this Student student)
        {
            return new StudentDetailsViewModel
            {
                Id = student.Id,
                StudentNumber = student.StudentNumber,
                FullName = $"{student.FirstName} {student.LastName}",
                Email = student.Email,
                Gender = student.Gender,
                Courses = student.Enrollments
                    .Select(e => e.Course.CourseName)
                    .ToList()
            };
        }

        public static StudentFormViewModel ToFormViewModel(this Student student)
        {
            return new StudentFormViewModel
            {
                Id = student.Id,
                StudentNumber = student.StudentNumber,
                FirstName = student.FirstName,
                LastName = student.LastName,
                Email = student.Email,
                Gender = student.Gender
            };
        }

        public static Student ToEntity(this StudentFormViewModel model)
        {
            return new Student
            {
                Id = model.Id,
                StudentNumber = model.StudentNumber,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                Gender = model.Gender
            };
        }

        public static void UpdateEntity(this Student student, StudentFormViewModel model)
        {
            student.StudentNumber = model.StudentNumber;
            student.FirstName = model.FirstName;
            student.LastName = model.LastName;
            student.Email = model.Email;
            student.Gender = model.Gender;
        }
    }
}
