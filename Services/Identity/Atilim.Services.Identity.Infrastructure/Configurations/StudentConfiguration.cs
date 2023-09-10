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

        }
    }
}
