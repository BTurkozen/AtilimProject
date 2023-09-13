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

            builder.HasData(
            new Student()
            {
                Id = Guid.NewGuid().ToString(),
                StudentNo = 23462368,
                CreatedBy = "1",
                StudentIdentity = new StudentIdentity()
                {
                    TCIdentificationNo = "45456747611",
                    Name = "Hasan",
                    Surname = "Ersoy",
                    CityOfBirth = "Kayseri",
                    DateOfBirth = Convert.ToDateTime("11.10.1983"),
                    ContactInformation = new ContactInformation
                    {
                        Address = "DEMİRCİKARA MAH. B.ONAT CAD. HEDE SİT. B BLOK NO : 1",
                        City = "ANKARA",
                        District = "PURSAKLAR",
                        Country = "Türkiye",
                        Email = "mno@xyz.com",
                        MobilePhoneNumber = "5555424245",
                    }
                }
            },
            new Student()
            {
                Id = Guid.NewGuid().ToString(),
                StudentNo = 27482379,
                CreatedBy = "1",
                StudentIdentity = new StudentIdentity()
                {
                    TCIdentificationNo = "67967856634",
                    Name = "Mehmet",
                    Surname = "Yılmaz",
                    CityOfBirth = "Adana",
                    DateOfBirth = Convert.ToDateTime("12.03.2000"),
                    ContactInformation = new ContactInformation { Address = "CUMHURİYET MAH. BİRİNCİ SOK. İKİNCİ APT. NO:111/6", City = "Ankara", District = "YENİMAHALLE", Country = "Türkiye", Email = "abc@hotmail.com", MobilePhoneNumber = "5332342342", }
                }
            },
            new Student()
            {
                Id = Guid.NewGuid().ToString(),
                StudentNo = 34565479,
                CreatedBy = "1",
                StudentIdentity = new StudentIdentity()
                {
                    TCIdentificationNo = "72347322958",
                    Name = "Ahmet",
                    Surname = "Ünal",
                    CityOfBirth = "Ankara",
                    DateOfBirth = Convert.ToDateTime("14.06.2001"),
                    ContactInformation = new ContactInformation
                    {
                        Address = "SİTELER MAHALLESİ 6223 SOKAK DURU APT. NO:11 KAT:3 ",
                        City = "Ankara",
                        District = "POLATLI",
                        Country = "Türkiye",
                        Email = "klm@outlook.com",
                        MobilePhoneNumber = "5408932042",
                    }
                }
            },
            new Student()
            {
                Id = Guid.NewGuid().ToString(),
                StudentNo = 53456346,
                CreatedBy = "1",
                StudentIdentity = new StudentIdentity()
                {
                    TCIdentificationNo = "97850348520",
                    Name = "Mustafa",
                    Surname = "Işık",
                    CityOfBirth = "Sivas",
                    DateOfBirth = Convert.ToDateTime("21.12.2000"),
                    ContactInformation = new ContactInformation
                    {
                        Address = "TURAN GÜNEŞ BULVARI TAMTAM SİTESİ 13. CAD. NO:51",
                        City = "Ankara",
                        District = "KEÇİÖREN",
                        Country = "Türkiye",
                        Email = "ghi@abc.com",
                        MobilePhoneNumber = "5305464646",
                    }
                }
            },
            new Student()
            {
                Id = Guid.NewGuid().ToString(),
                StudentNo = 34674575,
                CreatedBy = "1",
                StudentIdentity = new StudentIdentity()
                {
                    TCIdentificationNo = "32756874239",
                    Name = "Ayşe",
                    Surname = "Erdoğan",
                    CityOfBirth = "Uşak",
                    DateOfBirth = Convert.ToDateTime("04.03.2001"),
                    ContactInformation = new ContactInformation
                    {
                        Address = "AHMET HAMDİ SOK. NO:19/15",
                        City = "Ankara",
                        District = "SİNCAN",
                        Country = "Türkiye",
                        Email = "prs@hotmail.com",
                        MobilePhoneNumber = "5302908432",
                    }
                }
            },
            new Student()
            {
                Id = Guid.NewGuid().ToString(),
                StudentNo = 64672359,
                CreatedBy = "1",
                StudentIdentity = new StudentIdentity()
                {
                    TCIdentificationNo = "98423479320",
                    Name = "Fatma",
                    Surname = "Korkmaz",
                    CityOfBirth = "Kütahya",
                    DateOfBirth = Convert.ToDateTime("01.01.2001"),
                    ContactInformation = new ContactInformation
                    {
                        Address = "KUŞADASI SOK. NO:123 KARAAĞAÇ",
                        City = "Ankara",
                        District = "ÇANKAYA",
                        Country = "Türkiye",
                        Email = "def@gmail.com",
                        MobilePhoneNumber = "5437657567",
                    }
                }
            });
        }
    }
}
