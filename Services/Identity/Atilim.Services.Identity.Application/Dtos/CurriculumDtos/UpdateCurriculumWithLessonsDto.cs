using Atilim.Services.Identity.Application.Wrappers;

namespace Atilim.Services.Identity.Application.Dtos.CurriculumDtos
{
    public sealed class UpdateCurriculumWithLessonsDto : BaseEntityDto
    {
        public int Id { get; set; }
        public string CurriculumName { get; set; }
        public List<CurriculumLessonDto> CurriculumLessons { get; set; }
    }
}
