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

    }
}
