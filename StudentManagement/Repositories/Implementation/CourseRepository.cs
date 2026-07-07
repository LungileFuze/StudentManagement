using Microsoft.EntityFrameworkCore;
using StudentManagement.Data;
using StudentManagement.Models;
using StudentManagement.Repositories.Interfaces;

namespace StudentManagement.Repositories.Implementation
{
    public class CourseRepository : Repository<Course>, ICourseRepository
    {
        public CourseRepository(StudentManagementDbContext context) : base(context)
        {
        }

        public override async Task<Course?> GetByIdAsync(int id)
        {
            return await _context.Courses.Include(s => s.Enrollments).ThenInclude(e => e.Student).FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task<IEnumerable<Course>> SearchAsync(string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
            {
                return await _context.Courses.AsNoTracking().ToListAsync();
            }

            searchTerm = searchTerm.Trim();

            return await _context.Courses.AsNoTracking().Where(s => EF.Functions.Like(s.CourseCode, $"%{searchTerm}%") ||
                        EF.Functions.Like(s.CourseName, $"%{searchTerm}%")).ToListAsync();

            //return await _context.Students.AsNoTracking().Where(s => s.StudentNumber.Contains(searchTerm) || s.FirstName.Contains(searchTerm) ||
            //        s.LastName.Contains(searchTerm) || s.Email.Contains(searchTerm)).ToListAsync();
        }

    }
}
