using StudentManagement.Models;

namespace StudentManagement.Repositories.Interfaces
{
    public interface IStudentRepository : IRepository<Student>
    {
        Task<IEnumerable<Student>> SearchAsync(string searchTerm);
    }

}
