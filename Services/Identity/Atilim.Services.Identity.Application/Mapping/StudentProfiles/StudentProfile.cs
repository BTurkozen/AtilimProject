using Atilim.Services.Identity.Application.Dtos.StudentDtos;
using Atilim.Services.Identity.Domain.Entities.StudentEntities;
using AutoMapper;

namespace Atilim.Services.Identity.Application.Mapping.StudentProfiles
{
    public class StudentProfile : Profile
    {
        public StudentProfile()
        {
            CreateMap<Student, StudentDto>().ReverseMap();
            //CreateMap<Student, CreateStudentDto>().ForMember(dest => dest.StudentItentity, src => src.MapFrom(s => s.StudentIdentity)).ReverseMap();
            //CreateMap<Student, UpdateStudentDto>().ForMember(dest => dest.StudentItentity, src => src.MapFrom(s => s.StudentIdentity)).ReverseMap();
        }
    }
}
