using Atilim.Services.Identity.Application.Dtos.StudentIdentityDtos;
using Atilim.Services.Identity.Domain.Entities.StudentEntities;
using AutoMapper;

namespace Atilim.Services.Identity.Application.Mapping.StudentIdentityProfiles
{
    public class StudentIdentityProfile : Profile
    {
        public StudentIdentityProfile()
        {
            CreateMap<StudentIdentity, StudentIdentityDto>().ReverseMap();

            CreateMap<StudentIdentity, UpdateStudentIdentityDto>().ReverseMap();
        }
    }
}
