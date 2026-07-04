using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StudentManagement.Models;

namespace StudentManagement.Configurations
{
    public class CourseConfigurations : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.ToTable("Courses");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.CourseCode).IsRequired().HasMaxLength(20);

            builder.HasIndex(c => c.CourseCode).IsUnique();

            builder.Property(c => c.CourseName).IsRequired().HasMaxLength(100);

            builder.Property(c => c.Credits).IsRequired();

            builder.HasMany(c => c.Enrollments).WithOne(e => e.Course).HasForeignKey(e => e.CourseId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
