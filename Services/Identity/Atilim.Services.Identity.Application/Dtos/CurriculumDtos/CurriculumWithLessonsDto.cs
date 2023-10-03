using Atilim.Services.Identity.Application.Dtos.LessonDtos;

namespace Atilim.Services.Identity.Application.Dtos.CurriculumDtos
{
    public class CurriculumWithLessonsDto : CurriculumDto
    {
        public CurriculumWithLessonsDto()
        {
            CurriculumLessons = new List<CurriculumLessonDto>();
        }

        public List<CurriculumLessonDto> CurriculumLessons { get; set; }

        public bool HasStudent { get; set; }
    }
}
