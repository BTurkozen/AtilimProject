using Atilim.Services.Identity.Application.Dtos.LessonDtos;

namespace Atilim.Services.Identity.Application.Dtos.CurriculumDtos
{
    public class CurriculumWithLessonsDto : CurriculumDto
    {
        public CurriculumWithLessonsDto()
        {
            Lessons = new List<LessonDto>();
        }

        public List<LessonDto> Lessons { get; set; }
    }
}
