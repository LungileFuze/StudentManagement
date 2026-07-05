using Microsoft.EntityFrameworkCore;
using StudentManagement.Data;
using StudentManagement.Models;
using StudentManagement.Repositories.Interfaces;

namespace StudentManagement.Repositories.Implementation
{
    public class StudentRepository : Repository<Student>, IStudentRepository
    {
        public StudentRepository(StudentManagementDbContext context) : base(context)
        {
        }

        public override async Task<Student?> GetByIdAsync(int id)
        {
            return await _context.Students.Include(s => s.Enrollments).ThenInclude(e => e.Course).FirstOrDefaultAsync(s => s.Id == id);
        }
    }
}
