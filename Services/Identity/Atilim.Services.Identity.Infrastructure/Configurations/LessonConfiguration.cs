using Atilim.Services.Identity.Domain.Entities.StudentEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Atilim.Services.Identity.Infrastructure.Configurations
{
    public class LessonConfiguration : IEntityTypeConfiguration<Lesson>
    {
        public void Configure(EntityTypeBuilder<Lesson> builder)
        {
            builder.Property(b => b.LessonCode)
                   .IsRequired()
                   .HasMaxLength(50);

            builder.Property(b => b.LessonName)
                   .IsRequired()
                   .HasMaxLength(50);

            builder.Property(b => b.Credit)
                   .IsRequired();

            builder.HasIndex(b => b.Id)
                   .IsUnique();

            builder.HasIndex(b => b.LessonCode)
                   .IsUnique();

            //builder.HasMany(b => b.Curriculums)
            //       .WithMany(b => b.Lessons);
        }
    }
}
