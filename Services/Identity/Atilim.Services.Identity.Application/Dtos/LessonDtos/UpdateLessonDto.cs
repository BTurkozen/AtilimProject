using Atilim.Services.Identity.Application.Wrappers;

namespace Atilim.Services.Identity.Application.Dtos.LessonDtos
{
    public class UpdateLessonDto : BaseEntityDto
    {
        public string LessonCode { get; set; }
        public string LessonName { get; set; }
        public bool Status { get; set; }
        public int Credit { get; set; }
    }
}
