using Atilim.Services.Identity.Application.Wrappers;

namespace Atilim.Services.Identity.Application.Dtos.StudentIdentityDtos
{
    public sealed class StudentIdentityDto : BaseEntityDto
    {
        public string TCIdentificationNo { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string CityOfBirth { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}
