using Atilim.Services.Identity.Application.Dtos.ContactInformationDtos;
using Atilim.Services.Identity.Application.Dtos.CurriculumDtos;
using Atilim.Services.Identity.Application.Dtos.StudentIdentityDtos;
using Atilim.Services.Identity.Application.Wrappers;

namespace Atilim.Services.Identity.Application.Dtos.StudentDtos
{
    public sealed class StudentDto : BaseEntityDto
    {
        public int StudentNo { get; set; }
        public string FullName { get; set; }

        public CurriculumDto Curriculum { get; set; }

        public StudentIdentityDto StudentIdentity { get; set; }

        public ContactInformationDto ContactInformation { get; set; }
    }
}
