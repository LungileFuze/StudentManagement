using Microsoft.AspNetCore.Mvc;
using FluentValidation;
using StudentManagement.Services.Interfaces;
using StudentManagement.ViewModels.Student;

namespace StudentManagement.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentService _studentService;
        private readonly IValidator<StudentViewModel> _validator;

        public StudentController(IStudentService studentService, IValidator<StudentViewModel> validator)
        {
            _studentService = studentService;
            _validator = validator;
        }
        public IActionResult Create()
        {
            return View();
        }
    }
}
