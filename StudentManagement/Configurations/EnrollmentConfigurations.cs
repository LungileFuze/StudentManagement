using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StudentManagement.Models;

namespace StudentManagement.Configurations
{
    public class EnrollmentConfigurations : IEntityTypeConfiguration<Enrollment>
    {
        public void Configure(EntityTypeBuilder<Enrollment> builder)
        {
            builder.ToTable("Enrollments");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.EnrolledDate).IsRequired();

            builder.Property(e => e.FinalMark).HasColumnType("decimal(5,2)");

            builder.Property(e => e.Status).IsRequired().HasMaxLength(20);

            builder.HasOne(e => e.Student).WithMany(s => s.Enrollments).HasForeignKey(e => e.StudentId).OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(e => e.Course).WithMany(c => c.Enrollments).HasForeignKey(e => e.CourseId).OnDelete(DeleteBehavior.Cascade);

            // Prevent duplicate enrollments
            builder.HasIndex(e => new { e.StudentId, e.CourseId }).IsUnique();
        }
    }
}
