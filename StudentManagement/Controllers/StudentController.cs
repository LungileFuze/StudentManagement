using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StudentManagement.Helpers;
using StudentManagement.Services.Interfaces;
using StudentManagement.Validators;
using StudentManagement.ViewModels.Student;

namespace StudentManagement.Controllers
{
    [Authorize]
    public class StudentController : Controller
    {
        private readonly IStudentService _studentService;
        private readonly IValidator<StudentFormViewModel> _validator;

        public StudentController(IStudentService studentService, IValidator<StudentFormViewModel> validator)
        {
            _studentService = studentService;
            _validator = validator;
        }

        public async Task<IActionResult> Index()
        {
            var students = await _studentService.GetAllAsync();
            return View(students);
        }

        public async Task<IActionResult> Details(int id)
        {
            var student = await _studentService.GetByIdAsync(id);
            if (student == null)return NotFound();
            return View(student);
        }

        [HttpGet]
        [Authorize(Roles = Roles.Admin)]
        public IActionResult Create()
        {
            return View(new StudentFormViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = Roles.Admin)]
        public async Task<IActionResult> Create(StudentFormViewModel model)
        {
            var validationResult = await _validator.ValidateAsync(model);

            if (!validationResult.IsValid)
            {
                validationResult.AddToModelState(ModelState);

                return View(model);
            }

            await _studentService.CreateAsync(model);

            TempData[TempDataKeys.Success] = "Student created successfully.";

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        [Authorize(Roles = Roles.Admin)]
        public async Task<IActionResult> Edit(int id)
        {
            var student = await _studentService.GetForEditAsync(id);
            if (student == null)return NotFound();
            return View(student);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = Roles.Admin)]
        public async Task<IActionResult> Edit(StudentFormViewModel model)
        {
            var validationResult = await _validator.ValidateAsync(model);

            if (!validationResult.IsValid)
            {
                validationResult.AddToModelState(ModelState);
                return View(model);
            }
            var updated = await _studentService.UpdateAsync(model);

            if (!updated)
            {
                return NotFound();
            }

            TempData[TempDataKeys.Success] = "Student updated successfully.";

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        [Authorize(Roles = Roles.Admin)]
        public async Task<IActionResult> Delete(int id)
        {
            var student = await _studentService.GetByIdAsync(id);
            if (student == null) return NotFound();
            return View(student);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = Roles.Admin)]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var deleted = await _studentService.DeleteAsync(id);

            if (!deleted)
            {
                return NotFound();
            }

            TempData[TempDataKeys.Success] = "Student deleted successfully.";

            return RedirectToAction(nameof(Index));
        }
    }
}
