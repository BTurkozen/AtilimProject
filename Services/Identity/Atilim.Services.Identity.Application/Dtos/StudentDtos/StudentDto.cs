using Atilim.Services.Identity.Application.Dtos.ContactInformationDtos;
using Atilim.Services.Identity.Application.Dtos.StudentIdentityDtos;
using Atilim.Services.Identity.Application.Wrappers;

namespace Atilim.Services.Identity.Application.Dtos.StudentDtos
{
    public sealed class StudentDto : BaseEntityDto
    {
        public int Id { get; set; }
        public int StudentNo { get; set; }
        public string FullName { get; set; }
    }
}
