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
    
    }
}
