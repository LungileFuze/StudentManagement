using StudentManagement.Mappings;
using StudentManagement.Repositories.Interfaces;
using StudentManagement.Services.Interfaces;
using StudentManagement.ViewModels.Enrollment;

namespace StudentManagement.Services.Implementation
{
    public class EnrollmentService : IEnrollmentService
    {
        private readonly IEnrollmentRepository _enrollmentRepository;

        public EnrollmentService(IEnrollmentRepository enrollmentRepository)
        {
            _enrollmentRepository = enrollmentRepository;
        }
        public async Task<IEnumerable<EnrollmentViewModel>> GetAllAsync()
        {
            var enrollments = await _enrollmentRepository.GetAllAsync();
            return enrollments.Select(e => e.ToViewModel()).ToList();
        }

        public async Task<EnrollmentDetailsViewModel?> GetByIdAsync(int id)
        {
            var enrollment = await _enrollmentRepository.GetByIdAsync(id);
            if (enrollment == null) return null;
            return enrollment.ToDetailsViewModel();
        }

        public async Task<EnrollmentFormViewModel?> GetForEditAsync(int id)
        {
            var enrollment = await _enrollmentRepository.GetByIdAsync(id);
            if (enrollment == null) return null;
            return enrollment.ToFormViewModel();
        }
        public async Task CreateAsync(EnrollmentFormViewModel model)
        {
            var enrollment = model.ToEntity();
            await _enrollmentRepository.AddAsync(enrollment);
            await _enrollmentRepository.SaveChangesAsync();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var enrollment = await _enrollmentRepository.GetByIdAsync(id);
            if (enrollment == null) return false;
            _enrollmentRepository.Delete(enrollment);
            await _enrollmentRepository.SaveChangesAsync();
            return true;
        }

       
        public async Task<bool> UpdateAsync(EnrollmentFormViewModel model)
        {
            var enrollment = await _enrollmentRepository.GetByIdAsync(model.Id);
            if(enrollment == null) return false;
            enrollment.UpdateEntity(model);
            await _enrollmentRepository.SaveChangesAsync();
            return true;
        }
    }
}
