using StudentManagement.ViewModels.Enrollment;

namespace StudentManagement.Services.Interfaces
{
    public interface IEnrollmentService
    {
        Task<IEnumerable<EnrollmentViewModel>> GetAllAsync();

        Task<EnrollmentDetailsViewModel?> GetByIdAsync(int id);

        Task<EnrollmentFormViewModel?> GetForEditAsync(int id);

        Task CreateAsync(EnrollmentFormViewModel model);

        Task<bool> UpdateAsync(EnrollmentFormViewModel model);

        Task<bool> DeleteAsync(int id);
    }
}
