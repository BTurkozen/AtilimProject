using Atilim.Services.Identity.Application.Wrappers;
using Atilim.Services.Identity.Domain.Entities.StudentEntities;
using Atilim.Services.Identity.Domain.Entities;

namespace Atilim.Services.Identity.Application.Dtos.StudentIdentityDtos
{
    public sealed class StudentIdentityDto : BaseEntityDto
    {
        public string TCIdentificationNo { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string CityOfBirth { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
