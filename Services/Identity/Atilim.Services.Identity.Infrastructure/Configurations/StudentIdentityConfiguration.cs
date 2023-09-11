using Atilim.Services.Identity.Domain.Entities;
using Atilim.Services.Identity.Domain.Entities.StudentEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Atilim.Services.Identity.Infrastructure.Configurations
{
    public class StudentIdentityConfiguration : IEntityTypeConfiguration<StudentIdentity>
    {
        public void Configure(EntityTypeBuilder<StudentIdentity> builder)
        {
            builder.Property(b => b.TCIdentificationNo)
                   .IsRequired()
                   .HasMaxLength(11);

            builder.Property(b => b.Name)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(b => b.Surname)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(b => b.CityOfBirth)
                   .IsRequired();

            builder.Property(b => b.DateOfBirth)
                   .IsRequired();

            builder.HasIndex(b => b.Id);

            builder.HasIndex(b => b.TCIdentificationNo)
                   .IsUnique();

            builder.HasIndex(b => new { b.Name, b.Surname });

            builder.HasOne(b => b.ContactInformation)
                   .WithOne(b => b.StudentIdentity)
                   .HasForeignKey<ContactInformation>(b => b.StudentIdentityId)
                   .OnDelete(DeleteBehavior.Restrict);

            //builder.HasOne(b => b.User)
            //       .WithOne(b => b.StudentIdentity)
                   //.HasForeignKey<User>(b => b.StudentIdentityId)
            //       .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(b => b.Student)
                   .WithOne(b => b.StudentIdentity)
                   .HasForeignKey<Student>(b => b.StudentIdentityId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}