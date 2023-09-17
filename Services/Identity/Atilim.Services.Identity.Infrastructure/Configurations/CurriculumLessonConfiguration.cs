using Atilim.Services.Identity.Domain.Entities.StudentEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Atilim.Services.Identity.Infrastructure.Configurations
{
    public class CurriculumLessonConfiguration : IEntityTypeConfiguration<CurriculumLesson>
    {
        public void Configure(EntityTypeBuilder<CurriculumLesson> builder)
        {
            builder.HasKey(cl => new { cl.CurriculumId, cl.LessonId });

            builder.HasOne(cl => cl.Curriculum)
                   .WithMany(c => c.CurriculumLessons)
                   .HasForeignKey(cl => cl.CurriculumId);

            builder.HasOne(cl => cl.Lesson)
                   .WithMany(l => l.CurriculumLessons)
                   .HasForeignKey(cl => cl.LessonId); 
        }
    }
}