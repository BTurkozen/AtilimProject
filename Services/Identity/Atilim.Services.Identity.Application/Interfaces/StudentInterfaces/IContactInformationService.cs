using Atilim.Services.Identity.Application.Dtos.ContactInformationDtos;

namespace Atilim.Services.Identity.Application.Interfaces.StudentInterfaces
{
    public interface IContactInformationService
    {
        Task<ContactInformationDto> GetContactInformationByStudentId(int studentIdentityId);
    }
}
