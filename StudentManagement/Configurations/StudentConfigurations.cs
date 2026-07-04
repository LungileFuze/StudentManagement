using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StudentManagement.Models;

namespace StudentManagement.Configurations
{
    public class StudentConfigurations : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.ToTable("Students");

            builder.HasKey(s => s.Id);

            builder.Property(s => s.StudentNumber).IsRequired().HasMaxLength(20);

            builder.HasIndex(s => s.StudentNumber).IsUnique();

            builder.Property(s => s.FirstName).IsRequired().HasMaxLength(50);

            builder.Property(s => s.LastName).IsRequired().HasMaxLength(50);

            builder.Property(s => s.Email).IsRequired().HasMaxLength(100);

            builder.HasIndex(s => s.Email).IsUnique();

            builder.HasMany(s => s.Enrollments).WithOne(e => e.Student).HasForeignKey(e => e.StudentId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
