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
            
            CreateMap<CreateCurriculumWithLessonsDto, Curriculum>()
                .ForMember(dest => dest.CurriculumName, opt => opt.MapFrom(src => src.CurriculumName))
                .ForMember(dest => dest.CurriculumLessons, opt => opt.MapFrom(src => src.CurriculumLessons))
                .ReverseMap();

            CreateMap<Curriculum, UpdateCurriculumWithLessonsDto>().ReverseMap();
            CreateMap<Curriculum, CurriculumWithLessonsDto>().ForMember(dest => dest.CurriculumLessons, src => src.MapFrom(s => s.CurriculumLessons)).ReverseMap();
        }
    }
}
