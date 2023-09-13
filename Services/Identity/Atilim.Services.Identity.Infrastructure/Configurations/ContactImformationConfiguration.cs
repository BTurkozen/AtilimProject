using Atilim.Services.Identity.Domain.Entities.StudentEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Atilim.Services.Identity.Infrastructure.Configurations
{
    public class ContactImformationConfiguration : IEntityTypeConfiguration<ContactInformation>
    {
        public void Configure(EntityTypeBuilder<ContactInformation> builder)
        {
            builder.Property(b => b.Address)
                   .IsRequired()
                   .HasMaxLength(200);

            builder.Property(b => b.Country)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(b => b.District)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(b => b.Email)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(b => b.MobilePhoneNumber)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.HasIndex(b => b.Id);

            builder.HasIndex(b => b.Email)
                   .IsUnique();

            builder.HasOne(b => b.StudentIdentity)
                   .WithOne(b => b.ContactInformation)
                   .HasForeignKey<StudentIdentity>(b => b.ContactInformationId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasData(

                new ContactInformation
                {
                    Id = 1,
                    StudentIdentityId = 1,
                    Address = "DEMİRCİKARA MAH. B.ONAT CAD. HEDE SİT. B BLOK NO : 1",
                    City = "ANKARA",
                    District = "PURSAKLAR",
                    Country = "Türkiye",
                    Email = "mno@xyz.com",
                    MobilePhoneNumber = "5555424245",
                    CreatedBy = 1
                },
                new ContactInformation
                {
                    Id = 2,
                    StudentIdentityId = 2,
                    Address = "CUMHURİYET MAH. BİRİNCİ SOK. İKİNCİ APT. NO:111/6",
                    City = "Ankara",
                    District = "YENİMAHALLE",
                    Country = "Türkiye",
                    Email = "abc@hotmail.com",
                    MobilePhoneNumber = "5332342342",
                    CreatedBy = 1,
                },
                new ContactInformation
                {
                    Id = 3,
                    StudentIdentityId = 3,
                    Address = "SİTELER MAHALLESİ 6223 SOKAK DURU APT. NO:11 KAT:3 ",
                    City = "Ankara",
                    District = "POLATLI",
                    Country = "Türkiye",
                    Email = "klm@outlook.com",
                    MobilePhoneNumber = "5408932042",
                    CreatedBy = 1,
                },
                new ContactInformation
                {
                    Id = 4,
                    StudentIdentityId = 4,
                    Address = "TURAN GÜNEŞ BULVARI TAMTAM SİTESİ 13. CAD. NO:51",
                    City = "Ankara",
                    District = "KEÇİÖREN",
                    Country = "Türkiye",
                    Email = "ghi@abc.com",
                    MobilePhoneNumber = "5305464646",
                },
                new ContactInformation
                {
                    Id = 5,
                    StudentIdentityId = 5,
                    Address = "AHMET HAMDİ SOK. NO:19/15",
                    City = "Ankara",
                    District = "SİNCAN",
                    Country = "Türkiye",
                    Email = "prs@hotmail.com",
                    MobilePhoneNumber = "5302908432",
                    CreatedBy = 1,
                },
                new ContactInformation
                {
                    Id = 6,
                    Address = "KUŞADASI SOK. NO:123 KARAAĞAÇ",
                    City = "Ankara",
                    District = "ÇANKAYA",
                    Country = "Türkiye",
                    Email = "def@gmail.com",
                    MobilePhoneNumber = "5437657567",
                    CreatedBy = 1,
                    StudentIdentityId = 6,
                }
                );
        }
    }
}
