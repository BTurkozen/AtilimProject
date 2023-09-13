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

            builder.HasOne(b => b.Student)
                   .WithOne(b => b.StudentIdentity)
                   .HasForeignKey<Student>(b => b.StudentIdentityId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasData(

                new StudentIdentity()
                {
                    Id = 1,
                    StudentId = 1,
                    TCIdentificationNo = "45456747611",
                    Name = "Hasan",
                    Surname = "Ersoy",
                    CityOfBirth = "Kayseri",
                    DateOfBirth = DateTime.ParseExact("11.10.1983", "dd.MM.yyyy", null),
                    CreatedBy = 1,
                    UserId = 2
                },
                new StudentIdentity()
                {
                    Id = 2,
                    StudentId = 2,
                    TCIdentificationNo = "67967856634",
                    Name = "Mehmet",
                    Surname = "Yılmaz",
                    CityOfBirth = "Adana",
                    DateOfBirth = DateTime.ParseExact("12.03.2000", "dd.MM.yyyy", null),
                    CreatedBy = 1,
                    UserId = 3

                }, new StudentIdentity()
                {
                    Id = 3,
                    StudentId = 3,
                    TCIdentificationNo = "72347322958",
                    Name = "Ahmet",
                    Surname = "Ünal",
                    CityOfBirth = "Ankara",
                    DateOfBirth = DateTime.ParseExact("14.06.2001", "dd.MM.yyyy", null),
                    CreatedBy = 1,
                    UserId = 4
                },
                new StudentIdentity()
                {
                    Id = 4,
                    StudentId = 4,
                    TCIdentificationNo = "97850348520",
                    Name = "Mustafa",
                    Surname = "Işık",
                    CityOfBirth = "Sivas",
                    DateOfBirth = DateTime.ParseExact("21.12.2000", "dd.MM.yyyy", null),
                    CreatedBy = 1,
                    UserId = 5
                },
                new StudentIdentity()
                {
                    Id = 5,
                    StudentId = 5,
                    TCIdentificationNo = "32756874239",
                    Name = "Ayşe",
                    Surname = "Erdoğan",
                    CityOfBirth = "Uşak",
                    DateOfBirth = DateTime.ParseExact("04.03.2001", "dd.MM.yyyy", null),
                    CreatedBy = 1,
                    UserId = 6
                },
                new StudentIdentity()
                {
                    Id = 6,
                    StudentId = 6,
                    TCIdentificationNo = "98423479320",
                    Name = "Fatma",
                    Surname = "Korkmaz",
                    CityOfBirth = "Kütahya",
                    DateOfBirth = DateTime.ParseExact("01.01.2001", "dd.MM.yyyy", null),
                    CreatedBy = 1,
                    UserId = 7
                }
                );
        }
    }
}