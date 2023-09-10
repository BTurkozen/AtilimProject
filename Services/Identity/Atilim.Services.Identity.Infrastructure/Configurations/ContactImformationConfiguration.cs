using Atilim.Services.Identity.Domain.Entities.StudentEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Atilim.Services.Identity.Infrastructure.Configurations
{
    public class ContactImformationConfiguration : IEntityTypeConfiguration<ContactImformation>
    {
        public void Configure(EntityTypeBuilder<ContactImformation> builder)
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
                   .HasColumnType("EmailAddress")
                   .HasMaxLength(100);

            builder.Property(b => b.MobilePhoneNumber)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.HasIndex(b => b.Id);

            builder.HasIndex(b => b.Email)
                   .IsUnique();

            builder.HasOne(b => b.StudentIdentity)
                   .WithOne(b => b.ContactImformation)
                   .HasForeignKey<StudentIdentity>(b => b.ContactInformationId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
