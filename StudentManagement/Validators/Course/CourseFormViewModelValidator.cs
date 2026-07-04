using FluentValidation;
using StudentManagement.ViewModels.Course;

namespace StudentManagement.Validators.Course
{
    public class CourseFormViewModelValidator : AbstractValidator<CourseFormViewModel>
    {
        public CourseFormViewModelValidator()
        {
            RuleFor(x => x.CourseCode).NotEmpty().WithMessage("Course code is required.")
                .MaximumLength(20).WithMessage("Course code cannot exceed 20 characters.");

            RuleFor(x => x.CourseName).NotEmpty().WithMessage("Course name is required.")
                .MaximumLength(100).WithMessage("Course name cannot exceed 100 characters.");

            RuleFor(x => x.Credits).GreaterThan(0).WithMessage("Credits must be greater than zero.");
        }
    }
}
