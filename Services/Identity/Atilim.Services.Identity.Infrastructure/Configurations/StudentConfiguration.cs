using Atilim.Services.Identity.Domain.Entities.StudentEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Atilim.Services.Identity.Infrastructure.Configurations
{
    public class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {

            builder.Property(b => b.StudentNo)
                   .IsRequired()
                   .HasMaxLength(25);

            builder.HasIndex(b => b.Id);

            builder.HasIndex(b => b.StudentNo)
                   .IsUnique();

            builder.HasOne(b => b.Curriculum)
                   .WithMany(b => b.Students)
                   .HasForeignKey(b => b.CurriculumId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(b => b.StudentIdentity)
                   .WithOne(b => b.Student)
                   .HasForeignKey<StudentIdentity>(b => b.StudentId)
                   .OnDelete(DeleteBehavior.Restrict);

            var StudentId = Guid.NewGuid().ToString();

            builder.HasData(
                new Student()
                {
                    Id = 1,
                    StudentNo = 23462368,
                    CreatedBy = 1,
                    CurriculumId = 1,
                    StudentIdentityId = 1,
                },
                new Student()
                {
                    Id = 2,
                    StudentNo = 27482379,
                    CreatedBy = 1,
                    CurriculumId = 1,
                    StudentIdentityId = 2,
                },
                new Student()
                {
                    Id = 3,
                    StudentNo = 34565479,
                    CreatedBy = 1,
                    CurriculumId = 2,
                    StudentIdentityId = 3,
                },
                new Student()
                {
                    Id = 4,
                    StudentNo = 53456346,
                    CreatedBy = 1,
                    CurriculumId = 2,
                    StudentIdentityId = 4,
                },
                new Student()
                {
                    Id = 5,
                    StudentNo = 34674575,
                    CreatedBy = 1,
                    CurriculumId = 3,
                    StudentIdentityId = 5,
                },
                new Student()
                {
                    Id = 6,
                    StudentNo = 64672359,
                    CreatedBy = 1,
                    CurriculumId = 3,
                    StudentIdentityId = 6,
                }
            );
        }
    }
}
