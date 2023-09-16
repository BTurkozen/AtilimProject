using Atilim.Services.Identity.Application.Dtos.LessonDtos;
using Atilim.Services.Identity.Domain.Entities.StudentEntities;
using AutoMapper;

namespace Atilim.Services.Identity.Application.Mapping.LessonProfiles
{
    public class LessonProfile : Profile
    {
        public LessonProfile()
        {
            CreateMap<Lesson, LessonDto>().ReverseMap();
            CreateMap<Lesson, CreateLessonDto>().ReverseMap();
            CreateMap<Lesson, UpdateLessonDto>().ReverseMap();
        }
    }
}
