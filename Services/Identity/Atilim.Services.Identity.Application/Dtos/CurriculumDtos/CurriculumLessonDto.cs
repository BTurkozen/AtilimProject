using Atilim.Services.Identity.Application.Dtos.LessonDtos;

namespace Atilim.Services.Identity.Application.Dtos.CurriculumDtos
{
    public class CurriculumLessonDto
    {
        public int CurriculumId { get; set; }

        public CurriculumDto Curriculum { get; set; }
        public int LessonId { get; set; }
        public LessonDto Lesson { get; set; }
    }
}
