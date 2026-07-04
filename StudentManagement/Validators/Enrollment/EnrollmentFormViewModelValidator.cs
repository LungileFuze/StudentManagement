using FluentValidation;
using StudentManagement.ViewModels.Enrollment;

namespace StudentManagement.Validators.Enrollment
{
    public class EnrollmentFormViewModelValidator : AbstractValidator<EnrollmentFormViewModel>
    {
        public EnrollmentFormViewModelValidator()
        {
            RuleFor(x => x.StudentId).GreaterThan(0).WithMessage("Please select a student.");

            RuleFor(x => x.CourseId).GreaterThan(0).WithMessage("Please select a course.");

            RuleFor(x => x.EnrolledDate).NotEmpty().WithMessage("Enrollment date is required.");

            RuleFor(x => x.FinalMark).InclusiveBetween(0, 100).When(x => x.FinalMark.HasValue)
                    .WithMessage("Final mark must be between 0 and 100.");

            RuleFor(x => x.Status).IsInEnum().WithMessage("Please select a valid enrollment status.");
        }
    }
}
