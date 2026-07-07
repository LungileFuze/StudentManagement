using StudentManagement.Models;

namespace StudentManagement.Repositories.Interfaces
{
    public interface ICourseRepository : IRepository<Course>
    {
        Task<IEnumerable<Course>> SearchAsync(string searchTerm);
    }
}
