using Atilim.Services.Identity.Application.Dtos.CurriculumDtos;
using Atilim.Services.Identity.Domain.Entities.StudentEntities;
using AutoMapper;

namespace Atilim.Services.Identity.Application.Mapping.CurriculumProfiles
{
    public class CurriculumProfile : Profile
    {
        public CurriculumProfile()
        {
            CreateMap<Curriculum, CurriculumDto>().ReverseMap();
            CreateMap<Curriculum, CreateCurriculumDto>().ReverseMap();
            CreateMap<Curriculum, UpdateCurriculumDto>().ReverseMap();
            CreateMap<Curriculum, CurriculumWithLessonsDto>().ForMember(dest => dest.Lessons, src => src.MapFrom(s => s.Lessons)).ReverseMap();
        }
    }
}
