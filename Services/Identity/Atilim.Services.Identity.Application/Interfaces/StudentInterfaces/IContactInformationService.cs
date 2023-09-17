using Atilim.Services.Identity.Domain.Entities.StudentEntities;

namespace Atilim.Services.Identity.Application.Interfaces.StudentInterfaces
{
    public interface IContactInformationService
    {
        Task<ContactInformation> GetContactInformationById(int id);

        Task<bool> UpdateAsync(ContactInformation contactInformation);
    }
}
