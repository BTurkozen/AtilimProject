using Atilim.Services.Identity.Application.Dtos.LessonDtos;
using Atilim.Services.Identity.Domain.Entities.StudentEntities;
using AutoMapper;

namespace Atilim.Services.Identity.Application.Mapping.LessonProfiles
{
    public class LessonProfile : Profile
    {
        public LessonProfile()
        {
            CreateMap<LessonDto, Lesson>().ReverseMap();
            CreateMap<CreateLessonDto, Lesson>().ReverseMap();
            CreateMap<UpdateLessonDto, Lesson>().ReverseMap();
        }
    }
}
