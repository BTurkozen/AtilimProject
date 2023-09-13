using Atilim.Services.Identity.Domain.Entities.StudentEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Atilim.Services.Identity.Infrastructure.Configurations
{
    public class CurriculumConfiguration : IEntityTypeConfiguration<Curriculum>
    {
        public void Configure(EntityTypeBuilder<Curriculum> builder)
        {
            builder.Property(b => b.CurriculumName)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.HasIndex(b => b.Id);

            builder.HasIndex(b => b.CurriculumName)
                   .IsUnique()
                   .HasName("CurriculumName");

            builder.HasMany(b => b.Lessons)
                   .WithMany(b => b.Curriculums);

            builder.HasMany(b => b.Students)
                   .WithOne(b => b.Curriculum)
                   .HasForeignKey(b => b.CurriculumId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasData(
                new Curriculum() { Id = Guid.NewGuid().ToString(), CreatedBy = "1", CurriculumName = "Bilgisayar_Mühendisliği" },
                new Curriculum() { Id = Guid.NewGuid().ToString(), CreatedBy = "1", CurriculumName = "Grafik_Mühendisliği" },
                new Curriculum() { Id = Guid.NewGuid().ToString(), CreatedBy = "1", CurriculumName = "Ingiliz_Dil_Edebiyatı" });
        }
    }
}
