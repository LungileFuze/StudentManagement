using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using StudentManagement.Services.Interfaces;
using StudentManagement.Validators;
using StudentManagement.ViewModels.Enrollment;

namespace StudentManagement.Controllers
{
    public class EnrollmentController : Controller
    {
        private readonly IEnrollmentService _enrollmentService;
        private readonly IStudentService _studentService;
        private readonly ICourseService _courseService;
        private readonly IValidator<EnrollmentFormViewModel> _validator;

        public EnrollmentController(IEnrollmentService enrollmentService,  IValidator<EnrollmentFormViewModel> validator, IStudentService studentService, ICourseService courseService)
        {
            _enrollmentService = enrollmentService;
            _validator = validator;
            _studentService = studentService;
            _courseService = courseService;
        }

        public async Task<IActionResult> Index()
        {
            var enrollments = await _enrollmentService.GetAllAsync();
            return View(enrollments);
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var model = new EnrollmentFormViewModel();

            await PopulateDropdownsAsync(model);

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(EnrollmentFormViewModel model)
        {
            var validationResult = await _validator.ValidateAsync(model);

            if (!validationResult.IsValid)
            {
                validationResult.AddToModelState(ModelState);

                await PopulateDropdownsAsync(model);

                return View(model);
            }

            await _enrollmentService.CreateAsync(model);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var enrollment = await _enrollmentService.GetByIdAsync(id);

            if (enrollment == null) return NotFound();

            return View(enrollment);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var model = await _enrollmentService.GetForEditAsync(id);

            if (model == null) return NotFound();

            await PopulateDropdownsAsync(model);

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EnrollmentFormViewModel model)
        {
            var validationResult = await _validator.ValidateAsync(model);

            if (!validationResult.IsValid)
            {
                validationResult.AddToModelState(ModelState);

                await PopulateDropdownsAsync(model);

                return View(model);
            }

            if (!await _enrollmentService.UpdateAsync(model))
                return NotFound();

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var enrollment = await _enrollmentService.GetByIdAsync(id);

            if (enrollment == null) return NotFound();

            return View(enrollment);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (!await _enrollmentService.DeleteAsync(id))
                return NotFound();

            return RedirectToAction(nameof(Index));
        }

        private async Task PopulateDropdownsAsync(EnrollmentFormViewModel model)
        {
            var students = await _studentService.GetAllAsync();
            var courses = await _courseService.GetAllAsync();

            model.Students = students.Select(s => new SelectListItem
            {
                Value = s.Id.ToString(),
                Text = $"{s.StudentNumber} - {s.FullName}"
            });

            model.Courses = courses.Select(c => new SelectListItem
            {
                Value = c.Id.ToString(),
                Text = $"{c.CourseCode} - {c.CourseName}"
            });
        }
    }

}
