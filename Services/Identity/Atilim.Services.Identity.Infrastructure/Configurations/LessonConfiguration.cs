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

            builder.HasData(
                new Lesson() { Id = 1, CreatedBy = 1, LessonCode = "HUM101", LessonName = "Türk Demokrasi Tarihi", Status = true, Credit = 5 },
                new Lesson() { Id = 2, CreatedBy = 1, LessonCode = "MATH102", LessonName = "Calculus 2", Status = true, Credit = 6 },
                new Lesson() { Id = 3, CreatedBy = 1, LessonCode = "MATE103", LessonName = "Metalurjiye Giriş", Status = false, Credit = 6 },
                new Lesson() { Id = 4, CreatedBy = 1, LessonCode = "GRA105", LessonName = "Grafik Dizayn", Status = true, Credit = 5 },
                new Lesson() { Id = 5, CreatedBy = 1, LessonCode = "CMPE201", LessonName = "Bilgisayar Teknolojileri", Status = true, Credit = 4 },
                new Lesson() { Id = 6, CreatedBy = 1, LessonCode = "ENG102", LessonName = "İngilizce 2", Status = true, Credit = 4 },
                new Lesson() { Id = 7, CreatedBy = 1, LessonCode = "MATH201", LessonName = "İleri Calculus ", Status = true, Credit = 6 });
        }
    }
}
