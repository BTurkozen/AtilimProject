using Atilim.Services.Identity.Application.Dtos.LessonDtos;

namespace Atilim.Services.Identity.Application.Dtos.CurriculumDtos
{
    public sealed class CreateCurriculumWithLessonsDto
    {
        public CreateCurriculumWithLessonsDto()
        {
            Lessons = new List<LessonDto>();
        }

        public string CurriculumName { get; set; }

        public List<LessonDto> Lessons { get; set; }
    }
}
