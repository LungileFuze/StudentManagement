using StudentManagement.Mappings;
using StudentManagement.Repositories.Interfaces;
using StudentManagement.Services.Interfaces;
using StudentManagement.ViewModels.Student;

namespace StudentManagement.Services.Implementation
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;

        public StudentService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public async Task<IEnumerable<StudentViewModel>> GetAllAsync()
        {
            var students = await _studentRepository.GetAllAsync();
            return students.Select(s => s.ToViewModel()).ToList();
        }

        public async Task<StudentDetailsViewModel?> GetByIdAsync(int id)
        {
            var student = await _studentRepository.GetByIdAsync(id);
            if (student == null)throw new Exception("Student not found");
            return student.ToDetailsViewModel();
        }

        public async Task<StudentFormViewModel?> GetForEditAsync(int id)
        {
            var student = await _studentRepository.GetByIdAsync(id);
            if (student == null) throw new Exception("Student not found");
            return student.ToFormViewModel();
        }

        public async Task CreateAsync(StudentFormViewModel model)
        {
            var student = model.ToEntity();
            await _studentRepository.AddAsync(student);
            await _studentRepository.SaveChangesAsync();
        }

        public async Task UpdateAsync(StudentFormViewModel model)
        {
            var student = await _studentRepository.GetByIdAsync(model.Id);
            if (student == null) throw new Exception("Student not found");
            student.UpdateEntity(model);
            _studentRepository.Update(student);
            await _studentRepository.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var student = await _studentRepository.GetByIdAsync(id);
            if (student == null)throw new Exception("Student not found");
            _studentRepository.Delete(student);
            await _studentRepository.SaveChangesAsync();
        }
    }
}

