using StudentManagement.Mappings;
using StudentManagement.Repositories.Implementation;
using StudentManagement.Repositories.Interfaces;
using StudentManagement.Services.Interfaces;
using StudentManagement.ViewModels.Course;
using StudentManagement.ViewModels.Student;

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

        public async Task<bool> UpdateAsync(CourseFormViewModel model)
        {
            var course = await _courseRepository.GetByIdAsync(model.Id);
            if (course == null) return false;
            course.UpdateEntity(model);
            _courseRepository.Update(course);
            await _courseRepository.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var course = await _courseRepository.GetByIdAsync(id);
            if (course == null) return false;
            _courseRepository.Delete(course);
            await _courseRepository.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<CourseViewModel>> SearchAsync(string searchTerm)
        {
            var courses = await _courseRepository.SearchAsync(searchTerm);

            return courses.Select(c => c.ToViewModel());
        }



    }
}
