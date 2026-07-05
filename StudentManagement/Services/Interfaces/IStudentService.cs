using StudentManagement.ViewModels.Student;

namespace StudentManagement.Services.Interfaces
{
    public interface IStudentService
    {
        Task<IEnumerable<StudentViewModel>> GetAllAsync();

        Task<StudentDetailsViewModel?> GetByIdAsync(int id);

        Task<StudentFormViewModel?> GetForEditAsync(int id);

        Task CreateAsync(StudentFormViewModel model);

        Task UpdateAsync(StudentFormViewModel model);

        Task DeleteAsync(int id);
    }
}
