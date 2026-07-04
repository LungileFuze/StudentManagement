using FluentValidation;
using StudentManagement.ViewModels.Student;

namespace StudentManagement.Validators.Student
{
    public class StudentFormViewModelValidator : AbstractValidator<StudentFormViewModel>
    {
        public StudentFormViewModelValidator()
        {
            RuleFor(x => x.StudentNumber).NotEmpty().WithMessage("Student number is required.")
                .MaximumLength(20).WithMessage("Student number cannot exceed 20 characters.");

            RuleFor(x => x.FirstName).NotEmpty().WithMessage("First name is required.")
                .MaximumLength(50).WithMessage("First name cannot exceed 50 characters.");

            RuleFor(x => x.LastName).NotEmpty().WithMessage("Last name is required.")
                .MaximumLength(50).WithMessage("Last name cannot exceed 50 characters.");

            RuleFor(x => x.Email).NotEmpty().WithMessage("Email address is required.")
                .EmailAddress().WithMessage("Invalid email address format.").
                MaximumLength(100).WithMessage("Email address cannot exceed 100 characters.");

            RuleFor(x => x.Gender).IsInEnum();
        }
    }
}
