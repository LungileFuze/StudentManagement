using StudentManagement.ViewModels.Course;

namespace StudentManagement.Services.Interfaces
{
    public interface ICourseService
    {
        Task<IEnumerable<CourseViewModel>> GetAllAsync();

        Task<CourseDetailsViewModel?> GetByIdAsync(int id);

        Task<CourseFormViewModel?> GetForEditAsync(int id);

        Task CreateAsync(CourseFormViewModel model);

        Task UpdateAsync(CourseFormViewModel model);

        Task DeleteAsync(int id);
    }
}
