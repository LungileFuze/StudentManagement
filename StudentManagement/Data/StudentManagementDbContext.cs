using Microsoft.EntityFrameworkCore;
using StudentManagement.Configurations;
using StudentManagement.Models;

namespace StudentManagement.Data
{
    public class StudentManagementDbContext : DbContext
    {
        public StudentManagementDbContext(DbContextOptions<StudentManagementDbContext> options) : base(options)
        {
        }

        public DbSet<Student> Students => Set<Student>();

        public DbSet<Course> Courses => Set<Course>();

        public DbSet<Enrollment> Enrollments => Set<Enrollment>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new StudentConfigurations());
            modelBuilder.ApplyConfiguration(new CourseConfigurations());
            modelBuilder.ApplyConfiguration(new EnrollmentConfigurations());

            // Alternatively, apply all configurations automatically:
            // modelBuilder.ApplyConfigurationsFromAssembly(typeof(StudentManagementDbContext).Assembly);
        }
    }
}
