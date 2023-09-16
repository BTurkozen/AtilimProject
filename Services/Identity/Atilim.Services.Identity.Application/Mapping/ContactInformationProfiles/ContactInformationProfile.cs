using Atilim.Services.Identity.Application.Dtos.ContactInformationDtos;
using Atilim.Services.Identity.Domain.Entities.StudentEntities;
using AutoMapper;

namespace Atilim.Services.Identity.Application.Mapping.ContactInformationProfiles
{
    public class ContactInformationProfile : Profile
    {
        public ContactInformationProfile()
        {
            CreateMap<ContactInformation, ContactInformationDto>().ReverseMap();
        }
    }
}
