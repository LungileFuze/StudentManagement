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

        public async Task<IEnumerable<Student>> SearchAsync(string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
            {
                return await _context.Students.AsNoTracking().ToListAsync();
            }

            searchTerm = searchTerm.Trim();

            return await _context.Students.AsNoTracking().Where(s => EF.Functions.Like(s.StudentNumber, $"%{searchTerm}%") ||
                        EF.Functions.Like(s.FirstName, $"%{searchTerm}%") ||
                        EF.Functions.Like(s.LastName, $"%{searchTerm}%") ||
                        EF.Functions.Like(s.Email, $"%{searchTerm}%")).ToListAsync();

            //return await _context.Students.AsNoTracking().Where(s => s.StudentNumber.Contains(searchTerm) || s.FirstName.Contains(searchTerm) ||
            //        s.LastName.Contains(searchTerm) || s.Email.Contains(searchTerm)).ToListAsync();
        }
    }
}
