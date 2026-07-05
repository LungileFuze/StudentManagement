using StudentManagement.ViewModels.Student;

namespace StudentManagement.Services.Interfaces
{
    public interface IStudentService
    {
        Task<IEnumerable<StudentViewModel>> GetAllAsync();

        Task<StudentDetailsViewModel?> GetByIdAsync(int id);

        Task<StudentFormViewModel?> GetForEditAsync(int id);

        Task CreateAsync(StudentFormViewModel model);

        Task<bool> UpdateAsync(StudentFormViewModel model);

        Task<bool> DeleteAsync(int id);
    }
}
