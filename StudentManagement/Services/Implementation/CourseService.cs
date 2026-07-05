using StudentManagement.Mappings;
using StudentManagement.Repositories.Interfaces;
using StudentManagement.Services.Interfaces;
using StudentManagement.ViewModels.Course;

namespace StudentManagement.Services.Implementation
{
    public class CourseService : ICourseService
    {
        private readonly ICourseRepository _courseRepository;

        public CourseService(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }

         public async Task<IEnumerable<CourseViewModel>> GetAllAsync()
        {
            var courses = await _courseRepository.GetAllAsync();
            return courses.Select(s => s.ToViewModel());
        }

        public async Task<CourseDetailsViewModel?> GetByIdAsync(int id)
        {
            var course = await _courseRepository.GetByIdAsync(id);
            if (course == null) throw new Exception("Student not found");
            return course.ToDetailsViewModel();
        }

        public async Task<CourseFormViewModel?> GetForEditAsync(int id)
        {
            var course = await _courseRepository.GetByIdAsync(id);
            if (course == null) throw new Exception("Course not found");
            return course.ToFormViewModel();
        }

        public async Task CreateAsync(CourseFormViewModel model)
        {
            var course = model.ToEntity();
            await _courseRepository.AddAsync(course);
            await _courseRepository.SaveChangesAsync();
        }

        public async Task UpdateAsync(CourseFormViewModel model)
        {
            var course = await _courseRepository.GetByIdAsync(model.Id);
            if (course == null) throw new Exception("Course not found");
            course.UpdateEntity(model);
            _courseRepository.Update(course);
            await _courseRepository.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var course = await _courseRepository.GetByIdAsync(id);
            if (course == null) throw new Exception("Course not found");
            _courseRepository.Delete(course);
            await _courseRepository.SaveChangesAsync();
        }

       
       
    }
}
