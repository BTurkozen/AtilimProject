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
            CreateMap<Student, CreateStudentDto>().ReverseMap().IncludeMembers(s => s.StudentItentity);
            CreateMap<Student, UpdateStudentDto>().ReverseMap().IncludeMembers(s => s.StudentItentity);
        }
    }
}
