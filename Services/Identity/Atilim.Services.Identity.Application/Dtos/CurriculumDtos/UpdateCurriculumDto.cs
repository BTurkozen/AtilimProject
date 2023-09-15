using Atilim.Services.Identity.Application.Wrappers;

namespace Atilim.Services.Identity.Application.Dtos.CurriculumDtos
{
    public sealed class UpdateCurriculumDto : BaseEntityDto
    {
        public string CurriculumName { get; set; }
    }
}
