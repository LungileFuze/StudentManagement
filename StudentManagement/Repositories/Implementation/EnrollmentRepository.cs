using Microsoft.EntityFrameworkCore;
using StudentManagement.Data;
using StudentManagement.Models;
using StudentManagement.Repositories.Interfaces;

namespace StudentManagement.Repositories.Implementation
{
    public class EnrollmentRepository : Repository<Enrollment>, IEnrollmentRepository
    {
        public EnrollmentRepository(StudentManagementDbContext context) : base(context)
        {
        }

        public override async Task<IEnumerable<Enrollment>> GetAllAsync()
        {
            return await _context.Enrollments.Include(e => e.Student).Include(e => e.Course).ToListAsync();
        }


        public override async Task<Enrollment?> GetByIdAsync(int id)
        {
            return await _context.Enrollments.Include(e => e.Student).Include(e => e.Course).FirstOrDefaultAsync(e => e.Id == id);
        }
    }
}
