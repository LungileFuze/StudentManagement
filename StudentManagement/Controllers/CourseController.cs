using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using StudentManagement.Helpers;
using StudentManagement.Services.Interfaces;
using StudentManagement.Validators;
using StudentManagement.ViewModels.Course;

namespace StudentManagement.Controllers
{
    public class CourseController : Controller
    {
        private readonly ICourseService _courseService;
        private readonly IValidator<CourseFormViewModel> _validator;

        public CourseController(ICourseService courseService, IValidator<CourseFormViewModel> validator)
        {
            _courseService = courseService;
            _validator = validator;
        }

        public async Task<IActionResult> Index()
        {
            var courses = await _courseService.GetAllAsync();
            return View(courses);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View(new CourseFormViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CourseFormViewModel model)
        {
            var validationResult = await _validator.ValidateAsync(model);

            if (!validationResult.IsValid)
            {
                validationResult.AddToModelState(ModelState);
                return View(model);
            }

            await _courseService.CreateAsync(model);

            TempData[TempDataKeys.Success] = "Course created successfully.";

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var course = await _courseService.GetByIdAsync(id);

            if (course == null)
                return NotFound();

            return View(course);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var course = await _courseService.GetForEditAsync(id);

            if (course == null)
                return NotFound();

            return View(course);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(CourseFormViewModel model)
        {
            var validationResult = await _validator.ValidateAsync(model);

            if (!validationResult.IsValid)
            {
                validationResult.AddToModelState(ModelState);
                return View(model);
            }

            if (!await _courseService.UpdateAsync(model))
                return NotFound();

            TempData[TempDataKeys.Success] = "Course updated successfully.";

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var course = await _courseService.GetByIdAsync(id);

            if (course == null)
                return NotFound();

            return View(course);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (!await _courseService.DeleteAsync(id))
                return NotFound();

            TempData[TempDataKeys.Success] = "Course deleted successfully.";

            return RedirectToAction(nameof(Index));
        }
    }
}