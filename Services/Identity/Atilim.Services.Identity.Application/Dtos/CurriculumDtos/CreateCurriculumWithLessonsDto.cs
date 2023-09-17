namespace Atilim.Services.Identity.Application.Dtos.CurriculumDtos
{
    public sealed class CreateCurriculumWithLessonsDto
    {
        public CreateCurriculumWithLessonsDto()
        {
            CurriculumLessons = new List<CurriculumLessonDto>();
        }

        public string CurriculumName { get; set; }

        public List<CurriculumLessonDto> CurriculumLessons { get; set; }
    }
}
